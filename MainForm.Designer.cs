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
            this.cbEntireDayBooking = new System.Windows.Forms.CheckBox();
            this.lblSlut = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpSlutar = new System.Windows.Forms.DateTimePicker();
            this.dtpStartar = new System.Windows.Forms.DateTimePicker();
            this.cbFlerdagsbeh = new System.Windows.Forms.CheckBox();
            this.rbLowKompetens = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbHighKompetens = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NySSKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NyttRumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(414, 139);
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
            this.dtpBehTid.Location = new System.Drawing.Point(126, 35);
            this.dtpBehTid.Name = "dtpBehTid";
            this.dtpBehTid.Size = new System.Drawing.Size(50, 20);
            this.dtpBehTid.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.cbEntireDayBooking);
            this.groupBox1.Controls.Add(this.lblSlut);
            this.groupBox1.Controls.Add(this.lblStart);
            this.groupBox1.Controls.Add(this.dtpSlutar);
            this.groupBox1.Controls.Add(this.dtpStartar);
            this.groupBox1.Controls.Add(this.cbFlerdagsbeh);
            this.groupBox1.Controls.Add(this.rbLowKompetens);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbHighKompetens);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpBehTid);
            this.groupBox1.Controls.Add(this.btnExecute);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 179);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bokning";
            // 
            // cbEntireDayBooking
            // 
            this.cbEntireDayBooking.AutoSize = true;
            this.cbEntireDayBooking.Location = new System.Drawing.Point(208, 38);
            this.cbEntireDayBooking.Name = "cbEntireDayBooking";
            this.cbEntireDayBooking.Size = new System.Drawing.Size(60, 17);
            this.cbEntireDayBooking.TabIndex = 21;
            this.cbEntireDayBooking.Text = "Heldag";
            this.cbEntireDayBooking.UseVisualStyleBackColor = true;
            // 
            // lblSlut
            // 
            this.lblSlut.AutoSize = true;
            this.lblSlut.Enabled = false;
            this.lblSlut.Location = new System.Drawing.Point(208, 97);
            this.lblSlut.Name = "lblSlut";
            this.lblSlut.Size = new System.Drawing.Size(34, 13);
            this.lblSlut.TabIndex = 20;
            this.lblSlut.Text = "Slutar";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Enabled = false;
            this.lblStart.Location = new System.Drawing.Point(126, 97);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(34, 13);
            this.lblStart.TabIndex = 19;
            this.lblStart.Text = "Börjar";
            // 
            // dtpSlutar
            // 
            this.dtpSlutar.Enabled = false;
            this.dtpSlutar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSlutar.Location = new System.Drawing.Point(208, 113);
            this.dtpSlutar.Name = "dtpSlutar";
            this.dtpSlutar.Size = new System.Drawing.Size(76, 20);
            this.dtpSlutar.TabIndex = 18;
            // 
            // dtpStartar
            // 
            this.dtpStartar.Enabled = false;
            this.dtpStartar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartar.Location = new System.Drawing.Point(126, 113);
            this.dtpStartar.Name = "dtpStartar";
            this.dtpStartar.Size = new System.Drawing.Size(76, 20);
            this.dtpStartar.TabIndex = 17;
            // 
            // cbFlerdagsbeh
            // 
            this.cbFlerdagsbeh.AutoSize = true;
            this.cbFlerdagsbeh.Location = new System.Drawing.Point(126, 70);
            this.cbFlerdagsbeh.Name = "cbFlerdagsbeh";
            this.cbFlerdagsbeh.Size = new System.Drawing.Size(118, 17);
            this.cbFlerdagsbeh.TabIndex = 16;
            this.cbFlerdagsbeh.Text = "Flerdagsbehandling";
            this.cbFlerdagsbeh.UseVisualStyleBackColor = true;
            this.cbFlerdagsbeh.CheckedChanged += new System.EventHandler(this.cbFlerdagsbeh_CheckedChanged);
            // 
            // rbLowKompetens
            // 
            this.rbLowKompetens.AutoSize = true;
            this.rbLowKompetens.Checked = true;
            this.rbLowKompetens.Location = new System.Drawing.Point(364, 63);
            this.rbLowKompetens.Name = "rbLowKompetens";
            this.rbLowKompetens.Size = new System.Drawing.Size(98, 17);
            this.rbLowKompetens.TabIndex = 15;
            this.rbLowKompetens.TabStop = true;
            this.rbLowKompetens.Text = "Låg kompetens";
            this.rbLowKompetens.UseVisualStyleBackColor = true;
            this.rbLowKompetens.CheckedChanged += new System.EventHandler(this.rbLowKompetens_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Kompetens";
            // 
            // rbHighKompetens
            // 
            this.rbHighKompetens.AutoSize = true;
            this.rbHighKompetens.Location = new System.Drawing.Point(364, 35);
            this.rbHighKompetens.Name = "rbHighKompetens";
            this.rbHighKompetens.Size = new System.Drawing.Size(100, 17);
            this.rbHighKompetens.TabIndex = 13;
            this.rbHighKompetens.TabStop = true;
            this.rbHighKompetens.Text = "Hög kompetens";
            this.rbHighKompetens.UseVisualStyleBackColor = true;
            this.rbHighKompetens.CheckedChanged += new System.EventHandler(this.rbHighKompetens_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Beskrivning";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 127);
            this.textBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Behandlingstid";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(495, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 179);
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 121);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Location = new System.Drawing.Point(641, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 179);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rum";
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
            this.chart1.Location = new System.Drawing.Point(12, 226);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1142, 410);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(274, 38);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 17);
            this.checkBox2.TabIndex = 22;
            this.checkBox2.Text = "Nystart";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 648);
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
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbHighKompetens;
        private System.Windows.Forms.RadioButton rbLowKompetens;
        private System.Windows.Forms.CheckBox cbFlerdagsbeh;
        private System.Windows.Forms.DateTimePicker dtpStartar;
        private System.Windows.Forms.Label lblSlut;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpSlutar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NySSKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NyttRumToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox cbEntireDayBooking;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

