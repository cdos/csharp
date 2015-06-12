using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using PTZCameraTester.LensControl;
using PTZCameraTester.PositioningControl;
using PTZCameraTester.PelcoConfiguration;
using PTZCameraTester.Tests;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net.Sockets;
using System.Net;

namespace PTZCameraTester
{
    class TestController : ServiceLib
    {
        //Variables
        TestView _oMainView;
        string _sCameraModel;
        PTZCameraConfig _CameraConfig;
        string _reportFileName;
        bool stopFlag;
        TestBase activeTest;
        String logPath;

        public PTZCameraConfig CameraConfig
        {
            get
            {
                //Method that returns camera information.  References methods below.
                return _CameraConfig;
            }
        }

        //Method that takes in data from other class and converts to its own variable.
        public TestController(TestView iMV, string CameraIP, string reportfile, string _logPath)
            : base(CameraIP)
        {
            //Variables
            _oMainView = iMV;
            _reportFileName = reportfile;
            stopFlag = false;
            logPath = _logPath;
        }

        //The start camera tests.
        public void StartTest()
        {
            //API method. Get model Number which takes model and assign to camera model.
            try
            {
                _sCameraModel = PelcoClient.GetModelNumber();
            }
            catch (Exception e)
            {   
                //If soap error it will return this information.
                ConsoleAppendLine("Error: Cannot Communitcate with Camera. ", e.Data);
                return;
            }

            //Appends the console with Model Number and Model Name.  Obtain from PelcoConfiguratoin - GetModel and GetModelName.
            ConsoleAppendLine(String.Format("Camera Model Number, Name: {0}, {1}", PelcoClient.GetModelNumber(), PelcoClient.GetModelName()));
            ConsoleAppendLine("Loading Camera Defaults and Limits...");

            //new struct. CameraDetails is an object from CameraDetailsLoader.cs. How is it loaded into this app?
            _CameraConfig = CameraDetails.loadConfig(_sCameraModel, this);
            
            //Checks if _cameraconfig from PelcoClient.GetModelNumber.
            if (!_CameraConfig.validCamera)
            {
                ConsoleAppendLine(ConForm.AddColor("Error: Invalid Camera Type. ", "red")
                    + ConForm.AddBold(String.Format("Camera Model '{0}' is not defined", _sCameraModel))
                    );
                return;
            }
            //Checks the xml of the camera.  Part of the xml parsing under CameraDetails Class.
            if (_CameraConfig.badConfig)
            {
                ConsoleAppendLine(ConForm.AddColor("Error: Invalid Configuration File. ", "red")
                    + String.Format("Config XML for Camera Model '{0}' is invalid.", _sCameraModel)
                    );
                return;
            }

            //If not false then proceed to this line.
            else
            {
                ConsoleAppendLine(ConForm.AddColor("Valid Camera Type. ", "green")
                    + ConForm.AddBold(String.Format("Proceeding to Test Camera Model '{0}'", _sCameraModel))
                    );
            }
            try
            {
                //Execute this test and if its an error kick off an exception. 
                ExecuteTests();
            }

            //If there is an exception it will follow this step.
            catch (ThreadAbortException exp)
            {
                ConsoleAppendLine(ConForm.AddColor("Abort Request Received. ", "red")
                    + String.Format("Exception Data: '{0}'", exp.Data)
                    );
                
            }
        }

        //This is the heart of the execution.
        private void ExecuteTests(){
            
            //Variables.
            string log = "";
            ResultCounter counter = new ResultCounter();
            
            //assigns variable to object call TestBase Program.  Located in Tests folder of this project.
            Queue<TestBase> tq = new Queue<TestBase>();

            //Runs through all the tests.
            tq.Enqueue(new StartTest(this)); // Runs AutoFlip to invert flag.  Also test limits.
            tq.Enqueue(new AutoFlipTest(this)); //Runs everything in this class. Assigning TestBase.  Reads values from xml.
            tq.Enqueue(new PositionTest(this)); //Runs everything in this class.  There are limit tests, seek limits, azimuth zero.  More functional tests.
            tq.Enqueue(new PresetTest(this)); //Runs everythinbg in this class.  Max Presets, Preset with limits, and checking if camera reaches coordinate.
            //tq.Enqueue(new IrisTest(this)); //Test is skipped.  Howver it can be added from LensControl Test.
            tq.Enqueue(new VelocityTest(this)); //Velocity Test.  Uses Positioning Control for test.
            tq.Enqueue(new ZoomTest(this)); //Lens Control for test.

            while (tq.Count > 0)
            {
                //Sets the order of tests from above.
                activeTest = tq.Dequeue();
                activeTest.Run();
                counter.Combine(activeTest._counter);
                log = log + activeTest.GetTestResults();

                if (stopFlag)
                    break;
            }


            //output to file
            File.WriteAllText((logPath + "\\" + _reportFileName), ConForm.ResultsCSS + ConForm.ParseHeaderIntoTemplate(counter.success, counter.warning, counter.failure, counter.disabled) + log);
            //ClearForShutdown();
        }


        //Commonly used through out hte text.  Writes to console with string format and arguments.
        public void ConsoleAppendLine(string format, params object[] args)
        {
            object[] obj = { format };
            _oMainView.Invoke(_oMainView.AddLineToConsole, obj);
        }

        //Clears everything before shutdown.
        public void ClearForShutdown()
        {
            _oMainView.Invoke(_oMainView.ThreadClearForShutdown);
        }
        
        //Gets JPEG stream from device.  Need to pass it jpeg url.
        public void ConsoleAppendCurrentFrame()
        {
            Image retVal = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(JPEGQuickViewAddress);
                request.Timeout = 5000; // 5 sec timeout
                request.ReadWriteTimeout = 20000; // 20 sec
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                retVal = Image.FromStream(response.GetResponseStream());

                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
                TimeSpan span = (DateTime.Now - epoch);

                //string variable of where to save the jpeg.
                string path = logPath + "\\" + span.TotalSeconds+".jpg";

                //Call up the old path information.
                retVal.Save(path);

                //Writes to the text box.
                ConsoleAppendLine(ConForm.AddImage(path));
            }
            catch (Exception)
            {
                retVal = null;
            }
        }

        //Function used to stop the program.
        public void Shutdown()
        {
            ConsoleAppendLine(ConForm.AddColor("Test Thread Abort Request Recieved.  Shutting Down...", "red"));
            stopFlag = true;
            try
            {
                activeTest.Abort();
            }
            catch
            {

            }
        }
    }
}


/*
 * Tests to setup:
 *  * Autoflip Test
 *      - Check Speed
 *      - Check that AF occured
 *  * Position Speed Check. 
 *  * Preset check
 *  * Max Velocity Check
 *  * Zoom Speed Check
 *  * Zoom Accuracy Check
 *  
*/
