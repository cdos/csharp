namespace PTZCameraTester
{
    partial class MainView
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
            this.AboutButton = new System.Windows.Forms.Button();
            this.CameraIpAddress = new System.Windows.Forms.TextBox();
            this.Field_CameraIPAddress = new System.Windows.Forms.Label();
            this.IntroTextLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.Field_PortLabel = new System.Windows.Forms.Label();
            this.CameraPort = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.CloseButton = new System.Windows.Forms.Button();
            this.EditConfigButton = new System.Windows.Forms.Button();
            this.logLocationButton = new System.Windows.Forms.Button();
            this.changelogButton = new System.Windows.Forms.Button();
            this.LeftPTZButton = new System.Windows.Forms.Button();
            this.upPTZButton = new System.Windows.Forms.Button();
            this.righPTZtButton = new System.Windows.Forms.Button();
            this.downPTZButton = new System.Windows.Forms.Button();
            this.speedlabel = new System.Windows.Forms.Label();
            this.textboxtiltspeed = new System.Windows.Forms.TextBox();
            this.textboxpanspeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CameraInfobutton = new System.Windows.Forms.Button();
            this.alarmarraybutton = new System.Windows.Forms.Button();
            this.positioningbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(415, 8);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(49, 23);
            this.AboutButton.TabIndex = 0;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // CameraIpAddress
            // 
            this.CameraIpAddress.Location = new System.Drawing.Point(77, 38);
            this.CameraIpAddress.Name = "CameraIpAddress";
            this.CameraIpAddress.Size = new System.Drawing.Size(300, 20);
            this.CameraIpAddress.TabIndex = 1;
            // 
            // Field_CameraIPAddress
            // 
            this.Field_CameraIPAddress.AutoSize = true;
            this.Field_CameraIPAddress.Location = new System.Drawing.Point(12, 41);
            this.Field_CameraIPAddress.Name = "Field_CameraIPAddress";
            this.Field_CameraIPAddress.Size = new System.Drawing.Size(59, 13);
            this.Field_CameraIPAddress.TabIndex = 2;
            this.Field_CameraIPAddress.Text = "Camera IP:";
            // 
            // IntroTextLabel
            // 
            this.IntroTextLabel.AutoSize = true;
            this.IntroTextLabel.Location = new System.Drawing.Point(12, 18);
            this.IntroTextLabel.Name = "IntroTextLabel";
            this.IntroTextLabel.Size = new System.Drawing.Size(139, 13);
            this.IntroTextLabel.TabIndex = 3;
            this.IntroTextLabel.Text = "Please enter the Camera IP:";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(415, 64);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(92, 29);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Field_PortLabel
            // 
            this.Field_PortLabel.AutoSize = true;
            this.Field_PortLabel.Location = new System.Drawing.Point(389, 41);
            this.Field_PortLabel.Name = "Field_PortLabel";
            this.Field_PortLabel.Size = new System.Drawing.Size(29, 13);
            this.Field_PortLabel.TabIndex = 8;
            this.Field_PortLabel.Text = "Port:";
            // 
            // CameraPort
            // 
            this.CameraPort.Location = new System.Drawing.Point(418, 38);
            this.CameraPort.Name = "CameraPort";
            this.CameraPort.Size = new System.Drawing.Size(101, 20);
            this.CameraPort.TabIndex = 7;
            this.CameraPort.Text = "80";
            // 
            // progressBar
            // 
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(12, 434);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(504, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 9;
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.DarkRed;
            this.CloseButton.Location = new System.Drawing.Point(470, 8);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(49, 23);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // EditConfigButton
            // 
            this.EditConfigButton.Location = new System.Drawing.Point(341, 8);
            this.EditConfigButton.Name = "EditConfigButton";
            this.EditConfigButton.Size = new System.Drawing.Size(68, 23);
            this.EditConfigButton.TabIndex = 11;
            this.EditConfigButton.Text = "Edit Config";
            this.EditConfigButton.UseVisualStyleBackColor = true;
            this.EditConfigButton.Click += new System.EventHandler(this.EditConfigButton_Click);
            // 
            // logLocationButton
            // 
            this.logLocationButton.Location = new System.Drawing.Point(255, 8);
            this.logLocationButton.Name = "logLocationButton";
            this.logLocationButton.Size = new System.Drawing.Size(80, 23);
            this.logLocationButton.TabIndex = 12;
            this.logLocationButton.Text = "Log Location";
            this.logLocationButton.UseVisualStyleBackColor = true;
            this.logLocationButton.Click += new System.EventHandler(this.logLocationButton_Click);
            // 
            // changelogButton
            // 
            this.changelogButton.Location = new System.Drawing.Point(182, 8);
            this.changelogButton.Name = "changelogButton";
            this.changelogButton.Size = new System.Drawing.Size(67, 23);
            this.changelogButton.TabIndex = 13;
            this.changelogButton.Text = "Changelog";
            this.changelogButton.UseVisualStyleBackColor = true;
            this.changelogButton.Click += new System.EventHandler(this.changelogButton_Click);
            // 
            // LeftPTZButton
            // 
            this.LeftPTZButton.Location = new System.Drawing.Point(24, 192);
            this.LeftPTZButton.Name = "LeftPTZButton";
            this.LeftPTZButton.Size = new System.Drawing.Size(47, 36);
            this.LeftPTZButton.TabIndex = 16;
            this.LeftPTZButton.Text = "left";
            this.LeftPTZButton.UseVisualStyleBackColor = true;
            this.LeftPTZButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftPTZButton_MouseDown);
            this.LeftPTZButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LeftPTZButton_MouseUp);
            // 
            // upPTZButton
            // 
            this.upPTZButton.Location = new System.Drawing.Point(67, 151);
            this.upPTZButton.Name = "upPTZButton";
            this.upPTZButton.Size = new System.Drawing.Size(50, 36);
            this.upPTZButton.TabIndex = 17;
            this.upPTZButton.Text = "up";
            this.upPTZButton.UseVisualStyleBackColor = true;
            this.upPTZButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.upPTZButton_MouseDown);
            this.upPTZButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.upPTZButton_MouseUp);
            // 
            // righPTZtButton
            // 
            this.righPTZtButton.Location = new System.Drawing.Point(112, 192);
            this.righPTZtButton.Name = "righPTZtButton";
            this.righPTZtButton.Size = new System.Drawing.Size(49, 36);
            this.righPTZtButton.TabIndex = 18;
            this.righPTZtButton.Text = "right";
            this.righPTZtButton.UseVisualStyleBackColor = true;
            this.righPTZtButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightPTZButton_MouseDown);
            this.righPTZtButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rightPTZButton_MouseUp);
            // 
            // downPTZButton
            // 
            this.downPTZButton.Location = new System.Drawing.Point(66, 235);
            this.downPTZButton.Name = "downPTZButton";
            this.downPTZButton.Size = new System.Drawing.Size(51, 34);
            this.downPTZButton.TabIndex = 19;
            this.downPTZButton.Text = "down";
            this.downPTZButton.UseVisualStyleBackColor = true;
            this.downPTZButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.downPTZButton_MouseDown);
            this.downPTZButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.downPTZButton_MouseUp);
            // 
            // speedlabel
            // 
            this.speedlabel.AutoSize = true;
            this.speedlabel.Location = new System.Drawing.Point(21, 289);
            this.speedlabel.Name = "speedlabel";
            this.speedlabel.Size = new System.Drawing.Size(55, 13);
            this.speedlabel.TabIndex = 22;
            this.speedlabel.Text = "Tilt Speed";
            // 
            // textboxtiltspeed
            // 
            this.textboxtiltspeed.Location = new System.Drawing.Point(24, 305);
            this.textboxtiltspeed.Name = "textboxtiltspeed";
            this.textboxtiltspeed.Size = new System.Drawing.Size(100, 20);
            this.textboxtiltspeed.TabIndex = 23;
            this.textboxtiltspeed.Text = "0";
            // 
            // textboxpanspeed
            // 
            this.textboxpanspeed.Location = new System.Drawing.Point(24, 353);
            this.textboxpanspeed.Name = "textboxpanspeed";
            this.textboxpanspeed.Size = new System.Drawing.Size(100, 20);
            this.textboxpanspeed.TabIndex = 25;
            this.textboxpanspeed.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Pan Speed";
            // 
            // CameraInfobutton
            // 
            this.CameraInfobutton.Location = new System.Drawing.Point(237, 73);
            this.CameraInfobutton.Name = "CameraInfobutton";
            this.CameraInfobutton.Size = new System.Drawing.Size(140, 51);
            this.CameraInfobutton.TabIndex = 26;
            this.CameraInfobutton.Text = "Pelco Configuration Test";
            this.CameraInfobutton.UseVisualStyleBackColor = true;
            this.CameraInfobutton.Click += new System.EventHandler(this.CameraInfobutton_Click);
            // 
            // alarmarraybutton
            // 
            this.alarmarraybutton.Location = new System.Drawing.Point(237, 136);
            this.alarmarraybutton.Name = "alarmarraybutton";
            this.alarmarraybutton.Size = new System.Drawing.Size(140, 51);
            this.alarmarraybutton.TabIndex = 27;
            this.alarmarraybutton.Text = "AlarmArray Test";
            this.alarmarraybutton.UseVisualStyleBackColor = true;
            this.alarmarraybutton.Click += new System.EventHandler(this.alarmarraybutton_Click);
            // 
            // positioningbutton
            // 
            this.positioningbutton.Location = new System.Drawing.Point(237, 203);
            this.positioningbutton.Name = "positioningbutton";
            this.positioningbutton.Size = new System.Drawing.Size(140, 51);
            this.positioningbutton.TabIndex = 28;
            this.positioningbutton.Text = "Positioning Test";
            this.positioningbutton.UseVisualStyleBackColor = true;
            this.positioningbutton.Click += new System.EventHandler(this.positioningbutton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 489);
            this.ControlBox = false;
            this.Controls.Add(this.positioningbutton);
            this.Controls.Add(this.alarmarraybutton);
            this.Controls.Add(this.CameraInfobutton);
            this.Controls.Add(this.textboxpanspeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxtiltspeed);
            this.Controls.Add(this.speedlabel);
            this.Controls.Add(this.downPTZButton);
            this.Controls.Add(this.righPTZtButton);
            this.Controls.Add(this.upPTZButton);
            this.Controls.Add(this.LeftPTZButton);
            this.Controls.Add(this.changelogButton);
            this.Controls.Add(this.logLocationButton);
            this.Controls.Add(this.EditConfigButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Field_PortLabel);
            this.Controls.Add(this.CameraPort);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.IntroTextLabel);
            this.Controls.Add(this.Field_CameraIPAddress);
            this.Controls.Add(this.CameraIpAddress);
            this.Controls.Add(this.AboutButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PTZ Camera Tester";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Label Field_CameraIPAddress;
        private System.Windows.Forms.Label IntroTextLabel;
        private System.Windows.Forms.Button StartButton;
        public System.Windows.Forms.TextBox CameraIpAddress;
        private System.Windows.Forms.Label Field_PortLabel;
        public System.Windows.Forms.TextBox CameraPort;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button EditConfigButton;
        private System.Windows.Forms.Button logLocationButton;
        private System.Windows.Forms.Button changelogButton;
        private System.Windows.Forms.Button LeftPTZButton;
        private System.Windows.Forms.Button upPTZButton;
        private System.Windows.Forms.Button righPTZtButton;
        private System.Windows.Forms.Button downPTZButton;
        private System.Windows.Forms.Label speedlabel;
        private System.Windows.Forms.TextBox textboxtiltspeed;
        private System.Windows.Forms.TextBox textboxpanspeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CameraInfobutton;
        private System.Windows.Forms.Button alarmarraybutton;
        private System.Windows.Forms.Button positioningbutton;
    }
}