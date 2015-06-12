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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.button1.Location = new System.Drawing.Point(77, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 48);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(241, 189);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(278, 97);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.ControlBox = false;
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
    }
}