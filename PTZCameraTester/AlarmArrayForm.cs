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

                //populate text box with getconfiguration values
                severitytxtbox.Text = severity;
                polaritytxtbox.Text = polarity;
                enabledtxtbox.Text = enabled;
                supervisedtxtbox.Text = supervised;
                dwelltimetxtbox.Text = dwelltime;
                physicalinputtxtbox.Text = physicalInput;

            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

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

                offsettxtbox.Text = offset;
                lengthtxtbox.Text = length;
                changedtxtbox.Text = changed;
                state1txtbox.Text = state1;
                state2txtbox.Text = state1;
                stateenabledtxtbox.Text = enabled;
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

                severitytxtbox.Text = severity;
                polaritytxtbox.Text = polarity;
                enabledtxtbox.Text = enabled;
                supervisedtxtbox.Text = supervised;
                dwelltimetxtbox.Text = dwelltime;
                physicalinputtxtbox.Text = physicalInput;
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

                offsettxtbox.Text = offset;
                lengthtxtbox.Text = length;
                changedtxtbox.Text = changed;
                state1txtbox.Text = state1;
                state2txtbox.Text = state1;
                stateenabledtxtbox.Text = enabled;
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
                //var lines = getconfigtxtbox.Text.Split("\n");
                alarmconfig.severity = Convert.ToInt16(severitytxtbox.Text);
                alarmconfig.polarity = Convert.ToInt16(polaritytxtbox.Text);
                alarmconfig.enabled = Convert.ToInt16(enabledtxtbox.Text);
                alarmconfig.supervised = Convert.ToInt16(supervisedtxtbox.Text);
                alarmconfig.dwellTime = Convert.ToInt16(dwelltimetxtbox.Text);
                alarmconfig.physicalInput = Convert.ToInt16(physicalinputtxtbox.Text);

                svlib.AlarmClient.SetConfiguration(alarmid, alarmconfig);

                getconfigtxtbox.Text = "Sending SetConfiguration..";

            }
            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }
        }

        private void setalarmstatebutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int alarmid;
            try
            {
                alarmid = Convert.ToInt16(alarmidtxtbox.Text);
                AlarmStates alarmstates = svlib.AlarmClient.GetAlarmStates();

                //Need to see how to send a zero for the whole object.
                alarmstates.objId = Convert.ToInt16(setalarmstatetxtbox.Text);            

                svlib.AlarmClient.SetAlarmState(alarmid, alarmstates.objId);

                getalarmstatestxtbox.Text = "Sending Set Alarm State " + setalarmstatetxtbox.Text;

            }

            catch
            {
                catchNoCommunicateWithCamera();
                return;
            }

        }



    }
}
