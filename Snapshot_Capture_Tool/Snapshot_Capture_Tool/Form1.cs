using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Snapshot_Capture_Tool
{
    public partial class Form1 : Form
    {
        string TEST_data_location;
        string CAM_TEST_file_name;
        string SCENE_ratio;
        string STOP_time;
        string START_time;

        public Form1()
        {
            InitializeComponent();
        }

        private void bTn_Start_Click(object sender, EventArgs e)
        {
            SCENE_ratio = tBx_SR.Text;
            START_time = tBx_Start.Text;
            STOP_time = tBx_Stop.Text;
            //This process calls VLC to get the snapshots from the video
            tBx_status.AppendText("VLC Frame Capture Started" + Environment.NewLine);
            //Create the directory that the snapshots will be stored in
            Directory.CreateDirectory(TEST_data_location + "\\" + CAM_TEST_file_name + "_PNG");
            string PNG_Folder = TEST_data_location + "\\" + CAM_TEST_file_name + "_PNG\\";
            Process vlc = new Process();
            vlc.StartInfo.FileName = "c:\\program files\\videolan\\vlc\\vlc.exe";
            vlc.StartInfo.UseShellExecute = false;
            vlc.StartInfo.RedirectStandardInput = true;
            vlc.StartInfo.RedirectStandardOutput = true;
            vlc.StartInfo.CreateNoWindow = true;
            vlc.StartInfo.Arguments = TEST_data_location + "\\" + CAM_TEST_file_name + ".mp4 --video-filter=scene --vout=dummy --start-time=" + START_time + " --stop-time=" + STOP_time + "  --scene-format=png --scene-ratio=" + SCENE_ratio + " --scene-prefix=" + CAM_TEST_file_name + "_fr --scene-path=" + PNG_Folder + " vlc://quit";
            vlc.Start();
            vlc.WaitForExit();
            vlc.StandardInput.Close();
            tBx_status.AppendText("VLC Frame Capture Finished" + Environment.NewLine);
            
            
        }

        private void bTn_FileLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "mp4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Full_File_Path = openFileDialog1.FileName;
                CAM_TEST_file_name = Path.GetFileNameWithoutExtension(Full_File_Path);
                TEST_data_location = System.IO.Path.GetDirectoryName(Full_File_Path);
                tBx_VFN.Text = Full_File_Path;
            }


        }
    }
}
