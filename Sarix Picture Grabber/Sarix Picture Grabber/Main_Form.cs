using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Sarix_Picture_Grabber
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            //Create the Directory for the data to be stored in.
            Directory.CreateDirectory("c:\\IPcamFG\\" + tBx_TESTNAME.Text);
            int NumofPicts = Convert.ToInt32(tBx_NUMPICT.Text);
            int TimeofPicts = Convert.ToInt32(tBx_PICTTIME.Text);
            
            
            //Initialize the progress bar
            progressBar1.Maximum = NumofPicts;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;


            for (int i = 1; i <= NumofPicts; i++)
            {
                WebClient wc = new WebClient();
                if (rB_Pelco.Checked == true)
                {
                    wc.DownloadFile("http://" + tBx_IPADDR.Text + "/jpeg", "c:\\IPcamFG\\" + tBx_TESTNAME.Text + "\\picture" + "_fr" + i + ".jpg");
                }
                if (rB_Axis.Checked == true)
                {
                    wc.DownloadFile("http://" + tBx_IPADDR.Text + "/axis-cgi/jpg/image.cgi", "c:\\IPcamFG\\" + tBx_TESTNAME.Text + "\\picture" + "_fr" + i + ".jpg");
                }
                wc.Dispose();
                System.Threading.Thread.Sleep(TimeofPicts);
                progressBar1.Value = i;

            } 


            
        }
    }
}
