namespace PTZCameraTester
{
    partial class TestView
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
            this.webConsole = new System.Windows.Forms.WebBrowser();
            this.TestProgressLabel = new System.Windows.Forms.Label();
            this.TestProgressBar = new System.Windows.Forms.ProgressBar();
            this.AbortButton = new System.Windows.Forms.Button();
            this.TestTitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webConsole
            // 
            this.webConsole.IsWebBrowserContextMenuEnabled = false;
            this.webConsole.Location = new System.Drawing.Point(12, 58);
            this.webConsole.MinimumSize = new System.Drawing.Size(20, 20);
            this.webConsole.Name = "webConsole";
            this.webConsole.Size = new System.Drawing.Size(757, 455);
            this.webConsole.TabIndex = 10;
            this.webConsole.WebBrowserShortcutsEnabled = false;
            // 
            // TestProgressLabel
            // 
            this.TestProgressLabel.AutoSize = true;
            this.TestProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestProgressLabel.Location = new System.Drawing.Point(729, 533);
            this.TestProgressLabel.Name = "TestProgressLabel";
            this.TestProgressLabel.Size = new System.Drawing.Size(32, 20);
            this.TestProgressLabel.TabIndex = 13;
            this.TestProgressLabel.Text = "0%";
            this.TestProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TestProgressBar
            // 
            this.TestProgressBar.Location = new System.Drawing.Point(22, 533);
            this.TestProgressBar.Name = "TestProgressBar";
            this.TestProgressBar.Size = new System.Drawing.Size(701, 20);
            this.TestProgressBar.TabIndex = 12;
            // 
            // AbortButton
            // 
            this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AbortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbortButton.Location = new System.Drawing.Point(635, 12);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(126, 40);
            this.AbortButton.TabIndex = 14;
            this.AbortButton.Text = "ABORT";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // TestTitleLabel
            // 
            this.TestTitleLabel.AutoSize = true;
            this.TestTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestTitleLabel.Location = new System.Drawing.Point(19, 12);
            this.TestTitleLabel.Name = "TestTitleLabel";
            this.TestTitleLabel.Size = new System.Drawing.Size(286, 37);
            this.TestTitleLabel.TabIndex = 16;
            this.TestTitleLabel.Text = "Test in Progress....";
            // 
            // TestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.ControlBox = false;
            this.Controls.Add(this.TestTitleLabel);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.TestProgressLabel);
            this.Controls.Add(this.TestProgressBar);
            this.Controls.Add(this.webConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TestView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Test Console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webConsole;
        private System.Windows.Forms.Label TestProgressLabel;
        private System.Windows.Forms.ProgressBar TestProgressBar;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.Label TestTitleLabel;
    }
}