using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PTZCameraTester.Tests;
using PTZCameraTester.LensControl;


namespace PTZCameraTester
{
    public partial class LensControlForm : Form
    {
        public LensControlForm(string CameraIP)
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
                float maxdigitalmag = svlib.LensClient.GetMaxDigitalMag();
                float maxopticalmag = svlib.LensClient.GetMaxOpticalMag();
                uint aovmax = svlib.LensClient.GetMaxAOV();
                float getmag = svlib.LensClient.GetMag();
                float getmaxmag = svlib.LensClient.GetMaxMag();

                getmaxdigitalmagtxtbox.Text = Convert.ToString(maxdigitalmag);
                getmaxopticaltxtbox.Text = Convert.ToString(maxopticalmag);
                getmaxaovtxtbox.Text = Convert.ToString(aovmax);
                magtxtbox.Text = Convert.ToString(getmag);
                maxmagtxtbox.Text = Convert.ToString(getmaxmag);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }


        private static void catchNoCommunicateWithCamera()
        {
            MessageBox.Show("Error: Cannot Communicate with Camera.");
            return;
        }

        private void getmaxdigitalmagbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                float maxdigitalmag = svlib.LensClient.GetMaxDigitalMag();
                getmaxdigitalmagtxtbox.Text = Convert.ToString(maxdigitalmag);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void getmaxopticalmagbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                float maxopticalmag = svlib.LensClient.GetMaxOpticalMag();
                getmaxopticaltxtbox.Text = Convert.ToString(maxopticalmag);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void getmaxaovbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                uint aovmax = svlib.LensClient.GetMaxAOV();
                getmaxaovtxtbox.Text = Convert.ToString(aovmax);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void getmagbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                float getmag = svlib.LensClient.GetMag();
                magtxtbox.Text = Convert.ToString(getmag);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void getmaxmagbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            try
            {
                float getmaxmag = svlib.LensClient.GetMaxMag();
                maxmagtxtbox.Text = Convert.ToString(getmaxmag);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void setmagbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint setmag;

            try
            {               
                setmag = Convert.ToUInt16(magtxtbox.Text);
                svlib.LensClient.SetMag(setmag);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void setmaxmagbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint setmaxmag;
            try
            {
                setmaxmag = Convert.ToUInt16(maxmagtxtbox.Text);
                svlib.LensClient.SetMaxMag(setmaxmag);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void autofocusonbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int autofocuson = 1;
            try
            {
                svlib.LensClient.AutoFocus(autofocuson);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void autofocusoffbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int autofocusoff = 0;
            try
            {
                svlib.LensClient.AutoFocus(autofocusoff);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void autoirisonbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int autoirison = 1;
            try
            {
                svlib.LensClient.AutoIris(autoirison);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void autoirisoffbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            int autoirison = 0;
            try
            {
                svlib.LensClient.AutoIris(autoirison);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void focusnearmousedown(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint focusnear = 2;
            try
            {
                svlib.LensClient.Focus(focusnear);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void focusnearmouseup(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint focusnear = 0;
            try
            {
                svlib.LensClient.Focus(focusnear);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void focusfarmousedown(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint focusfar = 1;
            try
            {
                svlib.LensClient.Focus(focusfar);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void focusfarmouseup(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint focusfar = 0;
            try
            {
                svlib.LensClient.Focus(focusfar);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void irisopenmousedown(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint irisopen = 2;
            try
            {
                svlib.LensClient.Iris(irisopen);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void irisopenmouseup(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint irisopen = 0;
            try
            {
                svlib.LensClient.Iris(irisopen);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void irisclosemousedown(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint irisclose = 1;
            try
            {
                svlib.LensClient.Iris(irisclose);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void irisclosemouseup(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint irisclose = 0;
            try
            {
                svlib.LensClient.Iris(irisclose);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void zoominmousedown(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint zoomin = 2;
            try
            {
                svlib.LensClient.Zoom(zoomin);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void zoominmouseup(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint zoomin = 0;
            try
            {
                svlib.LensClient.Zoom(zoomin);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void zoomoutmousedown(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint zoomout = 1;
            try
            {
                svlib.LensClient.Zoom(zoomout);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void zoomoutmouseup(object sender, MouseEventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint zoomout = 0;
            try
            {
                svlib.LensClient.Zoom(zoomout);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void maxfocusnearbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint focusnear = 2;
            try
            {
                svlib.LensClient.Focus(focusnear);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void maxfocusfarbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint focusfar = 1;
            try
            {
                svlib.LensClient.Focus(focusfar);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void maxzoominbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint zoomin = 2;
            try
            {
                svlib.LensClient.Zoom(zoomin);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void maxzoomoutbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint zoomout = 1;
            try
            {
                svlib.LensClient.Zoom(zoomout);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void maxirisopenbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint irisopen = 2;
            try
            {
                svlib.LensClient.Iris(irisopen);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void maxirisclosebutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            uint zoomout = 1;
            try
            {
                svlib.LensClient.Zoom(zoomout);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void lensstopbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            
            try
            {
                svlib.LensClient.Stop();
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }


    }
}
