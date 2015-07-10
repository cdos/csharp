namespace PTZCameraTester
{
    partial class LensControlForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.getmaxdigitalmagtxtbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.getmaxdigitalmagbutton = new System.Windows.Forms.Button();
            this.getmaxopticalmagbutton = new System.Windows.Forms.Button();
            this.getmaxopticaltxtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.getmaxaovbutton = new System.Windows.Forms.Button();
            this.getmaxaovtxtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.maxmagtxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.magtxtbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.setmagbutton = new System.Windows.Forms.Button();
            this.getmagbutton = new System.Windows.Forms.Button();
            this.setmaxmagbutton = new System.Windows.Forms.Button();
            this.getmaxmagbutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.autofocusonbutton = new System.Windows.Forms.Button();
            this.autofocusoffbutton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.autoirisoffbutton = new System.Windows.Forms.Button();
            this.autoirisonbutton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.irisclosebutton = new System.Windows.Forms.Button();
            this.irisopenbutton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.focusfarbutton = new System.Windows.Forms.Button();
            this.focusnearbutton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.zoomoutbutton = new System.Windows.Forms.Button();
            this.zoominbutton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.maxzoomoutbutton = new System.Windows.Forms.Button();
            this.maxzoominbutton = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.maxirisclosebutton = new System.Windows.Forms.Button();
            this.maxirisopenbutton = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.maxfocusfarbutton = new System.Windows.Forms.Button();
            this.maxfocusnearbutton = new System.Windows.Forms.Button();
            this.lensstopbutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraPort
            // 
            this.CameraPort.Location = new System.Drawing.Point(427, 12);
            this.CameraPort.Name = "CameraPort";
            this.CameraPort.Size = new System.Drawing.Size(101, 20);
            this.CameraPort.TabIndex = 33;
            this.CameraPort.Text = "80";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(87, 38);
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
            this.Field_CameraIPAddress.Location = new System.Drawing.Point(22, 15);
            this.Field_CameraIPAddress.Name = "Field_CameraIPAddress";
            this.Field_CameraIPAddress.Size = new System.Drawing.Size(59, 13);
            this.Field_CameraIPAddress.TabIndex = 31;
            this.Field_CameraIPAddress.Text = "Camera IP:";
            // 
            // CameraIpAddress
            // 
            this.CameraIpAddress.Location = new System.Drawing.Point(87, 12);
            this.CameraIpAddress.Name = "CameraIpAddress";
            this.CameraIpAddress.Size = new System.Drawing.Size(300, 20);
            this.CameraIpAddress.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getmaxaovbutton);
            this.groupBox1.Controls.Add(this.getmaxaovtxtbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.getmaxopticalmagbutton);
            this.groupBox1.Controls.Add(this.getmaxopticaltxtbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.getmaxdigitalmagbutton);
            this.groupBox1.Controls.Add(this.getmaxdigitalmagtxtbox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(25, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 175);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get Mag Properties";
            // 
            // getmaxdigitalmagtxtbox
            // 
            this.getmaxdigitalmagtxtbox.Location = new System.Drawing.Point(13, 42);
            this.getmaxdigitalmagtxtbox.Name = "getmaxdigitalmagtxtbox";
            this.getmaxdigitalmagtxtbox.Size = new System.Drawing.Size(101, 20);
            this.getmaxdigitalmagtxtbox.TabIndex = 93;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 15);
            this.label15.TabIndex = 94;
            this.label15.Text = "GetMaxDigitalMag";
            // 
            // getmaxdigitalmagbutton
            // 
            this.getmaxdigitalmagbutton.Location = new System.Drawing.Point(126, 39);
            this.getmaxdigitalmagbutton.Name = "getmaxdigitalmagbutton";
            this.getmaxdigitalmagbutton.Size = new System.Drawing.Size(102, 24);
            this.getmaxdigitalmagbutton.TabIndex = 109;
            this.getmaxdigitalmagbutton.Text = "MaxDigitalMag";
            this.getmaxdigitalmagbutton.UseVisualStyleBackColor = true;
            this.getmaxdigitalmagbutton.Click += new System.EventHandler(this.getmaxdigitalmagbutton_Click);
            // 
            // getmaxopticalmagbutton
            // 
            this.getmaxopticalmagbutton.Location = new System.Drawing.Point(127, 83);
            this.getmaxopticalmagbutton.Name = "getmaxopticalmagbutton";
            this.getmaxopticalmagbutton.Size = new System.Drawing.Size(102, 23);
            this.getmaxopticalmagbutton.TabIndex = 112;
            this.getmaxopticalmagbutton.Text = "MaxOpticalMag";
            this.getmaxopticalmagbutton.UseVisualStyleBackColor = true;
            this.getmaxopticalmagbutton.Click += new System.EventHandler(this.getmaxopticalmagbutton_Click);
            // 
            // getmaxopticaltxtbox
            // 
            this.getmaxopticaltxtbox.Location = new System.Drawing.Point(14, 86);
            this.getmaxopticaltxtbox.Name = "getmaxopticaltxtbox";
            this.getmaxopticaltxtbox.Size = new System.Drawing.Size(101, 20);
            this.getmaxopticaltxtbox.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 111;
            this.label1.Text = "GetMaxOpticalMag";
            // 
            // getmaxaovbutton
            // 
            this.getmaxaovbutton.Location = new System.Drawing.Point(127, 124);
            this.getmaxaovbutton.Name = "getmaxaovbutton";
            this.getmaxaovbutton.Size = new System.Drawing.Size(102, 24);
            this.getmaxaovbutton.TabIndex = 115;
            this.getmaxaovbutton.Text = "MaxAOV";
            this.getmaxaovbutton.UseVisualStyleBackColor = true;
            this.getmaxaovbutton.Click += new System.EventHandler(this.getmaxaovbutton_Click);
            // 
            // getmaxaovtxtbox
            // 
            this.getmaxaovtxtbox.Location = new System.Drawing.Point(14, 127);
            this.getmaxaovtxtbox.Name = "getmaxaovtxtbox";
            this.getmaxaovtxtbox.Size = new System.Drawing.Size(101, 20);
            this.getmaxaovtxtbox.TabIndex = 113;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 114;
            this.label3.Text = "GetMaxAOV";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.setmaxmagbutton);
            this.groupBox3.Controls.Add(this.getmaxmagbutton);
            this.groupBox3.Controls.Add(this.setmagbutton);
            this.groupBox3.Controls.Add(this.maxmagtxtbox);
            this.groupBox3.Controls.Add(this.getmagbutton);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.magtxtbox);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(343, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 175);
            this.groupBox3.TabIndex = 119;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Get/Set Mag";
            // 
            // maxmagtxtbox
            // 
            this.maxmagtxtbox.Location = new System.Drawing.Point(12, 110);
            this.maxmagtxtbox.Name = "maxmagtxtbox";
            this.maxmagtxtbox.Size = new System.Drawing.Size(101, 20);
            this.maxmagtxtbox.TabIndex = 97;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 98;
            this.label6.Text = "Max Mag";
            // 
            // magtxtbox
            // 
            this.magtxtbox.Location = new System.Drawing.Point(13, 35);
            this.magtxtbox.Name = "magtxtbox";
            this.magtxtbox.Size = new System.Drawing.Size(101, 20);
            this.magtxtbox.TabIndex = 93;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 15);
            this.label11.TabIndex = 94;
            this.label11.Text = "Mag";
            // 
            // setmagbutton
            // 
            this.setmagbutton.Location = new System.Drawing.Point(122, 59);
            this.setmagbutton.Name = "setmagbutton";
            this.setmagbutton.Size = new System.Drawing.Size(102, 24);
            this.setmagbutton.TabIndex = 121;
            this.setmagbutton.Text = "Set Mag";
            this.setmagbutton.UseVisualStyleBackColor = true;
            this.setmagbutton.Click += new System.EventHandler(this.setmagbutton_Click);
            // 
            // getmagbutton
            // 
            this.getmagbutton.Location = new System.Drawing.Point(14, 59);
            this.getmagbutton.Name = "getmagbutton";
            this.getmagbutton.Size = new System.Drawing.Size(102, 24);
            this.getmagbutton.TabIndex = 120;
            this.getmagbutton.Text = "Get Mag";
            this.getmagbutton.UseVisualStyleBackColor = true;
            this.getmagbutton.Click += new System.EventHandler(this.getmagbutton_Click);
            // 
            // setmaxmagbutton
            // 
            this.setmaxmagbutton.Location = new System.Drawing.Point(122, 133);
            this.setmaxmagbutton.Name = "setmaxmagbutton";
            this.setmaxmagbutton.Size = new System.Drawing.Size(102, 24);
            this.setmaxmagbutton.TabIndex = 123;
            this.setmaxmagbutton.Text = "Set Max Mag";
            this.setmaxmagbutton.UseVisualStyleBackColor = true;
            this.setmaxmagbutton.Click += new System.EventHandler(this.setmaxmagbutton_Click);
            // 
            // getmaxmagbutton
            // 
            this.getmaxmagbutton.Location = new System.Drawing.Point(14, 133);
            this.getmaxmagbutton.Name = "getmaxmagbutton";
            this.getmaxmagbutton.Size = new System.Drawing.Size(102, 24);
            this.getmaxmagbutton.TabIndex = 122;
            this.getmaxmagbutton.Text = "Get Max Mag";
            this.getmaxmagbutton.UseVisualStyleBackColor = true;
            this.getmaxmagbutton.Click += new System.EventHandler(this.getmaxmagbutton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.autofocusoffbutton);
            this.groupBox2.Controls.Add(this.autofocusonbutton);
            this.groupBox2.Location = new System.Drawing.Point(25, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 126);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Focus";
            // 
            // autofocusonbutton
            // 
            this.autofocusonbutton.Location = new System.Drawing.Point(12, 32);
            this.autofocusonbutton.Name = "autofocusonbutton";
            this.autofocusonbutton.Size = new System.Drawing.Size(71, 36);
            this.autofocusonbutton.TabIndex = 120;
            this.autofocusonbutton.Text = "On";
            this.autofocusonbutton.UseVisualStyleBackColor = true;
            this.autofocusonbutton.Click += new System.EventHandler(this.autofocusonbutton_Click);
            // 
            // autofocusoffbutton
            // 
            this.autofocusoffbutton.Location = new System.Drawing.Point(13, 74);
            this.autofocusoffbutton.Name = "autofocusoffbutton";
            this.autofocusoffbutton.Size = new System.Drawing.Size(71, 36);
            this.autofocusoffbutton.TabIndex = 121;
            this.autofocusoffbutton.Text = "Off";
            this.autofocusoffbutton.UseVisualStyleBackColor = true;
            this.autofocusoffbutton.Click += new System.EventHandler(this.autofocusoffbutton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.autoirisoffbutton);
            this.groupBox4.Controls.Add(this.autoirisonbutton);
            this.groupBox4.Location = new System.Drawing.Point(385, 293);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 126);
            this.groupBox4.TabIndex = 125;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Auto Iris";
            // 
            // autoirisoffbutton
            // 
            this.autoirisoffbutton.Location = new System.Drawing.Point(13, 74);
            this.autoirisoffbutton.Name = "autoirisoffbutton";
            this.autoirisoffbutton.Size = new System.Drawing.Size(71, 36);
            this.autoirisoffbutton.TabIndex = 121;
            this.autoirisoffbutton.Text = "Off";
            this.autoirisoffbutton.UseVisualStyleBackColor = true;
            this.autoirisoffbutton.Click += new System.EventHandler(this.autoirisoffbutton_Click);
            // 
            // autoirisonbutton
            // 
            this.autoirisonbutton.Location = new System.Drawing.Point(12, 32);
            this.autoirisonbutton.Name = "autoirisonbutton";
            this.autoirisonbutton.Size = new System.Drawing.Size(71, 36);
            this.autoirisonbutton.TabIndex = 120;
            this.autoirisonbutton.Text = "On";
            this.autoirisonbutton.UseVisualStyleBackColor = true;
            this.autoirisonbutton.Click += new System.EventHandler(this.autoirisonbutton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.irisclosebutton);
            this.groupBox5.Controls.Add(this.irisopenbutton);
            this.groupBox5.Location = new System.Drawing.Point(487, 293);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(100, 126);
            this.groupBox5.TabIndex = 127;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Iris Control";
            // 
            // irisclosebutton
            // 
            this.irisclosebutton.Location = new System.Drawing.Point(13, 74);
            this.irisclosebutton.Name = "irisclosebutton";
            this.irisclosebutton.Size = new System.Drawing.Size(71, 36);
            this.irisclosebutton.TabIndex = 121;
            this.irisclosebutton.Text = "Close";
            this.irisclosebutton.UseVisualStyleBackColor = true;
            this.irisclosebutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.irisclosemousedown);
            this.irisclosebutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.irisclosemouseup);
            // 
            // irisopenbutton
            // 
            this.irisopenbutton.Location = new System.Drawing.Point(12, 32);
            this.irisopenbutton.Name = "irisopenbutton";
            this.irisopenbutton.Size = new System.Drawing.Size(71, 36);
            this.irisopenbutton.TabIndex = 120;
            this.irisopenbutton.Text = "Open";
            this.irisopenbutton.UseVisualStyleBackColor = true;
            this.irisopenbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.irisopenmousedown);
            this.irisopenbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.irisopenmouseup);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.focusfarbutton);
            this.groupBox6.Controls.Add(this.focusnearbutton);
            this.groupBox6.Location = new System.Drawing.Point(126, 293);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(100, 126);
            this.groupBox6.TabIndex = 126;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Focus Control";
            // 
            // focusfarbutton
            // 
            this.focusfarbutton.Location = new System.Drawing.Point(13, 74);
            this.focusfarbutton.Name = "focusfarbutton";
            this.focusfarbutton.Size = new System.Drawing.Size(71, 36);
            this.focusfarbutton.TabIndex = 121;
            this.focusfarbutton.Text = "Far";
            this.focusfarbutton.UseVisualStyleBackColor = true;
            this.focusfarbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.focusfarmousedown);
            this.focusfarbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.focusfarmouseup);
            // 
            // focusnearbutton
            // 
            this.focusnearbutton.Location = new System.Drawing.Point(12, 32);
            this.focusnearbutton.Name = "focusnearbutton";
            this.focusnearbutton.Size = new System.Drawing.Size(71, 36);
            this.focusnearbutton.TabIndex = 120;
            this.focusnearbutton.Text = "Near";
            this.focusnearbutton.UseVisualStyleBackColor = true;
            this.focusnearbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.focusnearmousedown);
            this.focusnearbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.focusnearmouseup);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.zoomoutbutton);
            this.groupBox7.Controls.Add(this.zoominbutton);
            this.groupBox7.Location = new System.Drawing.Point(256, 293);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(100, 126);
            this.groupBox7.TabIndex = 127;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Zoom Control";
            // 
            // zoomoutbutton
            // 
            this.zoomoutbutton.Location = new System.Drawing.Point(13, 74);
            this.zoomoutbutton.Name = "zoomoutbutton";
            this.zoomoutbutton.Size = new System.Drawing.Size(71, 36);
            this.zoomoutbutton.TabIndex = 121;
            this.zoomoutbutton.Text = "Out";
            this.zoomoutbutton.UseVisualStyleBackColor = true;
            this.zoomoutbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomoutmousedown);
            this.zoomoutbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zoomoutmouseup);
            // 
            // zoominbutton
            // 
            this.zoominbutton.Location = new System.Drawing.Point(12, 32);
            this.zoominbutton.Name = "zoominbutton";
            this.zoominbutton.Size = new System.Drawing.Size(71, 36);
            this.zoominbutton.TabIndex = 120;
            this.zoominbutton.Text = "In";
            this.zoominbutton.UseVisualStyleBackColor = true;
            this.zoominbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoominmousedown);
            this.zoominbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zoominmouseup);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.maxzoomoutbutton);
            this.groupBox8.Controls.Add(this.maxzoominbutton);
            this.groupBox8.Location = new System.Drawing.Point(256, 437);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(100, 126);
            this.groupBox8.TabIndex = 130;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Zoom";
            // 
            // maxzoomoutbutton
            // 
            this.maxzoomoutbutton.Location = new System.Drawing.Point(13, 74);
            this.maxzoomoutbutton.Name = "maxzoomoutbutton";
            this.maxzoomoutbutton.Size = new System.Drawing.Size(71, 36);
            this.maxzoomoutbutton.TabIndex = 121;
            this.maxzoomoutbutton.Text = "Max Out";
            this.maxzoomoutbutton.UseVisualStyleBackColor = true;
            this.maxzoomoutbutton.Click += new System.EventHandler(this.maxzoomoutbutton_Click);
            // 
            // maxzoominbutton
            // 
            this.maxzoominbutton.Location = new System.Drawing.Point(12, 32);
            this.maxzoominbutton.Name = "maxzoominbutton";
            this.maxzoominbutton.Size = new System.Drawing.Size(71, 36);
            this.maxzoominbutton.TabIndex = 120;
            this.maxzoominbutton.Text = "Max In";
            this.maxzoominbutton.UseVisualStyleBackColor = true;
            this.maxzoominbutton.Click += new System.EventHandler(this.maxzoominbutton_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.maxirisclosebutton);
            this.groupBox9.Controls.Add(this.maxirisopenbutton);
            this.groupBox9.Location = new System.Drawing.Point(356, 437);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(100, 126);
            this.groupBox9.TabIndex = 129;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Iris";
            // 
            // maxirisclosebutton
            // 
            this.maxirisclosebutton.Location = new System.Drawing.Point(13, 74);
            this.maxirisclosebutton.Name = "maxirisclosebutton";
            this.maxirisclosebutton.Size = new System.Drawing.Size(71, 36);
            this.maxirisclosebutton.TabIndex = 121;
            this.maxirisclosebutton.Text = "Max Close";
            this.maxirisclosebutton.UseVisualStyleBackColor = true;
            this.maxirisclosebutton.Click += new System.EventHandler(this.maxirisclosebutton_Click);
            // 
            // maxirisopenbutton
            // 
            this.maxirisopenbutton.Location = new System.Drawing.Point(12, 32);
            this.maxirisopenbutton.Name = "maxirisopenbutton";
            this.maxirisopenbutton.Size = new System.Drawing.Size(71, 36);
            this.maxirisopenbutton.TabIndex = 120;
            this.maxirisopenbutton.Text = "Max Open";
            this.maxirisopenbutton.UseVisualStyleBackColor = true;
            this.maxirisopenbutton.Click += new System.EventHandler(this.maxirisopenbutton_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.maxfocusfarbutton);
            this.groupBox10.Controls.Add(this.maxfocusnearbutton);
            this.groupBox10.Location = new System.Drawing.Point(156, 437);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(100, 126);
            this.groupBox10.TabIndex = 128;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Focus";
            // 
            // maxfocusfarbutton
            // 
            this.maxfocusfarbutton.Location = new System.Drawing.Point(13, 74);
            this.maxfocusfarbutton.Name = "maxfocusfarbutton";
            this.maxfocusfarbutton.Size = new System.Drawing.Size(71, 36);
            this.maxfocusfarbutton.TabIndex = 121;
            this.maxfocusfarbutton.Text = "Max Far";
            this.maxfocusfarbutton.UseVisualStyleBackColor = true;
            this.maxfocusfarbutton.Click += new System.EventHandler(this.maxfocusfarbutton_Click);
            // 
            // maxfocusnearbutton
            // 
            this.maxfocusnearbutton.Location = new System.Drawing.Point(12, 32);
            this.maxfocusnearbutton.Name = "maxfocusnearbutton";
            this.maxfocusnearbutton.Size = new System.Drawing.Size(71, 36);
            this.maxfocusnearbutton.TabIndex = 120;
            this.maxfocusnearbutton.Text = "Max Near";
            this.maxfocusnearbutton.UseVisualStyleBackColor = true;
            this.maxfocusnearbutton.Click += new System.EventHandler(this.maxfocusnearbutton_Click);
            // 
            // lensstopbutton
            // 
            this.lensstopbutton.Location = new System.Drawing.Point(182, 569);
            this.lensstopbutton.Name = "lensstopbutton";
            this.lensstopbutton.Size = new System.Drawing.Size(231, 24);
            this.lensstopbutton.TabIndex = 124;
            this.lensstopbutton.Text = "Stop";
            this.lensstopbutton.UseVisualStyleBackColor = true;
            this.lensstopbutton.Click += new System.EventHandler(this.lensstopbutton_Click);
            // 
            // LensControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 642);
            this.Controls.Add(this.lensstopbutton);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CameraPort);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.Field_CameraIPAddress);
            this.Controls.Add(this.CameraIpAddress);
            this.Name = "LensControlForm";
            this.Text = "LensControlForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox CameraPort;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label Field_CameraIPAddress;
        public System.Windows.Forms.TextBox CameraIpAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox getmaxdigitalmagtxtbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button getmaxaovbutton;
        public System.Windows.Forms.TextBox getmaxaovtxtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button getmaxopticalmagbutton;
        public System.Windows.Forms.TextBox getmaxopticaltxtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getmaxdigitalmagbutton;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox maxmagtxtbox;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox magtxtbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button setmagbutton;
        private System.Windows.Forms.Button getmagbutton;
        private System.Windows.Forms.Button setmaxmagbutton;
        private System.Windows.Forms.Button getmaxmagbutton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button autofocusoffbutton;
        private System.Windows.Forms.Button autofocusonbutton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button autoirisoffbutton;
        private System.Windows.Forms.Button autoirisonbutton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button irisclosebutton;
        private System.Windows.Forms.Button irisopenbutton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button focusfarbutton;
        private System.Windows.Forms.Button focusnearbutton;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button zoomoutbutton;
        private System.Windows.Forms.Button zoominbutton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button maxzoomoutbutton;
        private System.Windows.Forms.Button maxzoominbutton;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button maxirisclosebutton;
        private System.Windows.Forms.Button maxirisopenbutton;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button maxfocusfarbutton;
        private System.Windows.Forms.Button maxfocusnearbutton;
        private System.Windows.Forms.Button lensstopbutton;
    }
}