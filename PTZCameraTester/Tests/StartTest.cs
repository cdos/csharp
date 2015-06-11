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
            ResetMotion(true);

            VelocityMove(true, 2000, true, -1000); 
            Thread.Sleep(1000);
            VelocityMove(true, -2000, true, 1000);
            Thread.Sleep(1000);
            PositionMove(true, true, 1000, true, -4100, true, _cConfig.zoom.max/5);
            PositionMove(true, true, 35000, true, -2500, true, 100);

            _controller.ConsoleAppendLine("Testing Limits");
            SetLimits(9000, 18000, -4500, 0);
            Thread.Sleep(500);
            AxisLimits axis = _controller.PositionClient.GetPositionLimits();

            if (rangeCompare(axis.rotation.xMax, 18000, 5) && rangeCompare(axis.rotation.xMin, 9000, 5) && rangeCompare(axis.rotation.yMax, 0, 5) && rangeCompare(axis.rotation.yMin, -4500, 5))
            {
                _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Limits Set Successfully."), "green"));
            }
            else
            {
                _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Limits Failed to Take Effect. "), "red")+"<br />"
                    + ConForm.AddColor(String.Format("Pan Max -- Requested: {0}, Actual {1}", 18000, axis.rotation.xMax), "grey") + "<br />"
                    + ConForm.AddColor(String.Format("Pan Min -- Requested: {0}, Actual {1}", 18000, axis.rotation.xMin), "grey") + "<br />"
                    + ConForm.AddColor(String.Format("Tilt Max -- Requested: {0}, Actual {1}", 18000, axis.rotation.yMax), "grey") + "<br />"
                    + ConForm.AddColor(String.Format("Tilt Min -- Requested: {0}, Actual {1}", 18000, axis.rotation.yMin), "grey"));
            }

            ClearLimits();
            _controller.ConsoleAppendLine(ConForm.AddColor(ConForm.AddBold("Init Test Group Complete."), "blue"));
        }
    }
}
