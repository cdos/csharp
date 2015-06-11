using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using System.Diagnostics;


namespace Win_VLC_1_4
{
    public partial class Form1 : Form
    {
        public string[] RTSP_Name = new string[100];
        public string[] RTSP_Front = new string[100];
        public string[] RTSP_Rear = new string[100];
        public string[] RTSP_EBR = new string[100];
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string windows_ver = Environment.OSVersion.VersionString;

            if (Environment.OSVersion.Version < new Version(5, 1))
            {
                tBx_status.AppendText("Windows XP or later Required");
            }

            if (Environment.OSVersion.Version < new Version(6, 1))
            {
            tBx_status.AppendText("Windows XP detected.");
            // This will load the data into the form when the program is started.
            // Pre-Load the location of the main file storage area.
            tBx_mtsl.Text = "WIN-VLC-Multicam";
            //Directory.CreateDirectory(@"C:\WIN-VLC-Mulitcam\Test-Config");
            //Directory.CreateDirectory(@"C:\WIN-VLC-Mulitcam\BGR-Script");
            // Pre-Load a recording time
            tBx_rtsec.Text = "30";
            // Pre-Load the VLC install location
            tBx_VLC_i_loc.Text = @"c:\Program Files\videolan\vlc";
            tBx_WinSCP_FL.Text = @"C:\Program Files\WinSCP";
            }

            if (Environment.OSVersion.Version > new Version(6, 0) && Environment.OSVersion.Version < new Version(6, 3))
            {
                tBx_status.AppendText("Windows 7 detected.");
            //    // This will load the data into the form when the program is started.
            //    // Pre-Load the location of the main file storage area.
                tBx_mtsl.Text = "WIN-VLC-Multicam";
            //    //Directory.CreateDirectory(@"C:\WIN-VLC-Mulitcam\Test-Config");
            //    //Directory.CreateDirectory(@"C:\WIN-VLC-Mulitcam\BGR-Script");
            //    // Pre-Load a recording time
                tBx_rtsec.Text = "30";
            //    // Pre-Load the VLC install location
                tBx_VLC_i_loc.Text = @"c:\Program Files\videolan\vlc";
                tBx_WinSCP_FL.Text = @"C:\Program Files (x86)\WinSCP";
            }

            int i;
            // Disable the start button until a record box is checked
            btn_Start.Enabled = false;

            // This section loads the information in the in the RTSP list file.
            string[] RTSPlines = System.IO.File.ReadAllLines(@"C:\WIN-VLC-Multicam\RTSP_list.csv");
            int lengthoflines = RTSPlines.Length;
            //Parse the strings to get the data you need.
            char[] delimiterStrings = { ',' };

            Array.Resize(ref RTSP_Name, lengthoflines);
            Array.Resize(ref RTSP_Front, lengthoflines);
            Array.Resize(ref RTSP_Rear, lengthoflines);
            Array.Resize(ref RTSP_EBR, lengthoflines);

            //Load the information into the RTSP arrays
            for (i = 0; i < lengthoflines; i++)
            {
                string[] RTSP_parser = RTSPlines[i].Split(delimiterStrings);
                RTSP_Name[i] = RTSP_parser[0];
                RTSP_Front[i] = RTSP_parser[1];
                RTSP_Rear[i] = RTSP_parser[2];
                RTSP_EBR[i] = RTSP_parser[3];
            }
            // Add the camera names to the combo boxes
            for (i = 1; i < RTSP_Name.Length; i++)
            {
                cBx_cam1.Items.Add(RTSP_Name[i]);
                cBx_cam2.Items.Add(RTSP_Name[i]);
                cBx_cam3.Items.Add(RTSP_Name[i]);
                cBx_cam4.Items.Add(RTSP_Name[i]);
                cBx_cam5.Items.Add(RTSP_Name[i]);
                cBx_cam6.Items.Add(RTSP_Name[i]);
                cBx_cam7.Items.Add(RTSP_Name[i]);
                cBx_cam8.Items.Add(RTSP_Name[i]);
                cBx_cam9.Items.Add(RTSP_Name[i]);
                cBx_cam10.Items.Add(RTSP_Name[i]);
            }

            cBx_cam1.SelectedIndex = 0;
            cBx_cam2.SelectedIndex = 0;
            cBx_cam3.SelectedIndex = 0;
            cBx_cam4.SelectedIndex = 0;
            cBx_cam5.SelectedIndex = 0;
            cBx_cam6.SelectedIndex = 0;
            cBx_cam7.SelectedIndex = 0;
            cBx_cam8.SelectedIndex = 0;
            cBx_cam9.SelectedIndex = 0;
            cBx_cam10.SelectedIndex = 0;

            // Load the bug report script files into the bug report comboboxes
            DirectoryInfo BG_Directory;
            FileInfo[] BG_Files;
            BG_Directory = new DirectoryInfo(@"C:\WIN-VLC-Multicam\BGR-Script");
            BG_Files = BG_Directory.GetFiles();

            if (BG_Files != null)
            {
                for (i = 0; i < BG_Files.Length; i++)
                {
                    cBx_Cam1_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam2_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam3_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam4_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam5_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam6_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam7_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam8_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam9_BRS.Items.Add(BG_Files[i].Name);
                    cBx_Cam10_BRS.Items.Add(BG_Files[i].Name);
                }
            }

        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            int i, j;
            // We have clicked start so disable it until everything is done
            btn_Start.Enabled = false;

            //Clear the status text box
            tBx_status.Clear();

            //This is the amount of time to record in seconds.
            string rec_time_sec = tBx_rtsec.Text;
            // This is the name and location of the main storage
            string MAIN_test_storage = tBx_mtsl.Text;
            string TEST_data_location;
            // These are the names of the folders where you want the images to be stored
            string CAM_FOLDER_name;
            string[] Cam_folder = new string[10];
            Cam_folder[0] = tBx_cam1folder.Text;
            Cam_folder[1] = tBx_cam2folder.Text;
            Cam_folder[2] = tBx_cam3folder.Text;
            Cam_folder[3] = tBx_cam4folder.Text;
            Cam_folder[4] = tBx_cam5folder.Text;
            Cam_folder[5] = tBx_cam6folder.Text;
            Cam_folder[6] = tBx_cam7folder.Text;
            Cam_folder[7] = tBx_cam8folder.Text;
            Cam_folder[8] = tBx_cam9folder.Text;
            Cam_folder[9] = tBx_cam10folder.Text;

