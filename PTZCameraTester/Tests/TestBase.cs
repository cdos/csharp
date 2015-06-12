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

namespace PTZCameraTester
{
    class TestBase
    {
        protected TestStates _state;
        protected TestController _controller;
        protected PTZCameraConfig _cConfig;
        protected String _testResults;
        public ResultCounter _counter;
        public bool stopFlag;

        public TestBase(TestController c)
        {
            _controller = c;
            _cConfig = c.CameraConfig;
            _state = TestStates.Waiting;
            _testResults = "";
            _counter = new ResultCounter();
            stopFlag = false;
        }

        public String GetTestResults(){
            return _testResults;
        }

        protected void AddTestResult(String result)
        {
            _testResults = _testResults + result;
        }

        protected enum TestStates 
        {
            Waiting,
            Running,
            Complete
        }

        // To be replaced by child class
        public virtual void Run() { }

        // To be replaced by child class
        public virtual void Abort()
        {
            stopFlag = true;
        }

        //Utilities
        public static int calculateDistance(int start, int stop, int direction)
        {
            int result = 0;
            if (direction >= 0)
                if (start > stop)
                    result = (36000 - start) + stop;
                else
                    result = stop - start;
            else
                if (start < stop)
                    result = (36000 - stop) + start;
                else
                    result = start - stop;
            return result;
        }

        //Comparison of range values.  Range gives it wiggle room.  Returns 2 booleans.
        public static bool rangeCompare(double arg1, double arg2, double range)
        {
            bool test1 = (arg1 <= (arg2 + range));
            bool test2 = (arg1 >= (arg2 - range));
            return test1 && test2;
        }

        protected bool panRangeCompare(int arg1, int arg2, double range)
        {
            arg1 = panValueCalculate(arg1);
            arg2 = panValueCalculate(arg2);
            if(rangeCompare(arg1, arg2, range)){
                return true;
            }

            int high, low;
            if (arg1 > arg2)
            {
                high = arg1;
                low = arg2;
            }
            else
            {
                high = arg2;
                low = arg1;
            }

            return rangeCompare(low, high - 36000, range);
        }

        protected int panValueCalculate(int val)
        {
            if (val < 0) return (val + 36000);
            else if (val > 36000) return (val - 36000);
            else return val;
        }

        public void VelocityMove(bool pan, int panv, bool tilt, int tiltv)
        {
            if (!pan && !tilt) return;
            if (stopFlag) return;
            Velocity pos = _controller.PositionClient.GetVelocity();
            pos.rotation.x = panv;
            if (!pan) pos.rotation.xSpecified = false;
            pos.rotation.y = tiltv;
            if (!tilt) pos.rotation.ySpecified = false;
            _controller.PositionClient.SetVelocity(pos);

        }

        public void PositionMove(bool blocking, bool pan, int panv, bool tilt, int tiltv, bool zoom, uint mag)
        {
            Velocity pos;
            if (stopFlag) return;
            if (pan || tilt)
            {
                pos = _controller.PositionClient.GetPosition();
                pos.rotation.x = panv;
                if (!pan) pos.rotation.xSpecified = false;
                pos.rotation.y = tiltv;
                if (!tilt) pos.rotation.ySpecified = false;
                _controller.PositionClient.SetPosition(pos);
            }
            if (zoom && _cConfig.canZoom)
            {
                _controller.LensClient.SetMag(mag);
            }
            if (!blocking) return;
            TimeSpan elapsed = TimeSpan.FromMilliseconds(0);
            DateTime start = DateTime.Now;
            int maxWait = (zoom ? 10000 : 6000);
            bool PanTiltArrived = false;
            bool ZoomArrived = false;
            while (true)
            {               
                if ((pan || tilt) && !PanTiltArrived)
                {
                    pos = _controller.PositionClient.GetPosition();
                    if ((!pan || rangeCompare(pos.rotation.x, panv, _cConfig.global.PTAccuracy)) && (!pan || rangeCompare(pos.rotation.y, tiltv, _cConfig.global.PTAccuracy)))
                    {
                        PanTiltArrived = true;
                    }

                }
                else
                {
                    PanTiltArrived = true;
                }

                if (zoom && !ZoomArrived)
                {
                    uint currentmag = _controller.LensClient.GetMag();
                    //_controller.ConsoleAppendLine(ConForm.AddColor(String.Format("Sending Camera to mag = {0}, Current Mag = {1}", mag, currentmag), "grey"));
                    if (rangeCompare(currentmag, mag, _cConfig.global.zoomAccuracy))
                        ZoomArrived = true;
                }
                else
                {
                    ZoomArrived = true;
                }

                if (PanTiltArrived && ZoomArrived) 
                    break;

                elapsed = DateTime.Now - start;
                if (elapsed.TotalMilliseconds > maxWait)
                {
                    CameraDidNotReachTargetMessage(false, pan, panv, tilt, tiltv, zoom, mag);

                    break;
                }
            }
        }

