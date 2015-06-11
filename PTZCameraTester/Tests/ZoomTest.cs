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
    class ZoomTest : TestBase
    {
        public ZoomTest(TestController c)
            : base(c)
        {
            _testResults = ConForm.ParseGroupIntoTemplate("Zoom Test Group");
        }

        public override void Run()
        {
            XmlNode node;
            try
            {
                node = _cConfig.test.SelectSingleNode("Zoom");
            }
            catch
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Zoom Test Group Disabled.", "grey"));
                return;
            }

            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Starting Zoom Test Group..."), "blue"));
            ClearLimits();


            // Random Seek
            try
            {
                node = _cConfig.test.SelectSingleNode("Zoom/RandomSeek");
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
                node = _cConfig.test.SelectSingleNode("Zoom/RandomSeekWithMaxMag");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        RandomSeekWithMaxMag(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Random Seek With Max Mag Test",
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

            // Random Seek With Limits
            try
            {
                node = _cConfig.test.SelectSingleNode("Zoom/TeleWide");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        TeleWideCheck(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Tele/Wide Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Tele/Wide Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Tele/Wide Test Disabled.", "grey"));
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

            for (i = 0; i < trials; i++)
            {
                uint z = (uint)_r.Next((int)_cConfig.zoom.min, (int)_cConfig.zoom.max);
                _controller.ConsoleAppendLine(String.Format("Sending Camera to mag = {0}", z));

                PositionMove(true, false, 0, false, 0, true, z);
                Thread.Sleep(750);
                uint mag = _controller.LensClient.GetMag();

                if (rangeCompare(mag, z, _cConfig.global.zoomAccuracy))
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Arrived at Position.", "green"));
                }
                else
                {
                    failed = true;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not reach requested position.  ", "red") + String.Format("Actual Mag: {0}", mag));
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

        private void RandomSeekWithMaxMag(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Random Seek With Max Mag Test.", "purple"));
            bool failed = false;
            int i;
            Random _r = new Random();

            uint lim = _cConfig.zoom.max/2;
            _controller.LensClient.SetMaxMag(lim);
            _controller.ConsoleAppendLine(String.Format("Restricting Mag to {0} <-> {1}", _cConfig.zoom.min, lim));
            Thread.Sleep(500);

            for (i = 0; i < trials; i++)
            {
                uint z = (uint)_r.Next((int)_cConfig.zoom.min, (int)_cConfig.zoom.max);
                _controller.ConsoleAppendLine(String.Format("Sending Camera to mag = {0}", z));

                PositionMove(true, false, 0, false, 0, true, z);
                Thread.Sleep(750);
                uint mag = _controller.LensClient.GetMag();

                if (rangeCompare(mag, z, _cConfig.global.zoomAccuracy) && z <= lim)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Arrived at Position Outside of Limits.", "green"));
                }
                else
                {
                    if (rangeCompare(mag, z, _cConfig.global.zoomAccuracy) && z > lim)
                    {
                        if (rangeCompare(mag, lim, _cConfig.global.zoomAccuracy))
                        {
                            _controller.ConsoleAppendLine(ConForm.AddColor("Camera correctly moved into limits.  ", "green"));
                        }
                        else
                        {
                            failed = true;
                            _controller.ConsoleAppendLine(ConForm.AddColor("Camera Moved inside of limits.  ", "red") + String.Format("Actual Position: ({0})", mag));
                        }
                    }
                    else
                    {
                        failed = true;
                        _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not reach requested position.  ", "red") + String.Format("Actual Position: ({0})", mag));
                    }
                }
                Thread.Sleep(500);
                if (stopFlag)
                    return;
            }
            if (failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Random Seek With Max Mag Test",
                    String.Format("Test Failed. Camera did not reach requested positions in one or more trials.  See log for details.")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Random Seek With Max Mag Test",
                    String.Format("Test Completed Successfully. Camera reached all requested positions.")));
                _counter.incS();
            }
            _controller.LensClient.SetMaxMag(_cConfig.zoom.max);
            _controller.ConsoleAppendLine(ConForm.AddColor("Random Seek With Max Mag Test Complete.", "purple"));
        }

    private void TeleWideCheck(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Tele/Wide Test.", "purple"));
            PositionMove(true, false, 0, false, 0, true, _cConfig.zoom.max / 2);
            bool failed = false;
            int i;
            Random _r = new Random();

            for (i = 0; i < trials; i++)
            {
                PositionMove(true, false, 0, false, 0, true, _cConfig.zoom.max / 2);
                uint mag = _controller.LensClient.GetMag();
                _controller.ConsoleAppendLine("Sending Camera Tele");

                _controller.LensClient.Zoom(2);

                Thread.Sleep(2500);
                uint magend = _controller.LensClient.GetMag();

                _controller.LensClient.Zoom(0);

                if (magend > mag)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera zoomed in the proper direction.", "green"));
                }
                else
                {
                    failed = true;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not zoom in the proper direction.  ", "red") + String.Format("Start Mag: {0}, End Mag: {1}", mag, magend));
                }
                Thread.Sleep(500);
                PositionMove(true, false, 0, false, 0, true, _cConfig.zoom.max / 2);
                mag = _controller.LensClient.GetMag();
                _controller.ConsoleAppendLine("Sending Camera Wide ");

                _controller.LensClient.Zoom(1);

                Thread.Sleep(2500);
                magend = _controller.LensClient.GetMag();

                _controller.LensClient.Zoom(0);

                if (magend < mag)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera zoomed in the proper direction.", "green"));
                }
                else
                {
                    failed = true;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not zoom in the proper direction.  ", "red") + String.Format("Start Mag: {0}, End Mag: {1}", mag, magend));
                }
                Thread.Sleep(500);

                if (stopFlag)
                    return;
            }
            if (failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Tele/Wide Test",
                    String.Format("Test Failed. Camera did not zoom in the correct direction for one or more trials.  See log for details.")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Tele/Wide Test",
                    String.Format("Test Completed Successfully. Camera zoomed in the correct direction for all trials.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Tele/Wide Test Complete.", "purple"));
        }
    }
}
