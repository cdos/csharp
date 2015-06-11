using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Xml;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PTZCameraTester.LensControl;
using PTZCameraTester.PositioningControl;
using PTZCameraTester.PelcoConfiguration;
using PTZCameraTester.PresetControl;
using PTZCameraTester.CameraConfiguration;
using PTZCameraTester.Tests;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net.Sockets;
using System.Net;


namespace PTZCameraTester.Tests
{
    class IrisTest : TestBase
    {
        public IrisTest(TestController c) 
            : base(c)
        {
            _testResults = ConForm.ParseGroupIntoTemplate("Iris Test Group");
        }

        public override void Run()
        {
            XmlNode node;
            try
            {
                node = _cConfig.test.SelectSingleNode("Iris");
            }
            catch
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Iris Test Group Disabled.", "grey"));
                return;
            }

            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Starting Iris Test Group..."), "blue"));

            // Random Seek
            try
            {
                node = _cConfig.test.SelectSingleNode("Iris/Open");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        OpenIris(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Iris Open Test",
                        "Could not start test, invalid config file values. "));
                        _counter.incF();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                //Most Likely Test Disabled.
                if (_cConfig.showDisabled)
                {
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Iris Open Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Iris Open Test Disabled.", "grey"));
            }
        }

        void OpenIris(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Iris Test.", "purple"));
            _controller.LensClient.Iris(1);
            Thread.Sleep(4000);
            _controller.ConsoleAppendLine("Saving Current Image");
            _controller.ConsoleAppendCurrentFrame();
            CameraConfig conf = _controller.CameraConfClient.GetConfiguration();

            _controller.LensClient.Iris(2);


            Thread.Sleep(4000);
            _controller.ConsoleAppendLine("Saving Current Image");
            _controller.ConsoleAppendCurrentFrame();
            
            CameraConfig conf2 = _controller.CameraConfClient.GetConfiguration();
            return;
            //_controller.ConsoleAppendLine(String.Format("Sending Camera to ({0}, {1})", x, y));
            //_controller.LensClient.Iris(2);
            
        }
    }
}