            // This is the name of the files that are created
            string CAM_TEST_file_name;
            string[] Cam_file_name = new string[10];
            Cam_file_name[0] = tBx_cam1file.Text;
            Cam_file_name[1] = tBx_cam2file.Text;
            Cam_file_name[2] = tBx_cam3file.Text;
            Cam_file_name[3] = tBx_cam4file.Text;
            Cam_file_name[4] = tBx_cam5file.Text;
            Cam_file_name[5] = tBx_cam6file.Text;
            Cam_file_name[6] = tBx_cam7file.Text;
            Cam_file_name[7] = tBx_cam8file.Text;
            Cam_file_name[8] = tBx_cam9file.Text;
            Cam_file_name[9] = tBx_cam10file.Text;

            // IP camera Address
            string[] CAM_ipAddr = new string[10];
            CAM_ipAddr[0] = tBx_cam1IP.Text;
            CAM_ipAddr[1] = tBx_cam2IP.Text;
            CAM_ipAddr[2] = tBx_cam3IP.Text;
            CAM_ipAddr[3] = tBx_cam4IP.Text;
            CAM_ipAddr[4] = tBx_cam5IP.Text;
            CAM_ipAddr[5] = tBx_cam6IP.Text;
            CAM_ipAddr[6] = tBx_cam7IP.Text;
            CAM_ipAddr[7] = tBx_cam8IP.Text;
            CAM_ipAddr[8] = tBx_cam9IP.Text;
            CAM_ipAddr[9] = tBx_cam10IP.Text;

            // This array holds the assembled RTSP strings for the program to use.
            string[] CAM_RTSP = new string[10];

            CAM_RTSP[0] = "rtsp://" + RTSP_Front[(cBx_cam1.SelectedIndex + 1)] + CAM_ipAddr[0] + RTSP_Rear[(cBx_cam1.SelectedIndex + 1)];
            CAM_RTSP[1] = "rtsp://" + RTSP_Front[(cBx_cam2.SelectedIndex + 1)] + CAM_ipAddr[1] + RTSP_Rear[(cBx_cam2.SelectedIndex + 1)];
            CAM_RTSP[2] = "rtsp://" + RTSP_Front[(cBx_cam3.SelectedIndex + 1)] + CAM_ipAddr[2] + RTSP_Rear[(cBx_cam3.SelectedIndex + 1)];
            CAM_RTSP[3] = "rtsp://" + RTSP_Front[(cBx_cam4.SelectedIndex + 1)] + CAM_ipAddr[3] + RTSP_Rear[(cBx_cam4.SelectedIndex + 1)];
            CAM_RTSP[4] = "rtsp://" + RTSP_Front[(cBx_cam5.SelectedIndex + 1)] + CAM_ipAddr[4] + RTSP_Rear[(cBx_cam5.SelectedIndex + 1)];
            CAM_RTSP[5] = "rtsp://" + RTSP_Front[(cBx_cam6.SelectedIndex + 1)] + CAM_ipAddr[5] + RTSP_Rear[(cBx_cam6.SelectedIndex + 1)];
            CAM_RTSP[6] = "rtsp://" + RTSP_Front[(cBx_cam7.SelectedIndex + 1)] + CAM_ipAddr[6] + RTSP_Rear[(cBx_cam7.SelectedIndex + 1)];
            CAM_RTSP[7] = "rtsp://" + RTSP_Front[(cBx_cam8.SelectedIndex + 1)] + CAM_ipAddr[7] + RTSP_Rear[(cBx_cam8.SelectedIndex + 1)];
            CAM_RTSP[8] = "rtsp://" + RTSP_Front[(cBx_cam9.SelectedIndex + 1)] + CAM_ipAddr[8] + RTSP_Rear[(cBx_cam9.SelectedIndex + 1)];
            CAM_RTSP[9] = "rtsp://" + RTSP_Front[(cBx_cam10.SelectedIndex + 1)] + CAM_ipAddr[9] + RTSP_Rear[(cBx_cam10.SelectedIndex + 1)];

            // This array contains the status of the record checkboxes.
            bool[] checkbox_status = new bool[10];
            checkbox_status[0] = ckBx_cam1.Checked;
            checkbox_status[1] = ckBx_cam2.Checked;
            checkbox_status[2] = ckBx_cam3.Checked;
            checkbox_status[3] = ckBx_cam4.Checked;
            checkbox_status[4] = ckBx_cam5.Checked;
            checkbox_status[5] = ckBx_cam6.Checked;
            checkbox_status[6] = ckBx_cam7.Checked;
            checkbox_status[7] = ckBx_cam8.Checked;
            checkbox_status[8] = ckBx_cam9.Checked;
            checkbox_status[9] = ckBx_cam10.Checked;

            string RTSP_vlc_uri;
            for (i = 0; i < 10; i++)
            {
                j = i + 1;
                //if the camera is checked to be recorded
                if (checkbox_status[i] == true)
                {
                    tBx_status.AppendText("Camera " + j + " Settings:" + Environment.NewLine);
                    // Create the folders for the project
                    CAM_FOLDER_name = Cam_folder[i];
                    CAM_TEST_file_name = Cam_file_name[i];
                    // This is complete folder structure for the test
                    TEST_data_location = "C:\\" + MAIN_test_storage + "\\" + CAM_FOLDER_name;
                    tBx_status.AppendText("Test Data Location: " + TEST_data_location + Environment.NewLine);
                    tBx_status.AppendText("Test File Name: " + CAM_TEST_file_name + Environment.NewLine);
                    // Create the directory structure for the test
                    Directory.CreateDirectory(TEST_data_location);
                    tBx_status.AppendText("Directory Structure Created." + Environment.NewLine);

                    tBx_status.AppendText("RTSP URI: " + CAM_RTSP[i] + Environment.NewLine);
                    RTSP_vlc_uri = CAM_RTSP[i];
                    //This process calls VLC to record the video
                    tBx_status.AppendText("VLC Recording Started. - Camera " + j + Environment.NewLine);
                    Application.DoEvents();
                    ProcessStartInfo startinfo = new ProcessStartInfo();
                    startinfo.UseShellExecute = false;
                    startinfo.RedirectStandardInput = true;
                    startinfo.RedirectStandardOutput = true;
                    startinfo.FileName = (tBx_VLC_i_loc.Text + "\\vlc.exe");
                    startinfo.Arguments = "-vvv --no-fullscreen " + RTSP_vlc_uri + " --run-time=" + rec_time_sec + " --sout=#std{access=file,mux=mp4,dst=" + TEST_data_location + "\\" + CAM_TEST_file_name + ".mp4}} vlc://quit";
                    Application.DoEvents();
                    Process.Start(startinfo);
                    Application.DoEvents();
                }
            }
            // This section gets all of the VLC processes and waits for them to exit and then closes them.
            // This might be redundant since the vlc string also contains the command for VLC to quit when the recording is done.
            //Process[] vlc_instance = Process.GetProcessesByName("vlc");

            //foreach (Process process in vlc_instance)
            //{
            //    Application.DoEvents();
            //    process.WaitForExit();
            //    Application.DoEvents();
            //    process.Close();
            //}

