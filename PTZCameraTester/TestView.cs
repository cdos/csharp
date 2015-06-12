using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net.Sockets;
using System.Net;

namespace PTZCameraTester
{
    // A delegate type for hooking up change notifications.
    public delegate void TestCompleteEvent(object sender, EventArgs e);
    
    public partial class TestView : Form
    {
        //Variables
        Thread TestThread;
        string logPath;
        string activeTestPath;
        string activeTestLogFileName;
        string activeTestReportFileName;
        string CameraAddress;
        TestController tester;
        String log;
        
        public event TestCompleteEvent onComplete;

        //Delegates
        public delegate void consoleDelegate(string text);
        public consoleDelegate AddLineToConsole;
        public delegate void endDelegate();
        public endDelegate endTestDelegate;
        public delegate void threadClearForStopDelagate();
        public threadClearForStopDelagate ThreadClearForShutdown;
        
        //TestView method.  Takes argument of string and path.
        public TestView(string cameraIP, string path)
        {
            //Sets up before running the program.
            InitializeComponent();
            CameraAddress = cameraIP;
            AddLineToConsole = new consoleDelegate(ConsoleAppendLine);
            endTestDelegate = new endDelegate(endTest);
            ThreadClearForShutdown = new threadClearForStopDelagate(ThreadClearForShutdownFunc);
            logPath = path;
        }
        
        //Sets up the variable and environment before logging and writing.
        public void Setup()
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            string modelname = svlib.PelcoClient.GetModelNumber();
            string filename = "PTZTEST-" + modelname + "-" + getDateString();
            activeTestPath = logPath + "\\" + filename + "_Console.html";
            activeTestLogFileName = filename + "_Console.html";
            activeTestReportFileName = filename + "_Report.html";
            activeTestPath = new Uri(activeTestPath).LocalPath;
            File.AppendAllText(activeTestPath, ConForm.FileStart);
            SetConsoleFile(activeTestPath);

           //Writes to the form.  Big Text box.
            ConsoleAppendLine(ConForm.AddColor("Starting Test...", "blue"));
        }

        //Runs the test as another thread.
        public void Run()
        {
            TestThread = new Thread(new ThreadStart(ThreadInitFunction));
            TestThread.Start();
        }

        //Appends text to the console.  This is likely the logger that writes to the big text box.
        public void ConsoleAppendLine(string text)
        {

            //A variable that adds itself adn the new text.
            log = ConForm.LineFinalize(text) + log;

            //A variable that takes all the output from the big text box.
            String output = ConForm.FileStart + log + ConForm.FileEnd;

            //Finally writing that text into a file.  Using the current active directory.
            File.WriteAllText(activeTestPath, output);

            //Refresh the web console.
            webConsole.Refresh();


        }

        //Method to set the console file.  It checks if the file is there and returns a boolean.
        public bool SetConsoleFile(string path)
        {
            try
            {
                webConsole.Navigate(path);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString() + "\nSite Path: " + path);
                return false;
            }
            return true;
        }

        //Uses the systems date and time.  Converts to string.
        private string getDateString()
        {
            return DateTime.Now.ToString().Replace("/", ".").Replace(":", ".").Replace(" ", "_");
        }

        //Function to stop the test in the current state.  
        private void endTest()
        {
            //Conditions of the form elements when this function is called.
            AbortButton.Enabled = false;
            TestProgressBar.Value = 100;
            TestProgressLabel.Text = "100%";
            ConsoleAppendLine(ConForm.AddBold("Test Thread Exiting.  Console Log Saved to: <br /> ") + ConForm.TabSpace + activeTestLogFileName);

            //Checks if he log fil ename exist.
            if (File.Exists(logPath + "\\" + activeTestLogFileName))
            {
                System.Diagnostics.Process.Start(logPath + "\\" + activeTestLogFileName);
            }
            
            //.5 seconds wait time.
            Thread.Sleep(500);

            //checks if the report file name exist.
            if (File.Exists(logPath + "\\" + activeTestReportFileName))
            {
                System.Diagnostics.Process.Start(logPath + "\\" + activeTestReportFileName);
            }
        }


        //This controls the abort button on the form.  Stops the test from running and logs whatever it has.
        private void AbortButton_Click(object sender, EventArgs e)
        {
            AbortButton.Enabled = false;
            ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Abort Request Received, Attempting to Terminate Test..."), "red"));
            //TestThread.Abort();
            tester.Shutdown();
            //ConsoleAppendLine(ConForm.AddColor("Test Aborted.", "red"));
        }

        //Closes whatever program it is set in.  
        private void ThreadClearForShutdownFunc()
        {
            onComplete(this, EventArgs.Empty);
            this.Close();
        }


        //Other Thread.  Tester starts here.  run function calls this method.
        private void ThreadInitFunction()
        {
            try
            {
                //This is probably where the tests are run from.
                tester = new TestController(this, CameraAddress, activeTestReportFileName, logPath);
                tester.StartTest();
            }
            catch
            {
                ConsoleAppendLine(ConForm.AddColor("Test Thread Abort Request Recieved.  Shutting Down...", "red"));
                Thread.Sleep(1000);
            }
            this.Invoke(this.endTestDelegate);
            this.Invoke(this.ThreadClearForShutdown);
        }
    }
}
