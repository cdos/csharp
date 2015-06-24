using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net.Sockets;
using System.Net;
using PTZCameraTester.PositioningControl;
using PTZCameraTester.Tests;
using PTZCameraTester.PelcoConfiguration;

namespace PTZCameraTester
{
    public partial class MainView : Form
    {
        /// <summary>
        /// This is the main form program.  Each operator controls an item inside the form.
        /// </summary>
        /// 

        //Variables
        AboutBox About;
        TestView test;
        FolderBrowserDialog folder;
        String path;

        // CameraAddress is a global function that returns a string of the url of the camera.  Most likely used for endpoint of camera. String is concatenation of of 2 text boxes.
        public string CameraAddress
        {
            get
            {
                return "http://" + this.CameraIpAddress.Text + ":" + this.CameraPort.Text;
            }

        }

        //pointers
        public delegate void endDelegate(object sender, EventArgs e);
        public endDelegate endTestDelegate;

        public MainView()
        {
            InitializeComponent();
            System.Net.ServicePointManager.Expect100Continue = false;

            //When the application boots, it sets the condition of the form to endTest.  Should force it be stopped.
            endTestDelegate = new endDelegate(endTest);

            //Sets the properties PreviousIPAddress.  If length is not 0 then it will save it as PreviousIPAddress. 
            if (Properties.Settings.Default.PreviousIPAddress.Length != 0)
            {
                CameraIpAddress.Text = Properties.Settings.Default.PreviousIPAddress;
            }

            //function that opens the folder dialog box.
            folder = new FolderBrowserDialog();

            //Sets the LogPath properties.  If its not 0 save the new Logpath as 'path'.  If not use system default path.
            if (Properties.Settings.Default.LogPath.Length != 0)
            {
                path = Properties.Settings.Default.LogPath;
            }
            else
            {
                //System Default Path
                path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            }

            //Have the folder dialog box use the new path assigned from function above.
            folder.SelectedPath = path;
        }

        //When About Button is clicked.
        private void AboutButton_Click(object sender, EventArgs e)
        {
            About = new AboutBox();
            About.Show();
        }
        
        //When the Start Button clicked.
        private void StartButton_Click(object sender, EventArgs e)
        {
            //Turns off startbutton and the progress bar.
            StartButton.Enabled = false;
            progressBar.Value = 100;
            progressBar.Style = ProgressBarStyle.Marquee;

            //Creates a new Class from ServiceLib and call it svlib.  This class takes in the Camera's Address as an argument.
            //Camera Address is formatted as http://10.221.225.95:80
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                //Assigns the string variable name modelname.  This retrieved by sending PelcoAPI GetModelNumber;
                //PelcoClient is short for PelcoConfiguration API.  Probably pulled from PelcoConfiguration wsdl.
                //Inside PelcoClient you can choose different methods.  The example below uses GetModelNumber. 
                //GetModelNumber is assigned from PelcoConfiguration Service References.
                string modelname = svlib.PelcoClient.GetModelNumber();
            }
            catch
            {
                //If there is an error talking to the camera it will return a fault message.
                //Then it will enable the start button.
                MessageBox.Show("Error: Cannot Communitcate with Camera.");
                StartButton.Enabled = true;
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Value = 0;
                return;
            }
            Properties.Settings.Default.PreviousIPAddress = this.CameraIpAddress.Text;
            Properties.Settings.Default.Save();

            //When start button is pressed it starts Test View form.
            //The second big program.
            test = new TestView(CameraAddress, path);
            test.Setup();
            test.Show();
            test.Run();

            //After form loads it pauses the controls.
            test.onComplete += new TestCompleteEvent(endTestDelegate);
            //TestThread = new Thread(new ThreadStart(ThreadInitFunction));
            //TestThread.Start();
        }

        //This functions opens a Form call Testviews and also tells it to stop.
        private void endTest(object sender, EventArgs e) 
        {
            StartButton.Enabled = true;
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Value = 0;
            test.onComplete -= new TestCompleteEvent(endTestDelegate);
        }

