
namespace Oscillo_Logger
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_OpenSession = new System.Windows.Forms.Button();
            this.QueryTextBox = new System.Windows.Forms.TextBox();
            this.readTextBox = new System.Windows.Forms.TextBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.writeTextBox = new System.Windows.Forms.TextBox();
            this.writeButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_cycle = new System.Windows.Forms.TextBox();
            this.label_timer = new System.Windows.Forms.Label();
            this.label_s = new System.Windows.Forms.Label();
            this.textBox_interval = new System.Windows.Forms.TextBox();
            this.label_LogPATH = new System.Windows.Forms.Label();
            this.PATH_box = new System.Windows.Forms.TextBox();
            this.PATH_button = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_M4 = new System.Windows.Forms.Label();
            this.label_M3 = new System.Windows.Forms.Label();
            this.label_M2 = new System.Windows.Forms.Label();
            this.textBox_M4 = new System.Windows.Forms.TextBox();
            this.textBox_M3 = new System.Windows.Forms.TextBox();
            this.textBox_M2 = new System.Windows.Forms.TextBox();
            this.textBox_M1 = new System.Windows.Forms.TextBox();
            this.label_M1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.start_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_endtime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_filename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_T = new System.Windows.Forms.TextBox();
            this.label_T = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.button_OpenSession);
            this.groupBox2.Controls.Add(this.QueryTextBox);
            this.groupBox2.Controls.Add(this.readTextBox);
            this.groupBox2.Controls.Add(this.queryButton);
            this.groupBox2.Controls.Add(this.writeTextBox);
            this.groupBox2.Controls.Add(this.writeButton);
            this.groupBox2.Location = new System.Drawing.Point(21, 193);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(307, 225);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Oscilloscope(VISA)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 142);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 16);
            this.checkBox1.TabIndex = 52;
            this.checkBox1.Text = "Show details";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_OpenSession
            // 
            this.button_OpenSession.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_OpenSession.Location = new System.Drawing.Point(22, 29);
            this.button_OpenSession.Name = "button_OpenSession";
            this.button_OpenSession.Size = new System.Drawing.Size(100, 34);
            this.button_OpenSession.TabIndex = 46;
            this.button_OpenSession.Text = "Connect";
            this.button_OpenSession.UseVisualStyleBackColor = true;
            this.button_OpenSession.Click += new System.EventHandler(this.button_OpenSession_Click);
            // 
            // QueryTextBox
            // 
            this.QueryTextBox.Location = new System.Drawing.Point(22, 183);
            this.QueryTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.QueryTextBox.Name = "QueryTextBox";
            this.QueryTextBox.Size = new System.Drawing.Size(175, 19);
            this.QueryTextBox.TabIndex = 51;
            this.QueryTextBox.Text = "*IDN?";
            // 
            // readTextBox
            // 
            this.readTextBox.Location = new System.Drawing.Point(22, 68);
            this.readTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.readTextBox.Multiline = true;
            this.readTextBox.Name = "readTextBox";
            this.readTextBox.Size = new System.Drawing.Size(264, 54);
            this.readTextBox.TabIndex = 47;
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(203, 183);
            this.queryButton.Margin = new System.Windows.Forms.Padding(2);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(83, 18);
            this.queryButton.TabIndex = 48;
            this.queryButton.Text = "Query";
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // writeTextBox
            // 
            this.writeTextBox.Location = new System.Drawing.Point(22, 163);
            this.writeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.writeTextBox.Name = "writeTextBox";
            this.writeTextBox.Size = new System.Drawing.Size(175, 19);
            this.writeTextBox.TabIndex = 49;
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(203, 162);
            this.writeButton.Margin = new System.Windows.Forms.Padding(2);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(83, 18);
            this.writeButton.TabIndex = 50;
            this.writeButton.Text = "Write";
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox_endtime);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_cycle);
            this.groupBox3.Controls.Add(this.label_timer);
            this.groupBox3.Controls.Add(this.label_s);
            this.groupBox3.Controls.Add(this.textBox_interval);
            this.groupBox3.Location = new System.Drawing.Point(21, 26);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(307, 147);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Measurement Setting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 51);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 12);
            this.label5.TabIndex = 52;
            this.label5.Text = "Cycle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 12);
            this.label6.TabIndex = 53;
            this.label6.Text = "times";
            // 
            // textBox_cycle
            // 
            this.textBox_cycle.Location = new System.Drawing.Point(113, 49);
            this.textBox_cycle.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_cycle.Name = "textBox_cycle";
            this.textBox_cycle.Size = new System.Drawing.Size(84, 19);
            this.textBox_cycle.TabIndex = 54;
            this.textBox_cycle.TextChanged += new System.EventHandler(this.update_endtime);
            this.textBox_cycle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_cycle_KeyPress);
            // 
            // label_timer
            // 
            this.label_timer.AutoSize = true;
            this.label_timer.Location = new System.Drawing.Point(20, 30);
            this.label_timer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_timer.Name = "label_timer";
            this.label_timer.Size = new System.Drawing.Size(57, 12);
            this.label_timer.TabIndex = 20;
            this.label_timer.Text = "Time Step";
            // 
            // label_s
            // 
            this.label_s.AutoSize = true;
            this.label_s.Location = new System.Drawing.Point(201, 30);
            this.label_s.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_s.Name = "label_s";
            this.label_s.Size = new System.Drawing.Size(23, 12);
            this.label_s.TabIndex = 20;
            this.label_s.Text = "sec";
            // 
            // textBox_interval
            // 
            this.textBox_interval.Location = new System.Drawing.Point(113, 28);
            this.textBox_interval.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_interval.Name = "textBox_interval";
            this.textBox_interval.Size = new System.Drawing.Size(84, 19);
            this.textBox_interval.TabIndex = 20;
            this.textBox_interval.Text = "10";
            this.textBox_interval.TextChanged += new System.EventHandler(this.update_endtime);
            this.textBox_interval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_interval_KeyPress);
            // 
            // label_LogPATH
            // 
            this.label_LogPATH.AutoSize = true;
            this.label_LogPATH.Location = new System.Drawing.Point(20, 24);
            this.label_LogPATH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_LogPATH.Name = "label_LogPATH";
            this.label_LogPATH.Size = new System.Drawing.Size(64, 12);
            this.label_LogPATH.TabIndex = 19;
            this.label_LogPATH.Text = "Folder Path";
            // 
            // PATH_box
            // 
            this.PATH_box.Location = new System.Drawing.Point(22, 38);
            this.PATH_box.Margin = new System.Windows.Forms.Padding(2);
            this.PATH_box.Name = "PATH_box";
            this.PATH_box.Size = new System.Drawing.Size(232, 19);
            this.PATH_box.TabIndex = 18;
            // 
            // PATH_button
            // 
            this.PATH_button.Location = new System.Drawing.Point(258, 38);
            this.PATH_button.Margin = new System.Windows.Forms.Padding(2);
            this.PATH_button.Name = "PATH_button";
            this.PATH_button.Size = new System.Drawing.Size(28, 18);
            this.PATH_button.TabIndex = 17;
            this.PATH_button.Text = "...";
            this.PATH_button.UseVisualStyleBackColor = true;
            this.PATH_button.Click += new System.EventHandler(this.PATH_button_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_T);
            this.groupBox4.Controls.Add(this.label_T);
            this.groupBox4.Controls.Add(this.label_M4);
            this.groupBox4.Controls.Add(this.label_M3);
            this.groupBox4.Controls.Add(this.label_M2);
            this.groupBox4.Controls.Add(this.textBox_M4);
            this.groupBox4.Controls.Add(this.textBox_M3);
            this.groupBox4.Controls.Add(this.textBox_M2);
            this.groupBox4.Controls.Add(this.textBox_M1);
            this.groupBox4.Controls.Add(this.label_M1);
            this.groupBox4.Controls.Add(this.chart1);
            this.groupBox4.Location = new System.Drawing.Point(338, 26);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(864, 709);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Measurement Data ";
            // 
            // label_M4
            // 
            this.label_M4.AutoSize = true;
            this.label_M4.Location = new System.Drawing.Point(421, 28);
            this.label_M4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_M4.Name = "label_M4";
            this.label_M4.Size = new System.Drawing.Size(54, 12);
            this.label_M4.TabIndex = 62;
            this.label_M4.Text = "Measure4";
            // 
            // label_M3
            // 
            this.label_M3.AutoSize = true;
            this.label_M3.Location = new System.Drawing.Point(321, 28);
            this.label_M3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_M3.Name = "label_M3";
            this.label_M3.Size = new System.Drawing.Size(54, 12);
            this.label_M3.TabIndex = 61;
            this.label_M3.Text = "Measure3";
            // 
            // label_M2
            // 
            this.label_M2.AutoSize = true;
            this.label_M2.Location = new System.Drawing.Point(221, 28);
            this.label_M2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_M2.Name = "label_M2";
            this.label_M2.Size = new System.Drawing.Size(54, 12);
            this.label_M2.TabIndex = 60;
            this.label_M2.Text = "Measure2";
            // 
            // textBox_M4
            // 
            this.textBox_M4.Location = new System.Drawing.Point(423, 44);
            this.textBox_M4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_M4.Multiline = true;
            this.textBox_M4.Name = "textBox_M4";
            this.textBox_M4.Size = new System.Drawing.Size(92, 75);
            this.textBox_M4.TabIndex = 59;
            // 
            // textBox_M3
            // 
            this.textBox_M3.Location = new System.Drawing.Point(323, 44);
            this.textBox_M3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_M3.Multiline = true;
            this.textBox_M3.Name = "textBox_M3";
            this.textBox_M3.Size = new System.Drawing.Size(92, 75);
            this.textBox_M3.TabIndex = 58;
            // 
            // textBox_M2
            // 
            this.textBox_M2.Location = new System.Drawing.Point(223, 44);
            this.textBox_M2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_M2.Multiline = true;
            this.textBox_M2.Name = "textBox_M2";
            this.textBox_M2.Size = new System.Drawing.Size(92, 75);
            this.textBox_M2.TabIndex = 57;
            // 
            // textBox_M1
            // 
            this.textBox_M1.Location = new System.Drawing.Point(123, 44);
            this.textBox_M1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_M1.Multiline = true;
            this.textBox_M1.Name = "textBox_M1";
            this.textBox_M1.Size = new System.Drawing.Size(92, 75);
            this.textBox_M1.TabIndex = 56;
            // 
            // label_M1
            // 
            this.label_M1.AutoSize = true;
            this.label_M1.Location = new System.Drawing.Point(121, 28);
            this.label_M1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_M1.Name = "label_M1";
            this.label_M1.Size = new System.Drawing.Size(54, 12);
            this.label_M1.TabIndex = 54;
            this.label_M1.Text = "Measure1";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(24, 136);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(816, 548);
            this.chart1.TabIndex = 50;
            this.chart1.Text = "chart1";
            this.chart1.DoubleClick += new System.EventHandler(this.chart1_DoubleClick);
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.start_button.Location = new System.Drawing.Point(43, 606);
            this.start_button.Margin = new System.Windows.Forms.Padding(2);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(264, 48);
            this.start_button.TabIndex = 49;
            this.start_button.Text = "START LOG";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stop_button.Location = new System.Drawing.Point(43, 677);
            this.stop_button.Margin = new System.Windows.Forms.Padding(2);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(264, 48);
            this.stop_button.TabIndex = 50;
            this.stop_button.Text = "STOP LOG";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.textBox_filename);
            this.groupBox5.Controls.Add(this.PATH_box);
            this.groupBox5.Controls.Add(this.PATH_button);
            this.groupBox5.Controls.Add(this.label_LogPATH);
            this.groupBox5.Location = new System.Drawing.Point(21, 443);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(307, 122);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save CSV";
            // 
            // textBox_endtime
            // 
            this.textBox_endtime.Location = new System.Drawing.Point(113, 100);
            this.textBox_endtime.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_endtime.Name = "textBox_endtime";
            this.textBox_endtime.Size = new System.Drawing.Size(84, 19);
            this.textBox_endtime.TabIndex = 55;
            this.textBox_endtime.Text = "Until it stops";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 56;
            this.label1.Text = "hour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 57;
            this.label2.Text = "End Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 58;
            this.label4.Text = "↓";
            // 
            // textBox_filename
            // 
            this.textBox_filename.Location = new System.Drawing.Point(22, 83);
            this.textBox_filename.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_filename.Name = "textBox_filename";
            this.textBox_filename.Size = new System.Drawing.Size(232, 19);
            this.textBox_filename.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "File Name";
            // 
            // textBox_T
            // 
            this.textBox_T.Location = new System.Drawing.Point(23, 44);
            this.textBox_T.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_T.Multiline = true;
            this.textBox_T.Name = "textBox_T";
            this.textBox_T.Size = new System.Drawing.Size(92, 75);
            this.textBox_T.TabIndex = 64;
            // 
            // label_T
            // 
            this.label_T.AutoSize = true;
            this.label_T.Location = new System.Drawing.Point(21, 28);
            this.label_T.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_T.Name = "label_T";
            this.label_T.Size = new System.Drawing.Size(30, 12);
            this.label_T.TabIndex = 63;
            this.label_T.Text = "Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 760);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_LogPATH;
        private System.Windows.Forms.TextBox PATH_box;
        private System.Windows.Forms.Button PATH_button;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox QueryTextBox;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.TextBox writeTextBox;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.TextBox readTextBox;
        private System.Windows.Forms.Button button_OpenSession;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Label label_M4;
        private System.Windows.Forms.Label label_M3;
        private System.Windows.Forms.Label label_M2;
        private System.Windows.Forms.TextBox textBox_M4;
        private System.Windows.Forms.TextBox textBox_M3;
        private System.Windows.Forms.TextBox textBox_M2;
        private System.Windows.Forms.TextBox textBox_M1;
        private System.Windows.Forms.Label label_M1;
        private System.Windows.Forms.Label label_timer;
        private System.Windows.Forms.Label label_s;
        private System.Windows.Forms.TextBox textBox_interval;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_cycle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_endtime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_filename;
        private System.Windows.Forms.TextBox textBox_T;
        private System.Windows.Forms.Label label_T;
    }
}

