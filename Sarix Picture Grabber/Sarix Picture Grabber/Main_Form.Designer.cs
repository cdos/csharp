namespace Sarix_Picture_Grabber
{
    partial class Main_Form
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.tBx_IPADDR = new System.Windows.Forms.TextBox();
            this.tBx_NUMPICT = new System.Windows.Forms.TextBox();
            this.tBx_PICTTIME = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBx_TESTNAME = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rB_Pelco = new System.Windows.Forms.RadioButton();
            this.rB_Axis = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(358, 144);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // tBx_IPADDR
            // 
            this.tBx_IPADDR.Location = new System.Drawing.Point(333, 12);
            this.tBx_IPADDR.Name = "tBx_IPADDR";
            this.tBx_IPADDR.Size = new System.Drawing.Size(100, 20);
            this.tBx_IPADDR.TabIndex = 1;
            // 
            // tBx_NUMPICT
            // 
            this.tBx_NUMPICT.Location = new System.Drawing.Point(333, 38);
            this.tBx_NUMPICT.Name = "tBx_NUMPICT";
            this.tBx_NUMPICT.Size = new System.Drawing.Size(100, 20);
            this.tBx_NUMPICT.TabIndex = 2;
            // 
            // tBx_PICTTIME
            // 
            this.tBx_PICTTIME.Location = new System.Drawing.Point(333, 64);
            this.tBx_PICTTIME.Name = "tBx_PICTTIME";
            this.tBx_PICTTIME.Size = new System.Drawing.Size(100, 20);
            this.tBx_PICTTIME.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "# of Pictures:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time between Pictures(ms):";
            // 
            // tBx_TESTNAME
            // 
            this.tBx_TESTNAME.Location = new System.Drawing.Point(333, 91);
            this.tBx_TESTNAME.Name = "tBx_TESTNAME";
            this.tBx_TESTNAME.Size = new System.Drawing.Size(100, 20);
            this.tBx_TESTNAME.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Test Name:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(112, 144);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(240, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // rB_Pelco
            // 
            this.rB_Pelco.AutoSize = true;
            this.rB_Pelco.Location = new System.Drawing.Point(10, 19);
            this.rB_Pelco.Name = "rB_Pelco";
            this.rB_Pelco.Size = new System.Drawing.Size(52, 17);
            this.rB_Pelco.TabIndex = 11;
            this.rB_Pelco.TabStop = true;
            this.rB_Pelco.Text = "Pelco";
            this.rB_Pelco.UseVisualStyleBackColor = true;
            // 
            // rB_Axis
            // 
            this.rB_Axis.AutoSize = true;
            this.rB_Axis.Location = new System.Drawing.Point(10, 42);
            this.rB_Axis.Name = "rB_Axis";
            this.rB_Axis.Size = new System.Drawing.Size(44, 17);
            this.rB_Axis.TabIndex = 12;
            this.rB_Axis.TabStop = true;
            this.rB_Axis.Text = "Axis";
            this.rB_Axis.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rB_Axis);
            this.groupBox1.Controls.Add(this.rB_Pelco);
            this.groupBox1.Location = new System.Drawing.Point(6, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 73);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Type";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 180);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBx_TESTNAME);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBx_PICTTIME);
            this.Controls.Add(this.tBx_NUMPICT);
            this.Controls.Add(this.tBx_IPADDR);
            this.Controls.Add(this.btn_Start);
            this.Name = "Main_Form";
            this.Text = "IP Camera Frame Grabber";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox tBx_IPADDR;
        private System.Windows.Forms.TextBox tBx_NUMPICT;
        private System.Windows.Forms.TextBox tBx_PICTTIME;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBx_TESTNAME;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton rB_Pelco;
        private System.Windows.Forms.RadioButton rB_Axis;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

