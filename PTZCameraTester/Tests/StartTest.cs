using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    class StartTest : TestBase
    {
        public StartTest(TestController c) : base(c)
        {

        }

        public override void Run()
        {
            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Starting Init Test Group..."), "blue"));
            ClearLimits();
            //Perform Set Actions to reset AutoFlip and cached Actions.

            _controller.ConsoleAppendLine("Resetting Camera and Performing Random Movement to Clear AutoFlip Invert flag");
            ResetMotion(true); //This returns the camera to home position.  0, 0 position.   ResetMotoin is a confusing name for this method as it can be linked to motion detection.

            //Moves the camera right 2000 mdegree and down -1000 mdegree.
            VelocityMove(true, 2000, true, -1000); 
            
            //Waits 1 sec.
            Thread.Sleep(1000);

            //Moves camera left and up
            VelocityMove(true, -2000, true, 1000);
            
            //Wait
            Thread.Sleep(1000);
            
            //Moves the camera again.  Takes the MaxMag value and divide by 5.  Zooms in.
            PositionMove(true, true, 1000, true, -4100, true, _cConfig.zoom.max/5);
            
            //Moves again and zooms all the way out.
            PositionMove(true, true, 35000, true, -2500, true, 100);

            //Begins writing to console.
            _controller.ConsoleAppendLine("Testing Limits");
            
            //Function that uses Positioning Control - GetPositionLimits to get limits.
            SetLimits(9000, 18000, -4500, 0);

            //Wait
            Thread.Sleep(500);
            
            //Runs Positioning Control - GetPositionLimits.
            AxisLimits axis = _controller.PositionClient.GetPositionLimits();


            //Runs the test based on the limitations and returns a response which is then written to log and form.
            if (rangeCompare(axis.rotation.xMax, 18000, 5) && rangeCompare(axis.rotation.xMin, 9000, 5) && rangeCompare(axis.rotation.yMax, 0, 5) && rangeCompare(axis.rotation.yMin, -4500, 5))
            {
                _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Limits Set Successfully."), "green"));
            }
            else
            {
                //Outputs to form and log with the.  Writes the values that it is trying to set.
                _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Limits Failed to Take Effect. "), "red")+"<br />"
                    + ConForm.AddColor(String.Format("Pan Max -- Requested: {0}, Actual {1}", 18000, axis.rotation.xMax), "grey") + "<br />"
                    + ConForm.AddColor(String.Format("Pan Min -- Requested: {0}, Actual {1}", 18000, axis.rotation.xMin), "grey") + "<br />"
                    + ConForm.AddColor(String.Format("Tilt Max -- Requested: {0}, Actual {1}", 18000, axis.rotation.yMax), "grey") + "<br />"
                    + ConForm.AddColor(String.Format("Tilt Min -- Requested: {0}, Actual {1}", 18000, axis.rotation.yMin), "grey"));
            }

            //Clear the limits information.
            ClearLimits();
            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Init Test Group Complete."), "blue"));
        }
    }
}
