namespace PTZCameraTester
{
    partial class AlarmArrayForm
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
            this.Field_PortLabel = new System.Windows.Forms.Label();
            this.CameraPort = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.Field_CameraIPAddress = new System.Windows.Forms.Label();
            this.CameraIpAddress = new System.Windows.Forms.TextBox();
            this.getconfigurationbutton = new System.Windows.Forms.Button();
            this.resetalarmconfigurationbutton = new System.Windows.Forms.Button();
            this.getconfiglabel = new System.Windows.Forms.Label();
            this.getconfigtxtbox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.getarraysizetxtbox = new System.Windows.Forms.TextBox();
            this.alarmidtxtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.getalarmstatestxtbox = new System.Windows.Forms.RichTextBox();
            this.getalarmstatesbutton = new System.Windows.Forms.Button();
            this.setalarmstatebutton = new System.Windows.Forms.Button();
            this.setalarmconfigbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Field_PortLabel
            // 
            this.Field_PortLabel.AutoSize = true;
            this.Field_PortLabel.Location = new System.Drawing.Point(394, 15);
            this.Field_PortLabel.Name = "Field_PortLabel";
            this.Field_PortLabel.Size = new System.Drawing.Size(29, 13);
            this.Field_PortLabel.TabIndex = 26;
            this.Field_PortLabel.Text = "Port:";
            // 
            // CameraPort
            // 
            this.CameraPort.Location = new System.Drawing.Point(423, 12);
            this.CameraPort.Name = "CameraPort";
            this.CameraPort.Size = new System.Drawing.Size(101, 20);
            this.CameraPort.TabIndex = 25;
            this.CameraPort.Text = "80";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(83, 38);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(102, 24);
            this.connect.TabIndex = 24;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Field_CameraIPAddress
            // 
            this.Field_CameraIPAddress.AutoSize = true;
            this.Field_CameraIPAddress.Location = new System.Drawing.Point(18, 15);
            this.Field_CameraIPAddress.Name = "Field_CameraIPAddress";
            this.Field_CameraIPAddress.Size = new System.Drawing.Size(59, 13);
            this.Field_CameraIPAddress.TabIndex = 23;
            this.Field_CameraIPAddress.Text = "Camera IP:";
            // 
            // CameraIpAddress
            // 
            this.CameraIpAddress.Location = new System.Drawing.Point(83, 12);
            this.CameraIpAddress.Name = "CameraIpAddress";
            this.CameraIpAddress.Size = new System.Drawing.Size(300, 20);
            this.CameraIpAddress.TabIndex = 22;
            // 
            // getconfigurationbutton
            // 
            this.getconfigurationbutton.Location = new System.Drawing.Point(20, 361);
            this.getconfigurationbutton.Name = "getconfigurationbutton";
            this.getconfigurationbutton.Size = new System.Drawing.Size(133, 23);
            this.getconfigurationbutton.TabIndex = 40;
            this.getconfigurationbutton.Text = "Get Alarm Config";
            this.getconfigurationbutton.UseVisualStyleBackColor = true;
            this.getconfigurationbutton.Click += new System.EventHandler(this.getconfigurationbutton_Click);
            // 
            // resetalarmconfigurationbutton
            // 
            this.resetalarmconfigurationbutton.Location = new System.Drawing.Point(20, 390);
            this.resetalarmconfigurationbutton.Name = "resetalarmconfigurationbutton";
            this.resetalarmconfigurationbutton.Size = new System.Drawing.Size(133, 23);
            this.resetalarmconfigurationbutton.TabIndex = 39;
            this.resetalarmconfigurationbutton.Text = "Reset Alarm Config";
            this.resetalarmconfigurationbutton.UseVisualStyleBackColor = true;
            this.resetalarmconfigurationbutton.Click += new System.EventHandler(this.resetalarmconfigurationbutton_Click);
            // 
            // getconfiglabel
            // 
            this.getconfiglabel.AutoSize = true;
            this.getconfiglabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getconfiglabel.Location = new System.Drawing.Point(20, 205);
            this.getconfiglabel.Name = "getconfiglabel";
            this.getconfiglabel.Size = new System.Drawing.Size(168, 15);
            this.getconfiglabel.TabIndex = 38;
            this.getconfiglabel.Text = "AlarmArray - GetConfiguration";
            // 
            // getconfigtxtbox
            // 
            this.getconfigtxtbox.Location = new System.Drawing.Point(20, 224);
            this.getconfigtxtbox.Name = "getconfigtxtbox";
            this.getconfigtxtbox.Size = new System.Drawing.Size(275, 131);
            this.getconfigtxtbox.TabIndex = 37;
            this.getconfigtxtbox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "AlarmArray GetArraySize";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(19, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "AlarmArray Information";
            // 
            // getarraysizetxtbox
            // 
            this.getarraysizetxtbox.Location = new System.Drawing.Point(22, 168);
            this.getarraysizetxtbox.Name = "getarraysizetxtbox";
            this.getarraysizetxtbox.Size = new System.Drawing.Size(176, 20);
            this.getarraysizetxtbox.TabIndex = 41;
            // 
            // alarmidtxtbox
            // 
            this.alarmidtxtbox.Location = new System.Drawing.Point(23, 120);
            this.alarmidtxtbox.Name = "alarmidtxtbox";
            this.alarmidtxtbox.Size = new System.Drawing.Size(101, 20);
            this.alarmidtxtbox.TabIndex = 46;
            this.alarmidtxtbox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "AlarmID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(341, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 15);
            this.label5.TabIndex = 49;
            this.label5.Text = "AlarmArray - GetAlarmStates";
            // 
            // getalarmstatestxtbox
            // 
            this.getalarmstatestxtbox.Location = new System.Drawing.Point(341, 224);
            this.getalarmstatestxtbox.Name = "getalarmstatestxtbox";
            this.getalarmstatestxtbox.Size = new System.Drawing.Size(275, 131);
            this.getalarmstatestxtbox.TabIndex = 48;
            this.getalarmstatestxtbox.Text = "";
            // 
            // getalarmstatesbutton
            // 
            this.getalarmstatesbutton.Location = new System.Drawing.Point(341, 361);
            this.getalarmstatesbutton.Name = "getalarmstatesbutton";
            this.getalarmstatesbutton.Size = new System.Drawing.Size(133, 23);
            this.getalarmstatesbutton.TabIndex = 50;
            this.getalarmstatesbutton.Text = "Get Alarm States";
            this.getalarmstatesbutton.UseVisualStyleBackColor = true;
            this.getalarmstatesbutton.Click += new System.EventHandler(this.getalarmstatesbutton_Click);
            // 
            // setalarmstatebutton
            // 
            this.setalarmstatebutton.Location = new System.Drawing.Point(483, 361);
            this.setalarmstatebutton.Name = "setalarmstatebutton";
            this.setalarmstatebutton.Size = new System.Drawing.Size(133, 23);
            this.setalarmstatebutton.TabIndex = 51;
            this.setalarmstatebutton.Text = "Set Alarm States";
            this.setalarmstatebutton.UseVisualStyleBackColor = true;
            // 
            // setalarmconfigbutton
            // 
            this.setalarmconfigbutton.Location = new System.Drawing.Point(162, 361);
            this.setalarmconfigbutton.Name = "setalarmconfigbutton";
            this.setalarmconfigbutton.Size = new System.Drawing.Size(133, 23);
            this.setalarmconfigbutton.TabIndex = 52;
            this.setalarmconfigbutton.Text = "Set Alarm Config";
            this.setalarmconfigbutton.UseVisualStyleBackColor = true;
            this.setalarmconfigbutton.Click += new System.EventHandler(this.setalarmconfigbutton_Click);
            // 
            // AlarmArrayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 468);
            this.Controls.Add(this.setalarmconfigbutton);
            this.Controls.Add(this.setalarmstatebutton);
            this.Controls.Add(this.getalarmstatesbutton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.getalarmstatestxtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.alarmidtxtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getarraysizetxtbox);
            this.Controls.Add(this.getconfigurationbutton);
            this.Controls.Add(this.resetalarmconfigurationbutton);
            this.Controls.Add(this.getconfiglabel);
            this.Controls.Add(this.getconfigtxtbox);
            this.Controls.Add(this.Field_PortLabel);
            this.Controls.Add(this.CameraPort);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.Field_CameraIPAddress);
            this.Controls.Add(this.CameraIpAddress);
            this.Name = "AlarmArrayForm";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Field_PortLabel;
        public System.Windows.Forms.TextBox CameraPort;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label Field_CameraIPAddress;
        public System.Windows.Forms.TextBox CameraIpAddress;
        private System.Windows.Forms.Button getconfigurationbutton;
        private System.Windows.Forms.Button resetalarmconfigurationbutton;
        private System.Windows.Forms.Label getconfiglabel;
        private System.Windows.Forms.RichTextBox getconfigtxtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox getarraysizetxtbox;
        public System.Windows.Forms.TextBox alarmidtxtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox getalarmstatestxtbox;
        private System.Windows.Forms.Button getalarmstatesbutton;
        private System.Windows.Forms.Button setalarmstatebutton;
        private System.Windows.Forms.Button setalarmconfigbutton;
    }
}