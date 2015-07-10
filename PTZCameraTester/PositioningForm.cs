using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PTZCameraTester.Tests;
using PTZCameraTester.PositioningControl;

namespace PTZCameraTester
{
    public partial class PositioningForm : Form
    {
        public PositioningForm(string CameraIP)
        {
            InitializeComponent();
            this.CameraIpAddress.Text = CameraIP;
             
        }

        public string CameraAddress
        {
            get
            {
                return "http://" + this.CameraIpAddress.Text + ":" + this.CameraPort.Text;
            }

        }

        private void connect_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                Velocity position = svlib.PositionClient.GetPosition();
                xpositiontxtbox.Text = Convert.ToString(position.rotation.x);
                ypositiontxtbox.Text = Convert.ToString(position.rotation.y);
                
            }
            catch 
            {
                catchNoCommunicateWithCamera();
                return;
            }

            try
            {
                AxisLimits positionlimits = svlib.PositionClient.GetPositionLimits();

                xmintxtbox.Text = Convert.ToString(positionlimits.rotation.xMin);
                xmaxtxtbox.Text = Convert.ToString(positionlimits.rotation.xMax);
                ymintxtbox.Text = Convert.ToString(positionlimits.rotation.yMin);
                ymaxtxtbox.Text = Convert.ToString(positionlimits.rotation.yMax);
            }
            catch 
            {
                catchNoCommunicateWithCamera();
                return;
            }

            try
            {
                int azimuthzero = svlib.PositionClient.GetAzimuthZero();
                azimuthtxtbox.Text = Convert.ToString(azimuthzero);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();
                xvelocitytxtbox.Text = Convert.ToString(vel.rotation.x);
                yvelocitytxtbox.Text = Convert.ToString(vel.rotation.y);
                zvelocitytxtbox.Text = Convert.ToString(vel.translation.z);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

        }

        private static void catchNoCommunicateWithCamera()
        {
            MessageBox.Show("Error: Cannot Communicate with Camera.");
            return;
        }

