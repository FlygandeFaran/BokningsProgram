namespace BokningsProgram
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnExecute = new System.Windows.Forms.Button();
            this.dtpBehTid = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSickLeave = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbDescription = new System.Windows.Forms.ComboBox();
            this.cbEntireDayBooking = new System.Windows.Forms.CheckBox();
            this.cbNystart = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbFlerdagsbeh = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbAvailableSSK = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbAvailableRooms = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NySSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NyttRumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rbChartSSK = new System.Windows.Forms.RadioButton();
            this.rbChartRoom = new System.Windows.Forms.RadioButton();
            this.dtpScheduleDay = new System.Windows.Forms.DateTimePicker();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.btnPrevDay = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(34, 103);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(50, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Boka";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // dtpBehTid
            // 
            this.dtpBehTid.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBehTid.Location = new System.Drawing.Point(6, 88);
            this.dtpBehTid.Name = "dtpBehTid";
            this.dtpBehTid.Size = new System.Drawing.Size(50, 20);
            this.dtpBehTid.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSickLeave);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 788);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bokning";
            // 
            // btnSickLeave
            // 
            this.btnSickLeave.Location = new System.Drawing.Point(28, 752);
            this.btnSickLeave.Name = "btnSickLeave";
            this.btnSickLeave.Size = new System.Drawing.Size(93, 23);
            this.btnSickLeave.TabIndex = 31;
            this.btnSickLeave.Text = "Sjukanmälan";
            this.btnSickLeave.UseVisualStyleBackColor = true;
            this.btnSickLeave.Click += new System.EventHandler(this.btnSickLeave_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbDescription);
            this.groupBox6.Controls.Add(this.cbEntireDayBooking);
            this.groupBox6.Controls.Add(this.cbNystart);
            this.groupBox6.Controls.Add(this.btnExecute);
            this.groupBox6.Location = new System.Drawing.Point(6, 302);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(148, 136);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Beskrivning";
            // 
            // cbDescription
            // 
            this.cbDescription.FormattingEnabled = true;
            this.cbDescription.Location = new System.Drawing.Point(6, 19);
            this.cbDescription.Name = "cbDescription";
            this.cbDescription.Size = new System.Drawing.Size(100, 21);
            this.cbDescription.TabIndex = 18;
            this.cbDescription.SelectedIndexChanged += new System.EventHandler(this.cbDescription_SelectedIndexChanged);
            // 
            // cbEntireDayBooking
            // 
            this.cbEntireDayBooking.AutoSize = true;
            this.cbEntireDayBooking.Location = new System.Drawing.Point(6, 46);
            this.cbEntireDayBooking.Name = "cbEntireDayBooking";
            this.cbEntireDayBooking.Size = new System.Drawing.Size(60, 17);
            this.cbEntireDayBooking.TabIndex = 21;
            this.cbEntireDayBooking.Text = "Heldag";
            this.cbEntireDayBooking.UseVisualStyleBackColor = true;
            this.cbEntireDayBooking.CheckedChanged += new System.EventHandler(this.cbEntireDayBooking_CheckedChanged);
            // 
            // cbNystart
            // 
            this.cbNystart.AutoSize = true;
            this.cbNystart.Location = new System.Drawing.Point(6, 69);
            this.cbNystart.Name = "cbNystart";
            this.cbNystart.Size = new System.Drawing.Size(59, 17);
            this.cbNystart.TabIndex = 22;
            this.cbNystart.Text = "Nystart";
            this.cbNystart.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbFlerdagsbeh);
            this.groupBox5.Controls.Add(this.dtpEndDate);
            this.groupBox5.Controls.Add(this.lblStartDate);
            this.groupBox5.Controls.Add(this.dtpStartDate);
            this.groupBox5.Controls.Add(this.lblEndDate);
            this.groupBox5.Location = new System.Drawing.Point(6, 161);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(148, 135);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Välj dagar";
            // 
            // cbFlerdagsbeh
            // 
            this.cbFlerdagsbeh.AutoSize = true;
            this.cbFlerdagsbeh.Location = new System.Drawing.Point(6, 19);
            this.cbFlerdagsbeh.Name = "cbFlerdagsbeh";
            this.cbFlerdagsbeh.Size = new System.Drawing.Size(118, 17);
            this.cbFlerdagsbeh.TabIndex = 16;
            this.cbFlerdagsbeh.Text = "Flerdagsbehandling";
            this.cbFlerdagsbeh.UseVisualStyleBackColor = true;
            this.cbFlerdagsbeh.CheckedChanged += new System.EventHandler(this.cbFlerdagsbeh_CheckedChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(6, 102);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(76, 20);
            this.dtpEndDate.TabIndex = 17;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Enabled = false;
            this.lblStartDate.Location = new System.Drawing.Point(6, 44);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(38, 13);
            this.lblStartDate.TabIndex = 20;
            this.lblStartDate.Text = "Startar";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(6, 60);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(76, 20);
            this.dtpStartDate.TabIndex = 18;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Enabled = false;
            this.lblEndDate.Location = new System.Drawing.Point(6, 86);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(34, 13);
            this.lblEndDate.TabIndex = 19;
            this.lblEndDate.Text = "Slutar";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dtpStartTime);
            this.groupBox4.Controls.Add(this.dtpBehTid);
            this.groupBox4.Location = new System.Drawing.Point(6, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 135);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Behandlingstid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Starttid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Varaktighet (h)";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(6, 36);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(50, 20);
            this.dtpStartTime.TabIndex = 25;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.lbAvailableSSK);
            this.groupBox2.Location = new System.Drawing.Point(6, 444);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 148);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sköterskor";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Två spår";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lbAvailableSSK
            // 
            this.lbAvailableSSK.FormattingEnabled = true;
            this.lbAvailableSSK.Location = new System.Drawing.Point(6, 41);
            this.lbAvailableSSK.Name = "lbAvailableSSK";
            this.lbAvailableSSK.Size = new System.Drawing.Size(120, 95);
            this.lbAvailableSSK.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbAvailableRooms);
            this.groupBox3.Location = new System.Drawing.Point(6, 598);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 148);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rum";
            // 
            // lbAvailableRooms
            // 
            this.lbAvailableRooms.Enabled = false;
            this.lbAvailableRooms.FormattingEnabled = true;
            this.lbAvailableRooms.Location = new System.Drawing.Point(6, 28);
            this.lbAvailableRooms.Name = "lbAvailableRooms";
            this.lbAvailableRooms.Size = new System.Drawing.Size(120, 108);
            this.lbAvailableRooms.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1166, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NySSKToolStripMenuItem,
            this.NyttRumToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // NySSKToolStripMenuItem
            // 
            this.NySSKToolStripMenuItem.Name = "NySSKToolStripMenuItem";
            this.NySSKToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.NySSKToolStripMenuItem.Text = "Lägg till sköterska";
            this.NySSKToolStripMenuItem.Click += new System.EventHandler(this.NySSKToolStripMenuItem_Click);
            // 
            // NyttRumToolStripMenuItem
            // 
            this.NyttRumToolStripMenuItem.Name = "NyttRumToolStripMenuItem";
            this.NyttRumToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.NyttRumToolStripMenuItem.Text = "Lägg till rum";
            this.NyttRumToolStripMenuItem.Click += new System.EventHandler(this.NyttRumToolStripMenuItem_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(172, 86);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(982, 779);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // rbChartSSK
            // 
            this.rbChartSSK.AutoSize = true;
            this.rbChartSSK.Checked = true;
            this.rbChartSSK.Location = new System.Drawing.Point(1082, 62);
            this.rbChartSSK.Name = "rbChartSSK";
            this.rbChartSSK.Size = new System.Drawing.Size(46, 17);
            this.rbChartSSK.TabIndex = 16;
            this.rbChartSSK.TabStop = true;
            this.rbChartSSK.Text = "SSK";
            this.rbChartSSK.UseVisualStyleBackColor = true;
            // 
            // rbChartRoom
            // 
            this.rbChartRoom.AutoSize = true;
            this.rbChartRoom.Location = new System.Drawing.Point(1018, 62);
            this.rbChartRoom.Name = "rbChartRoom";
            this.rbChartRoom.Size = new System.Drawing.Size(47, 17);
            this.rbChartRoom.TabIndex = 17;
            this.rbChartRoom.Text = "Rum";
            this.rbChartRoom.UseVisualStyleBackColor = true;
            this.rbChartRoom.CheckedChanged += new System.EventHandler(this.rbChartRoom_CheckedChanged);
            // 
            // dtpScheduleDay
            // 
            this.dtpScheduleDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduleDay.Location = new System.Drawing.Point(845, 60);
            this.dtpScheduleDay.Name = "dtpScheduleDay";
            this.dtpScheduleDay.Size = new System.Drawing.Size(93, 20);
            this.dtpScheduleDay.TabIndex = 28;
            this.dtpScheduleDay.ValueChanged += new System.EventHandler(this.dtpScheduleDay_ValueChanged);
            // 
            // btnNextDay
            // 
            this.btnNextDay.Location = new System.Drawing.Point(944, 60);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(28, 20);
            this.btnNextDay.TabIndex = 27;
            this.btnNextDay.Text = "->";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // btnPrevDay
            // 
            this.btnPrevDay.Location = new System.Drawing.Point(811, 60);
            this.btnPrevDay.Name = "btnPrevDay";
            this.btnPrevDay.Size = new System.Drawing.Size(28, 20);
            this.btnPrevDay.TabIndex = 29;
            this.btnPrevDay.Text = "<-";
            this.btnPrevDay.UseVisualStyleBackColor = true;
            this.btnPrevDay.Click += new System.EventHandler(this.btnPrevDay_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(813, 32);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(65, 13);
            this.lblWarning.TabIndex = 30;
            this.lblWarning.Text = "Varningstext";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 877);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.btnPrevDay);
            this.Controls.Add(this.btnNextDay);
            this.Controls.Add(this.dtpScheduleDay);
            this.Controls.Add(this.rbChartRoom);
            this.Controls.Add(this.rbChartSSK);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bokningssystem Dagvård av Erik Fura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.DateTimePicker dtpBehTid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbFlerdagsbeh;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbAvailableSSK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbAvailableRooms;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NySSKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NyttRumToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox cbEntireDayBooking;
        private System.Windows.Forms.CheckBox cbNystart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbChartSSK;
        private System.Windows.Forms.RadioButton rbChartRoom;
        private System.Windows.Forms.ComboBox cbDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpScheduleDay;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.Button btnPrevDay;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnSickLeave;
    }
}