            // This is the section that will grab the bug report information
            // This is the arrays of what the file name will be called.
            string[] BGRFN_array = new string[10];
            BGRFN_array[0] = tBx_Cam1_BRFN.Text;
            BGRFN_array[1] = tBx_Cam2_BRFN.Text;
            BGRFN_array[2] = tBx_Cam3_BRFN.Text;
            BGRFN_array[3] = tBx_Cam4_BRFN.Text;
            BGRFN_array[4] = tBx_Cam5_BRFN.Text;
            BGRFN_array[5] = tBx_Cam6_BRFN.Text;
            BGRFN_array[6] = tBx_Cam7_BRFN.Text;
            BGRFN_array[7] = tBx_Cam8_BRFN.Text;
            BGRFN_array[8] = tBx_Cam9_BRFN.Text;
            BGRFN_array[9] = tBx_Cam10_BRFN.Text;

            // This is the array of the ssh Username
            string[] SSHUN_array = new string[10];
            SSHUN_array[0] = tBx_Cam1_SSHUN.Text;
            SSHUN_array[1] = tBx_Cam2_SSHUN.Text;
            SSHUN_array[2] = tBx_Cam3_SSHUN.Text;
            SSHUN_array[3] = tBx_Cam4_SSHUN.Text;
            SSHUN_array[4] = tBx_Cam5_SSHUN.Text;
            SSHUN_array[5] = tBx_Cam6_SSHUN.Text;
            SSHUN_array[6] = tBx_Cam7_SSHUN.Text;
            SSHUN_array[7] = tBx_Cam8_SSHUN.Text;
            SSHUN_array[8] = tBx_Cam9_SSHUN.Text;
            SSHUN_array[9] = tBx_Cam10_SSHUN.Text;

            // This is the array of the ssh password
            string[] SSHPW_array = new string[10];
            SSHPW_array[0] = tBx_Cam1_SSHPW.Text;
            SSHPW_array[1] = tBx_Cam2_SSHPW.Text;
            SSHPW_array[2] = tBx_Cam3_SSHPW.Text;
            SSHPW_array[3] = tBx_Cam4_SSHPW.Text;
            SSHPW_array[4] = tBx_Cam5_SSHPW.Text;
            SSHPW_array[5] = tBx_Cam6_SSHPW.Text;
            SSHPW_array[6] = tBx_Cam7_SSHPW.Text;
            SSHPW_array[7] = tBx_Cam8_SSHPW.Text;
            SSHPW_array[8] = tBx_Cam9_SSHPW.Text;
            SSHPW_array[9] = tBx_Cam10_SSHPW.Text;

            // This is the array that holds the name of the script
            // file that is to be used.
            string[] BGRS_array = new string[10];
            BGRS_array[0] = cBx_Cam1_BRS.Text;
            BGRS_array[1] = cBx_Cam2_BRS.Text;
            BGRS_array[2] = cBx_Cam3_BRS.Text;
            BGRS_array[3] = cBx_Cam4_BRS.Text;
            BGRS_array[4] = cBx_Cam5_BRS.Text;
            BGRS_array[5] = cBx_Cam6_BRS.Text;
            BGRS_array[6] = cBx_Cam7_BRS.Text;
            BGRS_array[7] = cBx_Cam8_BRS.Text;
            BGRS_array[8] = cBx_Cam9_BRS.Text;
            BGRS_array[9] = cBx_Cam10_BRS.Text;

            bool[] checkbox_br_status = new bool[10];
            checkbox_br_status[0] = ckBx_Cam1_br.Checked;
            checkbox_br_status[1] = ckBx_Cam2_br.Checked;
            checkbox_br_status[2] = ckBx_Cam3_br.Checked;
            checkbox_br_status[3] = ckBx_Cam4_br.Checked;
            checkbox_br_status[4] = ckBx_Cam5_br.Checked;
            checkbox_br_status[5] = ckBx_Cam6_br.Checked;
            checkbox_br_status[6] = ckBx_Cam7_br.Checked;
            checkbox_br_status[7] = ckBx_Cam8_br.Checked;
            checkbox_br_status[8] = ckBx_Cam9_br.Checked;
            checkbox_br_status[9] = ckBx_Cam10_br.Checked;


