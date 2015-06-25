using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PTZCameraTester.Tests;
using PTZCameraTester.CameraConfiguration;
using PTZCameraTester.AlarmArrayConfiguration;

namespace PTZCameraTester
{
    public partial class AlarmArrayForm : Form
    {
        public AlarmArrayForm(string CameraIP)
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
            int alarmid;
            try
            {
                string getarraysize = Convert.ToString(svlib.AlarmClient.GetArraySize());
                getarraysizetxtbox.Text = getarraysize;

            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

            try
            {
                alarmid = Convert.ToInt16(alarmidtxtbox.Text);

                AlarmConfig alarmconfig = svlib.AlarmClient.GetConfiguration(alarmid);
                string severity = Convert.ToString(alarmconfig.severity);
                string polarity = Convert.ToString(alarmconfig.polarity);
                string enabled = Convert.ToString(alarmconfig.enabled);
                string supervised = Convert.ToString(alarmconfig.supervised);
                string dwelltime = Convert.ToString(alarmconfig.dwellTime);
                string physicalInput = Convert.ToString(alarmconfig.physicalInput);
                
                getconfigtxtbox.Text = string.Format(
                    "<severity>" + severity + "</severity>)\n" +
                    "<polarity>" + polarity + "</polarity>\n" +
                    "<enabled>" + enabled + "</enabled>\n" +
                    "<supervised>" + supervised + "</supervised>\n" +
                    "<dwellTime>" + dwelltime + "</dwellTime>\n" +
                    "<physicalInput>" + physicalInput + "</physicalInput>"
                    );
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

        private void getconfigurationbutton_Click(object sender, EventArgs e)
        {

            ServiceLib svlib = new ServiceLib(CameraAddress);
            int alarmid;
            try
            {
                alarmid = Convert.ToInt16(alarmidtxtbox.Text);

                AlarmConfig alarmconfig = svlib.AlarmClient.GetConfiguration(alarmid);
                string severity = Convert.ToString(alarmconfig.severity);
                string polarity = Convert.ToString(alarmconfig.polarity);
                string enabled = Convert.ToString(alarmconfig.enabled);
                string supervised = Convert.ToString(alarmconfig.supervised);
                string dwelltime = Convert.ToString(alarmconfig.dwellTime);
                string physicalInput = Convert.ToString(alarmconfig.physicalInput);

                getconfigtxtbox.Text = string.Format(
                    "<severity>" + severity + "</severity>\n" +
                    "<polarity>" + polarity + "</polarity>\n" +
                    "<enabled>" + enabled + "</enabled>\n" +
                    "<supervised>" + supervised + "</supervised>\n" +
                    "<dwellTime>" + dwelltime + "</dwellTime>\n" +
                    "<physicalInput>" + physicalInput + "</physicalInput>"
                    );
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void resetalarmconfigurationbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int alarmid;
            try
            {
                alarmid = Convert.ToInt16(alarmidtxtbox.Text);
                svlib.AlarmClient.ResetConfiguration(alarmid);
                getconfigtxtbox.Text = "Sending Reset Alarm Configuration";
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return; 
            }
        }

        private void getalarmstatesbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            
            try
            {
                AlarmStates alarmstates = svlib.AlarmClient.GetAlarmStates();
                string offset = Convert.ToString(alarmstates.offset);
                string length = Convert.ToString(alarmstates.length);
                string changed = alarmstates.changed;
                string state1 = alarmstates.state1;
                string state2 = alarmstates.state2;
                string enabled = alarmstates.enabled;

                getalarmstatestxtbox.Text = string.Format(
                    "<offset>" + offset + "</offset>\n" +
                    "<length>" + length + "</length>\n" +
                    "<changed>" + changed + "</changed>\n" +
                    "<state1>" + state1 + "</state1>\n" +
                    "<state2>" + state2 + "</state2>\n" +
                    "<enabled>" + enabled + "</enabled>\n" 
                    );
            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void setalarmconfigbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int alarmid;
            try
            {
                alarmid = Convert.ToInt16(alarmidtxtbox.Text);
                AlarmConfig alarmconfig = svlib.AlarmClient.GetConfiguration(alarmid);

                //Should read from contents of text box.
                alarmconfig.severity = 1;
                alarmconfig.polarity = 0;
                alarmconfig.enabled = 1;
                alarmconfig.supervised = 0;
                alarmconfig.dwellTime = 5;
                alarmconfig.physicalInput = 0;

                svlib.AlarmClient.SetConfiguration(alarmid, alarmconfig);

                getconfigtxtbox.Text = "Sending SetConfiguration..";

            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }


  
    }
}
