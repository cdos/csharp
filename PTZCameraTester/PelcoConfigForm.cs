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

namespace PTZCameraTester
{
    public partial class PelcoConfigForm : Form
    {
        public PelcoConfigForm(string CameraAddress)
        {
            InitializeComponent();
            CameraIpAddress.Text = CameraAddress;
        }

        private void CameraIpAddress_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