        private void getpositionbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                Velocity position = svlib.PositionClient.GetPosition();
                xpositiontxtbox.Text = Convert.ToString(position.rotation.x);
                ypositiontxtbox.Text = Convert.ToString(position.rotation.y);

            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }


        }

        private void setpositionbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                Velocity position = svlib.PositionClient.GetPosition();
                position.rotation.x = Convert.ToInt16(xpositiontxtbox.Text);
                position.rotation.y = Convert.ToInt16(ypositiontxtbox.Text);

                svlib.PositionClient.SetPosition(position);
            }

            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                AxisLimits positionlimits = svlib.PositionClient.GetPositionLimits();

                xmintxtbox.Text = Convert.ToString(positionlimits.rotation.xMin);
                xmaxtxtbox.Text = Convert.ToString(positionlimits.rotation.xMax);
                ymintxtbox.Text = Convert.ToString(positionlimits.rotation.yMin);
                ymaxtxtbox.Text = Convert.ToString(positionlimits.rotation.yMax);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                AxisLimits positionlimits = svlib.PositionClient.GetPositionLimits();

                positionlimits.rotation.xMin = Convert.ToInt16(xmintxtbox.Text);
                positionlimits.rotation.xMax = Convert.ToInt16(xmaxtxtbox.Text);
                positionlimits.rotation.yMin = Convert.ToInt16(ymintxtbox.Text);
                positionlimits.rotation.yMax = Convert.ToInt16(ymaxtxtbox.Text);

                svlib.PositionClient.SetPositionLimits(positionlimits);
            }

            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void restorelimitsbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                svlib.PositionClient.RestoreDefaultPositionLimits();
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }
        //Refactor PTZ Controls

        private void LeftPTZButton_MouseDown(object sender, MouseEventArgs e)
        {
            //This is move left button.
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int velpanspeed = Convert.ToInt32(textboxpanspeed.Text);
            int veltiltspeed = Convert.ToInt32(textboxtiltspeed.Text);
            try
            {
             
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.x = velpanspeed;
                svlib.PositionClient.SetVelocity(vel);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void LeftPTZButton_MouseUp(object sender, MouseEventArgs e)
        {
            
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
               
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.x = 0;
                svlib.PositionClient.SetVelocity(vel);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void rightPTZButton_MouseDown(object sender, MouseEventArgs e)
        {
            //This button moves the camera right.
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int velpanspeed = Convert.ToInt32(textboxpanspeed.Text);
            int veltiltspeed = Convert.ToInt32(textboxtiltspeed.Text);
            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.x = -velpanspeed;
                svlib.PositionClient.SetVelocity(vel);

            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void rightPTZButton_MouseUp(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.x = 0;
                svlib.PositionClient.SetVelocity(vel);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void upPTZButton_MouseDown(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int velpanspeed = Convert.ToInt32(textboxpanspeed.Text);
            int veltiltspeed = Convert.ToInt32(textboxtiltspeed.Text);
            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.y = -veltiltspeed;
                svlib.PositionClient.SetVelocity(vel);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void upPTZButton_MouseUp(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();

                vel.rotation.y = 0;
                svlib.PositionClient.SetVelocity(vel);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void downPTZButton_MouseDown(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int velpanspeed = Convert.ToInt32(textboxpanspeed.Text);
            int veltiltspeed = Convert.ToInt32(textboxtiltspeed.Text);          
            

            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();

                //Gets the input from the textbox and converts to int.  

                //Replaces y with the value from the textbox.
                vel.rotation.y = veltiltspeed;
                svlib.PositionClient.SetVelocity(vel);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void downPTZButton_MouseUp(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.y = 0;
                svlib.PositionClient.SetVelocity(vel);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                int azimuthzero = svlib.PositionClient.GetAzimuthZero();
                azimuthtxtbox.Text = Convert.ToString(azimuthzero);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void setazimuthbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                int azimuthvalue = Convert.ToInt16(azimuthtxtbox.Text);    
                svlib.PositionClient.SetAzimuthZero(azimuthvalue);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();
                xvelocitytxtbox.Text = Convert.ToString(vel.rotation.x);
                yvelocitytxtbox.Text = Convert.ToString(vel.rotation.y);
                zvelocitytxtbox.Text = Convert.ToString(vel.translation.z);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                Velocity position = svlib.PositionClient.GetPosition();
                position.rotation.x = 0;
                position.rotation.y = 0;

                svlib.PositionClient.SetPosition(position);
            }

            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void setvelocitybutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.x = Convert.ToInt16(xvelocitytxtbox.Text);
                vel.rotation.y = Convert.ToInt16(yvelocitytxtbox.Text);
                vel.translation.z = Convert.ToInt16(zvelocitytxtbox.Text);

                svlib.PositionClient.SetVelocity(vel);
            }

            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                Velocity vel = svlib.PositionClient.GetVelocity();
                vel.rotation.x = 0;
                vel.rotation.y = 0;
                vel.translation.z = 0;

                svlib.PositionClient.SetVelocity(vel);
            }

            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void getvellimitbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                
                VelocityLimits velocitylimits = svlib.PositionClient.GetVelocityLimits();
                xminvellimittxtbox.Text = Convert.ToString(velocitylimits.rotation.xMin);
                xmaxvellimittxtbox.Text = Convert.ToString(velocitylimits.rotation.xMax);
                yminvellimittxtbox.Text = Convert.ToString(velocitylimits.rotation.yMin);
                ymaxvellimittxtbox.Text = Convert.ToString(velocitylimits.rotation.yMax);
                zminvellimittxtbox.Text = Convert.ToString(velocitylimits.rotation.zMin);
                zmaxvellimittxtbox.Text = Convert.ToString(velocitylimits.rotation.zMax);

                zmintranstxtbox.Text = Convert.ToString(velocitylimits.translation.zMin);
                zmaxtranstxtbutton.Text = Convert.ToString(velocitylimits.translation.zMax); 
                
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

        }

        private void setvellimitbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                VelocityLimits velocitylimits = svlib.PositionClient.GetVelocityLimits();
                
                velocitylimits.rotation.xMin = Convert.ToInt16(xminvellimittxtbox.Text);
                velocitylimits.rotation.xMin = Convert.ToInt16(xmaxvellimittxtbox.Text);
                velocitylimits.rotation.yMin = Convert.ToInt16(yminvellimittxtbox.Text);
                velocitylimits.rotation.yMin = Convert.ToInt16(ymaxvellimittxtbox.Text);
                velocitylimits.rotation.zMin = Convert.ToInt16(zminvellimittxtbox.Text);
                velocitylimits.rotation.zMin = Convert.ToInt16(zmaxvellimittxtbox.Text);
                velocitylimits.translation.zMin = Convert.ToUInt16(zmintranstxtbox.Text);
                velocitylimits.translation.zMax = Convert.ToInt16(zmaxtranstxtbutton.Text);

                svlib.PositionClient.SetVelocityLimits(velocitylimits);
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void viewobjectbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);          

            try
            {
                Velocity position = svlib.PositionClient.GetPosition();
                position.translation.z = Convert.ToInt16(zviewobjecttxtbox.Text);
                position.rotation.x = Convert.ToInt16(xviewobjecttxtbox.Text);
                position.rotation.y = Convert.ToInt16(yviewobjecttxtbox.Text);

                svlib.PositionClient.ViewObject(position, 30);
            }

            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void LeftPTZButton_Click(object sender, EventArgs e)
        {

        }

    }
}
