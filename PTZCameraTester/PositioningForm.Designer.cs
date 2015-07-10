namespace PTZCameraTester
{
    partial class PositioningForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ypositiontxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xpositiontxtbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.getpositionbutton = new System.Windows.Forms.Button();
            this.setpositionbutton = new System.Windows.Forms.Button();
            this.textboxpanspeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textboxtiltspeed = new System.Windows.Forms.TextBox();
            this.speedlabel = new System.Windows.Forms.Label();
            this.downPTZButton = new System.Windows.Forms.Button();
            this.righPTZtButton = new System.Windows.Forms.Button();
            this.upPTZButton = new System.Windows.Forms.Button();
            this.LeftPTZButton = new System.Windows.Forms.Button();
            this.setpositionlimitbutton = new System.Windows.Forms.Button();
            this.getpositionlimitbutton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.xmaxtxtbox = new System.Windows.Forms.TextBox();
            this.xmintxtbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ymaxtxtbox = new System.Windows.Forms.TextBox();
            this.ymintxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.restorelimitsbutton = new System.Windows.Forms.Button();
            this.setazimuthbutton = new System.Windows.Forms.Button();
            this.getazimuthbutton = new System.Windows.Forms.Button();
            this.azimuthtxtbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.homebutton = new System.Windows.Forms.Button();
            this.Velocity = new System.Windows.Forms.GroupBox();
            this.zvelocitytxtbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.yvelocitytxtbox = new System.Windows.Forms.TextBox();
            this.xvelocitytxtbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.setvelocitybutton = new System.Windows.Forms.Button();
            this.stopbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ymaxvellimittxtbox = new System.Windows.Forms.TextBox();
            this.yminvellimittxtbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.xmaxvellimittxtbox = new System.Windows.Forms.TextBox();
            this.xminvellimittxtbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.zmaxvellimittxtbox = new System.Windows.Forms.TextBox();
            this.zminvellimittxtbox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.getvellimitbutton = new System.Windows.Forms.Button();
            this.setvellimitbutton = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.zmaxtranstxtbutton = new System.Windows.Forms.TextBox();
            this.zmintranstxtbox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.zviewobjecttxtbox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.yviewobjecttxtbox = new System.Windows.Forms.TextBox();
            this.xviewobjecttxtbox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.viewobjectbutton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Velocity.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraPort
            // 
            this.CameraPort.Location = new System.Drawing.Point(425, 12);
            this.CameraPort.Name = "CameraPort";
            this.CameraPort.Size = new System.Drawing.Size(101, 20);
            this.CameraPort.TabIndex = 29;
            this.CameraPort.Text = "80";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(85, 38);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(102, 24);
            this.connect.TabIndex = 28;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // Field_CameraIPAddress
            // 
            this.Field_CameraIPAddress.AutoSize = true;
            this.Field_CameraIPAddress.Location = new System.Drawing.Point(20, 15);
            this.Field_CameraIPAddress.Name = "Field_CameraIPAddress";
            this.Field_CameraIPAddress.Size = new System.Drawing.Size(59, 13);
            this.Field_CameraIPAddress.TabIndex = 27;
            this.Field_CameraIPAddress.Text = "Camera IP:";
            // 
            // CameraIpAddress
            // 
            this.CameraIpAddress.Location = new System.Drawing.Point(85, 12);
            this.CameraIpAddress.Name = "CameraIpAddress";
            this.CameraIpAddress.Size = new System.Drawing.Size(300, 20);
            this.CameraIpAddress.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "Y Value";
            // 
            // ypositiontxtbox
            // 
            this.ypositiontxtbox.Location = new System.Drawing.Point(129, 35);
            this.ypositiontxtbox.Name = "ypositiontxtbox";
            this.ypositiontxtbox.Size = new System.Drawing.Size(101, 20);
            this.ypositiontxtbox.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 94;
            this.label2.Text = "X Value";
            // 
            // xpositiontxtbox
            // 
            this.xpositiontxtbox.Location = new System.Drawing.Point(13, 35);
            this.xpositiontxtbox.Name = "xpositiontxtbox";
            this.xpositiontxtbox.Size = new System.Drawing.Size(101, 20);
            this.xpositiontxtbox.TabIndex = 93;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ypositiontxtbox);
            this.groupBox2.Controls.Add(this.xpositiontxtbox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(25, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 74);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Get/Set Position";
            // 
            // getpositionbutton
            // 
            this.getpositionbutton.Location = new System.Drawing.Point(39, 158);
            this.getpositionbutton.Name = "getpositionbutton";
            this.getpositionbutton.Size = new System.Drawing.Size(102, 24);
            this.getpositionbutton.TabIndex = 94;
            this.getpositionbutton.Text = "Get Position";
            this.getpositionbutton.UseVisualStyleBackColor = true;
            this.getpositionbutton.Click += new System.EventHandler(this.getpositionbutton_Click);
            // 
            // setpositionbutton
            // 
            this.setpositionbutton.Location = new System.Drawing.Point(147, 158);
            this.setpositionbutton.Name = "setpositionbutton";
            this.setpositionbutton.Size = new System.Drawing.Size(102, 24);
            this.setpositionbutton.TabIndex = 95;
            this.setpositionbutton.Text = "Set Position";
            this.setpositionbutton.UseVisualStyleBackColor = true;
            this.setpositionbutton.Click += new System.EventHandler(this.setpositionbutton_Click);
            // 
            // textboxpanspeed
            // 
            this.textboxpanspeed.Location = new System.Drawing.Point(368, 78);
            this.textboxpanspeed.Name = "textboxpanspeed";
            this.textboxpanspeed.Size = new System.Drawing.Size(63, 20);
            this.textboxpanspeed.TabIndex = 103;
            this.textboxpanspeed.Text = "2000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "Pan Speed";
            // 
            // textboxtiltspeed
            // 
            this.textboxtiltspeed.Location = new System.Drawing.Point(290, 78);
            this.textboxtiltspeed.Name = "textboxtiltspeed";
            this.textboxtiltspeed.Size = new System.Drawing.Size(63, 20);
            this.textboxtiltspeed.TabIndex = 101;
            this.textboxtiltspeed.Text = "2000";
            // 
            // speedlabel
            // 
            this.speedlabel.AutoSize = true;
            this.speedlabel.Location = new System.Drawing.Point(287, 62);
            this.speedlabel.Name = "speedlabel";
            this.speedlabel.Size = new System.Drawing.Size(55, 13);
            this.speedlabel.TabIndex = 100;
            this.speedlabel.Text = "Tilt Speed";
            // 
            // downPTZButton
            // 
            this.downPTZButton.Location = new System.Drawing.Point(334, 192);
            this.downPTZButton.Name = "downPTZButton";
            this.downPTZButton.Size = new System.Drawing.Size(51, 34);
            this.downPTZButton.TabIndex = 99;
            this.downPTZButton.Text = "Down";
            this.downPTZButton.UseVisualStyleBackColor = true;
            this.downPTZButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.downPTZButton_MouseDown);
            this.downPTZButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.downPTZButton_MouseUp);
            // 
            // righPTZtButton
            // 
            this.righPTZtButton.Location = new System.Drawing.Point(384, 154);
            this.righPTZtButton.Name = "righPTZtButton";
            this.righPTZtButton.Size = new System.Drawing.Size(49, 36);
            this.righPTZtButton.TabIndex = 98;
            this.righPTZtButton.Text = "Right";
            this.righPTZtButton.UseVisualStyleBackColor = true;
            this.righPTZtButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightPTZButton_MouseDown);
            this.righPTZtButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightPTZButton_MouseUp);
            // 
            // upPTZButton
            // 
            this.upPTZButton.Location = new System.Drawing.Point(335, 116);
            this.upPTZButton.Name = "upPTZButton";
            this.upPTZButton.Size = new System.Drawing.Size(50, 36);
            this.upPTZButton.TabIndex = 97;
            this.upPTZButton.Text = "Up";
            this.upPTZButton.UseVisualStyleBackColor = true;
            this.upPTZButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.upPTZButton_MouseDown);
            this.upPTZButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.upPTZButton_MouseUp);
            // 
            // LeftPTZButton
            // 
            this.LeftPTZButton.Location = new System.Drawing.Point(288, 154);
            this.LeftPTZButton.Name = "LeftPTZButton";
            this.LeftPTZButton.Size = new System.Drawing.Size(47, 36);
            this.LeftPTZButton.TabIndex = 96;
            this.LeftPTZButton.Text = "Left";
            this.LeftPTZButton.UseVisualStyleBackColor = true;
            this.LeftPTZButton.Click += new System.EventHandler(this.LeftPTZButton_Click);
            this.LeftPTZButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftPTZButton_MouseDown);
            this.LeftPTZButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LeftPTZButton_MouseUp);
            // 
            // setpositionlimitbutton
            // 
            this.setpositionlimitbutton.Location = new System.Drawing.Point(151, 318);
            this.setpositionlimitbutton.Name = "setpositionlimitbutton";
            this.setpositionlimitbutton.Size = new System.Drawing.Size(102, 24);
            this.setpositionlimitbutton.TabIndex = 106;
            this.setpositionlimitbutton.Text = "Set Position Limit";
            this.setpositionlimitbutton.UseVisualStyleBackColor = true;
            this.setpositionlimitbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // getpositionlimitbutton
            // 
            this.getpositionlimitbutton.Location = new System.Drawing.Point(37, 318);
            this.getpositionlimitbutton.Name = "getpositionlimitbutton";
            this.getpositionlimitbutton.Size = new System.Drawing.Size(102, 24);
            this.getpositionlimitbutton.TabIndex = 105;
            this.getpositionlimitbutton.Text = "Get Position Limit";
            this.getpositionlimitbutton.UseVisualStyleBackColor = true;
            this.getpositionlimitbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.ymaxtxtbox);
            this.groupBox3.Controls.Add(this.ymintxtbox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.xmaxtxtbox);
            this.groupBox3.Controls.Add(this.xmintxtbox);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(23, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 110);
            this.groupBox3.TabIndex = 104;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Get/Set Position Limits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(125, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 96;
            this.label5.Text = "X Max";
            // 
            // xmaxtxtbox
            // 
            this.xmaxtxtbox.Location = new System.Drawing.Point(129, 35);
            this.xmaxtxtbox.Name = "xmaxtxtbox";
            this.xmaxtxtbox.Size = new System.Drawing.Size(101, 20);
            this.xmaxtxtbox.TabIndex = 95;
            // 
            // xmintxtbox
            // 
            this.xmintxtbox.Location = new System.Drawing.Point(13, 35);
            this.xmintxtbox.Name = "xmintxtbox";
            this.xmintxtbox.Size = new System.Drawing.Size(101, 20);
            this.xmintxtbox.TabIndex = 93;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 15);
            this.label11.TabIndex = 94;
            this.label11.Text = "X Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 100;
            this.label3.Text = "Y Max";
            // 
            // ymaxtxtbox
            // 
            this.ymaxtxtbox.Location = new System.Drawing.Point(128, 75);
            this.ymaxtxtbox.Name = "ymaxtxtbox";
            this.ymaxtxtbox.Size = new System.Drawing.Size(101, 20);
            this.ymaxtxtbox.TabIndex = 99;
            // 
            // ymintxtbox
            // 
            this.ymintxtbox.Location = new System.Drawing.Point(12, 75);
            this.ymintxtbox.Name = "ymintxtbox";
            this.ymintxtbox.Size = new System.Drawing.Size(101, 20);
            this.ymintxtbox.TabIndex = 97;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 98;
            this.label6.Text = "Y Min";
            // 
            // restorelimitsbutton
            // 
            this.restorelimitsbutton.Location = new System.Drawing.Point(37, 348);
            this.restorelimitsbutton.Name = "restorelimitsbutton";
            this.restorelimitsbutton.Size = new System.Drawing.Size(102, 24);
            this.restorelimitsbutton.TabIndex = 107;
            this.restorelimitsbutton.Text = "Restore Limits";
            this.restorelimitsbutton.UseVisualStyleBackColor = true;
            this.restorelimitsbutton.Click += new System.EventHandler(this.restorelimitsbutton_Click);
            // 
            // setazimuthbutton
            // 
            this.setazimuthbutton.Location = new System.Drawing.Point(565, 104);
            this.setazimuthbutton.Name = "setazimuthbutton";
            this.setazimuthbutton.Size = new System.Drawing.Size(102, 24);
            this.setazimuthbutton.TabIndex = 110;
            this.setazimuthbutton.Text = "Set Azimuth";
            this.setazimuthbutton.UseVisualStyleBackColor = true;
            this.setazimuthbutton.Click += new System.EventHandler(this.setazimuthbutton_Click);
            // 
            // getazimuthbutton
            // 
            this.getazimuthbutton.Location = new System.Drawing.Point(451, 104);
            this.getazimuthbutton.Name = "getazimuthbutton";
            this.getazimuthbutton.Size = new System.Drawing.Size(102, 24);
            this.getazimuthbutton.TabIndex = 109;
            this.getazimuthbutton.Text = "Get Azimuth";
            this.getazimuthbutton.UseVisualStyleBackColor = true;
            this.getazimuthbutton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // azimuthtxtbox
            // 
            this.azimuthtxtbox.Location = new System.Drawing.Point(453, 79);
            this.azimuthtxtbox.Name = "azimuthtxtbox";
            this.azimuthtxtbox.Size = new System.Drawing.Size(101, 20);
            this.azimuthtxtbox.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(449, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 98;
            this.label7.Text = "Azimuth Zero";
            // 
            // homebutton
            // 
            this.homebutton.Location = new System.Drawing.Point(335, 154);
            this.homebutton.Name = "homebutton";
            this.homebutton.Size = new System.Drawing.Size(50, 36);
            this.homebutton.TabIndex = 111;
            this.homebutton.Text = "Home";
            this.homebutton.UseVisualStyleBackColor = true;
            this.homebutton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Velocity
            // 
            this.Velocity.Controls.Add(this.stopbutton);
            this.Velocity.Controls.Add(this.zvelocitytxtbox);
            this.Velocity.Controls.Add(this.label9);
            this.Velocity.Controls.Add(this.label10);
            this.Velocity.Controls.Add(this.yvelocitytxtbox);
            this.Velocity.Controls.Add(this.xvelocitytxtbox);
            this.Velocity.Controls.Add(this.label12);
            this.Velocity.Location = new System.Drawing.Point(453, 142);
            this.Velocity.Name = "Velocity";
            this.Velocity.Size = new System.Drawing.Size(245, 110);
            this.Velocity.TabIndex = 105;
            this.Velocity.TabStop = false;
            this.Velocity.Text = "Velocity";
            // 
            // zvelocitytxtbox
            // 
            this.zvelocitytxtbox.Location = new System.Drawing.Point(12, 75);
            this.zvelocitytxtbox.Name = "zvelocitytxtbox";
            this.zvelocitytxtbox.Size = new System.Drawing.Size(101, 20);
            this.zvelocitytxtbox.TabIndex = 97;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 98;
            this.label9.Text = "Z Velocity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(125, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 15);
            this.label10.TabIndex = 96;
            this.label10.Text = "Y Velocity";
            // 
            // yvelocitytxtbox
            // 
            this.yvelocitytxtbox.Location = new System.Drawing.Point(129, 35);
            this.yvelocitytxtbox.Name = "yvelocitytxtbox";
            this.yvelocitytxtbox.Size = new System.Drawing.Size(101, 20);
            this.yvelocitytxtbox.TabIndex = 95;
            // 
            // xvelocitytxtbox
            // 
            this.xvelocitytxtbox.Location = new System.Drawing.Point(13, 35);
            this.xvelocitytxtbox.Name = "xvelocitytxtbox";
            this.xvelocitytxtbox.Size = new System.Drawing.Size(101, 20);
            this.xvelocitytxtbox.TabIndex = 93;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 15);
            this.label12.TabIndex = 94;
            this.label12.Text = "X Velocity";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(467, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 24);
            this.button2.TabIndex = 112;
            this.button2.Text = "Get Velocity";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // setvelocitybutton
            // 
            this.setvelocitybutton.Location = new System.Drawing.Point(582, 258);
            this.setvelocitybutton.Name = "setvelocitybutton";
            this.setvelocitybutton.Size = new System.Drawing.Size(102, 24);
            this.setvelocitybutton.TabIndex = 113;
            this.setvelocitybutton.Text = "Set Velocity";
            this.setvelocitybutton.UseVisualStyleBackColor = true;
            this.setvelocitybutton.Click += new System.EventHandler(this.setvelocitybutton_Click);
            // 
            // stopbutton
            // 
            this.stopbutton.Location = new System.Drawing.Point(128, 75);
            this.stopbutton.Name = "stopbutton";
            this.stopbutton.Size = new System.Drawing.Size(102, 24);
            this.stopbutton.TabIndex = 114;
            this.stopbutton.Text = "Stop";
            this.stopbutton.UseVisualStyleBackColor = true;
            this.stopbutton.Click += new System.EventHandler(this.stopbutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.zmintranstxtbox);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.zmaxvellimittxtbox);
            this.groupBox1.Controls.Add(this.zmaxtranstxtbutton);
            this.groupBox1.Controls.Add(this.zminvellimittxtbox);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ymaxvellimittxtbox);
            this.groupBox1.Controls.Add(this.yminvellimittxtbox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.xmaxvellimittxtbox);
            this.groupBox1.Controls.Add(this.xminvellimittxtbox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(316, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 153);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get/Set Velocity Limits";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(127, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 100;
            this.label8.Text = "Y Max Rotation";
            // 
            // ymaxvellimittxtbox
            // 
            this.ymaxvellimittxtbox.Location = new System.Drawing.Point(128, 75);
            this.ymaxvellimittxtbox.Name = "ymaxvellimittxtbox";
            this.ymaxvellimittxtbox.Size = new System.Drawing.Size(101, 20);
            this.ymaxvellimittxtbox.TabIndex = 99;
            // 
            // yminvellimittxtbox
            // 
            this.yminvellimittxtbox.Location = new System.Drawing.Point(12, 75);
            this.yminvellimittxtbox.Name = "yminvellimittxtbox";
            this.yminvellimittxtbox.Size = new System.Drawing.Size(101, 20);
            this.yminvellimittxtbox.TabIndex = 97;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 15);
            this.label13.TabIndex = 98;
            this.label13.Text = "Y Min Rotation";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(125, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 15);
            this.label14.TabIndex = 96;
            this.label14.Text = "X Max Rotation";
            // 
            // xmaxvellimittxtbox
            // 
            this.xmaxvellimittxtbox.Location = new System.Drawing.Point(129, 35);
            this.xmaxvellimittxtbox.Name = "xmaxvellimittxtbox";
            this.xmaxvellimittxtbox.Size = new System.Drawing.Size(101, 20);
            this.xmaxvellimittxtbox.TabIndex = 95;
            // 
            // xminvellimittxtbox
            // 
            this.xminvellimittxtbox.Location = new System.Drawing.Point(13, 35);
            this.xminvellimittxtbox.Name = "xminvellimittxtbox";
            this.xminvellimittxtbox.Size = new System.Drawing.Size(101, 20);
            this.xminvellimittxtbox.TabIndex = 93;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 15);
            this.label15.TabIndex = 94;
            this.label15.Text = "X Min Rotation";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(129, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 15);
            this.label16.TabIndex = 104;
            this.label16.Text = "Z Max Rotation";
            // 
            // zmaxvellimittxtbox
            // 
            this.zmaxvellimittxtbox.Location = new System.Drawing.Point(130, 117);
            this.zmaxvellimittxtbox.Name = "zmaxvellimittxtbox";
            this.zmaxvellimittxtbox.Size = new System.Drawing.Size(101, 20);
            this.zmaxvellimittxtbox.TabIndex = 103;
            // 
            // zminvellimittxtbox
            // 
            this.zminvellimittxtbox.Location = new System.Drawing.Point(14, 117);
            this.zminvellimittxtbox.Name = "zminvellimittxtbox";
            this.zminvellimittxtbox.Size = new System.Drawing.Size(101, 20);
            this.zminvellimittxtbox.TabIndex = 101;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 15);
            this.label17.TabIndex = 102;
            this.label17.Text = "Z Min Rotation";
            // 
            // getvellimitbutton
            // 
            this.getvellimitbutton.Location = new System.Drawing.Point(469, 463);
            this.getvellimitbutton.Name = "getvellimitbutton";
            this.getvellimitbutton.Size = new System.Drawing.Size(102, 24);
            this.getvellimitbutton.TabIndex = 114;
            this.getvellimitbutton.Text = "Get Vel Limit";
            this.getvellimitbutton.UseVisualStyleBackColor = true;
            this.getvellimitbutton.Click += new System.EventHandler(this.getvellimitbutton_Click);
            // 
            // setvellimitbutton
            // 
            this.setvellimitbutton.Location = new System.Drawing.Point(584, 463);
            this.setvellimitbutton.Name = "setvellimitbutton";
            this.setvellimitbutton.Size = new System.Drawing.Size(102, 24);
            this.setvellimitbutton.TabIndex = 115;
            this.setvellimitbutton.Text = "Set Vel Limit";
            this.setvellimitbutton.UseVisualStyleBackColor = true;
            this.setvellimitbutton.Click += new System.EventHandler(this.setvellimitbutton_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(252, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 15);
            this.label18.TabIndex = 108;
            this.label18.Text = "Z Max Translation";
            // 
            // zmaxtranstxtbutton
            // 
            this.zmaxtranstxtbutton.Location = new System.Drawing.Point(253, 75);
            this.zmaxtranstxtbutton.Name = "zmaxtranstxtbutton";
            this.zmaxtranstxtbutton.Size = new System.Drawing.Size(101, 20);
            this.zmaxtranstxtbutton.TabIndex = 107;
            // 
            // zmintranstxtbox
            // 
            this.zmintranstxtbox.Location = new System.Drawing.Point(253, 35);
            this.zmintranstxtbox.Name = "zmintranstxtbox";
            this.zmintranstxtbox.Size = new System.Drawing.Size(101, 20);
            this.zmintranstxtbox.TabIndex = 105;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(252, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(102, 15);
            this.label19.TabIndex = 106;
            this.label19.Text = "Z Min Translation";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.viewobjectbutton);
            this.groupBox4.Controls.Add(this.zviewobjecttxtbox);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.yviewobjecttxtbox);
            this.groupBox4.Controls.Add(this.xviewobjecttxtbox);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Location = new System.Drawing.Point(25, 389);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 110);
            this.groupBox4.TabIndex = 105;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "View Object";
            // 
            // zviewobjecttxtbox
            // 
            this.zviewobjecttxtbox.Location = new System.Drawing.Point(12, 75);
            this.zviewobjecttxtbox.Name = "zviewobjecttxtbox";
            this.zviewobjecttxtbox.Size = new System.Drawing.Size(101, 20);
            this.zviewobjecttxtbox.TabIndex = 97;
            this.zviewobjecttxtbox.Text = "1";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(11, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 15);
            this.label21.TabIndex = 98;
            this.label21.Text = "Z Translation";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(125, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 15);
            this.label22.TabIndex = 96;
            this.label22.Text = "Y Rotation";
            // 
            // yviewobjecttxtbox
            // 
            this.yviewobjecttxtbox.Location = new System.Drawing.Point(129, 35);
            this.yviewobjecttxtbox.Name = "yviewobjecttxtbox";
            this.yviewobjecttxtbox.Size = new System.Drawing.Size(101, 20);
            this.yviewobjecttxtbox.TabIndex = 95;
            this.yviewobjecttxtbox.Text = "1";
            // 
            // xviewobjecttxtbox
            // 
            this.xviewobjecttxtbox.Location = new System.Drawing.Point(13, 35);
            this.xviewobjecttxtbox.Name = "xviewobjecttxtbox";
            this.xviewobjecttxtbox.Size = new System.Drawing.Size(101, 20);
            this.xviewobjecttxtbox.TabIndex = 93;
            this.xviewobjecttxtbox.Text = "1";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(9, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 15);
            this.label23.TabIndex = 94;
            this.label23.Text = "X Rotation";
            // 
            // viewobjectbutton
            // 
            this.viewobjectbutton.Location = new System.Drawing.Point(126, 75);
            this.viewobjectbutton.Name = "viewobjectbutton";
            this.viewobjectbutton.Size = new System.Drawing.Size(102, 24);
            this.viewobjectbutton.TabIndex = 115;
            this.viewobjectbutton.Text = "ViewObject";
            this.viewobjectbutton.UseVisualStyleBackColor = true;
            this.viewobjectbutton.Click += new System.EventHandler(this.viewobjectbutton_Click);
            // 
            // PositioningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 550);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.getvellimitbutton);
            this.Controls.Add(this.setvellimitbutton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.setvelocitybutton);
            this.Controls.Add(this.Velocity);
            this.Controls.Add(this.homebutton);
            this.Controls.Add(this.azimuthtxtbox);
            this.Controls.Add(this.setazimuthbutton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.getazimuthbutton);
            this.Controls.Add(this.restorelimitsbutton);
            this.Controls.Add(this.setpositionlimitbutton);
            this.Controls.Add(this.getpositionlimitbutton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textboxpanspeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textboxtiltspeed);
            this.Controls.Add(this.speedlabel);
            this.Controls.Add(this.downPTZButton);
            this.Controls.Add(this.righPTZtButton);
            this.Controls.Add(this.upPTZButton);
            this.Controls.Add(this.LeftPTZButton);
            this.Controls.Add(this.setpositionbutton);
            this.Controls.Add(this.getpositionbutton);
            this.Controls.Add(this.CameraPort);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.Field_CameraIPAddress);
            this.Controls.Add(this.CameraIpAddress);
            this.Controls.Add(this.groupBox2);
            this.Name = "PositioningForm";
            this.Text = "PositioningForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Velocity.ResumeLayout(false);
            this.Velocity.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox CameraPort;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label Field_CameraIPAddress;
        public System.Windows.Forms.TextBox CameraIpAddress;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox ypositiontxtbox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox xpositiontxtbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button getpositionbutton;
        private System.Windows.Forms.Button setpositionbutton;
        private System.Windows.Forms.TextBox textboxpanspeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textboxtiltspeed;
        private System.Windows.Forms.Label speedlabel;
        private System.Windows.Forms.Button downPTZButton;
        private System.Windows.Forms.Button righPTZtButton;
        private System.Windows.Forms.Button upPTZButton;
        private System.Windows.Forms.Button LeftPTZButton;
        private System.Windows.Forms.Button setpositionlimitbutton;
        private System.Windows.Forms.Button getpositionlimitbutton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox ymaxtxtbox;
        public System.Windows.Forms.TextBox ymintxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox xmaxtxtbox;
        public System.Windows.Forms.TextBox xmintxtbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button restorelimitsbutton;
        private System.Windows.Forms.Button setazimuthbutton;
        private System.Windows.Forms.Button getazimuthbutton;
        public System.Windows.Forms.TextBox azimuthtxtbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button homebutton;
        private System.Windows.Forms.GroupBox Velocity;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox zvelocitytxtbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox yvelocitytxtbox;
        public System.Windows.Forms.TextBox xvelocitytxtbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button setvelocitybutton;
        private System.Windows.Forms.Button stopbutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox zmaxvellimittxtbox;
        public System.Windows.Forms.TextBox zminvellimittxtbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox ymaxvellimittxtbox;
        public System.Windows.Forms.TextBox yminvellimittxtbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox xmaxvellimittxtbox;
        public System.Windows.Forms.TextBox xminvellimittxtbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button getvellimitbutton;
        private System.Windows.Forms.Button setvellimitbutton;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox zmintranstxtbox;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox zmaxtranstxtbutton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button viewobjectbutton;
        public System.Windows.Forms.TextBox zviewobjecttxtbox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.TextBox yviewobjecttxtbox;
        public System.Windows.Forms.TextBox xviewobjecttxtbox;
        private System.Windows.Forms.Label label23;
    }
}