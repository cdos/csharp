using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace PTZCameraTester
{
    class CameraDetails
    {
        public static PTZCameraConfig loadConfig(string modelname, ServiceLib servlib)
        {
            PTZCameraConfig cConfig = new PTZCameraConfig();
            //XElement root = XElement.Parse(PTZCameraTester.Properties.Resources.D5220);
            //Console.WriteLine(root.Descendants());
            cConfig.model = modelname;

            if (File.Exists("XML\\" + modelname + ".xml"))
            {
                try
                {

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load("XML\\" + modelname + ".xml");

                    cConfig.canZoom = (xmlDoc.SelectSingleNode("Camera/Specs/CanZoom").InnerText == "true" ? true : false);
                    cConfig.name = xmlDoc.SelectSingleNode("Camera/Specs/Name").InnerText;

                    //////// POSITION LIMITS ////////
                    try
                    {
                        cConfig.pos.max_x = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Position/x/Max").InnerText);
                    }
                    catch
                    {
                        cConfig.pos.max_x = 36000;
                    }
                    try
                    {
                        cConfig.pos.min_x = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Position/x/Min").InnerText);
                    }
                    catch
                    {
                        cConfig.pos.min_x = 0;
                    }

                    try
                    {
                        cConfig.pos.max_y = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Position/y/Max").InnerText);
                    }
                    catch
                    {
                        cConfig.pos.max_y = servlib.PositionClient.GetPositionLimits().rotation.yMax; 
                    } 
                    try
                    {
                        cConfig.pos.min_y = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Position/y/Min").InnerText);
                    }
                    catch
                    {
                        cConfig.pos.min_y = servlib.PositionClient.GetPositionLimits().rotation.yMin; 
                    }


                    //////// VELOCITY LIMITS ////////
                    try
                    {
                        cConfig.vel.max_x = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Velocity/x/Max").InnerText);
                    }
                    catch
                    {
                        cConfig.vel.max_x = servlib.PositionClient.GetVelocityLimits().rotation.xMax; 
                    }
                    try
                    {
                        cConfig.vel.min_x = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Velocity/x/Min").InnerText);
                    }
                    catch
                    {
                        cConfig.vel.min_x = servlib.PositionClient.GetVelocityLimits().rotation.xMin; 
                    }

                    try
                    {
                        cConfig.vel.max_y = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Velocity/y/Max").InnerText);
                    }
                    catch
                    {
                        cConfig.vel.max_y = servlib.PositionClient.GetVelocityLimits().rotation.yMax; 
                    }
                    try
                    {
                        cConfig.vel.min_y = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Velocity/y/Min").InnerText);
                    }
                    catch
                    {
                        cConfig.vel.min_y = servlib.PositionClient.GetVelocityLimits().rotation.yMin; 
                    }

                    //////// VELOCITY TIMEOUT ////////
                    try
                    {
                        cConfig.vel.timeout = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/Velocity/Timeout").InnerText);
                    }
                    catch
                    {
                        cConfig.vel.timeout = 10000;
                    }

                    //////// ZOOM LIMITS ////////
                    try
                    {
                        cConfig.zoom.max = Convert.ToUInt32(xmlDoc.SelectSingleNode("Camera/Specs/Zoom/Max").InnerText);
                    }
                    catch
                    {
                        cConfig.zoom.max = servlib.LensClient.GetMaxMag();
                    }
                    try
                    {
                        cConfig.zoom.min = Convert.ToUInt32(xmlDoc.SelectSingleNode("Camera/Specs/Zoom/Min").InnerText);
                    }
                    catch
                    {
                        cConfig.zoom.min = 100;
                    }

                    //////// ACCELERATION CONTSTANTS (Not Currently Used) ////////
                    try
                    {
                        cConfig.accel.pan = Convert.ToUInt32(xmlDoc.SelectSingleNode("Camera/Specs/Acceleration/Pan").InnerText);
                    }
                    catch
                    {
                        cConfig.accel.pan = 800.75;
                    }
                    try
                    {
                        cConfig.accel.tilt = Convert.ToUInt32(xmlDoc.SelectSingleNode("Camera/Specs/Acceleration/Tilt").InnerText);
                    }
                    catch
                    {
                        cConfig.accel.tilt = 700.66;
                    }

                    //////// GLOBAL TEST CONSTANTS ////////
                    try
                    {
                        cConfig.global.PanTimeDelay = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/TestGlobals/PanTimeDelay").InnerText);
                    }
                    catch
                    {
                        cConfig.global.PanTimeDelay = 2500;
                    }
                    try
                    {
                        cConfig.global.PTAccuracy = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/TestGlobals/PanTiltAccuracy").InnerText);
                    }
                    catch
                    {
                        cConfig.global.PTAccuracy = 10;
                    }
                    try
                    {
                        cConfig.global.zoomAccuracy = Convert.ToInt32(xmlDoc.SelectSingleNode("Camera/Specs/TestGlobals/ZoomAccuracy").InnerText);
                    }
                    catch
                    {
                        cConfig.global.zoomAccuracy = 30;
                    }

                    cConfig.test = xmlDoc.SelectSingleNode("Camera/Tests");

                    try
                    {
                        cConfig.showDisabled = (xmlDoc.SelectSingleNode("Camera/Specs/TestGlobals/ShowDisabledTests").InnerText == "true" ? true : false);
                    }
                    catch
                    {
                        cConfig.showDisabled = false;
                    }

                    try
                    {
                        cConfig.preset.max_presets = servlib.PresetClient.GetMaxPresets();
                        cConfig.preset.enabled = true;
                    }
                    catch
                    {
                        cConfig.preset.max_presets = 0;
                        cConfig.preset.enabled = false;
                    }

                    cConfig.badConfig = false;
                    cConfig.validCamera = true;
                }
                catch
                {
                    cConfig.badConfig = true;
                }

            }
            else
            {
                cConfig.validCamera = false;
            }

            return cConfig;
        }
    }
    struct PTZCameraConfig
    {
        public bool canZoom;
        public bool validCamera;
        public bool badConfig;
        public bool showDisabled;
        public string name;
        public string model;
        public VelConfig vel;
        public PosConfig pos;
        public ZoomConfig zoom;
        public AccelConfig accel;
        public TestGlobalsConfig global;
        public XmlNode test;
        public PresetConfig preset;
    }
    struct VelConfig
    {
        public int max_x;
        public int max_y;
        public int min_x;
        public int min_y;
        public int timeout;
    }
    struct PosConfig
    {
        public int max_x;
        public int max_y;
        public int min_x;
        public int min_y;
    }
    struct ZoomConfig
    {
        public uint max;
        public uint min;
    }
    struct AccelConfig
    {
        public double pan;
        public double tilt;
    }
    struct TestGlobalsConfig
    {
        public int PanTimeDelay;
        public int PTAccuracy;
        public int zoomAccuracy;
    }
    struct PresetConfig
    {
        public int max_presets;
        public bool enabled;
    }
}
