﻿using System;
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
using PTZCameraTester.Tests;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net.Sockets;
using System.Net;

namespace PTZCameraTester.Tests
{
    class PresetTest : TestBase
    {
        private List<PresetContainer> presets;

        public PresetTest(TestController c)
            : base(c)
        {
            _testResults = ConForm.ParseGroupIntoTemplate("Preset Test Group");
            presets = new List<PresetContainer>();
        }

        public override void Run()
        {
            XmlNode node;      
            try
            {
                node = _cConfig.test.SelectSingleNode("Preset");
            }
            catch
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Preset Test Group Disabled.", "grey"));
                return;
            }

            if (!_cConfig.preset.enabled)
            {
                _controller.ConsoleAppendLine(ConForm.AddColor("Camera does not support presets.  Disabling Preset Tests.", "grey"));
                return;
            }

            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Starting Preset Test Group..."), "blue"));
            ClearLimits();

            // Random Seek
            try
            {
                node = _cConfig.test.SelectSingleNode("Preset/SetAndCheck");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        SetAndCheck(Convert.ToInt32(atts.GetNamedItem("Trials").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Preset Set and Check Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Preset Set and Check Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Preset Set and Check Test Disabled.", "grey"));
            }


            // With Limits
            try
            {
                node = _cConfig.test.SelectSingleNode("Preset/WithLimits");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        PresetWithLimits();
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Preset With Limits Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Preset With Limits Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Preset With Limits Test Disabled.", "grey"));
            }

            // Max Presets
            try
            {
                node = _cConfig.test.SelectSingleNode("Preset/MaxPresets");
                if (String.Equals(node.InnerText, "enabled", StringComparison.CurrentCultureIgnoreCase))
                {
                    try
                    {
                        XmlAttributeCollection atts = node.Attributes;
                        MaxPresets(Convert.ToInt32(atts.GetNamedItem("RealPresets").Value));
                    }
                    catch
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Max Presets Test",
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
                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Disabled, "Max Presets Test", ""));
                    _counter.incD();
                }
                _controller.ConsoleAppendLine(ConForm.AddColor("Max Presets Test Disabled.", "grey"));
            }
           
            ClearLimits();
            ClearPresets();
            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Preset Test Group Complete."), "blue"));
        }


        private void SetAndCheck(int trials)
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Preset Set and Check Test.", "purple"));
            bool failed = false, warning = false;
            int i, x, y;
            uint z;
            Random _r = new Random();
            Velocity pos;

            presets = new List<PresetContainer>();
            String prefix = "PTZTEST_";
            

