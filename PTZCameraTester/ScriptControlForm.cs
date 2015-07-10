using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PTZCameraTester.Tests;
using PTZCameraTester.ScriptControl;

namespace PTZCameraTester
{
    public partial class ScriptControlForm : Form
    {

        int totalmaxpreset;
       
        //string[] presetnamearray = new string[] { };

        public ScriptControlForm(string CameraIP)
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

        private static void catchNoCommunicateWithCamera()
        {
            MessageBox.Show("Error: Cannot Communicate with Camera.");
            return;
        }

        private void queryscriptsbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            scriptlisttxtbox.Clear();
            try
            {
                
                //This is where we send an empty response inside the soap request
                ScriptQuery scriptquery = new ScriptQuery();

                //Returns a list of infomration.
                ScriptList scriptlist = svlib.ScriptClient.QueryScripts(scriptquery);
                //scriptlisttxtbox.Text = Convert.ToString(scriptlist.maxPresets);

                //Used to determine how many times we interate through the array.
                int totalentries = scriptlist.totalEntries;
                totalmaxpreset = scriptlist.maxPresets;
                int[] totalmaxpresetarray = new int[totalmaxpreset];
                
                //Creates array for max preset number
                int i;
                for (i = 0; i < totalmaxpreset; i++)
                {
                    totalmaxpresetarray[i] = i;
                }

                List<int> list = new List<int>(totalmaxpresetarray);
                list.RemoveAt(0);
                int[] newtotalmaxpresetarray = list.ToArray();

               
                //for (i = 0; i< totalentries; i++)
                //{
                    
                    
                //    }
                //}
              
                //This is where we put script information into an array;
                Script[] scripts = scriptlist.scripts;
                
                
                foreach (Script script in scripts)
                {
                    //iterates through the array and pull the name field.                    
                    scriptlisttxtbox.AppendText(script.id+", "+script.name+", "+script.description+"\n");
                                     
                }

                //Indicates the total size of the array
                string[] presetnamearray = new string[totalentries];
                                
                for (i = 0; i < totalentries; i++)
                {
                    //Iterates through the scripts xml and assign the name into array.
                    presetnamearray[i] = scripts[i].name;
                }

                //Assigns source of the list.
                deletepresetlistbox.DataSource = presetnamearray;

                maxentriestxtbox.Text = Convert.ToString(scriptlist.maxEntries);
                maxpresettxtbox.Text = Convert.ToString(scriptlist.maxPresets);
                maxpatternstxtbox.Text = Convert.ToString(scriptlist.maxPatterns);
                totalentriestxtbox.Text = Convert.ToString(scriptlist.totalEntries);
                presetnumberlistbox.DataSource = newtotalmaxpresetarray;

                //Need to generate array from script.
                //deletepresetlistbox.DataSource = presetnamearray;

            }
            catch
            {
                catchNoCommunicateWithCamera();
               
            }        



        }

        private void addpresetbutton_Click(object sender, EventArgs e)
        {
            string scriptnumber = Convert.ToString(presetnumberlistbox.SelectedItem);
            string requiredPresetText = "PRESET";
            string scriptname = requiredPresetText + scriptnumber;
            ServiceLib svlib = new ServiceLib(CameraAddress);
            
            try
            {
                svlib.ScriptClient.BeginScript(scriptname);
                svlib.ScriptClient.EndScript(scriptname);
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

            queryscriptsbutton_Click(sender, e);
                
        }

        private void connect_Click(object sender, EventArgs e)
        {

            //refreshes the form with updated information.
            queryscriptsbutton_Click(sender, e);

            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                ScriptQuery scriptquery = new ScriptQuery();                
                ScriptList scriptlist = svlib.ScriptClient.QueryScripts(scriptquery);
                Script[] scripts = scriptlist.scripts;
                int totalentries = scriptlist.totalEntries;

                //Indicates the total size of the array
                string[] presetnamearray = new string[totalentries];

                for (int i = 0; i < totalentries; i++)                
                {
                    //Iterates through the scripts xml and assign the name into array.
                    string presetdisplayname = scripts[i].name;
                    //+", " + scripts[i].id + ", " + scripts[i].description;
                    presetnamearray[i] = presetdisplayname;
                }
                
                //Assigns source of the list.
                deletepresetlistbox.DataSource = presetnamearray;
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

            

        }

        private void removepresetbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);
            
            try
            {
                string scriptname = Convert.ToString(deletepresetlistbox.SelectedItem);
                
                //Some reason it adds an empty space in the front of name.  We need to clean it up or else camera will not accept the space.
                string newscriptname = scriptname.Replace(" ", string.Empty);               
                svlib.ScriptClient.DeleteScript(newscriptname);

                queryscriptsbutton_Click(sender, e);
                
            }

            catch
            {
                catchNoCommunicateWithCamera();
            }

        }

        private void presetnumberlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void executescriptbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                string scriptname = Convert.ToString(deletepresetlistbox.SelectedItem);

                //Some reason it adds an empty space in the front of name.  We need to clean it up or else camera will not accept the space.
                string newscriptname = scriptname.Replace(" ", string.Empty);
                svlib.ScriptClient.ExecuteScript(newscriptname);             

            }

            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void haltscriptbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                string scriptname = Convert.ToString(deletepresetlistbox.SelectedItem);

                //Some reason it adds an empty space in the front of name.  We need to clean it up or else camera will not accept the space.
                string newscriptname = scriptname.Replace(" ", string.Empty);
                
                //Not sure why this is needed in the arguement.  SOAP request does not have it.  Could be requirement from older ptz cameras.
                int pid = 0;
                svlib.ScriptClient.HaltScript(newscriptname, pid);

            }

            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

        private void createmaxpresetbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                ScriptQuery scriptquery = new ScriptQuery();
                ScriptList scriptlist = svlib.ScriptClient.QueryScripts(scriptquery);               
                totalmaxpreset = scriptlist.maxPresets;

                //Create the loop that reach maximum total preset.
                int[] totalmaxpresetarray = new int[totalmaxpreset];

                //Prepare the string for preset name
                string requiredPresetText = "PRESET";
                string scriptname = requiredPresetText;

                //Creates array for max preset number
                int i;
                for (i = 1; i <= totalmaxpreset; i++)
                {
                    svlib.ScriptClient.BeginScript(scriptname+i);
                    svlib.ScriptClient.EndScript(scriptname+i);
                    queryscriptsbutton_Click(sender, e);
                }
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }

            
        }

        private void deleteallpresetbutton_Click(object sender, EventArgs e)
        {
            ServiceLib svlib = new ServiceLib(CameraAddress);

            try
            {
                ScriptQuery scriptquery = new ScriptQuery();
                ScriptList scriptlist = svlib.ScriptClient.QueryScripts(scriptquery);
                int totalpreset = scriptlist.totalEntries;

                //Create the loop that reach maximum total preset.
                int[] totalmaxpresetarray = new int[totalpreset];

                //Prepare the string for preset name
                string requiredPresetText = "PRESET";
                string scriptname = requiredPresetText;

                //Creates array for max preset number
                int i;
                for (i = 1; i <= totalmaxpreset; i++)
                {
                    svlib.ScriptClient.DeleteScript(scriptname + i);
                    queryscriptsbutton_Click(sender, e);
                }
            }
            catch
            {
                catchNoCommunicateWithCamera();
            }
        }

       
    }
}
