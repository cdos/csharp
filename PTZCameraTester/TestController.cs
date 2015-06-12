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
            //API method get model Number which takes model and assign to camera model.
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

            //Appends the console with Model Number and Model Name.
            ConsoleAppendLine(String.Format("Camera Model Number, Name: {0}, {1}", PelcoClient.GetModelNumber(), PelcoClient.GetModelName()));
            ConsoleAppendLine("Loading Camera Defaults and Limits...");

            //new struct. CameraDetails is an object from CameraDetailsLoader.cs. How is it loaded into this app?
            _CameraConfig = CameraDetails.loadConfig(_sCameraModel, this);
            
            //Checks if _cameraconfig from 
            if (!_CameraConfig.validCamera)
            {
                ConsoleAppendLine(ConForm.AddColor("Error: Invalid Camera Type. ", "red")
                    + ConForm.AddBold(String.Format("Camera Model '{0}' is not defined", _sCameraModel))
                    );
                return;
            }
            if (_CameraConfig.badConfig)
            {
                ConsoleAppendLine(ConForm.AddColor("Error: Invalid Configuration File. ", "red")
                    + String.Format("Config XML for Camera Model '{0}' is invalid.", _sCameraModel)
                    );
                return;
            }
            else
            {
                ConsoleAppendLine(ConForm.AddColor("Valid Camera Type. ", "green")
                    + ConForm.AddBold(String.Format("Proceeding to Test Camera Model '{0}'", _sCameraModel))
                    );
            }
            try
            {
                ExecuteTests();
            }
            catch (ThreadAbortException exp)
            {
                ConsoleAppendLine(ConForm.AddColor("Abort Request Received. ", "red")
                    + String.Format("Exception Data: '{0}'", exp.Data)
                    );
                
            }
        }

        private void ExecuteTests(){
            string log = "";
            ResultCounter counter = new ResultCounter();
            Queue<TestBase> tq = new Queue<TestBase>();

            tq.Enqueue(new StartTest(this));
            tq.Enqueue(new AutoFlipTest(this));
            tq.Enqueue(new PositionTest(this));
            tq.Enqueue(new PresetTest(this));
            //tq.Enqueue(new IrisTest(this));
            tq.Enqueue(new VelocityTest(this));
            tq.Enqueue(new ZoomTest(this));

            while (tq.Count > 0)
            {
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


        public void ConsoleAppendLine(string format, params object[] args)
        {
            object[] obj = { format };
            _oMainView.Invoke(_oMainView.AddLineToConsole, obj);
        }

        public void ClearForShutdown()
        {
            _oMainView.Invoke(_oMainView.ThreadClearForShutdown);
        }

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

                string path = logPath + "\\" + span.TotalSeconds+".jpg";

                retVal.Save(path);

                ConsoleAppendLine(ConForm.AddImage(path));
            }
            catch (Exception)
            {
                retVal = null;
            }
        }

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
