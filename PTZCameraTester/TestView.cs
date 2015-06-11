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
        
        public TestView(string cameraIP, string path)
        {
            InitializeComponent();
            CameraAddress = cameraIP;
            AddLineToConsole = new consoleDelegate(ConsoleAppendLine);
            endTestDelegate = new endDelegate(endTest);
            ThreadClearForShutdown = new threadClearForStopDelagate(ThreadClearForShutdownFunc);
            logPath = path;
        }

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

            ConsoleAppendLine(ConForm.AddColor("Starting Test...", "blue"));
        }

        public void Run()
        {
            TestThread = new Thread(new ThreadStart(ThreadInitFunction));
            TestThread.Start();
        }

        public void ConsoleAppendLine(string text)
        {

            log = ConForm.LineFinalize(text) + log;

            String output = ConForm.FileStart + log + ConForm.FileEnd;

            File.WriteAllText(activeTestPath, output);

            webConsole.Refresh();

        }


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

        private string getDateString()
        {
            return DateTime.Now.ToString().Replace("/", ".").Replace(":", ".").Replace(" ", "_");
        }

        private void endTest()
        {
            AbortButton.Enabled = false;
            TestProgressBar.Value = 100;
            TestProgressLabel.Text = "100%";
            ConsoleAppendLine(ConForm.AddBold("Test Thread Exiting.  Console Log Saved to: <br /> ") + ConForm.TabSpace + activeTestLogFileName);

            if (File.Exists(logPath + "\\" + activeTestLogFileName))
            {
                System.Diagnostics.Process.Start(logPath + "\\" + activeTestLogFileName);
            }
            Thread.Sleep(500);
            if (File.Exists(logPath + "\\" + activeTestReportFileName))
            {
                System.Diagnostics.Process.Start(logPath + "\\" + activeTestReportFileName);
            }
        }



        private void AbortButton_Click(object sender, EventArgs e)
        {
            AbortButton.Enabled = false;
            ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Abort Request Received, Attempting to Terminate Test..."), "red"));
            //TestThread.Abort();
            tester.Shutdown();
            //ConsoleAppendLine(ConForm.AddColor("Test Aborted.", "red"));
        }

        private void ThreadClearForShutdownFunc()
        {
            onComplete(this, EventArgs.Empty);
            this.Close();
        }


        //Other Thread
        private void ThreadInitFunction()
        {
            try
            {
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
