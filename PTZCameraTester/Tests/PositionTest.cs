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
using PTZCameraTester.Tests;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net.Sockets;
using System.Net;

namespace PTZCameraTester.Tests
{
    class PositionTest : TestBase
    {
        public PositionTest(TestController c)
            : base(c)
        {
            _testResults = ConForm.ParseGroupIntoTemplate("Positioning Test Group");
        }

        public override void Run()
        {
            XmlNode node;      
            try
            {
                node = _cConfig.test.SelectSingleNode("Position");
            }
            catch
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Positioning Test Group Disabled.", "grey"));
                return;
            }

            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Starting Positioning Test Group..."), "blue"));
            ClearLimits();
            

            // Random Seek
            try
            {
                node = _cConfig.test.SelectSingleNode("Position/RandomSeek");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        RandomSeek(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Random Seek Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Random Seek Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Random Seek Test Disabled.", "grey"));
            }

            // Random Seek With Limits
            try
            {
                node = _cConfig.test.SelectSingleNode("Position/RandomSeekWithLimits");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        RandomSeekWithLimits(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Random Seek With Limits Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Random Seek With Limits Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Random Seek With Limits Test Disabled.", "grey"));
            }

            // Asmuth
            try
            {
                node = _cConfig.test.SelectSingleNode("Position/AsmuthZero");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        AsmuthCheck();
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Asmuth Zero Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Asmuth Zero Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Asmuth Zero Test Disabled.", "grey"));
            }
           
            ClearLimits();
            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Positioning Test Group Complete."), "blue"));
        }


        private void RandomSeek(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Random Seek Test.", "purple"));
            bool failed = false;
            int i;
            Random _r = new Random();
            Velocity pos;

            for (i = 0; i < trials; i++)
            {
                int x = _r.Next(_cConfig.pos.min_x, _cConfig.pos.max_x);
                int y = _r.Next(_cConfig.pos.min_y, _cConfig.pos.max_y);
                _controller.ConsoleAppendLine(String.Format("Sending Camera to ({0}, {1})", x, y));

                PositionMove(true, true, x, true, y, false, 100);
                Thread.Sleep(500);
                pos = _controller.PositionClient.GetPosition();

                if (rangeCompare(pos.rotation.x, x, _cConfig.global.PTAccuracy) && rangeCompare(pos.rotation.y, y, _cConfig.global.PTAccuracy))
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Arrived at Position.", "green"));
                }
                else
                {
                    failed = true;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not reach requested position.  ", "red") + String.Format("Actual Position: ({0}, {1})", pos.rotation.x, pos.rotation.y));
                }
                Thread.Sleep(500);
                if (stopFlag)
                    return;
            }
            if (failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Random Seek Test",
                    String.Format("Test Failed. Camera did not reach requested positions in one or more trials.  See log for details.")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Random Seek Test",
                    String.Format("Test Completed Successfully. Camera reached all requested positions.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Random Seek Test Complete.", "purple"));
        }

        private void RandomSeekWithLimits(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Random Seek With Limits Test.", "purple"));
            bool failed = false;
            int i;
            Random _r = new Random();
            Velocity pos;

            int xlimh = _cConfig.pos.max_x - _cConfig.pos.max_x * 2 / 11;
            int xliml = _cConfig.pos.min_x + _cConfig.pos.max_x * 2 / 11;
            _controller.ConsoleAppendLine(String.Format("Restricting Pan to {0}cdeg <-> {1}cdeg", xliml, xlimh));
            SetLimits(xliml, xlimh, _cConfig.pos.min_y, _cConfig.pos.max_y);
            Thread.Sleep(500);

            for (i = 0; i < trials; i++)
            {
                int x = _r.Next(_cConfig.pos.min_x, _cConfig.pos.max_x);
                int y = _r.Next(_cConfig.pos.min_y, _cConfig.pos.max_y);
                _controller.ConsoleAppendLine(String.Format("Sending Camera to ({0}, {1})", x, y));

                PositionMove(true, true, x, true, y, false, 100);
                Thread.Sleep(500);
                pos = _controller.PositionClient.GetPosition();

                if (panRangeCompare(pos.rotation.x, x, _cConfig.global.PTAccuracy) && rangeCompare(pos.rotation.y, y, _cConfig.global.PTAccuracy) && x >= xliml && x <= xlimh)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Arrived at Position Outside of Limits.", "green"));
                }
                else
                {
                    if (rangeCompare(pos.rotation.y, y, _cConfig.global.PTAccuracy) && (x < xliml || x > xlimh))
                    {
                        if (panRangeCompare(pos.rotation.x, xliml, _cConfig.global.PTAccuracy) || panRangeCompare(pos.rotation.x, xlimh, _cConfig.global.PTAccuracy))
                        {
                            _controller.ConsoleAppendLine(ConForm.AddColor("Camera correctly moved into limits.  ", "green"));
                        }
                        else
                        {
                            failed = true;
                            _controller.ConsoleAppendLine(ConForm.AddColor("Camera Moved inside of limits.  ", "red") + String.Format("Actual Position: ({0}, {1})", pos.rotation.x, pos.rotation.y));
                        }
                    }
                    else
                    {
                        failed = true;
                        _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not reach requested position.  ", "red") + String.Format("Actual Position: ({0}, {1})", pos.rotation.x, pos.rotation.y));
                    }
                }
                Thread.Sleep(500);
                if (stopFlag)
                    return;
            }
            if (failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Random Seek With Limits Test",
                    String.Format("Test Failed. Camera did not reach requested positions in one or more trials.  See log for details.")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Random Seek With Limits Test",
                    String.Format("Test Completed Successfully. Camera reached all requested positions.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Random Seek With Limits Test Complete.", "purple"));
        }

        private void AsmuthCheck()
        {
            //check pan
            //change asmuth
            //check pan again
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Asmuth Zero Test.", "purple"));
            Random _r = new Random();
            bool failed = false;
            Velocity pos, pos2;
            try
            {
                pos = _controller.PositionClient.GetPosition();

                _controller.PositionClient.SetAzimuthZero(120);

                pos2 = _controller.PositionClient.GetPosition();

                _controller.PositionClient.SetAzimuthZero(1);
            }
            catch (Exception ex1)
            {
                pos = _controller.PositionClient.GetPosition();
                pos2 = _controller.PositionClient.GetPosition();
                _controller.ConsoleAppendLine(ConForm.AddColor("Text Exception: ", "red") + ex1.Message);
            }

            if (!panRangeCompare(pos.rotation.x - 119, pos2.rotation.x, _cConfig.global.PTAccuracy) || failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Asmuth Zero Test",
                    String.Format("Test Failed. Camera did not change asmuth zero.  See log for details.")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Asmuth Zero Test",
                    String.Format("Test Completed Successfully. Camera Changed asmuth zero.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Asmuth Zero Test Complete.", "purple"));
        }
    }
}