        //Other Thread
        private void ThreadInitFunction()
        {
            try
            {
                //Calls TestView and opens a new instance.  Taking the argument of the camera ip address and path.
                TestView test = new TestView(CameraAddress, path);
                //Takes configuration and assing to variable.
                test.Setup();
                
                //Displays the TestView form.
                test.Show();
                
                //Starts the TestView thread.
                test.Run();
            }
            catch { }

            this.Invoke(this.endTestDelegate);
        }

        //Controls the action of the close button.
        private void CloseButton_Click(object sender, EventArgs e)
        {   
            //Checks if start button is on.  If not then it returns a message that its running.  Allows you to exit the application.
            if (StartButton.Enabled == false)
            {
                MessageBox.Show("Test in Progress... Cannot Close.");
            }
            else
            {
                Application.Exit();
            }
        }

        //Controls the action of the close button.
        private void EditConfigButton_Click(object sender, EventArgs e)
        {
           //define path from default folder.
           string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

           //A .net framework library that reads in file.  Takes in the path and looks for xml folder.
           Process.Start(path + "\\XML");
        }

        //Controls the action of the logLocationButton.  This is where you will be storing your logging information.
        private void logLocationButton_Click(object sender, EventArgs e)
        {
            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
                //This is where the new logpath information gets generated.
                Properties.Settings.Default.LogPath = path;
                Properties.Settings.Default.Save();
            }
        }

        //Controls the change log Button.  Provides the user with a static location based on current directory of the application.
        private void changelogButton_Click(object sender, EventArgs e)
        {
            Process.Start(path + "\\static\\changelog.txt");
        }

        //Controls the behavior of the form when it launches.
        private void MainView_Load(object sender, EventArgs e)
        {

        }

        //Pan Left button
        private void button1_Click(object sender, EventArgs e)
        {
            string excited = " Fuck Yeah";
            
            //Gets the addres from the text box.
            ServiceLib svlib = new ServiceLib(CameraAddress);
            string modelname = svlib.PelcoClient.GetModelNumber();
            richTextBox1.Text = modelname + excited;
 
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
                        //This is move left button.
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                //Assigns the string variable name modelname.  This retrieved by sending PelcoAPI GetModelNumber;
                //PelcoClient is short for PelcoConfiguration API.  Probably pulled from PelcoConfiguration wsdl.
                //Inside PelcoClient you can choose different methods.  The example below uses GetModelNumber. 
                //GetModelNumber is assigned from PelcoConfiguration Service References.
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.x = 10000;
                svlib.PositionClient.SetVelocity(vel);
            }
            catch
            {
                //If there is an error talking to the camera it will return a fault message.
                //Then it will enable the start button.
                MessageBox.Show("Error: Cannot Communitcate with Camera.");
                return;
            }  
  
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PelcoConfigForm pelconfigform = new PelcoConfigForm(CameraIpAddress.Text);
            pelconfigform.Show();
        }

        //private void LeftPTZButton_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //This is move left button.
        //    ServiceLib svlib = new ServiceLib(CameraAddress);
        //    int velpanspeed = Convert.ToInt32(textboxpanspeed.Text);
        //    int veltiltspeed = Convert.ToInt32(textboxtiltspeed.Text);
        //    try
        //    {
        //        //Assigns the string variable name modelname.  This retrieved by sending PelcoAPI GetModelNumber;
        //        //PelcoClient is short for PelcoConfiguration API.  Probably pulled from PelcoConfiguration wsdl.
        //        //Inside PelcoClient you can choose different methods.  The example below uses GetModelNumber. 
        //        //GetModelNumber is assigned from PelcoConfiguration Service References.
        //        Velocity vel = svlib.PositionClient.GetVelocity();
        //        vel.rotation.x = velpanspeed;
        //        svlib.PositionClient.SetVelocity(vel);
        //    }
        //    catch
        //    {
        //        //If there is an error talking to the camera it will return a fault message.
        //        //Then it will enable the start button.
        //        MessageBox.Show("Error: Cannot Communitcate with Camera.");
        //        return;
        //    }
        //}
        //private void LeftPTZButton_MouseUp(object sender, MouseEventArgs e)
        //{
        //    //This is move left button.
        //    ServiceLib svlib = new ServiceLib(CameraAddress);
        //    try
        //    {
        //        //Assigns the string variable name modelname.  This retrieved by sending PelcoAPI GetModelNumber;
        //        //PelcoClient is short for PelcoConfiguration API.  Probably pulled from PelcoConfiguration wsdl.
        //        //Inside PelcoClient you can choose different methods.  The example below uses GetModelNumber. 
        //        //GetModelNumber is assigned from PelcoConfiguration Service References.
        //        Velocity vel = svlib.PositionClient.GetVelocity();
        //        vel.rotation.x = 0;
        //        svlib.PositionClient.SetVelocity(vel);
        //    }
        //    catch
        //    {
        //        //If there is an error talking to the camera it will return a fault message.
        //        //Then it will enable the start button.
        //        MessageBox.Show("Error: Cannot Communitcate with Camera.");
        //        return;
        //    }
        //}

        //private void rightPTZButton_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //This button moves the camera right.
        //    ServiceLib svlib = new ServiceLib(CameraAddress);
        //    int velpanspeed = Convert.ToInt32(textboxpanspeed.Text);
        //    int veltiltspeed = Convert.ToInt32(textboxtiltspeed.Text);
        //    try
        //    {
        //        Velocity vel = svlib.PositionClient.GetVelocity();
        //        vel.rotation.x = -velpanspeed;
        //        svlib.PositionClient.SetVelocity(vel);

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error: Cannot Communicate with Camera.");
        //        return;
        //    }
        //}

        //private void rightPTZButton_MouseUp(object sender, MouseEventArgs e)
        //{
        //    ServiceLib svlib = new ServiceLib(CameraAddress);
        //    try
        //    {
        //        Velocity vel = svlib.PositionClient.GetVelocity();
        //        vel.rotation.x = 0;
        //        svlib.PositionClient.SetVelocity(vel);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error: Cannot Communitcate with Camera.");
        //        return;
        //    }
        //}

        //private void upPTZButton_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ServiceLib svlib = new ServiceLib(CameraAddress);
        //    int velpanspeed = Convert.ToInt32(textboxpanspeed.Text);
        //    int veltiltspeed = Convert.ToInt32(textboxtiltspeed.Text);
        //    try
        //    {
        //        Velocity vel = svlib.PositionClient.GetVelocity();
        //        vel.rotation.y = -veltiltspeed;
        //        svlib.PositionClient.SetVelocity(vel);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error: Cannot Communicate with Camera.");
        //        return;
        //    }
        //}

        //private void upPTZButton_MouseUp(object sender, MouseEventArgs e)
        //{
        //    ServiceLib svlib = new ServiceLib(CameraAddress);
        //    try
        //    {
        //        Velocity vel = svlib.PositionClient.GetVelocity();

        //        vel.rotation.y = 0;
        //        svlib.PositionClient.SetVelocity(vel);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error: Cannot Communicate with Camera.");
        //        return;
        //    }
        //}

        //private void downPTZButton_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ServiceLib svlib = new ServiceLib(CameraAddress);
        //    int velpanspeed = Convert.ToInt32(textboxpanspeed.Text);
        //    int veltiltspeed = Convert.ToInt32(textboxtiltspeed.Text);
        //    if (veltiltspeed == null)
        //    {
        //        veltiltspeed = 0;
        //    }
        //    if (velpanspeed == null)
        //    {
        //        velpanspeed = 0;
        //    }

        //    try
        //    {
        //        Velocity vel = svlib.PositionClient.GetVelocity();

        //        //Gets the input from the textbox and converts to int.  

        //        //Replaces y with the value from the textbox.
        //        vel.rotation.y = veltiltspeed;
        //        svlib.PositionClient.SetVelocity(vel);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error: Cannot Communicate with Camera.");
        //        return;
        //    }
        //}

        //private void downPTZButton_MouseUp(object sender, MouseEventArgs e)
        //{
        //    ServiceLib svlib = new ServiceLib(CameraAddress);
        //    try
        //    {
        //        Velocity vel = svlib.PositionClient.GetVelocity();
        //        vel.rotation.y = 0;
        //        svlib.PositionClient.SetVelocity(vel);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error: Cannot Communicate with Camera.");
        //        return;
        //    }
        //}
    
    }
}


/* <sectionGroup name="userSettings" type="System.Configuration.UserSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
            <section name="PTZCameraTester.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" allowExeDefinition="MachineToLocalUser" requirePermission="false" />
        </sectionGroup>
*/