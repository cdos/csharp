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
            this.label3 = new System.Windows.Forms.Label();
            this.severitytxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.polaritytxtbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.enabledtxtbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.physicalinputtxtbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dwelltimetxtbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.supervisedtxtbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.stateenabledtxtbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.state2txtbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.state1txtbox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.changedtxtbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lengthtxtbox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.offsettxtbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.setalarmstatetxtbox = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
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
            this.getconfigurationbutton.Location = new System.Drawing.Point(24, 413);
            this.getconfigurationbutton.Name = "getconfigurationbutton";
            this.getconfigurationbutton.Size = new System.Drawing.Size(133, 23);
            this.getconfigurationbutton.TabIndex = 40;
            this.getconfigurationbutton.Text = "Get Alarm Config";
            this.getconfigurationbutton.UseVisualStyleBackColor = true;
            this.getconfigurationbutton.Click += new System.EventHandler(this.getconfigurationbutton_Click);
            // 
            // resetalarmconfigurationbutton
            // 
            this.resetalarmconfigurationbutton.Location = new System.Drawing.Point(24, 442);
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
            this.getconfiglabel.Location = new System.Drawing.Point(24, 257);
            this.getconfiglabel.Name = "getconfiglabel";
            this.getconfiglabel.Size = new System.Drawing.Size(168, 15);
            this.getconfiglabel.TabIndex = 38;
            this.getconfiglabel.Text = "AlarmArray - GetConfiguration";
            // 
            // getconfigtxtbox
            // 
            this.getconfigtxtbox.Location = new System.Drawing.Point(24, 276);
            this.getconfigtxtbox.Name = "getconfigtxtbox";
            this.getconfigtxtbox.Size = new System.Drawing.Size(275, 131);
            this.getconfigtxtbox.TabIndex = 37;
            this.getconfigtxtbox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "GetArraySize";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(231, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "AlarmArray Information";
            // 
            // getarraysizetxtbox
            // 
            this.getarraysizetxtbox.Location = new System.Drawing.Point(289, 162);
            this.getarraysizetxtbox.Name = "getarraysizetxtbox";
            this.getarraysizetxtbox.Size = new System.Drawing.Size(75, 20);
            this.getarraysizetxtbox.TabIndex = 41;
            // 
            // alarmidtxtbox
            // 
            this.alarmidtxtbox.Location = new System.Drawing.Point(290, 114);
            this.alarmidtxtbox.Name = "alarmidtxtbox";
            this.alarmidtxtbox.Size = new System.Drawing.Size(74, 20);
            this.alarmidtxtbox.TabIndex = 46;
            this.alarmidtxtbox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(286, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "AlarmID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(394, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 15);
            this.label5.TabIndex = 49;
            this.label5.Text = "AlarmArray - GetAlarmStates";
            // 
            // getalarmstatestxtbox
            // 
            this.getalarmstatestxtbox.Location = new System.Drawing.Point(397, 276);
            this.getalarmstatestxtbox.Name = "getalarmstatestxtbox";
            this.getalarmstatestxtbox.Size = new System.Drawing.Size(275, 131);
            this.getalarmstatestxtbox.TabIndex = 48;
            this.getalarmstatestxtbox.Text = "";
            // 
            // getalarmstatesbutton
            // 
            this.getalarmstatesbutton.Location = new System.Drawing.Point(397, 413);
            this.getalarmstatesbutton.Name = "getalarmstatesbutton";
            this.getalarmstatesbutton.Size = new System.Drawing.Size(133, 23);
            this.getalarmstatesbutton.TabIndex = 50;
            this.getalarmstatesbutton.Text = "Get Alarm States";
            this.getalarmstatesbutton.UseVisualStyleBackColor = true;
            this.getalarmstatesbutton.Click += new System.EventHandler(this.getalarmstatesbutton_Click);
            // 
            // setalarmstatebutton
            // 
            this.setalarmstatebutton.Location = new System.Drawing.Point(276, 236);
            this.setalarmstatebutton.Name = "setalarmstatebutton";
            this.setalarmstatebutton.Size = new System.Drawing.Size(115, 25);
            this.setalarmstatebutton.TabIndex = 51;
            this.setalarmstatebutton.Text = "Set Alarm State";
            this.setalarmstatebutton.UseVisualStyleBackColor = true;
            this.setalarmstatebutton.Click += new System.EventHandler(this.setalarmstatebutton_Click);
            // 
            // setalarmconfigbutton
            // 
            this.setalarmconfigbutton.Location = new System.Drawing.Point(166, 413);
            this.setalarmconfigbutton.Name = "setalarmconfigbutton";
            this.setalarmconfigbutton.Size = new System.Drawing.Size(133, 23);
            this.setalarmconfigbutton.TabIndex = 52;
            this.setalarmconfigbutton.Text = "Set Alarm Config";
            this.setalarmconfigbutton.UseVisualStyleBackColor = true;
            this.setalarmconfigbutton.Click += new System.EventHandler(this.setalarmconfigbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 56;
            this.label3.Text = "Severity";
            // 
            // severitytxtbox
            // 
            this.severitytxtbox.Location = new System.Drawing.Point(32, 114);
            this.severitytxtbox.Name = "severitytxtbox";
            this.severitytxtbox.Size = new System.Drawing.Size(101, 20);
            this.severitytxtbox.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 58;
            this.label6.Text = "Polarity";
            // 
            // polaritytxtbox
            // 
            this.polaritytxtbox.Location = new System.Drawing.Point(31, 160);
            this.polaritytxtbox.Name = "polaritytxtbox";
            this.polaritytxtbox.Size = new System.Drawing.Size(101, 20);
            this.polaritytxtbox.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 60;
            this.label7.Text = "Enabled";
            // 
            // enabledtxtbox
            // 
            this.enabledtxtbox.Location = new System.Drawing.Point(33, 208);
            this.enabledtxtbox.Name = "enabledtxtbox";
            this.enabledtxtbox.Size = new System.Drawing.Size(101, 20);
            this.enabledtxtbox.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(145, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 66;
            this.label8.Text = "PhysicalInput";
            // 
            // physicalinputtxtbox
            // 
            this.physicalinputtxtbox.Location = new System.Drawing.Point(149, 208);
            this.physicalinputtxtbox.Name = "physicalinputtxtbox";
            this.physicalinputtxtbox.Size = new System.Drawing.Size(101, 20);
            this.physicalinputtxtbox.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(143, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 64;
            this.label9.Text = "DwellTime";
            // 
            // dwelltimetxtbox
            // 
            this.dwelltimetxtbox.Location = new System.Drawing.Point(147, 160);
            this.dwelltimetxtbox.Name = "dwelltimetxtbox";
            this.dwelltimetxtbox.Size = new System.Drawing.Size(101, 20);
            this.dwelltimetxtbox.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(144, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 62;
            this.label10.Text = "Supervised";
            // 
            // supervisedtxtbox
            // 
            this.supervisedtxtbox.Location = new System.Drawing.Point(148, 114);
            this.supervisedtxtbox.Name = "supervisedtxtbox";
            this.supervisedtxtbox.Size = new System.Drawing.Size(101, 20);
            this.supervisedtxtbox.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(123, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 78;
            this.label11.Text = "Enabled";
            // 
            // stateenabledtxtbox
            // 
            this.stateenabledtxtbox.Location = new System.Drawing.Point(127, 141);
            this.stateenabledtxtbox.Name = "stateenabledtxtbox";
            this.stateenabledtxtbox.Size = new System.Drawing.Size(101, 20);
            this.stateenabledtxtbox.TabIndex = 77;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(121, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 15);
            this.label12.TabIndex = 76;
            this.label12.Text = "State2";
            // 
            // state2txtbox
            // 
            this.state2txtbox.Location = new System.Drawing.Point(125, 93);
            this.state2txtbox.Name = "state2txtbox";
            this.state2txtbox.Size = new System.Drawing.Size(101, 20);
            this.state2txtbox.TabIndex = 75;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(122, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 15);
            this.label13.TabIndex = 74;
            this.label13.Text = "State1";
            // 
            // state1txtbox
            // 
            this.state1txtbox.Location = new System.Drawing.Point(126, 47);
            this.state1txtbox.Name = "state1txtbox";
            this.state1txtbox.Size = new System.Drawing.Size(101, 20);
            this.state1txtbox.TabIndex = 73;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 15);
            this.label14.TabIndex = 72;
            this.label14.Text = "Changed";
            // 
            // changedtxtbox
            // 
            this.changedtxtbox.Location = new System.Drawing.Point(11, 141);
            this.changedtxtbox.Name = "changedtxtbox";
            this.changedtxtbox.Size = new System.Drawing.Size(101, 20);
            this.changedtxtbox.TabIndex = 71;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(5, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 15);
            this.label15.TabIndex = 70;
            this.label15.Text = "Length";
            // 
            // lengthtxtbox
            // 
            this.lengthtxtbox.Location = new System.Drawing.Point(9, 93);
            this.lengthtxtbox.Name = "lengthtxtbox";
            this.lengthtxtbox.Size = new System.Drawing.Size(101, 20);
            this.lengthtxtbox.TabIndex = 69;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 15);
            this.label16.TabIndex = 68;
            this.label16.Text = "OffSet";
            // 
            // offsettxtbox
            // 
            this.offsettxtbox.Location = new System.Drawing.Point(10, 47);
            this.offsettxtbox.Name = "offsettxtbox";
            this.offsettxtbox.Size = new System.Drawing.Size(101, 20);
            this.offsettxtbox.TabIndex = 67;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(24, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 176);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GetConfiguration";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.state2txtbox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.offsettxtbox);
            this.groupBox2.Controls.Add(this.stateenabledtxtbox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lengthtxtbox);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.changedtxtbox);
            this.groupBox2.Controls.Add(this.state1txtbox);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(397, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 176);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GetAlarmState";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(288, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 15);
            this.label17.TabIndex = 82;
            this.label17.Text = "Set Alarm State";
            // 
            // setalarmstatetxtbox
            // 
            this.setalarmstatetxtbox.Location = new System.Drawing.Point(290, 210);
            this.setalarmstatetxtbox.Name = "setalarmstatetxtbox";
            this.setalarmstatetxtbox.Size = new System.Drawing.Size(89, 20);
            this.setalarmstatetxtbox.TabIndex = 81;
            this.setalarmstatetxtbox.Text = "0";
            // 
            // AlarmArrayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 468);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.setalarmstatetxtbox);
            this.Controls.Add(this.setalarmconfigbutton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.physicalinputtxtbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dwelltimetxtbox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.supervisedtxtbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.enabledtxtbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.polaritytxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.severitytxtbox);
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AlarmArrayForm";
            this.Text = "AlarmArrayForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox severitytxtbox;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox polaritytxtbox;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox enabledtxtbox;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox physicalinputtxtbox;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox dwelltimetxtbox;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox supervisedtxtbox;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox stateenabledtxtbox;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox state2txtbox;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox state1txtbox;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox changedtxtbox;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox lengthtxtbox;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox offsettxtbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox setalarmstatetxtbox;
    }
}