            if ((checkbox_br_status[0] | checkbox_br_status[1] | checkbox_br_status[2] | checkbox_br_status[3] | checkbox_br_status[4] |
                checkbox_br_status[5] | checkbox_br_status[6] | checkbox_br_status[7] | checkbox_br_status[8] | checkbox_br_status[9]) == true)
            {
                // This is the bug report script upload and process the script in the camera
                for (i = 0; i < 10; i++)
                {
                    j = i + 1;
                    //if the camera is checked to be recorded
                    if (checkbox_br_status[i] == true)
                    {
                        if (BGRS_array[i] == "bgr-pelco-pro.sh")
                        {
                            tBx_status.AppendText("Camera is a Pelco Pro Model. Bug report request is being sent." + Environment.NewLine);
                            WebClient wc = new WebClient();
                            wc.Credentials = new NetworkCredential(SSHUN_array[i], SSHPW_array[i]);
                            Application.DoEvents();
                            wc.DownloadFileAsync(new Uri("http://" + CAM_ipAddr[i] + "/cgi-bin/systemlog.cgi"), "c:\\" + MAIN_test_storage + "\\" + Cam_folder[i] + "\\" + BGRFN_array[i] + ".tgz");

                        }
                        else
                        {
                            // Run hidden WinSCP process
                            Process winscp = new Process();
                            winscp.StartInfo.FileName = tBx_WinSCP_FL.Text + "\\winscp.com";
                            winscp.StartInfo.UseShellExecute = false;
                            winscp.StartInfo.RedirectStandardInput = true;
                            winscp.StartInfo.RedirectStandardOutput = true;
                            winscp.StartInfo.CreateNoWindow = true;
                            winscp.Start();
                            tBx_status.AppendText("Starting the Bug Report Download Process for Camera " + j + Environment.NewLine);
                            /// Feed in the scripting commands for startup
                            winscp.StandardInput.WriteLine("option batch on");
                            winscp.StandardInput.WriteLine("option confirm off");
                            winscp.StandardInput.WriteLine("open scp://" + SSHUN_array[i] + ":" + SSHPW_array[i] + "@" + CAM_ipAddr[i]);
                            tBx_status.AppendText("open scp://" + SSHUN_array[i] + ":" + SSHPW_array[i] + "@" + CAM_ipAddr[i] + Environment.NewLine);
                            winscp.StandardInput.WriteLine("cd /sbin");
                            winscp.StandardInput.WriteLine("option transfer binary");
                            winscp.StandardInput.WriteLine("put C:\\WIN-VLC-Multicam\\BGR-Script\\" + BGRS_array[i]);
                            tBx_status.AppendText("Load the Script file on the Camera" + Environment.NewLine);
                            Application.DoEvents();
                            //System.Threading.Thread.Sleep(10000);
                            winscp.StandardInput.WriteLine("chmod 0755 " + BGRS_array[i]);
                            winscp.StandardInput.WriteLine("call sh ./" + BGRS_array[i]);
                            winscp.StandardInput.Close();
                        }

                    }
                }
                // Added a delay to allow for the processing of the bugreports to happen.
                tBx_status.AppendText("Files are being processed:");
                for (i = 0; i < 180; i++)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1000);
                    tBx_status.AppendText("/");

                }
                tBx_status.AppendText(Environment.NewLine);
                // This array will contain the flags that will show if the bugreports have been down loaded
                bool[] BGRDLS = new bool[10];
                // Preload the array with true values
                for (i = 0; i < 10; i++)
                {
                    BGRDLS[i] = true;
                }
                //This loop is intended to allow for the script to process and do it's thing.
                for (i = 0; i < 10; i++)
                {
                    if (checkbox_br_status[i] == true)
                    {
                        // if the checkbox for a bug report is true, then the file needs to be downloaded, the BGRDLS array needs to be set for false
                        // since the file has yet to be down loaded.
                        BGRDLS[i] = false;
                        if (BGRS_array[i] == "bgr-pelco-pro.sh")
                        {
                            tBx_status.AppendText("Camera is a Pelco Pro Model. Bug report request has already been sent." + Environment.NewLine);
                        }
                        else
                        {
                            // Run hidden WinSCP process
                            Process winscp = new Process();
                            winscp.StartInfo.FileName = tBx_WinSCP_FL.Text + "\\winscp.com";

                            winscp.StartInfo.UseShellExecute = false;
                            winscp.StartInfo.RedirectStandardInput = true;
                            winscp.StartInfo.RedirectStandardOutput = true;
                            winscp.StartInfo.CreateNoWindow = true;
                            Application.DoEvents();
                            winscp.Start();
                            winscp.StandardInput.WriteLine("option batch on");
                            winscp.StandardInput.WriteLine("option confirm off");
                            winscp.StandardInput.WriteLine("open scp://" + SSHUN_array[i] + ":" + SSHPW_array[i] + "@" + CAM_ipAddr[i]);
                            winscp.StandardInput.WriteLine("cd /tmp");
                            winscp.StandardInput.WriteLine("option transfer binary");
                            winscp.StandardInput.WriteLine("get -delete bugreport.tgz c:\\" + MAIN_test_storage + "\\" + Cam_folder[i] + "\\" + BGRFN_array[i] + ".tgz");
                            tBx_status.AppendText("Starting Download of the Bugreport." + Environment.NewLine);
                            //System.Threading.Thread.Sleep(10000);
                            winscp.StandardInput.WriteLine("rmdir /tmp/bugreport");
                            winscp.StandardInput.WriteLine("cd /sbin");
                            winscp.StandardInput.WriteLine("rm " + BGRS_array[i]);
                            tBx_status.AppendText("Scripts removed from Camera." + Environment.NewLine);
                            winscp.StandardInput.Close();
                        }
                    }
                }
                // Added a delay to allow for the downloading of the bugreports to happen.
                tBx_status.AppendText("Files are being downloaded:" + Environment.NewLine);

                i = 0;
                j = 0;
                bool download_complete = false;
                bool download_timeout = false;
                while (download_complete == false & download_timeout == false)
                {
                    while (((BGRDLS[0] & BGRDLS[1] & BGRDLS[2] & BGRDLS[3] & BGRDLS[4] & BGRDLS[5] & BGRDLS[6] & BGRDLS[7] & BGRDLS[8] & BGRDLS[9]) != true) & download_timeout == false)
                    {
                        if (BGRDLS[i] == false)
                        {
                            if (File.Exists("c:\\" + MAIN_test_storage + "\\" + Cam_folder[i] + "\\" + BGRFN_array[i] + ".tgz") == true)
                            {
                                tBx_status.AppendText(BGRFN_array[i] + ".tgz has been downloaded." + Environment.NewLine);
                                BGRDLS[i] = true;
                            }
                        }
                        i++;
                        j++;
                        if (i >= 10)
                        {
                            i = 0;
                        }
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(500);
                        if (j >= 60)
                        {
                            // If we get here, one or more of the files have not downloaded so let's get out.
                            download_timeout = true;
                        }

                    }
                    // We are out of the while loop so we check to see if the reason was due to a time out.
                    if (download_timeout == false)
                    {
                        download_complete = true;
                    }
                }

