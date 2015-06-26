namespace WeatherApp
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
            this.components = new System.ComponentModel.Container();
            this.lstWeather = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.towntxtbox = new System.Windows.Forms.TextBox();
            this.conditiontxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.temperaturetxtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.humiditytxtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.windspeedtxtbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tomorrowcondtxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tomorrowhightxtbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tomorrowlowtxtbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.getweatherbutton = new System.Windows.Forms.Button();
            this.oeidcmbox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstWeather
            // 
            this.lstWeather.FormattingEnabled = true;
            this.lstWeather.Location = new System.Drawing.Point(24, 30);
            this.lstWeather.Name = "lstWeather";
            this.lstWeather.Size = new System.Drawing.Size(248, 121);
            this.lstWeather.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateTime.Location = new System.Drawing.Point(21, 9);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(35, 15);
            this.lblUpdateTime.TabIndex = 1;
            this.lblUpdateTime.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Town";
            // 
            // towntxtbox
            // 
            this.towntxtbox.Location = new System.Drawing.Point(407, 59);
            this.towntxtbox.Name = "towntxtbox";
            this.towntxtbox.Size = new System.Drawing.Size(100, 20);
            this.towntxtbox.TabIndex = 3;
            // 
            // conditiontxtbox
            // 
            this.conditiontxtbox.Location = new System.Drawing.Point(407, 85);
            this.conditiontxtbox.Name = "conditiontxtbox";
            this.conditiontxtbox.Size = new System.Drawing.Size(100, 20);
            this.conditiontxtbox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Condition";
            // 
            // temperaturetxtbox
            // 
            this.temperaturetxtbox.Location = new System.Drawing.Point(407, 111);
            this.temperaturetxtbox.Name = "temperaturetxtbox";
            this.temperaturetxtbox.Size = new System.Drawing.Size(100, 20);
            this.temperaturetxtbox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Temperature";
            // 
            // humiditytxtbox
            // 
            this.humiditytxtbox.Location = new System.Drawing.Point(407, 137);
            this.humiditytxtbox.Name = "humiditytxtbox";
            this.humiditytxtbox.Size = new System.Drawing.Size(100, 20);
            this.humiditytxtbox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Humidity";
            // 
            // windspeedtxtbox
            // 
            this.windspeedtxtbox.Location = new System.Drawing.Point(407, 163);
            this.windspeedtxtbox.Name = "windspeedtxtbox";
            this.windspeedtxtbox.Size = new System.Drawing.Size(100, 20);
            this.windspeedtxtbox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Wind Speed";
            // 
            // tomorrowcondtxtbox
            // 
            this.tomorrowcondtxtbox.Location = new System.Drawing.Point(407, 189);
            this.tomorrowcondtxtbox.Name = "tomorrowcondtxtbox";
            this.tomorrowcondtxtbox.Size = new System.Drawing.Size(100, 20);
            this.tomorrowcondtxtbox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tomorrow Condition";
            // 
            // tomorrowhightxtbox
            // 
            this.tomorrowhightxtbox.Location = new System.Drawing.Point(407, 215);
            this.tomorrowhightxtbox.Name = "tomorrowhightxtbox";
            this.tomorrowhightxtbox.Size = new System.Drawing.Size(100, 20);
            this.tomorrowhightxtbox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tomorrow High";
            // 
            // tomorrowlowtxtbox
            // 
            this.tomorrowlowtxtbox.Location = new System.Drawing.Point(407, 241);
            this.tomorrowlowtxtbox.Name = "tomorrowlowtxtbox";
            this.tomorrowlowtxtbox.Size = new System.Drawing.Size(100, 20);
            this.tomorrowlowtxtbox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(302, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tomorrow Low";
            // 
            // getweatherbutton
            // 
            this.getweatherbutton.Location = new System.Drawing.Point(407, 267);
            this.getweatherbutton.Name = "getweatherbutton";
            this.getweatherbutton.Size = new System.Drawing.Size(98, 23);
            this.getweatherbutton.TabIndex = 18;
            this.getweatherbutton.Text = "Get Weather";
            this.getweatherbutton.UseVisualStyleBackColor = true;
            this.getweatherbutton.Click += new System.EventHandler(this.getweatherbutton_Click);
            // 
            // oeidcmbox
            // 
            this.oeidcmbox.FormattingEnabled = true;
            this.oeidcmbox.Location = new System.Drawing.Point(407, 32);
            this.oeidcmbox.Name = "oeidcmbox";
            this.oeidcmbox.Size = new System.Drawing.Size(100, 21);
            this.oeidcmbox.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(302, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "OEID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 321);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.oeidcmbox);
            this.Controls.Add(this.getweatherbutton);
            this.Controls.Add(this.tomorrowlowtxtbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tomorrowhightxtbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tomorrowcondtxtbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.windspeedtxtbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.humiditytxtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.temperaturetxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.conditiontxtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.towntxtbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUpdateTime);
            this.Controls.Add(this.lstWeather);
            this.Name = "Form1";
            this.Text = "Weather App Yahoo API";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstWeather;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox towntxtbox;
        private System.Windows.Forms.TextBox conditiontxtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox temperaturetxtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox humiditytxtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox windspeedtxtbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tomorrowcondtxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tomorrowhightxtbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tomorrowlowtxtbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button getweatherbutton;
        private System.Windows.Forms.ComboBox oeidcmbox;
        private System.Windows.Forms.Label label9;
    }
}

