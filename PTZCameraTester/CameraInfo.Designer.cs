namespace PTZCameraTester
{
    partial class CameraInfo
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
            this.connect = new System.Windows.Forms.Button();
            this.Field_CameraIPAddress = new System.Windows.Forms.Label();
            this.CameraIpAddress = new System.Windows.Forms.TextBox();
            this.Field_PortLabel = new System.Windows.Forms.Label();
            this.CameraPort = new System.Windows.Forms.TextBox();
            this.ModelNametxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ModelNumbertxtbox = new System.Windows.Forms.TextBox();
            this.getconfigtxtbox = new System.Windows.Forms.RichTextBox();
            this.getconfiglabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.getlocationtxtbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.isRegisteredtxtbox = new System.Windows.Forms.TextBox();
            this.resetconfigurationbutton = new System.Windows.Forms.Button();
            this.resetsecuritybutton = new System.Windows.Forms.Button();
            this.resetsyncedbutton = new System.Windows.Forms.Button();
            this.getconfigurationbutton = new System.Windows.Forms.Button();
            this.restartbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(77, 38);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(102, 24);
            this.connect.TabIndex = 18;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // Field_CameraIPAddress
            // 
            this.Field_CameraIPAddress.AutoSize = true;
            this.Field_CameraIPAddress.Location = new System.Drawing.Point(12, 15);
            this.Field_CameraIPAddress.Name = "Field_CameraIPAddress";
            this.Field_CameraIPAddress.Size = new System.Drawing.Size(59, 13);
            this.Field_CameraIPAddress.TabIndex = 17;
            this.Field_CameraIPAddress.Text = "Camera IP:";
            // 
            // CameraIpAddress
            // 
            this.CameraIpAddress.Location = new System.Drawing.Point(77, 12);
            this.CameraIpAddress.Name = "CameraIpAddress";
            this.CameraIpAddress.Size = new System.Drawing.Size(300, 20);
            this.CameraIpAddress.TabIndex = 16;
            this.CameraIpAddress.TextChanged += new System.EventHandler(this.CameraIpAddress_TextChanged);
            // 
            // Field_PortLabel
            // 
            this.Field_PortLabel.AutoSize = true;
            this.Field_PortLabel.Location = new System.Drawing.Point(388, 15);
            this.Field_PortLabel.Name = "Field_PortLabel";
            this.Field_PortLabel.Size = new System.Drawing.Size(29, 13);
            this.Field_PortLabel.TabIndex = 21;
            this.Field_PortLabel.Text = "Port:";
            // 
            // CameraPort
            // 
            this.CameraPort.Location = new System.Drawing.Point(417, 12);
            this.CameraPort.Name = "CameraPort";
            this.CameraPort.Size = new System.Drawing.Size(101, 20);
            this.CameraPort.TabIndex = 20;
            this.CameraPort.Text = "80";
            // 
            // ModelNametxtbox
            // 
            this.ModelNametxtbox.Location = new System.Drawing.Point(16, 142);
            this.ModelNametxtbox.Name = "ModelNametxtbox";
            this.ModelNametxtbox.Size = new System.Drawing.Size(176, 20);
            this.ModelNametxtbox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Camera Information";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "PelcoConfiguration ModelName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "PelcoConfiguration ModelNumber";
            // 
            // ModelNumbertxtbox
            // 
            this.ModelNumbertxtbox.Location = new System.Drawing.Point(15, 190);
            this.ModelNumbertxtbox.Name = "ModelNumbertxtbox";
            this.ModelNumbertxtbox.Size = new System.Drawing.Size(177, 20);
            this.ModelNumbertxtbox.TabIndex = 25;
            // 
            // getconfigtxtbox
            // 
            this.getconfigtxtbox.Location = new System.Drawing.Point(277, 142);
            this.getconfigtxtbox.Name = "getconfigtxtbox";
            this.getconfigtxtbox.Size = new System.Drawing.Size(356, 144);
            this.getconfigtxtbox.TabIndex = 27;
            this.getconfigtxtbox.Text = "";
            // 
            // getconfiglabel
            // 
            this.getconfiglabel.AutoSize = true;
            this.getconfiglabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getconfiglabel.Location = new System.Drawing.Point(277, 123);
            this.getconfiglabel.Name = "getconfiglabel";
            this.getconfiglabel.Size = new System.Drawing.Size(213, 15);
            this.getconfiglabel.TabIndex = 28;
            this.getconfiglabel.Text = "PelcoConfiguration - GetConfiguration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "PelcoConfiguration GetLocation";
            // 
            // getlocationtxtbox
            // 
            this.getlocationtxtbox.Location = new System.Drawing.Point(12, 237);
            this.getlocationtxtbox.Name = "getlocationtxtbox";
            this.getlocationtxtbox.Size = new System.Drawing.Size(244, 20);
            this.getlocationtxtbox.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "PelcoConfiguration IsRegistered";
            // 
            // isRegisteredtxtbox
            // 
            this.isRegisteredtxtbox.Location = new System.Drawing.Point(16, 284);
            this.isRegisteredtxtbox.Name = "isRegisteredtxtbox";
            this.isRegisteredtxtbox.Size = new System.Drawing.Size(177, 20);
            this.isRegisteredtxtbox.TabIndex = 31;
            // 
            // resetconfigurationbutton
            // 
            this.resetconfigurationbutton.Location = new System.Drawing.Point(447, 292);
            this.resetconfigurationbutton.Name = "resetconfigurationbutton";
            this.resetconfigurationbutton.Size = new System.Drawing.Size(133, 23);
            this.resetconfigurationbutton.TabIndex = 33;
            this.resetconfigurationbutton.Text = "Reset Configuration";
            this.resetconfigurationbutton.UseVisualStyleBackColor = true;
            this.resetconfigurationbutton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // resetsecuritybutton
            // 
            this.resetsecuritybutton.Location = new System.Drawing.Point(12, 310);
            this.resetsecuritybutton.Name = "resetsecuritybutton";
            this.resetsecuritybutton.Size = new System.Drawing.Size(97, 23);
            this.resetsecuritybutton.TabIndex = 34;
            this.resetsecuritybutton.Text = "Reset Security";
            this.resetsecuritybutton.UseVisualStyleBackColor = true;
            this.resetsecuritybutton.Click += new System.EventHandler(this.resetsecuritybutton_Click);
            // 
            // resetsyncedbutton
            // 
            this.resetsyncedbutton.Location = new System.Drawing.Point(121, 310);
            this.resetsyncedbutton.Name = "resetsyncedbutton";
            this.resetsyncedbutton.Size = new System.Drawing.Size(99, 23);
            this.resetsyncedbutton.TabIndex = 35;
            this.resetsyncedbutton.Text = "Reset Synced";
            this.resetsyncedbutton.UseVisualStyleBackColor = true;
            this.resetsyncedbutton.Click += new System.EventHandler(this.resetsyncedbutton_Click);
            // 
            // getconfigurationbutton
            // 
            this.getconfigurationbutton.Location = new System.Drawing.Point(284, 292);
            this.getconfigurationbutton.Name = "getconfigurationbutton";
            this.getconfigurationbutton.Size = new System.Drawing.Size(133, 23);
            this.getconfigurationbutton.TabIndex = 36;
            this.getconfigurationbutton.Text = "Get Configuration";
            this.getconfigurationbutton.UseVisualStyleBackColor = true;
            this.getconfigurationbutton.Click += new System.EventHandler(this.getconfigurationbutton_Click);
            // 
            // restartbutton
            // 
            this.restartbutton.Location = new System.Drawing.Point(59, 339);
            this.restartbutton.Name = "restartbutton";
            this.restartbutton.Size = new System.Drawing.Size(99, 23);
            this.restartbutton.TabIndex = 37;
            this.restartbutton.Text = "Restart";
            this.restartbutton.UseVisualStyleBackColor = true;
            this.restartbutton.Click += new System.EventHandler(this.restartbutton_Click);
            // 
            // CameraInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 408);
            this.Controls.Add(this.restartbutton);
            this.Controls.Add(this.getconfigurationbutton);
            this.Controls.Add(this.resetsyncedbutton);
            this.Controls.Add(this.resetsecuritybutton);
            this.Controls.Add(this.resetconfigurationbutton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isRegisteredtxtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.getlocationtxtbox);
            this.Controls.Add(this.getconfiglabel);
            this.Controls.Add(this.getconfigtxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ModelNumbertxtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ModelNametxtbox);
            this.Controls.Add(this.Field_PortLabel);
            this.Controls.Add(this.CameraPort);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.Field_CameraIPAddress);
            this.Controls.Add(this.CameraIpAddress);
            this.Name = "CameraInfo";
            this.Text = "CameraInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label Field_CameraIPAddress;
        public System.Windows.Forms.TextBox CameraIpAddress;
        private System.Windows.Forms.Label Field_PortLabel;
        public System.Windows.Forms.TextBox CameraPort;
        private System.Windows.Forms.TextBox ModelNametxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ModelNumbertxtbox;
        private System.Windows.Forms.RichTextBox getconfigtxtbox;
        private System.Windows.Forms.Label getconfiglabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox getlocationtxtbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox isRegisteredtxtbox;
        private System.Windows.Forms.Button resetconfigurationbutton;
        private System.Windows.Forms.Button resetsecuritybutton;
        private System.Windows.Forms.Button resetsyncedbutton;
        private System.Windows.Forms.Button getconfigurationbutton;
        private System.Windows.Forms.Button restartbutton;
    }
}