                if (download_complete == true)
                {
                    tBx_status.AppendText("All files have downloaded." + Environment.NewLine);
                }
                if (download_timeout == true)
                {
                    // One or more of the files did not download, let's find out which ones and let the end user know about it.
                    for (i = 0; i < 10; i++)
                    {
                        if (BGRDLS[i] == false)
                        {
                            tBx_status.AppendText("The following files did not get downloaded:" + Environment.NewLine);
                            tBx_status.AppendText(BGRFN_array[i] + ".tgz" + Environment.NewLine);
                        }
                    }
                }
            }
            //The process is finished so the start button gets re-enabled
            btn_Start.Enabled = true;
        }

        private void btn_VLCloc_Click(object sender, EventArgs e)
        {
            DialogResult VLC_location = folderBrowserDialog1.ShowDialog();
            if (VLC_location == DialogResult.OK)
            {
                tBx_VLC_i_loc.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_WinScp_ld_Click(object sender, EventArgs e)
        {
            DialogResult WinSCP_location = folderBrowserDialog1.ShowDialog();
            if (WinSCP_location == DialogResult.OK)
            {
                tBx_WinSCP_FL.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_Save_Config_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "c:\\WIN-VLC-Multicam\\Test-Config";
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                try
                {
                    sw.WriteLine("//Test Configuration ************************************************");
                    sw.WriteLine("VLC Install Location," + tBx_VLC_i_loc.Text);
                    sw.WriteLine("Record Time," + tBx_rtsec.Text);
                    sw.WriteLine("//Camera 1 Information ***************************************");
                    sw.WriteLine(tBx_cam1IP.Text + "," + cBx_cam1.Text + "," + tBx_cam1folder.Text + "," + tBx_cam1file.Text);
                    sw.WriteLine("//Camera 2 Information ***************************************");
                    sw.WriteLine(tBx_cam2IP.Text + "," + cBx_cam2.Text + "," + tBx_cam2folder.Text + "," + tBx_cam2file.Text);
                    sw.WriteLine("//Camera 3 Information ***************************************");
                    sw.WriteLine(tBx_cam3IP.Text + "," + cBx_cam3.Text + "," + tBx_cam3folder.Text + "," + tBx_cam3file.Text);
                    sw.WriteLine("//Camera 4 Information ***************************************");
                    sw.WriteLine(tBx_cam4IP.Text + "," + cBx_cam4.Text + "," + tBx_cam4folder.Text + "," + tBx_cam4file.Text);
                    sw.WriteLine("//Camera 5 Information ***************************************");
                    sw.WriteLine(tBx_cam5IP.Text + "," + cBx_cam5.Text + "," + tBx_cam5folder.Text + "," + tBx_cam5file.Text);
                    sw.WriteLine("//Camera 6 Information ***************************************");
                    sw.WriteLine(tBx_cam6IP.Text + "," + cBx_cam6.Text + "," + tBx_cam6folder.Text + "," + tBx_cam6file.Text);
                    sw.WriteLine("//Camera 7 Information ***************************************");
                    sw.WriteLine(tBx_cam7IP.Text + "," + cBx_cam7.Text + "," + tBx_cam7folder.Text + "," + tBx_cam7file.Text);
                    sw.WriteLine("//Camera 8 Information ***************************************");
                    sw.WriteLine(tBx_cam8IP.Text + "," + cBx_cam8.Text + "," + tBx_cam8folder.Text + "," + tBx_cam8file.Text);
                    sw.WriteLine("//Camera 9 Information ***************************************");
                    sw.WriteLine(tBx_cam9IP.Text + "," + cBx_cam9.Text + "," + tBx_cam9folder.Text + "," + tBx_cam9file.Text);
                    sw.WriteLine("//Camera 10 Information ***************************************");
                    sw.WriteLine(tBx_cam10IP.Text + "," + cBx_cam10.Text + "," + tBx_cam10folder.Text + "," + tBx_cam10file.Text);
                    sw.WriteLine("//Bug Report Data ************************************************");
                    sw.WriteLine("WinSCP.com Install Location," + tBx_WinSCP_FL.Text);
                    sw.WriteLine("//Camera 1 Information ***************************************");
                    sw.WriteLine(tBx_Cam1_BRFN.Text + "," + tBx_Cam1_SSHUN.Text + "," + tBx_Cam1_SSHPW.Text + "," + cBx_Cam1_BRS.Text);
                    sw.WriteLine("//Camera 2 Information ***************************************");
                    sw.WriteLine(tBx_Cam2_BRFN.Text + "," + tBx_Cam2_SSHUN.Text + "," + tBx_Cam2_SSHPW.Text + "," + cBx_Cam2_BRS.Text);
                    sw.WriteLine("//Camera 3 Information ***************************************");
                    sw.WriteLine(tBx_Cam3_BRFN.Text + "," + tBx_Cam3_SSHUN.Text + "," + tBx_Cam3_SSHPW.Text + "," + cBx_Cam3_BRS.Text);
                    sw.WriteLine("//Camera 4 Information ***************************************");
                    sw.WriteLine(tBx_Cam4_BRFN.Text + "," + tBx_Cam4_SSHUN.Text + "," + tBx_Cam4_SSHPW.Text + "," + cBx_Cam4_BRS.Text);
                    sw.WriteLine("//Camera 5 Information ***************************************");
                    sw.WriteLine(tBx_Cam5_BRFN.Text + "," + tBx_Cam5_SSHUN.Text + "," + tBx_Cam5_SSHPW.Text + "," + cBx_Cam5_BRS.Text);
                    sw.WriteLine("//Camera 6 Information ***************************************");
                    sw.WriteLine(tBx_Cam6_BRFN.Text + "," + tBx_Cam6_SSHUN.Text + "," + tBx_Cam6_SSHPW.Text + "," + cBx_Cam6_BRS.Text);
                    sw.WriteLine("//Camera 7 Information ***************************************");
                    sw.WriteLine(tBx_Cam7_BRFN.Text + "," + tBx_Cam7_SSHUN.Text + "," + tBx_Cam7_SSHPW.Text + "," + cBx_Cam7_BRS.Text);
                    sw.WriteLine("//Camera 8 Information ***************************************");
                    sw.WriteLine(tBx_Cam8_BRFN.Text + "," + tBx_Cam8_SSHUN.Text + "," + tBx_Cam8_SSHPW.Text + "," + cBx_Cam8_BRS.Text);
                    sw.WriteLine("//Camera 9 Information ***************************************");
                    sw.WriteLine(tBx_Cam9_BRFN.Text + "," + tBx_Cam9_SSHUN.Text + "," + tBx_Cam9_SSHPW.Text + "," + cBx_Cam9_BRS.Text);
                    sw.WriteLine("//Camera 10 Information ***************************************");
                    sw.WriteLine(tBx_Cam10_BRFN.Text + "," + tBx_Cam10_SSHUN.Text + "," + tBx_Cam10_SSHPW.Text + "," + cBx_Cam10_BRS.Text);

                    sw.Dispose();
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        private void btn_Load_Config_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\WIN-VLC-Multicam\\Test-Config";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileName);
                    int lenthoflines = lines.Length;
                    //Parse the strings to get the data you need.
                    char[] delimiterStrings = { ',' };
                    //Load the VLC installation location and recording time
                    string[] VLC_INST_LOC_parser = lines[1].Split(delimiterStrings);
                    tBx_VLC_i_loc.Text = VLC_INST_LOC_parser[1];
                    string[] rectime_parser = lines[2].Split(delimiterStrings);
                    tBx_rtsec.Text = rectime_parser[1];
                    //Load the Camera 1 settings
                    string[] CAM1_parser = lines[4].Split(delimiterStrings);
                    tBx_cam1IP.Text = CAM1_parser[0];
                    cBx_cam1.SelectedIndex = FindCamRTSPLoc(CAM1_parser[1], RTSP_Name);
                    //cBx_cam1.SelectedIndex = Convert.ToInt16(CAM1_parser[1]);
                    tBx_cam1folder.Text = CAM1_parser[2];
                    tBx_cam1file.Text = CAM1_parser[3];

                    //Load the Camera 2 settings
                    string[] CAM2_parser = lines[6].Split(delimiterStrings);
                    tBx_cam2IP.Text = CAM2_parser[0];
                    cBx_cam2.SelectedIndex = FindCamRTSPLoc(CAM2_parser[1], RTSP_Name);
                    //cBx_cam2.SelectedIndex = Convert.ToInt16(CAM2_parser[1]);
                    tBx_cam2folder.Text = CAM2_parser[2];
                    tBx_cam2file.Text = CAM2_parser[3];

                    //Load the Camera 3 settings
                    string[] CAM3_parser = lines[8].Split(delimiterStrings);
                    tBx_cam3IP.Text = CAM3_parser[0];
                    cBx_cam3.SelectedIndex = FindCamRTSPLoc(CAM3_parser[1], RTSP_Name);
                    //cBx_cam3.SelectedIndex = Convert.ToInt16(CAM3_parser[1]);
                    tBx_cam3folder.Text = CAM3_parser[2];
                    tBx_cam3file.Text = CAM3_parser[3];

                    //Load the Camera 4 settings
                    string[] CAM4_parser = lines[10].Split(delimiterStrings);
                    tBx_cam4IP.Text = CAM4_parser[0];
                    cBx_cam4.SelectedIndex = FindCamRTSPLoc(CAM4_parser[1], RTSP_Name);
                    //cBx_cam4.SelectedIndex = Convert.ToInt16(CAM4_parser[1]);
                    tBx_cam4folder.Text = CAM4_parser[2];
                    tBx_cam4file.Text = CAM4_parser[3];

                    //Load the Camera 5 settings
                    string[] CAM5_parser = lines[12].Split(delimiterStrings);
                    tBx_cam5IP.Text = CAM5_parser[0];
                    cBx_cam5.SelectedIndex = FindCamRTSPLoc(CAM5_parser[1], RTSP_Name);
                    //cBx_cam5.SelectedIndex = Convert.ToInt16(CAM5_parser[1]);
                    tBx_cam5folder.Text = CAM5_parser[2];
                    tBx_cam5file.Text = CAM5_parser[3];

                    //Load the Camera 6 settings
                    string[] CAM6_parser = lines[14].Split(delimiterStrings);
                    tBx_cam6IP.Text = CAM6_parser[0];
                    cBx_cam6.SelectedIndex = FindCamRTSPLoc(CAM6_parser[1], RTSP_Name);
                    //cBx_cam6.SelectedIndex = Convert.ToInt16(CAM6_parser[1]);
                    tBx_cam6folder.Text = CAM6_parser[2];
                    tBx_cam6file.Text = CAM6_parser[3];

                    //Load the Camera 7 settings
                    string[] CAM7_parser = lines[16].Split(delimiterStrings);
                    tBx_cam7IP.Text = CAM7_parser[0];
                    cBx_cam7.SelectedIndex = FindCamRTSPLoc(CAM7_parser[1], RTSP_Name);
                    //cBx_cam7.SelectedIndex = Convert.ToInt16(CAM7_parser[1]);
                    tBx_cam7folder.Text = CAM7_parser[2];
                    tBx_cam7file.Text = CAM7_parser[3];

                    //Load the Camera 8 settings
                    string[] CAM8_parser = lines[18].Split(delimiterStrings);
                    tBx_cam8IP.Text = CAM8_parser[0];
                    cBx_cam8.SelectedIndex = FindCamRTSPLoc(CAM8_parser[1], RTSP_Name);
                    //cBx_cam8.SelectedIndex = Convert.ToInt16(CAM8_parser[1]);
                    tBx_cam8folder.Text = CAM8_parser[2];
                    tBx_cam8file.Text = CAM8_parser[3];

                    //Load the Camera 9 settings
                    string[] CAM9_parser = lines[20].Split(delimiterStrings);
                    tBx_cam9IP.Text = CAM9_parser[0];
                    cBx_cam9.SelectedIndex = FindCamRTSPLoc(CAM9_parser[1], RTSP_Name);
                    //cBx_cam9.SelectedIndex = Convert.ToInt16(CAM9_parser[1]);
                    tBx_cam9folder.Text = CAM9_parser[2];
                    tBx_cam9file.Text = CAM9_parser[3];

                    //Load the Camera 10 settings
                    string[] CAM10_parser = lines[22].Split(delimiterStrings);
                    tBx_cam10IP.Text = CAM10_parser[0];
                    cBx_cam10.SelectedIndex = FindCamRTSPLoc(CAM10_parser[1], RTSP_Name);
                    //cBx_cam10.SelectedIndex = Convert.ToInt16(CAM10_parser[1]);
                    tBx_cam10folder.Text = CAM10_parser[2];
                    tBx_cam10file.Text = CAM10_parser[3];

                    //Load the WinSCP installation location 
                    string[] WinSCP_INST_LOC_parser = lines[24].Split(delimiterStrings);
                    tBx_WinSCP_FL.Text = WinSCP_INST_LOC_parser[1];
                    //Load the Camera 1 Bug Report settings
                    string[] CAM1BR_parser = lines[26].Split(delimiterStrings);
                    tBx_Cam1_BRFN.Text = CAM1BR_parser[0];
                    tBx_Cam1_SSHUN.Text = CAM1BR_parser[1];
                    tBx_Cam1_SSHPW.Text = CAM1BR_parser[2];
                    cBx_Cam1_BRS.Text = CAM1BR_parser[3];
                    //Load the Camera 2 Bug Report settings
                    string[] CAM2BR_parser = lines[28].Split(delimiterStrings);
                    tBx_Cam2_BRFN.Text = CAM2BR_parser[0];
                    tBx_Cam2_SSHUN.Text = CAM2BR_parser[1];
                    tBx_Cam2_SSHPW.Text = CAM2BR_parser[2];
                    cBx_Cam2_BRS.Text = CAM2BR_parser[3];
                    //Load the Camera 3 Bug Report settings
                    string[] CAM3BR_parser = lines[30].Split(delimiterStrings);
                    tBx_Cam3_BRFN.Text = CAM3BR_parser[0];
                    tBx_Cam3_SSHUN.Text = CAM3BR_parser[1];
                    tBx_Cam3_SSHPW.Text = CAM3BR_parser[2];
                    cBx_Cam3_BRS.Text = CAM3BR_parser[3];
                    //Load the Camera 4 Bug Report settings
                    string[] CAM4BR_parser = lines[32].Split(delimiterStrings);
                    tBx_Cam4_BRFN.Text = CAM4BR_parser[0];
                    tBx_Cam4_SSHUN.Text = CAM4BR_parser[1];
                    tBx_Cam4_SSHPW.Text = CAM4BR_parser[2];
                    cBx_Cam4_BRS.Text = CAM4BR_parser[3];
                    //Load the Camera 5 Bug Report settings
                    string[] CAM5BR_parser = lines[34].Split(delimiterStrings);
                    tBx_Cam5_BRFN.Text = CAM5BR_parser[0];
                    tBx_Cam5_SSHUN.Text = CAM5BR_parser[1];
                    tBx_Cam5_SSHPW.Text = CAM5BR_parser[2];
                    cBx_Cam5_BRS.Text = CAM5BR_parser[3];
                    //Load the Camera 6 Bug Report settings
                    string[] CAM6BR_parser = lines[36].Split(delimiterStrings);
                    tBx_Cam6_BRFN.Text = CAM6BR_parser[0];
                    tBx_Cam6_SSHUN.Text = CAM6BR_parser[1];
                    tBx_Cam6_SSHPW.Text = CAM6BR_parser[2];
                    cBx_Cam6_BRS.Text = CAM6BR_parser[3];
                    //Load the Camera 7 Bug Report settings
                    string[] CAM7BR_parser = lines[38].Split(delimiterStrings);
                    tBx_Cam7_BRFN.Text = CAM7BR_parser[0];
                    tBx_Cam7_SSHUN.Text = CAM7BR_parser[1];
                    tBx_Cam7_SSHPW.Text = CAM7BR_parser[2];
                    cBx_Cam7_BRS.Text = CAM7BR_parser[3];
                    //Load the Camera 8 Bug Report settings
                    string[] CAM8BR_parser = lines[40].Split(delimiterStrings);
                    tBx_Cam8_BRFN.Text = CAM8BR_parser[0];
                    tBx_Cam8_SSHUN.Text = CAM8BR_parser[1];
                    tBx_Cam8_SSHPW.Text = CAM8BR_parser[2];
                    cBx_Cam8_BRS.Text = CAM8BR_parser[3];
                    //Load the Camera 9 Bug Report settings
                    string[] CAM9BR_parser = lines[42].Split(delimiterStrings);
                    tBx_Cam9_BRFN.Text = CAM9BR_parser[0];
                    tBx_Cam9_SSHUN.Text = CAM9BR_parser[1];
                    tBx_Cam9_SSHPW.Text = CAM9BR_parser[2];
                    cBx_Cam9_BRS.Text = CAM9BR_parser[3];
                    //Load the Camera 10 Bug Report settings
                    string[] CAM10BR_parser = lines[44].Split(delimiterStrings);
                    tBx_Cam10_BRFN.Text = CAM10BR_parser[0];
                    tBx_Cam10_SSHUN.Text = CAM10BR_parser[1];
                    tBx_Cam10_SSHPW.Text = CAM10BR_parser[2];
                    cBx_Cam10_BRS.Text = CAM10BR_parser[3];


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }     

        }

        private void ckBx_Cam1_br_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true & ckBx_Cam1_br.Checked == true)
            {
                tBx_Cam1_BRFN.Enabled = true;
                tBx_Cam1_SSHUN.Enabled = true;
                tBx_Cam1_SSHPW.Enabled = true;
                cBx_Cam1_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam1_BRFN.Enabled = false;
                tBx_Cam1_SSHUN.Enabled = false;
                tBx_Cam1_SSHPW.Enabled = false;
                cBx_Cam1_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam2_br_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam2.Checked == true & ckBx_Cam2_br.Checked == true)
            {
                tBx_Cam2_BRFN.Enabled = true;
                tBx_Cam2_SSHUN.Enabled = true;
                tBx_Cam2_SSHPW.Enabled = true;
                cBx_Cam2_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam2_BRFN.Enabled = false;
                tBx_Cam2_SSHUN.Enabled = false;
                tBx_Cam2_SSHPW.Enabled = false;
                cBx_Cam2_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam3_br_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam3.Checked == true & ckBx_Cam3_br.Checked == true)
            {
                tBx_Cam3_BRFN.Enabled = true;
                tBx_Cam3_SSHUN.Enabled = true;
                tBx_Cam3_SSHPW.Enabled = true;
                cBx_Cam3_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam3_BRFN.Enabled = false;
                tBx_Cam3_SSHUN.Enabled = false;
                tBx_Cam3_SSHPW.Enabled = false;
                cBx_Cam3_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam4_br_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam4.Checked == true & ckBx_Cam4_br.Checked == true)
            {
                tBx_Cam4_BRFN.Enabled = true;
                tBx_Cam4_SSHUN.Enabled = true;
                tBx_Cam4_SSHPW.Enabled = true;
                cBx_Cam4_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam4_BRFN.Enabled = false;
                tBx_Cam4_SSHUN.Enabled = false;
                tBx_Cam4_SSHPW.Enabled = false;
                cBx_Cam4_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam5_br_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam5.Checked == true & ckBx_Cam5_br.Checked == true)
            {
                tBx_Cam5_BRFN.Enabled = true;
                tBx_Cam5_SSHUN.Enabled = true;
                tBx_Cam5_SSHPW.Enabled = true;
                cBx_Cam5_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam5_BRFN.Enabled = false;
                tBx_Cam5_SSHUN.Enabled = false;
                tBx_Cam5_SSHPW.Enabled = false;
                cBx_Cam5_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam6_br_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam6.Checked == true & ckBx_Cam6_br.Checked == true)
            {
                tBx_Cam6_BRFN.Enabled = true;
                tBx_Cam6_SSHUN.Enabled = true;
                tBx_Cam6_SSHPW.Enabled = true;
                cBx_Cam6_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam6_BRFN.Enabled = false;
                tBx_Cam6_SSHUN.Enabled = false;
                tBx_Cam6_SSHPW.Enabled = false;
                cBx_Cam6_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam7_br_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam7.Checked == true & ckBx_Cam7_br.Checked == true)
            {
                tBx_Cam7_BRFN.Enabled = true;
                tBx_Cam7_SSHUN.Enabled = true;
                tBx_Cam7_SSHPW.Enabled = true;
                cBx_Cam7_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam7_BRFN.Enabled = false;
                tBx_Cam7_SSHUN.Enabled = false;
                tBx_Cam7_SSHPW.Enabled = false;
                cBx_Cam7_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam8_br_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam8.Checked == true & ckBx_Cam8_br.Checked == true)
            {
                tBx_Cam8_BRFN.Enabled = true;
                tBx_Cam8_SSHUN.Enabled = true;
                tBx_Cam8_SSHPW.Enabled = true;
                cBx_Cam8_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam8_BRFN.Enabled = false;
                tBx_Cam8_SSHUN.Enabled = false;
                tBx_Cam8_SSHPW.Enabled = false;
                cBx_Cam8_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam9_br_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckBx_cam9.Checked == true & ckBx_Cam9_br.Checked == true)
            {
                tBx_Cam9_BRFN.Enabled = true;
                tBx_Cam9_SSHUN.Enabled = true;
                tBx_Cam9_SSHPW.Enabled = true;
                cBx_Cam9_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam9_BRFN.Enabled = false;
                tBx_Cam9_SSHUN.Enabled = false;
                tBx_Cam9_SSHPW.Enabled = false;
                cBx_Cam9_BRS.Enabled = false;
            }
        }

        private void ckBx_Cam10_br_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckBx_cam10.Checked == true & ckBx_Cam10_br.Checked == true)
            {
                tBx_Cam10_BRFN.Enabled = true;
                tBx_Cam10_SSHUN.Enabled = true;
                tBx_Cam10_SSHPW.Enabled = true;
                cBx_Cam10_BRS.Enabled = true;
            }
            else
            {
                tBx_Cam10_BRFN.Enabled = false;
                tBx_Cam10_SSHUN.Enabled = false;
                tBx_Cam10_SSHPW.Enabled = false;
                cBx_Cam10_BRS.Enabled = false;
            }
        }

        private void ckBx_cam1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
                ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam1.SelectedIndex + 1] == "TRUE") & (ckBx_cam1.Checked == true))
            {
                ckBx_Cam1_br.Enabled = true;
            }
            else
            {
                ckBx_Cam1_br.Enabled = false;
                tBx_Cam1_BRFN.Enabled = false;
                tBx_Cam1_SSHUN.Enabled = false;
                tBx_Cam1_SSHPW.Enabled = false;
                cBx_Cam1_BRS.Enabled = false;

            }
        }

        private void ckBx_cam2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
               ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam2.SelectedIndex + 1] == "TRUE") & (ckBx_cam2.Checked == true))
            {
                ckBx_Cam2_br.Enabled = true;
            }
            else
            {
                ckBx_Cam2_br.Enabled = false;
                tBx_Cam2_BRFN.Enabled = false;
                tBx_Cam2_SSHUN.Enabled = false;
                tBx_Cam2_SSHPW.Enabled = false;
                cBx_Cam2_BRS.Enabled = false;

            }
        }

        private void ckBx_cam3_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
               ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam3.SelectedIndex + 1] == "TRUE") & (ckBx_cam3.Checked == true))
            {
                ckBx_Cam3_br.Enabled = true;
            }
            else
            {
                ckBx_Cam3_br.Enabled = false;
                tBx_Cam3_BRFN.Enabled = false;
                tBx_Cam3_SSHUN.Enabled = false;
                tBx_Cam3_SSHPW.Enabled = false;
                cBx_Cam3_BRS.Enabled = false;

            }
        }

        private void ckBx_cam4_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
                ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam4.SelectedIndex + 1] == "TRUE") & (ckBx_cam4.Checked == true))
            {
                ckBx_Cam4_br.Enabled = true;
            }
            else
            {
                ckBx_Cam4_br.Enabled = false;
                tBx_Cam4_BRFN.Enabled = false;
                tBx_Cam4_SSHUN.Enabled = false;
                tBx_Cam4_SSHPW.Enabled = false;
                cBx_Cam4_BRS.Enabled = false;

            }
        }

        private void ckBx_cam5_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
               ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam5.SelectedIndex + 1] == "TRUE") & (ckBx_cam5.Checked == true))
            {
                ckBx_Cam5_br.Enabled = true;
            }
            else
            {
                ckBx_Cam5_br.Enabled = false;
                tBx_Cam5_BRFN.Enabled = false;
                tBx_Cam5_SSHUN.Enabled = false;
                tBx_Cam5_SSHPW.Enabled = false;
                cBx_Cam5_BRS.Enabled = false;
            }
        }

        private void ckBx_cam6_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
                 ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam6.SelectedIndex + 1] == "TRUE") & (ckBx_cam6.Checked == true))
            {
                ckBx_Cam6_br.Enabled = true;
            }
            else
            {
                ckBx_Cam6_br.Enabled = false;
                tBx_Cam6_BRFN.Enabled = false;
                tBx_Cam6_SSHUN.Enabled = false;
                tBx_Cam6_SSHPW.Enabled = false;
                cBx_Cam6_BRS.Enabled = false;
            } 
        }

        private void ckBx_cam7_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
               ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam7.SelectedIndex + 1] == "TRUE") & (ckBx_cam7.Checked == true))
            {
                ckBx_Cam7_br.Enabled = true;
            }
            else
            {
                ckBx_Cam7_br.Enabled = false;
                tBx_Cam7_BRFN.Enabled = false;
                tBx_Cam7_SSHUN.Enabled = false;
                tBx_Cam7_SSHPW.Enabled = false;
                cBx_Cam7_BRS.Enabled = false;
            }
        }

        private void ckBx_cam8_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
               ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam8.SelectedIndex + 1] == "TRUE") & (ckBx_cam8.Checked == true))
            {
                ckBx_Cam8_br.Enabled = true;
            }
            else
            {
                ckBx_Cam8_br.Enabled = false;
                tBx_Cam8_BRFN.Enabled = false;
                tBx_Cam8_SSHUN.Enabled = false;
                tBx_Cam8_SSHPW.Enabled = false;
                cBx_Cam8_BRS.Enabled = false;
            }
        }

        private void ckBx_cam9_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
                ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }

            if ((RTSP_EBR[cBx_cam9.SelectedIndex + 1] == "TRUE") & (ckBx_cam9.Checked == true))
            {
                ckBx_Cam9_br.Enabled = true;
            }
            else
            {
                ckBx_Cam9_br.Enabled = false;
                tBx_Cam9_BRFN.Enabled = false;
                tBx_Cam9_SSHUN.Enabled = false;
                tBx_Cam9_SSHPW.Enabled = false;
                cBx_Cam9_BRS.Enabled = false;
            }
        }

        private void ckBx_cam10_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBx_cam1.Checked == true | ckBx_cam2.Checked == true | ckBx_cam3.Checked == true | ckBx_cam4.Checked == true | ckBx_cam5.Checked == true |
               ckBx_cam6.Checked == true | ckBx_cam7.Checked == true | ckBx_cam8.Checked == true | ckBx_cam9.Checked == true | ckBx_cam10.Checked == true)
            {
                // Enable the start button
                btn_Start.Enabled = true;
            }
            else
            {
                // Disable the start button
                btn_Start.Enabled = false;
            }
            if ((RTSP_EBR[cBx_cam10.SelectedIndex + 1] == "TRUE") & (ckBx_cam10.Checked == true))
            {
                ckBx_Cam10_br.Enabled = true;
            }
            else
            {
                ckBx_Cam10_br.Enabled = false;
                tBx_Cam10_BRFN.Enabled = false;
                tBx_Cam10_SSHUN.Enabled = false;
                tBx_Cam10_SSHPW.Enabled = false;
                cBx_Cam10_BRS.Enabled = false;
            }
        }

        public static int FindCamRTSPLoc(string cam_name, string[] RTSP_Name)
        {
            int index = 0;
            int false_count = 0;
            for (int i = 1; i < RTSP_Name.Length; i++)
            {
                bool result = cam_name.Equals(RTSP_Name[i], StringComparison.OrdinalIgnoreCase);
                if (result == true)
                {
                    index = i - 1;
                }
                if (result == false)
                {
                    false_count++;
                }

            }
            // if the false counts equal the length of the array, that particular name is not in the list.
            // The routint will default to the first item in the index.
            if (false_count == RTSP_Name.Length)
            {
                MessageBox.Show("Camera Name: " + cam_name + " cannot be found. Defaulting to first name in RTSP list.");
                index = 0;
            }
            return index;
        }   
    }
}
