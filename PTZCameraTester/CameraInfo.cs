using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Net.Sockets;
using System.Net;
using PTZCameraTester.PositioningControl;
using PTZCameraTester.Tests;
using PTZCameraTester.CameraConfiguration;
using PTZCameraTester.AlarmArrayConfiguration;
using PTZCameraTester.ImagingConfiguration;
using PTZCameraTester.LensControl;
using PTZCameraTester.PelcoConfiguration;
using PTZCameraTester.PresetControl;


namespace PTZCameraTester
{
    public partial class CameraInfo : Form
    {
        public CameraInfo(string CameraIp)
        {
            InitializeComponent();
            this.CameraIpAddress.Text = CameraIp;
        }

        public string CameraAddress
        {
            get
            {
                return "http://" + this.CameraIpAddress.Text + ":" + this.CameraPort.Text;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string modelname;
            string modelnumber;
            string getlocation;
            string isregistered;

            //Service to run the PelcoConfiguration Client
            ServiceLib svlib = new ServiceLib(CameraAddress);
            
            //Single item response from pelco configuration method;
            try {
                string modelname1 = svlib.PelcoClient.GetModelName();
                modelname = modelname1;
                ModelNametxtbox.Text = modelname;
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

            try {
                string modelnumber1 = svlib.PelcoClient.GetModelNumber();
                modelnumber = modelnumber1;
                ModelNumbertxtbox.Text = modelnumber;
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

            try {
                string getlocation1 = svlib.PelcoClient.GetLocation();
                getlocation = getlocation1;
                getlocationtxtbox.Text = getlocation;
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

            try {
                string isregistered1 = Convert.ToString(svlib.PelcoClient.IsRegistered());
                isregistered = isregistered1;
                isRegisteredtxtbox.Text = isregistered;
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }          
                     
            //Structure that defines PelcoConfig items.
            try
            {
                PelcoConfig pelcoconfig = svlib.PelcoClient.GetConfiguration();
                string renewInterval = Convert.ToString(pelcoconfig.renewInterval);
                string startupInterval = Convert.ToString(pelcoconfig.startupInterval);
                string ntpAddress = Convert.ToString(pelcoconfig.ntpAddress);
                string shutdownWatchdogTimeout = Convert.ToString(pelcoconfig.shutdownWatchdogTimeout);
                string allowSystemUpdate = Convert.ToString(pelcoconfig.allowSystemUpdate);
                string isSynced = Convert.ToString(pelcoconfig.isSynced);

                getconfigtxtbox.Text = string.Format(
                    "<renewInterval>" + renewInterval + "</renewInterval>\n" +
                    "<startupInterval>" + startupInterval + "</startupInterval>\n" +
                    "<ntpAddress>" + ntpAddress + "</ntpAddress>\n" +
                    "<shutdownWatchdogTimeout>" + shutdownWatchdogTimeout + "<shutdownWatchdogTimeout>\n" +
                    "<allowSystemUpdate>" + allowSystemUpdate + "<allowSystemUpdate>\n" +
                    "<isSynced>" + isSynced + "<isSynced>");
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
            
        }

         //Velocity vel = svlib.PositionClient.GetVelocity();
         //       vel.rotation.y = 0;
         //       svlib.PositionClient.SetVelocity(vel);


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CameraIpAddress_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Sends a ResetConfguration
            ServiceLib svlib = new ServiceLib(CameraAddress);            
            svlib.PelcoClient.ResetConfiguration();

            //Would like to read http status and output into the rich text box.
        }

        private void resetsecuritybutton_Click(object sender, EventArgs e)
        {
            //Sends reset security
            try
            {
                ServiceLib svlib = new ServiceLib(CameraAddress);
                string modelname = svlib.PelcoClient.GetModelName();
                svlib.PelcoClient.ResetSecurity(modelname);
                getconfigtxtbox.Text = "Sending Reset Security";
            }
            catch 
            {
                catchNoCommunicateWithCamera();
                return;
            }

            //Would like to read http status and output into the rich text box.

        }

        private void resetsyncedbutton_Click(object sender, EventArgs e)
        {
            //Sends reset synced
            try
            {
                ServiceLib svlib = new ServiceLib(CameraAddress);
                string modelname = svlib.PelcoClient.GetModelNumber();
                svlib.PelcoClient.ResetSynced(modelname);
                getconfigtxtbox.Text = "Sending Reset Synced";
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
            //Would like to read http status and output into the rich text box.
        }

        private void getconfigurationbutton_Click(object sender, EventArgs e)
        {
            //GetConfiguration
            //Structure that defines PelcoConfig items.
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                PelcoConfig pelcoconfig = svlib.PelcoClient.GetConfiguration();
                string renewInterval = Convert.ToString(pelcoconfig.renewInterval);
                string startupInterval = Convert.ToString(pelcoconfig.startupInterval);
                string ntpAddress = Convert.ToString(pelcoconfig.ntpAddress);
                string shutdownWatchdogTimeout = Convert.ToString(pelcoconfig.shutdownWatchdogTimeout);
                string allowSystemUpdate = Convert.ToString(pelcoconfig.allowSystemUpdate);
                string isSynced = Convert.ToString(pelcoconfig.isSynced);

                getconfigtxtbox.Text = string.Format(
                        "<renewInterval>" + renewInterval + "</renewInterval>\n" +
                        "<startupInterval>" + startupInterval + "</startupInterval>\n" +
                        "<ntpAddress>" + ntpAddress + "</ntpAddress>\n" +
                        "<shutdownWatchdogTimeout>" + shutdownWatchdogTimeout + "<shutdownWatchdogTimeout>\n" +
                        "<allowSystemUpdate>" + allowSystemUpdate + "<allowSystemUpdate>\n" +
                        "<isSynced>" + isSynced + "<isSynced>");
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

        private void restartbutton_Click(object sender, EventArgs e)
        {
            //Sends Restart command.
            try
            {
                ServiceLib svlib = new ServiceLib(CameraAddress);
                string modelname = svlib.PelcoClient.GetModelNumber();
                svlib.PelcoClient.Restart(modelname);
                getconfigtxtbox.Text = "Sending Restart";                
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }            
        }
    }
}