            for (i = 0; i < trials; i++)
            {
                if (stopFlag) break;
                x = _r.Next(_cConfig.pos.min_x, _cConfig.pos.max_x);
                y = _r.Next(_cConfig.pos.min_y, _cConfig.pos.max_y);
                z = (uint)_r.Next((int)_cConfig.zoom.min, (int)_cConfig.zoom.max);

                

                String name = prefix + i.ToString();
                _controller.ConsoleAppendLine(String.Format("Sending Camera to ({0}, {1})", x, y));

                PositionMove(true, true, x, true, y, true, z);

                Thread.Sleep(500);
                pos = _controller.PositionClient.GetPosition();

                if (rangeCompare(pos.rotation.x, x, _cConfig.global.PTAccuracy) && rangeCompare(pos.rotation.y, y, _cConfig.global.PTAccuracy) && rangeCompare(_controller.LensClient.GetMag(), z, _cConfig.global.zoomAccuracy))
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Arrived at Position.", "green"));
                    _controller.ConsoleAppendLine(String.Format("Creating Preset...", x, y));
                    string id;
                    try
                    {
                        id = _controller.PresetClient.SetPreset(new SetPreset { name = name, autoFocus = false });
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(50);
                        try
                        {
                            id = _controller.PresetClient.SetPreset(new SetPreset { name = name, autoFocus = false });
                        }
                        catch (Exception ex2)
                        {
                            Console.WriteLine(ex2.Message);
                            return;
                        }
                    }
                    Preset preset = _controller.PresetClient.GetPresets(new string[] { id })[0];
                    _controller.ConsoleAppendLine("Preset Created.  Now Testing...");
                    ResetMotion(true);
                    _controller.PresetClient.GotoPreset(new GotoPreset { id = id });
                    Thread.Sleep(6000);
                    pos = _controller.PositionClient.GetPosition();
                    if (rangeCompare(pos.rotation.x, x, _cConfig.global.PTAccuracy) && rangeCompare(pos.rotation.y, y, _cConfig.global.PTAccuracy) && rangeCompare(_controller.LensClient.GetMag(), z, _cConfig.global.zoomAccuracy))
                    {
                        _controller.ConsoleAppendLine(ConForm.AddColor("Preset Arrived Successfully.", "green"));
                    }
                    else
                    {
                        _controller.ConsoleAppendLine(ConForm.AddColor("Preset Did not Arrive at location.", "red"));
                        failed = true;
                    }
                    
                    presets.Add(new PresetContainer {x = x, y = y, z = z, preset = preset} );
                    
                }
                else
                {
                    warning = true;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not reach requested position.  ", "orange") + String.Format("Actual Position: ({0}, {1})", pos.rotation.x, pos.rotation.y));
                }
                Thread.Sleep(500);
                if (stopFlag)
                    return;
            }
            if (failed)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Preset Set and Check",
                    String.Format("Test Failed. Camera did not reach set positions for one or more trials.  See log for details.")));
                _counter.incF();
            }
            else if (warning)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Warning, "Preset Set and Check",
                    String.Format("Test Warning. Camera did not initailly reach position required for preset, however all other presets were acquired succesfully.  See log for details.")));
                _counter.incW();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Preset Set and Check",
                    String.Format("Test Completed Successfully. Camera reached all requested positions.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Preset Set and Check Test Complete.", "purple"));
        }


        private void PresetWithLimits()
        {
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Preset With Limits Test.", "purple"));
            bool panFail = false, tiltFail = false, zoomFail = false;
            int xlimh = _cConfig.pos.max_x - _cConfig.pos.max_x * 2 / 11;
            int xliml = _cConfig.pos.min_x + _cConfig.pos.max_x * 2 / 11;
            int ylimh = _cConfig.pos.max_y - _cConfig.pos.max_y * 2 / 11;
            int yliml = _cConfig.pos.min_y + _cConfig.pos.max_y * 2 / 11;
            //_controller.ConsoleAppendLine(String.Format("Restricting Pan to {0}cdeg <-> {1}cdeg", xliml, xlimh));
            SetLimits(xliml, xlimh, yliml, ylimh);

            if (presets.Count == 0)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Preset With Limits Test",
                    String.Format("Test Failed.  Preset Set and Check test must be run before this test.  See log for details.")));
                _counter.incF();
                return;
            }
            
            foreach (PresetContainer preset in presets)
            {

                panFail = false;
                tiltFail = false;
                zoomFail = false;

                _controller.ConsoleAppendLine(String.Format("Sending Camera to ({0}, {1})", preset.x, preset.y));

                _controller.PresetClient.GotoPreset(new GotoPreset { id = preset.preset.id });

                Thread.Sleep(2500);
                Velocity pos = _controller.PositionClient.GetPosition();

                //Pan Check
                if (panRangeCompare(pos.rotation.x, preset.x, _cConfig.global.PTAccuracy) && preset.x >= xliml && preset.x <= xlimh)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Arrived at Pan Position Outside of Limits.", "green"));
                }
                else
                {
                    if (preset.x < xliml || preset.x > xlimh)
                    {
                        if (panRangeCompare(pos.rotation.x, xliml, _cConfig.global.PTAccuracy) || panRangeCompare(pos.rotation.x, xlimh, _cConfig.global.PTAccuracy))
                        {
                            _controller.ConsoleAppendLine(ConForm.AddColor("Camera correctly moved into Pan limits.  ", "green"));
                        }
                        else
                        {
                            panFail = true;
                            _controller.ConsoleAppendLine(ConForm.AddColor("Camera Moved inside of Pan limits. ", "red") + String.Format("Actual Position: ({0}, {1})", pos.rotation.x, pos.rotation.y));
                        }
                    }
                    else
                    {
                        panFail = true;
                        _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not reach requested pan position. ", "red") + String.Format("Actual Position: ({0}, {1})", pos.rotation.x, pos.rotation.y));
                    }
                }

                //Tilt Check
                if (panRangeCompare(pos.rotation.y, preset.y, _cConfig.global.PTAccuracy) && preset.y >= yliml && preset.y <= ylimh)
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Arrived at Tilt Position Outside of Limits.", "green"));
                }
                else
                {
                    if (preset.y < yliml || preset.y > ylimh)
                    {
                        if (panRangeCompare(pos.rotation.y, yliml, _cConfig.global.PTAccuracy) || panRangeCompare(pos.rotation.y, ylimh, _cConfig.global.PTAccuracy))
                        {
                            _controller.ConsoleAppendLine(ConForm.AddColor("Camera correctly moved into Tilt limits.  ", "green"));
                        }
                        else
                        {
                            tiltFail = true;
                            _controller.ConsoleAppendLine(ConForm.AddColor("Camera Moved inside of Tilt limits. ", "red") + String.Format("Actual Position: ({0}, {1})", pos.rotation.x, pos.rotation.y));
                        }
                    }
                    else
                    {
                        tiltFail = true;
                        _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not reach requested Tilt position. ", "red") + String.Format("Actual Position: ({0}, {1})", pos.rotation.x, pos.rotation.y));
                    }
                }

                //Tilt Check
                if (rangeCompare(_controller.LensClient.GetMag(), preset.z, _cConfig.global.zoomAccuracy))
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera Arrived at Zoom Position.", "green"));
                }
                else
                {
                    zoomFail = true;
                    _controller.ConsoleAppendLine(ConForm.AddColor("Camera did not reach requested Zoom position. ", "red") + String.Format("Actual Position: ({0})", _controller.LensClient.GetMag()));
                }
                Thread.Sleep(500);
                if (stopFlag)
                    return;
            }
            if (panFail || tiltFail || zoomFail)
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Preset With Limits Test",
                    String.Format("Test Failed. Camera did not reach set positions for one or more trials.  See log for details.")));
                _counter.incF();
            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Preset With Limits Test",
                    String.Format("Test Completed Successfully. Camera reached all requested presets within limits.")));
                _counter.incS();
            }
            _controller.ConsoleAppendLine(ConForm.AddColor("Preset With Limits Test Complete.", "purple"));
        }


        private void MaxPresets(int mode)
        {
            int remaining = _cConfig.preset.max_presets - presets.Count;
            _controller.ConsoleAppendLine(ConForm.AddColor("Starting Max Presets Test.", "purple"));
            int failed = 0;
            int i, x, y;
            uint z;
            Random _r = new Random();
            Velocity pos;

            String prefix = "PTZTEST_";


            pos = _controller.PositionClient.GetPosition();

            x = pos.rotation.x;
            y = pos.rotation.y;
            z = _controller.LensClient.GetMag();
            i = presets.Count;
            while (i < _cConfig.preset.max_presets)
            {
                if (stopFlag) break;
                bool loopfail = false;
                String name = prefix + i.ToString();

                _controller.ConsoleAppendLine(String.Format("Creating Preset #{0}...", i));
                string id = "";
                string message = "";
                try
                {
                    id = _controller.PresetClient.SetPreset(new SetPreset { name = name, autoFocus = false });
                }
                catch (Exception ex1)
                {
                    System.Threading.Thread.Sleep(50);
                    try
                    {
                        id = _controller.PresetClient.SetPreset(new SetPreset { name = name, autoFocus = false });
                    }
                    catch (Exception ex2)
                    {
                        message = "[Ex1] " + ex1.Message + "[Ex2] " + ex2.Message;
                        failed ++;
                        loopfail = true;
                        if (ex1.Message == "maximum exceeded")
                        {
                            break;
                        }
                    }
                }
                if (!loopfail)
                {
                    Preset preset = _controller.PresetClient.GetPresets(new string[] { id })[0];
                    presets.Add(new PresetContainer { x = x, y = y, z = z, preset = preset });
                    _controller.ConsoleAppendLine("Preset Created. ");
                    i++;
                }
                else
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Failed to Create Preset. Error Message: ", "red") + message);
                }

                if (stopFlag)
                    return;
            }

            if (!stopFlag)
            {
                //Next Preset should fail.
                bool loopfail = false;
                String name = prefix + (_cConfig.preset.max_presets + 1).ToString();

                _controller.ConsoleAppendLine(String.Format("Creating Preset Extra Preset...", x, y));
                string id = "";
                string message = "";
                try
                {
                    id = _controller.PresetClient.SetPreset(new SetPreset { name = name, autoFocus = false });
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    loopfail = true;
                }
                if (loopfail)
                {
                    _controller.ConsoleAppendLine("Preset Failed to be added. Exception Message: "+message);

                    if (failed == 0)
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Success, "Max Presets",
                            String.Format("Test Completed Successfully. Created Max presets on Camera reached and did not exceed max.")));
                        _counter.incS();
                    }
                    else
                    {
                        AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Warning, "Max Presets",
                                   String.Format("Test Completed Successfully. However, Camera Failed to create " + failed.ToString() + " valid preset(s).  See log for details.")));
                        _counter.incF();
                    }

                }
                else
                {
                    _controller.ConsoleAppendLine(ConForm.AddColor("Preset did not fail.", "red"));

                    AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Max Presets",
                        "Test Failed. Camera created to many presets.  See log for details."));
                    _counter.incF();

                }

            }
            else
            {
                AddTestResult(ConForm.ParseResultIntoTemplate(ConForm.ResultTypes.Failure, "Max Presets",
                           String.Format("Test Aborted.")));
                _counter.incF();
            }

            _controller.ConsoleAppendLine(ConForm.AddColor("Max Presets Test Complete.", "purple"));

        }

        private void ClearPresets()
        {
            String[] ids = new String[presets.Count];
            int i = 0;

            foreach (PresetContainer preset in presets)
            {
                ids[i++] = preset.preset.id;
            }

            _controller.PresetClient.RemovePresets(ids);
        }

        private void PresetWithSpeed()
        {
            
        }
    }

    struct PresetContainer
    {
        public Preset preset;
        public int x;
        public int y;
        public uint z;
    }
}
