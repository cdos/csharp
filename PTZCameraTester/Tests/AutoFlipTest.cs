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
    class AutoFlipTest : TestBase
    {
        //Controls the autoflip test.
        public AutoFlipTest(TestController c) : base(c)
        {
            _testResults = ConForm.ParseGroupIntoTemplate("AutoFlip Test Group");
        }

        public override void Run()
        {
            //Writes everything to console controller. For logging.
            XmlNode node;      
            try
            {
                node = _cConfig.test.SelectSingleNode("AutoFlip");
            }
            catch
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Autoflip Test Group Disabled.", "grey"));
                return;
            }

            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Starting AutoFlip Test Group..."), "blue"));
            ClearLimits();
            

            // Standard Test.  The start of the autoflip test.
            try
            {
                //Reads from the xml and looks for this node.
                node = _cConfig.test.SelectSingleNode("AutoFlip/Standard");

                //If it find the string to be matching and enabled then it proceeds to the next step.
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        //Pulls Trials from the xml.  Converts string to int and assign xml value.  Standard test is run based on these values.
                        XmlAttributeCollection atts = node.Attributes;
                        StandardTest(Convert.ToInt32(atts.GetNamedItem("Trials").Value), Convert.ToInt32(atts.GetNamedItem("MaxFlipDuration").Value));
                    }
                    catch
                    {
                        //If it fails it will output the log below.
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Standard AutoFlip Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Standard AutoFlip Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Standard Autoflip Test Disabled.", "grey"));
            }

            if (stopFlag) return;
            //With Limits Test
            try
            {

                node = _cConfig.test.SelectSingleNode("AutoFlip/WithLimits");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        TestWithLimits();
                    }
                    catch { }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                if (_cConfig.showDisabled)
                {
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "AutoFlip Test Around Limits", ""));
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "AutoFlip Test Into Limits", ""));
                    _counter.incD();
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Autoflip Tests with Limits Disabled.", "grey"));
            }

            ClearLimits();

            if (stopFlag) return;
            //Control test
            try
            {
                node = _cConfig.test.SelectSingleNode("AutoFlip/CheckPostFlipControl");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        TestForControl(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "AutoFlip with Post Control Check",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "AutoFlip with Post Control Check", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("AutoFlip with Post Control Check Test Disabled.", "grey"));
            }

            ClearLimits();
            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("AutoFlip Test Group Complete."), "blue"));
        }


        private void StandardTest(int trials, int maxDuration)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Standard AutoFlip Test.", "purple"));
            /* ** Test Outline **
             * Reset Position
             * Tilt Down
             * Pool until pan movement
             * Record time
             * Pool until pan stop
             * Record time
             * Compare.
             */

            int[] positions = new int[trials];
            int i;
            int increment = (_cConfig.pos.max_x - _cConfig.pos.min_x) / trials;
            bool errorFlag = false;

            List<double> durations = new List<double>();

            for (i = 0; i < trials; i++)
            {
                positions[i] = _cConfig.pos.min_x + increment * i;
            }

            for (i = 0; i < trials; i++)
            {
                //Reset Camera to start position
                _controller.ConsoleAppendLine(ConForm.AddColor(String.Format("Moving Camera to {0}, 0.", positions[i]), "grey"));
                PositionMove(true, true, positions[i], true, 0, true, 100);

                AutoFlipResult result = DoAutoFlip();

                if (result.error)
                {
                    errorFlag = true;
                    continue;
                }

                durations.Add(result.elapsedms);            
            }
            if (durations.Count == 0)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Standard AutoFlip Test",
                    String.Format("CRITICAL FAILURE!  No Autoflips occurred.  Camera Control may be lost.",
                    durations.Average(), durations.Min(), durations.Max(), maxDuration)));
                _counter.incF();
            }
            else if (errorFlag)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Standard AutoFlip Test",
                    String.Format("Camera did not perform required actions during test.  Please See log.  Of Valid results: Average Duration: {0}ms (Min: {1}ms, Max: {2}ms)",
                    durations.Average(), durations.Min(), durations.Max(), maxDuration)));
                _counter.incF();
            }
            else if (durations.Average() > maxDuration)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Standard AutoFlip Test", 
                    String.Format("Test Failed to meet specification time of {3}.  Average Duration: {0}ms (Min: {1}ms, Max: {2}ms)", 
                    durations.Average(), durations.Min(), durations.Max(), maxDuration)));
                _counter.incF();
            }
            else if (durations.Min() <= maxDuration && durations.Max() <= maxDuration)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Standard AutoFlip Test", 
                    String.Format("Test Completed Successfully.  Average Duration: {0}ms (Min: {1}ms, Max: {2}ms)", 
                    durations.Average(), durations.Min(), durations.Max())));
                _counter.incS();
            }
            else if (durations.Min() <= maxDuration && durations.Max() > maxDuration)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Warning, "Standard AutoFlip Test", 
                    String.Format("Average time meets specification time of {3}, but one or more tests were above the specification time.  Average Duration: {0}ms (Min: {1}ms, Max: {2}ms)", 
                    durations.Average(), durations.Min(), durations.Max(), maxDuration)));
                _counter.incW();
            }

            _controller.ConsoleAppendLine(ConForm.AddColor("Standard AutoFlip Test Complete.", "purple"));
        }


        private void TestWithLimits()
        {
            bool errorFlag = false;
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting AutoFlip Test With Limits.", "purple"));

            int xlimh = _cConfig.pos.max_x - _cConfig.pos.max_x/8;
            int xliml = _cConfig.pos.min_x + _cConfig.pos.max_x/8;
            _controller.ConsoleAppendLine(String.Format("Restricting Pan to {0}cdeg <-> {1}cdeg", xliml, xlimh));
            SetLimits(xliml, xlimh, _cConfig.pos.min_y, _cConfig.pos.max_y);
            Thread.Sleep(500);

            _controller.ConsoleAppendLine(ConForm.AddColor(String.Format("Moving Camera to {0}, 0.", xliml), "grey"));

            PositionMove(true, true, xliml, true, _cConfig.pos.max_y, true, _cConfig.zoom.min);

            AutoFlipResult result = DoAutoFlip();

            if (!rangeCompare(result.panstop, xliml + 18000, _cConfig.global.PTAccuracy) || result.error)
            {
                errorFlag = true;
                _controller.ConsoleAppendLine(ConForm.AddColor("Error: Camera did not rotate 180 degrees. ", "red")
                    + String.Format("Target: {0}, Actual {1}", xliml + 18000, result.panstop));
            }

            PositionMove(true, false, 0, true, _cConfig.pos.max_y, false, 100);
            AutoFlipResult result2 = DoAutoFlip();

            if (!rangeCompare(result2.panstop, xliml, _cConfig.global.PTAccuracy) || result2.error)
            {
                errorFlag = true;
                _controller.ConsoleAppendLine(ConForm.AddColor("Error: Camera did not move into expected position. ", "red") 
                    + String.Format("Target: {0}, Actual {1}", xliml, result2.panstop));
            }


            if (errorFlag)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "AutoFlip Test Around Limits",
                    String.Format("Camera did not properly move around limits.  See log for Details.")));
                _counter.incF();

                _controller.ConsoleAppendLine(ConForm.AddColor("Test Failed, Camera did not properly move around limits.", "red"));
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "AutoFlip Test Around Limits",
                   String.Format("Camera moved properly around limits.")));
                _counter.incS();


                _controller.ConsoleAppendLine(ConForm.AddColor("Test Success, Camera properly moved around limits.", "green"));
            }


            xlimh = _cConfig.pos.max_x - _cConfig.pos.max_x / 4;
            xliml = _cConfig.pos.min_x + _cConfig.pos.max_x / 8;
            SetLimits(xliml, xlimh, _cConfig.pos.min_y, _cConfig.pos.max_y);
            _controller.ConsoleAppendLine(String.Format("Restricting Pan to {0}cdeg <-> {1}cdeg", xliml, xlimh));
            Thread.Sleep(500);

            PositionMove(true, true, 18000, true, 0, false, 100);
            _controller.ConsoleAppendLine(ConForm.AddColor(String.Format("Moving Camera to {0}, 0.", 18000), "grey"));

            result = DoAutoFlip(true, true);

            if (!(rangeCompare(xliml, result.panstop, _cConfig.global.PTAccuracy) || rangeCompare(xlimh, result.panstop, _cConfig.global.PTAccuracy)) || result.error)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "AutoFlip Test into Limits",
                    String.Format("Camera did not properly move into limits.  See log for Details.")));
                _counter.incF();
                _controller.ConsoleAppendLine(ConForm.AddColor("Test Failed, Camera did not properly move into limits.  Camera should be at a limit.", "red"));
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "AutoFlip Test into Limits",
                    String.Format("Camera properly moved into limits.  See log for Details.")));
                _counter.incS();
                _controller.ConsoleAppendLine(ConForm.AddColor("Test Success, Camera properly moved into limits.", "green"));
            }


            _controller.ConsoleAppendLine(ConForm.AddColor("AutoFlip Test With Limits Complete.", "purple"));
        }

        private void TestForControl(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting AutoFlip Test with Post Control Check.", "purple"));
            int i; bool flipFailFlag = false; int errorCount = 0;
            int xstart = _cConfig.pos.min_x + _cConfig.pos.max_x / 4;
            for (i = 0; i < trials; i++)
            {
                //Reset Camera to start position
                _controller.ConsoleAppendLine(ConForm.AddColor("Moving Camera to 0, 0.", "grey"));
                PositionMove(true, true, xstart, true, 0, true, 100);

                AutoFlipResult result = DoAutoFlip(false);

                if (result.error)
                {
                    flipFailFlag = true;
                    continue;
                }

                _controller.ConsoleAppendLine(ConForm.AddColor("Testing Pan.  Velocity set to " + String.Format("({0}, {1})", _cConfig.vel.max_x / 4, -_cConfig.vel.max_y / 4), "black"));
                VelocityMove(true, _cConfig.vel.max_x / 2, true, -_cConfig.vel.max_y / 4);
                Velocity pos = _controller.PositionClient.GetPosition();
                Thread.Sleep(400);
                Velocity pos2 = _controller.PositionClient.GetPosition();
                _controller.ConsoleAppendLine(ConForm.AddColor("Testing Pan.  Velocity set to " + String.Format("({0}, {1})", -_cConfig.vel.max_x / 4, -_cConfig.vel.max_y / 4), "black"));
                VelocityMove(true, -_cConfig.vel.max_x / 2, true, -_cConfig.vel.max_y / 4);
                Thread.Sleep(400);
                Velocity pos3 = _controller.PositionClient.GetPosition();
                VelocityMove(true, 0, true, 0);

                if (rangeCompare(pos.rotation.x, pos2.rotation.x, 20) || rangeCompare(pos2.rotation.x, pos3.rotation.x, 20))
                {
                    errorCount++;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Error:  Pan did not move. ", "red") + String.Format("Test Results for Pan {0}, {1}, {2}", pos.rotation.x, pos2.rotation.x, pos3.rotation.x));
                }
                else
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Success: Pan Moved following test. ", "green") + String.Format("Test Results for Pan {0}, {1}, {2}", pos.rotation.x, pos2.rotation.x, pos3.rotation.x));
                }
            }
            if (flipFailFlag && errorCount == 0)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Warning, "AutoFlip Test with Post Control Check",
                    "Camera did not complete Autoflip properly for some trials, however all valid flips maintained post control."));
                _counter.incW();
            }
            else if (flipFailFlag && errorCount > 0)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "AutoFlip Test with Post Control Check",
                    String.Format("Camera failed to maintain PTZ control post autoflip for {0}/{1} trials.  Camera also failed to perform autoflips for one or more trials.", errorCount, trials)));
                _counter.incF();
            }
            else if (!flipFailFlag && errorCount == 0)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "AutoFlip Test with Post Control Check",
                    "Camera maintained PTZ control following autoflip for all trials."));
                _counter.incS();
            }
            else if (!flipFailFlag && errorCount > 0)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "AutoFlip Test with Post Control Check",
                     String.Format("Camera failed to maintain PTZ control post autoflip for {0}/{1} trials.", errorCount, trials)));
                _counter.incF();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("AutoFlip Test with Post Control Check Complete.", "purple"));
        }

        private AutoFlipResult DoAutoFlip()
        {
            return DoAutoFlip(true);
        }

        private AutoFlipResult DoAutoFlip(bool poststop)
        {
            return DoAutoFlip(poststop, false);
        }

        private AutoFlipResult DoAutoFlip(bool poststop, bool ignoreStopPoint)
        {
            TimeSpan elapsed = new TimeSpan(0);
            AutoFlipResult result;
            if (stopFlag)
            {
                result.error = true;
                result.elapsedms = 0;
                result.distance = 0;
                result.panstop = 0;
                result.flippedNegative = false;
                return result;
            }

            //Get Current Position
            Velocity pos = _controller.PositionClient.GetPosition();
            int panstart = pos.rotation.x;
            int pantarget = (panstart >= 18000 ? panstart - 18000 : panstart + 18000) ;
            int panstop = panstart;

            //Start Tilt Movement
            Thread.Sleep(500);
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Tilt Velocity Move.", "black"));
            VelocityMove(false, 0, true, -_cConfig.vel.max_y);

            DateTime setupstart = DateTime.Now;
            bool startfailure = false;
            while (rangeCompare(panstart, pos.rotation.x, 5))
            {
                pos = _controller.PositionClient.GetPosition();
                elapsed = DateTime.Now - setupstart;
                if (elapsed.TotalMilliseconds > 6000)
                {
                    startfailure = true;
                    break;
                }
            }
            if (startfailure)
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Error: Camera did not start tilting. ", "red"));
                _controller.ConsoleAppendLine(ConForm.AddColor("Warning. Autoflip tilt invert flag may be stuck.", "orange") + "  Attempting to Clear.");
                ResetAutoFlip();
                result.error = true;
                result.elapsedms = 0;
                result.distance = 0;
                result.panstop = 0;
                result.flippedNegative = false;
                return result;
            }
            DateTime start = DateTime.Now;

            //Allow Camera to Speed Up
            //Thread.Sleep(350);
            pos = _controller.PositionClient.GetPosition();
            _controller.ConsoleAppendLine(ConForm.AddColor("AutoFlip Detected.", "black"));
            _controller.ConsoleAppendLine(ConForm.AddColor(String.Format("Camera at Position: {0}, {1}.", pos.rotation.x, pos.rotation.y), "grey"));
            int flipdir = 0;
            while (!rangeCompare(pantarget, pos.rotation.x, _cConfig.global.PTAccuracy))
            {
                panstop = pos.rotation.x;
                pos = _controller.PositionClient.GetPosition();
                elapsed = DateTime.Now - start;
                if (flipdir == 0)
                {
                    if (panstop > pos.rotation.x) flipdir = -1;
                    else flipdir = 1;
                }
                if (elapsed.TotalMilliseconds > 10000)
                {
                    CameraDidNotReachTargetMessage(true, true, panValueCalculate(panstart + 18000), true, -9000, false, 0);
                    startfailure = true;
                    break;
                } 
                _controller.ConsoleAppendLine(ConForm.AddColor(String.Format("Camera at Position: {0}, {1}.", pos.rotation.x, pos.rotation.y), "grey"));
                Thread.Sleep(50);

            }
            DateTime stop = DateTime.Now;
            TimeSpan duration = stop - start;

            if (startfailure && !ignoreStopPoint)
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Error: Camera did not reach autoflip target in 10 seconds.", "red"));
                result.error = true;
                result.elapsedms = elapsed.TotalMilliseconds;
                result.distance = calculateDistance(panstart, pos.rotation.x, -1);
                result.panstop = pos.rotation.x;
                result.flippedNegative = (flipdir == -1 ? true : false);
                return result;
            }

            panstop = _controller.PositionClient.GetPosition().rotation.x;

            if(poststop) VelocityMove(true, 0, true, 0);
            Thread.Sleep(500);

            _controller.ConsoleAppendLine(ConForm.AddColor("AutoFlip Complete.  ", "Blue")
                + String.Format("Duration: {0} ms,  ", duration.TotalMilliseconds)
                //+ String.Format("Duration2: {0} ms,  ", elapsed.TotalMilliseconds) 
                + String.Format("Distance: {0} cdeg", calculateDistance(panstart, panstop, -1)));
            int distance = calculateDistance(panstart, panstop, flipdir);


            if (!rangeCompare(distance,  18000, _cConfig.global.PTAccuracy) && !ignoreStopPoint)
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Warning. Distance is not 18000.", "orange") + "  Restarting Test.");
                ResetMotion(true);
                int xstart = _cConfig.pos.min_x + _cConfig.pos.max_x / 4;
                PositionMove(true, true, xstart, false, 0, false, 100);
                return DoAutoFlip(poststop);
            }

            result.error = false;
            result.elapsedms = duration.TotalMilliseconds;
            result.distance = calculateDistance(panstart, panstop, -1);
            result.panstop = panstop;
            result.flippedNegative = (flipdir == -1 ? true : false);
            return result;
        }

        private void ResetAutoFlip()
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Resetting Autoflip flag...", "grey"));
            ResetMotion(true);
            PositionMove(true, true, 4500, true, -4500, true, 100);
            Thread.Sleep(1000);
            VelocityMove(true, _cConfig.vel.max_x, true, _cConfig.vel.max_y);
            Thread.Sleep(250);
            VelocityMove(true, -_cConfig.vel.max_x, true, -_cConfig.vel.max_y);
            ResetMotion(true);
        }

        struct AutoFlipResult
        {
            public double elapsedms;
            public int distance;
            public bool error;
            public int panstop;
            public bool flippedNegative;
        }

        
        
    }
}
