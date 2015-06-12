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
    //Runs through all methods in this class.
    class VelocityTest: TestBase
    {
        public VelocityTest(TestController c) 
            : base(c)
        {
            _testResults = ConForm.ParseGroupIntoTemplate("Velocity Test Group");
        }

        public override void Run()
        {
            XmlNode node;
            try
            {
                //Reads xml and looks for velocity.
                node = _cConfig.test.SelectSingleNode("Velocity");
            }
            catch
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Velocity Test Group Disabled.", "grey"));
                return;
            }

            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Starting Velocity Test Group..."), "blue"));

            // Movement Verification
            try
            {
                node = _cConfig.test.SelectSingleNode("Velocity/Movement");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        MovementVerification(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Movement Verification Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Movement Verification Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Movement Verification Test Disabled.", "grey"));
            }

            // Relational Verification
            try
            {
                node = _cConfig.test.SelectSingleNode("Velocity/Relational");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        RelationalVerification();
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Relational Verification Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Relational Verification Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Relational Verification Test Disabled.", "grey"));
            }

            // Runaway Check
            try
            {
                //Reads xml to see if there is a velocity and runaway test.
                node = _cConfig.test.SelectSingleNode("Velocity/Runaway");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        RunawayCheck(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Runaway Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Runaway Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Runaway Test Disabled.", "grey"));
            }

            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Velocity Test Group Complete."), "blue"));
        }

        void MovementVerification(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Movement Verification Test.", "purple"));

            //Variable
            bool failed = false;
            int i;
            Random _r = new Random();
            Velocity pos,pos2;

            //loop.  Uses PelcoAPI, Postioning Control - GetPosition.
            for (i = 0; i < trials; i++)
            {
                PositionMove(true, true, _cConfig.pos.max_x / 2, true, _cConfig.pos.min_y / 2, true, _cConfig.zoom.min);
                pos = _controller.PositionClient.GetPosition();
                _controller.ConsoleAppendLine("Checking Postitive Velocity.  (Trial "+(i+1).ToString()+"/"+trials.ToString()+")");

                VelocityMove(true, _cConfig.vel.max_x / 4, true, _cConfig.vel.max_y / 4);
                
                Thread.Sleep(1000);

                VelocityMove(true, 0, true, 0);

                pos2 = _controller.PositionClient.GetPosition();

                if (pos.rotation.x < pos2.rotation.x && pos.rotation.y < pos2.rotation.y)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Moved in the Correct Direction (Positive).", "green"));
                }
                else
                {
                    failed = true;
                    if(pos.rotation.x > pos2.rotation.x)
                        _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not move the correct pan direction (Positive).  ", "red"));

                    if (pos.rotation.y > pos2.rotation.y)
                        _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not move the correct tilt direction (Positive).  ", "red"));
                }

                PositionMove(true, true, _cConfig.pos.max_x / 2, true, _cConfig.pos.min_y / 2, true, _cConfig.zoom.min);
                pos = _controller.PositionClient.GetPosition();
                _controller.ConsoleAppendLine("Checking Postitive Velocity");

                VelocityMove(true, -_cConfig.vel.max_x / 4, true, -_cConfig.vel.max_y / 4);

                Thread.Sleep(1000);

                VelocityMove(true, 0, true, 0);

                pos2 = _controller.PositionClient.GetPosition();

                if (pos.rotation.x > pos2.rotation.x && pos.rotation.y > pos2.rotation.y)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Moved in the Correct Direction (Negative).", "green"));
                }
                else
                {
                    failed = true;
                    if (pos.rotation.x <pos2.rotation.x)
                        _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not move the correct pan direction (Negative).  ", "red"));

                    if (pos.rotation.y < pos2.rotation.y)
                        _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not move the correct tilt direction (Negative).  ", "red"));
                }
                Thread.Sleep(500);
            }
            if (failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Movement Verification Test",
                    String.Format("Test Failed. Camera did not move as expected.  Is neg/pos velocity inverted? See log for details..")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Movement Verification Test",
                    String.Format("Test Completed Successfully. Camera moved as expected.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Movement Verification Test Complete.", "purple"));
        }

        void RelationalVerification()
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Relational Verification Test.", "purple"));

            bool failed = false;
            double[] percent = new double[3] { .25, .50, .75 };
            int i;
            Random _r = new Random();
            Velocity pos, pos2;

            for (i = 0; i < percent.Length-1; i++)
            {
                double speed1 = percent[i];
                double speed2 = percent[i + 1];
                _controller.ConsoleAppendLine(String.Format("Performing Pan test with {0}% and {1}%", speed1, speed2 ));
                PositionMove(true, true, _cConfig.pos.max_x / 2, true, _cConfig.pos.min_y / 2, true, _cConfig.zoom.min);
                //Get Distance for Speed 1
                pos = _controller.PositionClient.GetPosition();
                VelocityMove(true, (int)(speed1*_cConfig.vel.max_x), false, 0);
                Thread.Sleep(2000);
                VelocityMove(true, 0, true, 0);
                pos2 = _controller.PositionClient.GetPosition();
                int length1 = pos2.rotation.x - pos.rotation.x;

                //Get Distance for Speed 2
                PositionMove(true, true, _cConfig.pos.max_x / 2, true, _cConfig.pos.min_y / 2, true, _cConfig.zoom.min);
                pos = _controller.PositionClient.GetPosition();
                VelocityMove(true, (int)(speed2 * _cConfig.vel.max_x), false, 0);
                Thread.Sleep(2000);
                VelocityMove(true, 0, true, 0);
                pos2 = _controller.PositionClient.GetPosition();
                int length2 = pos2.rotation.x - pos.rotation.x;


                if (length1 < length2)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Moved as expected.", "green"));
                }
                else
                {
                    failed = true;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not move as expected.", "red"));
                }
                Thread.Sleep(500);
            }
            if (failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Relational Verification Test",
                    String.Format("Test Failed. Speed Relations failed.  Higher speeds should go farther.  See log for details.")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Relational Verification Test",
                    String.Format("Test Completed Successfully. Camera moved as expected.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Relational Verification Test Complete.", "purple"));
        }

        void RunawayCheck(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Runaway Test.", "purple"));

            bool failed = false;
            int i, panval;
            Velocity pos, pos2;

            for (i = 0; i < trials; i++)
            {
                bool success = false;
                ResetMotion(true);
                pos = _controller.PositionClient.GetPosition();
                panval = pos.rotation.x;
                _controller.ConsoleAppendLine("Checking Runaway.  (Trial " + (i + 1).ToString() + "/" + trials.ToString() + ")");

                TimeSpan length = TimeSpan.FromMilliseconds(0);
                TimeSpan max = TimeSpan.FromSeconds(13);
                
                VelocityMove(true, _cConfig.vel.max_x, true, _cConfig.vel.max_y);
                DateTime start = DateTime.Now;
                Thread.Sleep(1500);
                while (length < max)
                {
                    pos = _controller.PositionClient.GetPosition();
                    length = DateTime.Now - start;
                    if (panRangeCompare(pos.rotation.x, panval, _cConfig.global.PTAccuracy))
                    {
                        success = true;
                        break;
                    }
                    panval = pos.rotation.x;
                    Thread.Sleep(500);
                }

                pos2 = _controller.PositionClient.GetPosition();

                if (length < max && success)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera stopped as expected (Positive). ", "green") + String.Format("Duration: {0}", (DateTime.Now - start).TotalSeconds));
                }
                else
                {
                    failed = true;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not stop as expected (Positive). ", "red") + String.Format("Duration: {0}", (DateTime.Now - start).TotalSeconds));
                }

                Thread.Sleep(500);
            }
            if (failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Runaway Test",
                    String.Format("Test Failed. Camera did not move as expected.")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Runaway Test",
                    String.Format("Test Completed Successfully. Camera moved as expected.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Runaway Test Complete.", "purple"));
        }
    }
}