        public void ResetMotion(bool blocking, bool pan, bool tilt, bool zoom)
        {
            PositionMove(blocking, pan, 0, tilt, 0, zoom, 100);
        }

        public void ResetMotion(bool blocking)
        {
            PositionMove(blocking, true, 0, true, 0, true, 100);
        }

        public void GoToMag(bool blocking, uint mag)
        {
            PositionMove(blocking, false, 0, false, 0, true, mag);
        }

        public void CameraDidNotReachTargetMessage(bool warnOrError, bool pan, int panv, bool tilt, int tiltv, bool zoom, uint mag)
        {
            Velocity pos = _controller.PositionClient.GetPosition();
            String output = "";
            if (pan)
                output = output + "<br />" + ConForm.TabSpace + String.Format("PAN Target: {0}, Actual: {1}", panv, pos.rotation.x);
            if (tilt)
                output = output + "<br />" + ConForm.TabSpace + String.Format("TILT Target: {0}, Actual: {1}", tiltv, pos.rotation.y);
            if (zoom)
                output = output + "<br />" + ConForm.TabSpace + String.Format("ZOOM Target: {0}, Actual: {1}", mag, _controller.LensClient.GetMag());

            _controller.ConsoleAppendLine(ConForm.AddColor((warnOrError ? "Warning" : "Error") + ": Camera did not reach target position. ", (warnOrError ? "orange" : "red")) + output);
           
        }

        //Pelco API - Positioning Control - GetPositionLimits
        public void SetLimits(int xl, int xh, int yl, int yh)
        {
            if (stopFlag) return; 
            AxisLimits lims = _controller.PositionClient.GetPositionLimits();
            lims.rotation.xMax = xh;
            lims.rotation.xMaxSpecified = true;
            lims.rotation.xMin = xl;
            lims.rotation.xMinSpecified = true;
            lims.rotation.yMaxSpecified = true;
            lims.rotation.yMinSpecified = true;
            lims.rotation.yMax = yh;
            lims.rotation.yMin = yl;
            _controller.PositionClient.SetPositionLimits(lims);
        }

        public void ClearLimits()
        {
            if (stopFlag) return; 
            _controller.PositionClient.RestoreDefaultPositionLimits();
        }
    }

    class ResultCounter
    {
        public int success;
        public int warning;
        public int failure;
        public int disabled;
        public ResultCounter()
        {
            success = 0;
            warning = 0;
            failure = 0;
            disabled = 0;
        }
        public void Combine(ResultCounter c)
        {
            success = success + c.success;
            warning = warning + c.warning;
            failure = failure + c.failure;
            disabled = disabled + c.disabled;
        }
        public void incS() { success++; }
        public void incW() { warning++; }
        public void incF() { failure++; }
        public void incD() { disabled++; }
    }
}
