﻿namespace BokningsProgram
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
            this.cbPiccline = new System.Windows.Forms.CheckBox();
            this.cbNystart = new System.Windows.Forms.CheckBox();
            this.cbEntireDayBooking = new System.Windows.Forms.CheckBox();
            this.lblSlut = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpSlutar = new System.Windows.Forms.DateTimePicker();
            this.dtpStartar = new System.Windows.Forms.DateTimePicker();
            this.cbFlerdagsbeh = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbAvailableSSK = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NySSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NyttRumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbChartSSK = new System.Windows.Forms.RadioButton();
            this.rbChartRoom = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(393, 127);
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
            this.dtpBehTid.Location = new System.Drawing.Point(6, 26);
            this.dtpBehTid.Name = "dtpBehTid";
            this.dtpBehTid.Size = new System.Drawing.Size(50, 20);
            this.dtpBehTid.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnExecute);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 162);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bokning";
            // 
            // cbPiccline
            // 
            this.cbPiccline.AutoSize = true;
            this.cbPiccline.Location = new System.Drawing.Point(6, 107);
            this.cbPiccline.Name = "cbPiccline";
            this.cbPiccline.Size = new System.Drawing.Size(63, 17);
            this.cbPiccline.TabIndex = 23;
            this.cbPiccline.Text = "Piccline";
            this.cbPiccline.UseVisualStyleBackColor = true;
            // 
            // cbNystart
            // 
            this.cbNystart.AutoSize = true;
            this.cbNystart.Location = new System.Drawing.Point(6, 84);
            this.cbNystart.Name = "cbNystart";
            this.cbNystart.Size = new System.Drawing.Size(59, 17);
            this.cbNystart.TabIndex = 22;
            this.cbNystart.Text = "Nystart";
            this.cbNystart.UseVisualStyleBackColor = true;
            // 
            // cbEntireDayBooking
            // 
            this.cbEntireDayBooking.AutoSize = true;
            this.cbEntireDayBooking.Location = new System.Drawing.Point(6, 61);
            this.cbEntireDayBooking.Name = "cbEntireDayBooking";
            this.cbEntireDayBooking.Size = new System.Drawing.Size(60, 17);
            this.cbEntireDayBooking.TabIndex = 21;
            this.cbEntireDayBooking.Text = "Heldag";
            this.cbEntireDayBooking.UseVisualStyleBackColor = true;
            this.cbEntireDayBooking.CheckedChanged += new System.EventHandler(this.cbEntireDayBooking_CheckedChanged);
            // 
            // lblSlut
            // 
            this.lblSlut.AutoSize = true;
            this.lblSlut.Enabled = false;
            this.lblSlut.Location = new System.Drawing.Point(6, 44);
            this.lblSlut.Name = "lblSlut";
            this.lblSlut.Size = new System.Drawing.Size(34, 13);
            this.lblSlut.TabIndex = 20;
            this.lblSlut.Text = "Slutar";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Enabled = false;
            this.lblStart.Location = new System.Drawing.Point(6, 86);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(34, 13);
            this.lblStart.TabIndex = 19;
            this.lblStart.Text = "Börjar";
            // 
            // dtpSlutar
            // 
            this.dtpSlutar.Enabled = false;
            this.dtpSlutar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSlutar.Location = new System.Drawing.Point(6, 60);
            this.dtpSlutar.Name = "dtpSlutar";
            this.dtpSlutar.Size = new System.Drawing.Size(76, 20);
            this.dtpSlutar.TabIndex = 18;
            // 
            // dtpStartar
            // 
            this.dtpStartar.Enabled = false;
            this.dtpStartar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartar.Location = new System.Drawing.Point(6, 102);
            this.dtpStartar.Name = "dtpStartar";
            this.dtpStartar.Size = new System.Drawing.Size(76, 20);
            this.dtpStartar.TabIndex = 17;
            // 
            // cbFlerdagsbeh
            // 
            this.cbFlerdagsbeh.AutoSize = true;
            this.cbFlerdagsbeh.Location = new System.Drawing.Point(6, 19);
            this.cbFlerdagsbeh.Name = "cbFlerdagsbeh";
            this.cbFlerdagsbeh.Size = new System.Drawing.Size(34, 17);
            this.cbFlerdagsbeh.TabIndex = 16;
            this.cbFlerdagsbeh.Text = "ja";
            this.cbFlerdagsbeh.UseVisualStyleBackColor = true;
            this.cbFlerdagsbeh.CheckedChanged += new System.EventHandler(this.cbFlerdagsbeh_CheckedChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 19);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 110);
            this.txtDescription.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.lbAvailableSSK);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(864, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 148);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sköterskor";
            this.groupBox2.Visible = false;
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
            this.lbAvailableSSK.Size = new System.Drawing.Size(120, 121);
            this.lbAvailableSSK.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(1010, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 148);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rum";
            this.groupBox3.Visible = false;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 28);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 134);
            this.listBox2.TabIndex = 0;
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
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 195);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1142, 441);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpBehTid);
            this.groupBox4.Controls.Add(this.cbPiccline);
            this.groupBox4.Controls.Add(this.cbNystart);
            this.groupBox4.Controls.Add(this.cbEntireDayBooking);
            this.groupBox4.Location = new System.Drawing.Point(6, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(126, 135);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Behandlingstid";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbFlerdagsbeh);
            this.groupBox5.Controls.Add(this.dtpStartar);
            this.groupBox5.Controls.Add(this.lblSlut);
            this.groupBox5.Controls.Add(this.dtpSlutar);
            this.groupBox5.Controls.Add(this.lblStart);
            this.groupBox5.Location = new System.Drawing.Point(138, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(130, 135);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Flerdagsbehandling";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtDescription);
            this.groupBox6.Location = new System.Drawing.Point(275, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(112, 135);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Beskrivning";
            // 
            // rbChartSSK
            // 
            this.rbChartSSK.AutoSize = true;
            this.rbChartSSK.Checked = true;
            this.rbChartSSK.Location = new System.Drawing.Point(640, 165);
            this.rbChartSSK.Name = "rbChartSSK";
            this.rbChartSSK.Size = new System.Drawing.Size(46, 17);
            this.rbChartSSK.TabIndex = 16;
            this.rbChartSSK.Text = "SSK";
            this.rbChartSSK.UseVisualStyleBackColor = true;
            // 
            // rbChartRoom
            // 
            this.rbChartRoom.AutoSize = true;
            this.rbChartRoom.Location = new System.Drawing.Point(573, 165);
            this.rbChartRoom.Name = "rbChartRoom";
            this.rbChartRoom.Size = new System.Drawing.Size(47, 17);
            this.rbChartRoom.TabIndex = 17;
            this.rbChartRoom.Text = "Rum";
            this.rbChartRoom.UseVisualStyleBackColor = true;
            this.rbChartRoom.CheckedChanged += new System.EventHandler(this.rbChartRoom_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 648);
            this.Controls.Add(this.rbChartRoom);
            this.Controls.Add(this.rbChartSSK);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bokningssystem Dagvård av Erik Fura";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.DateTimePicker dtpBehTid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox cbFlerdagsbeh;
        private System.Windows.Forms.DateTimePicker dtpStartar;
        private System.Windows.Forms.Label lblSlut;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpSlutar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbAvailableSSK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NySSKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NyttRumToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox cbEntireDayBooking;
        private System.Windows.Forms.CheckBox cbNystart;
        private System.Windows.Forms.CheckBox cbPiccline;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbChartSSK;
        private System.Windows.Forms.RadioButton rbChartRoom;
    }
}

