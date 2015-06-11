namespace Snapshot_Capture_Tool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bTn_FileLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tBx_VFN = new System.Windows.Forms.TextBox();
            this.tBx_SR = new System.Windows.Forms.TextBox();
            this.bTn_Start = new System.Windows.Forms.Button();
            this.tBx_status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBx_Start = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tBx_Stop = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bTn_FileLoad
            // 
            this.bTn_FileLoad.Location = new System.Drawing.Point(12, 31);
            this.bTn_FileLoad.Name = "bTn_FileLoad";
            this.bTn_FileLoad.Size = new System.Drawing.Size(75, 23);
            this.bTn_FileLoad.TabIndex = 0;
            this.bTn_FileLoad.Text = "Load";
            this.bTn_FileLoad.UseVisualStyleBackColor = true;
            this.bTn_FileLoad.Click += new System.EventHandler(this.bTn_FileLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tBx_VFN
            // 
            this.tBx_VFN.Location = new System.Drawing.Point(105, 33);
            this.tBx_VFN.Name = "tBx_VFN";
            this.tBx_VFN.Size = new System.Drawing.Size(335, 20);
            this.tBx_VFN.TabIndex = 1;
            // 
            // tBx_SR
            // 
            this.tBx_SR.Location = new System.Drawing.Point(177, 59);
            this.tBx_SR.Name = "tBx_SR";
            this.tBx_SR.Size = new System.Drawing.Size(29, 20);
            this.tBx_SR.TabIndex = 2;
            // 
            // bTn_Start
            // 
            this.bTn_Start.Location = new System.Drawing.Point(12, 110);
            this.bTn_Start.Name = "bTn_Start";
            this.bTn_Start.Size = new System.Drawing.Size(75, 23);
            this.bTn_Start.TabIndex = 4;
            this.bTn_Start.Text = "Start";
            this.bTn_Start.UseVisualStyleBackColor = true;
            this.bTn_Start.Click += new System.EventHandler(this.bTn_Start_Click);
            // 
            // tBx_status
            // 
            this.tBx_status.Location = new System.Drawing.Point(12, 139);
            this.tBx_status.Multiline = true;
            this.tBx_status.Name = "tBx_status";
            this.tBx_status.Size = new System.Drawing.Size(515, 242);
            this.tBx_status.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Video File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Scene Ratio:";
            // 
            // tBx_Start
            // 
            this.tBx_Start.Location = new System.Drawing.Point(302, 59);
            this.tBx_Start.Name = "tBx_Start";
            this.tBx_Start.Size = new System.Drawing.Size(45, 20);
            this.tBx_Start.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Start Time (sec):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stop Time (sec):";
            // 
            // tBx_Stop
            // 
            this.tBx_Stop.Location = new System.Drawing.Point(302, 85);
            this.tBx_Stop.Name = "tBx_Stop";
            this.tBx_Stop.Size = new System.Drawing.Size(45, 20);
            this.tBx_Stop.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 396);
            this.Controls.Add(this.tBx_Stop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBx_Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBx_status);
            this.Controls.Add(this.bTn_Start);
            this.Controls.Add(this.tBx_SR);
            this.Controls.Add(this.tBx_VFN);
            this.Controls.Add(this.bTn_FileLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "VLC Snapshot Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bTn_FileLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tBx_VFN;
        private System.Windows.Forms.TextBox tBx_SR;
        private System.Windows.Forms.Button bTn_Start;
        private System.Windows.Forms.TextBox tBx_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBx_Start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBx_Stop;
    }
}

