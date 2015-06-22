﻿namespace PTZCameraTester
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.leftButton = new System.Windows.Forms.Button();
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
            this.StartButton.Location = new System.Drawing.Point(12, 64);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(507, 40);
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
            this.progressBar.Location = new System.Drawing.Point(15, 113);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 24);
            this.button1.TabIndex = 14;
            this.button1.Text = "GetModel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(123, 159);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(271, 48);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(198, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 36);
            this.button3.TabIndex = 17;
            this.button3.Text = "up";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(327, 286);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 36);
            this.button4.TabIndex = 18;
            this.button4.Text = "right";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(198, 339);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 36);
            this.button5.TabIndex = 19;
            this.button5.Text = "down";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(554, 8);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 23);
            this.button6.TabIndex = 20;
            this.button6.Text = "Discover";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(554, 41);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(200, 342);
            this.richTextBox2.TabIndex = 21;
            this.richTextBox2.Text = "";
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(56, 286);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(137, 36);
            this.leftButton.TabIndex = 22;
            this.leftButton.Text = "left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 468);
            this.ControlBox = false;
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button leftButton;
    }
}