namespace PTZCameraTester
{
    partial class ScriptControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CameraPort = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.Field_CameraIPAddress = new System.Windows.Forms.Label();
            this.CameraIpAddress = new System.Windows.Forms.TextBox();
            this.queryscriptsbutton = new System.Windows.Forms.Button();
            this.scriptlisttxtbox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalentriestxtbox = new System.Windows.Forms.TextBox();
            this.maxpatternstxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxpresettxtbox = new System.Windows.Forms.TextBox();
            this.maxentriestxtbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addpresetbutton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.removepresetbutton = new System.Windows.Forms.Button();
            this.deletepresetlistbox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.presetnumberlistbox = new System.Windows.Forms.ListBox();
            this.executescriptbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.haltscriptbutton = new System.Windows.Forms.Button();
            this.createmaxpresetbutton = new System.Windows.Forms.Button();
            this.deleteallpresetbutton = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraPort
            // 
            this.CameraPort.Location = new System.Drawing.Point(419, 12);
            this.CameraPort.Name = "CameraPort";
            this.CameraPort.Size = new System.Drawing.Size(101, 20);
            this.CameraPort.TabIndex = 33;
            this.CameraPort.Text = "80";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(79, 38);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(102, 24);
            this.connect.TabIndex = 32;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Field_CameraIPAddress
            // 
            this.Field_CameraIPAddress.AutoSize = true;
            this.Field_CameraIPAddress.Location = new System.Drawing.Point(14, 15);
            this.Field_CameraIPAddress.Name = "Field_CameraIPAddress";
            this.Field_CameraIPAddress.Size = new System.Drawing.Size(59, 13);
            this.Field_CameraIPAddress.TabIndex = 31;
            this.Field_CameraIPAddress.Text = "Camera IP:";
            // 
            // CameraIpAddress
            // 
            this.CameraIpAddress.Location = new System.Drawing.Point(79, 12);
            this.CameraIpAddress.Name = "CameraIpAddress";
            this.CameraIpAddress.Size = new System.Drawing.Size(300, 20);
            this.CameraIpAddress.TabIndex = 30;
            // 
            // queryscriptsbutton
            // 
            this.queryscriptsbutton.Location = new System.Drawing.Point(17, 93);
            this.queryscriptsbutton.Name = "queryscriptsbutton";
            this.queryscriptsbutton.Size = new System.Drawing.Size(121, 24);
            this.queryscriptsbutton.TabIndex = 95;
            this.queryscriptsbutton.Text = "QueryScripts";
            this.queryscriptsbutton.UseVisualStyleBackColor = true;
            this.queryscriptsbutton.Click += new System.EventHandler(this.queryscriptsbutton_Click);
            // 
            // scriptlisttxtbox
            // 
            this.scriptlisttxtbox.Location = new System.Drawing.Point(419, 221);
            this.scriptlisttxtbox.Name = "scriptlisttxtbox";
            this.scriptlisttxtbox.Size = new System.Drawing.Size(245, 149);
            this.scriptlisttxtbox.TabIndex = 96;
            this.scriptlisttxtbox.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.totalentriestxtbox);
            this.groupBox3.Controls.Add(this.maxpatternstxtbox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.maxpresettxtbox);
            this.groupBox3.Controls.Add(this.maxentriestxtbox);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(419, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 110);
            this.groupBox3.TabIndex = 105;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Query Script Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 100;
            this.label3.Text = "Total Entries";
            // 
            // totalentriestxtbox
            // 
            this.totalentriestxtbox.Location = new System.Drawing.Point(128, 75);
            this.totalentriestxtbox.Name = "totalentriestxtbox";
            this.totalentriestxtbox.Size = new System.Drawing.Size(101, 20);
            this.totalentriestxtbox.TabIndex = 99;
            // 
            // maxpatternstxtbox
            // 
            this.maxpatternstxtbox.Location = new System.Drawing.Point(12, 75);
            this.maxpatternstxtbox.Name = "maxpatternstxtbox";
            this.maxpatternstxtbox.Size = new System.Drawing.Size(101, 20);
            this.maxpatternstxtbox.TabIndex = 97;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 98;
            this.label6.Text = "Max Patterns";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(125, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 96;
            this.label5.Text = "Max Presets";
            // 
            // maxpresettxtbox
            // 
            this.maxpresettxtbox.Location = new System.Drawing.Point(129, 35);
            this.maxpresettxtbox.Name = "maxpresettxtbox";
            this.maxpresettxtbox.Size = new System.Drawing.Size(101, 20);
            this.maxpresettxtbox.TabIndex = 95;
            // 
            // maxentriestxtbox
            // 
            this.maxentriestxtbox.Location = new System.Drawing.Point(13, 35);
            this.maxentriestxtbox.Name = "maxentriestxtbox";
            this.maxentriestxtbox.Size = new System.Drawing.Size(101, 20);
            this.maxentriestxtbox.TabIndex = 93;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 94;
            this.label11.Text = "Max Entries";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(416, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 101;
            this.label1.Text = "ID, Name, Description";
            // 
            // addpresetbutton
            // 
            this.addpresetbutton.Location = new System.Drawing.Point(271, 93);
            this.addpresetbutton.Name = "addpresetbutton";
            this.addpresetbutton.Size = new System.Drawing.Size(79, 55);
            this.addpresetbutton.TabIndex = 117;
            this.addpresetbutton.Text = "Add/Update Preset";
            this.addpresetbutton.UseVisualStyleBackColor = true;
            this.addpresetbutton.Click += new System.EventHandler(this.addpresetbutton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(141, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 116;
            this.label9.Text = "Preset Name";
            // 
            // removepresetbutton
            // 
            this.removepresetbutton.Location = new System.Drawing.Point(17, 136);
            this.removepresetbutton.Name = "removepresetbutton";
            this.removepresetbutton.Size = new System.Drawing.Size(121, 26);
            this.removepresetbutton.TabIndex = 120;
            this.removepresetbutton.Text = "Remove Preset";
            this.removepresetbutton.UseVisualStyleBackColor = true;
            this.removepresetbutton.Click += new System.EventHandler(this.removepresetbutton_Click);
            // 
            // deletepresetlistbox
            // 
            this.deletepresetlistbox.FormattingEnabled = true;
            this.deletepresetlistbox.Location = new System.Drawing.Point(144, 93);
            this.deletepresetlistbox.Name = "deletepresetlistbox";
            this.deletepresetlistbox.Size = new System.Drawing.Size(121, 277);
            this.deletepresetlistbox.TabIndex = 121;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(355, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 122;
            this.label2.Text = "PRESET";
            // 
            // presetnumberlistbox
            // 
            this.presetnumberlistbox.FormattingEnabled = true;
            this.presetnumberlistbox.Location = new System.Drawing.Point(358, 93);
            this.presetnumberlistbox.Name = "presetnumberlistbox";
            this.presetnumberlistbox.Size = new System.Drawing.Size(53, 277);
            this.presetnumberlistbox.TabIndex = 123;
            this.presetnumberlistbox.SelectedIndexChanged += new System.EventHandler(this.presetnumberlistbox_SelectedIndexChanged);
            // 
            // executescriptbutton
            // 
            this.executescriptbutton.Location = new System.Drawing.Point(17, 178);
            this.executescriptbutton.Name = "executescriptbutton";
            this.executescriptbutton.Size = new System.Drawing.Size(121, 26);
            this.executescriptbutton.TabIndex = 124;
            this.executescriptbutton.Text = "Execute Script";
            this.executescriptbutton.UseVisualStyleBackColor = true;
            this.executescriptbutton.Click += new System.EventHandler(this.executescriptbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(356, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 15);
            this.label4.TabIndex = 125;
            this.label4.Text = "* PATTERNS CREATED IN WEBUI";
            // 
            // haltscriptbutton
            // 
            this.haltscriptbutton.Location = new System.Drawing.Point(16, 219);
            this.haltscriptbutton.Name = "haltscriptbutton";
            this.haltscriptbutton.Size = new System.Drawing.Size(121, 26);
            this.haltscriptbutton.TabIndex = 126;
            this.haltscriptbutton.Text = "Halt Script";
            this.haltscriptbutton.UseVisualStyleBackColor = true;
            this.haltscriptbutton.Click += new System.EventHandler(this.haltscriptbutton_Click);
            // 
            // createmaxpresetbutton
            // 
            this.createmaxpresetbutton.Location = new System.Drawing.Point(271, 164);
            this.createmaxpresetbutton.Name = "createmaxpresetbutton";
            this.createmaxpresetbutton.Size = new System.Drawing.Size(79, 55);
            this.createmaxpresetbutton.TabIndex = 127;
            this.createmaxpresetbutton.Text = "Create Max Preset";
            this.createmaxpresetbutton.UseVisualStyleBackColor = true;
            this.createmaxpresetbutton.Click += new System.EventHandler(this.createmaxpresetbutton_Click);
            // 
            // deleteallpresetbutton
            // 
            this.deleteallpresetbutton.Location = new System.Drawing.Point(271, 234);
            this.deleteallpresetbutton.Name = "deleteallpresetbutton";
            this.deleteallpresetbutton.Size = new System.Drawing.Size(79, 55);
            this.deleteallpresetbutton.TabIndex = 128;
            this.deleteallpresetbutton.Text = "Delete All Preset";
            this.deleteallpresetbutton.UseVisualStyleBackColor = true;
            this.deleteallpresetbutton.Click += new System.EventHandler(this.deleteallpresetbutton_Click);
            // 
            // ScriptControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 441);
            this.Controls.Add(this.deleteallpresetbutton);
            this.Controls.Add(this.createmaxpresetbutton);
            this.Controls.Add(this.haltscriptbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.executescriptbutton);
            this.Controls.Add(this.presetnumberlistbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deletepresetlistbox);
            this.Controls.Add(this.removepresetbutton);
            this.Controls.Add(this.addpresetbutton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.scriptlisttxtbox);
            this.Controls.Add(this.queryscriptsbutton);
            this.Controls.Add(this.CameraPort);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.Field_CameraIPAddress);
            this.Controls.Add(this.CameraIpAddress);
            this.Name = "ScriptControlForm";
            this.Text = "ScriptControlForm";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox CameraPort;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label Field_CameraIPAddress;
        public System.Windows.Forms.TextBox CameraIpAddress;
        private System.Windows.Forms.Button queryscriptsbutton;
        private System.Windows.Forms.RichTextBox scriptlisttxtbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox totalentriestxtbox;
        public System.Windows.Forms.TextBox maxpatternstxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox maxpresettxtbox;
        public System.Windows.Forms.TextBox maxentriestxtbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addpresetbutton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button removepresetbutton;
        private System.Windows.Forms.ListBox deletepresetlistbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox presetnumberlistbox;
        private System.Windows.Forms.Button executescriptbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button haltscriptbutton;
        private System.Windows.Forms.Button createmaxpresetbutton;
        private System.Windows.Forms.Button deleteallpresetbutton;

    }
}