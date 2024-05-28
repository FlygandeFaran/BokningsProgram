namespace BokningsProgram.Forms
{
    partial class RecurringMeetings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMeetings = new System.Windows.Forms.ListBox();
            this.btnAddMeeting = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveSelectedSSK = new System.Windows.Forms.Button();
            this.btnAddSelectedSSK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSelectedSSK = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAvailableSSK = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveMeeting = new System.Windows.Forms.Button();
            this.btnEditMeeting = new System.Windows.Forms.Button();
            this.gbReccurence = new System.Windows.Forms.GroupBox();
            this.cbWednesday = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMonday = new System.Windows.Forms.CheckBox();
            this.dtpTimeOfMeeting = new System.Windows.Forms.DateTimePicker();
            this.cbTuesday = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbThursday = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFriday = new System.Windows.Forms.CheckBox();
            this.txtWeeklyInterval = new System.Windows.Forms.TextBox();
            this.txtNameOfMeeting = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbReccurence.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMeetings);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Möten";
            // 
            // lbMeetings
            // 
            this.lbMeetings.FormattingEnabled = true;
            this.lbMeetings.Location = new System.Drawing.Point(6, 19);
            this.lbMeetings.Name = "lbMeetings";
            this.lbMeetings.Size = new System.Drawing.Size(100, 264);
            this.lbMeetings.TabIndex = 0;
            this.lbMeetings.SelectedIndexChanged += new System.EventHandler(this.lbMeetings_SelectedIndexChanged);
            // 
            // btnAddMeeting
            // 
            this.btnAddMeeting.Location = new System.Drawing.Point(9, 252);
            this.btnAddMeeting.Name = "btnAddMeeting";
            this.btnAddMeeting.Size = new System.Drawing.Size(59, 23);
            this.btnAddMeeting.TabIndex = 1;
            this.btnAddMeeting.Text = "Lägg till";
            this.btnAddMeeting.UseVisualStyleBackColor = true;
            this.btnAddMeeting.Click += new System.EventHandler(this.btnAddMeeting_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveSelectedSSK);
            this.groupBox2.Controls.Add(this.btnAddSelectedSSK);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbSelectedSSK);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbAvailableSSK);
            this.groupBox2.Location = new System.Drawing.Point(387, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 296);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sköterskor";
            // 
            // btnRemoveSelectedSSK
            // 
            this.btnRemoveSelectedSSK.Location = new System.Drawing.Point(112, 169);
            this.btnRemoveSelectedSSK.Name = "btnRemoveSelectedSSK";
            this.btnRemoveSelectedSSK.Size = new System.Drawing.Size(59, 23);
            this.btnRemoveSelectedSSK.TabIndex = 5;
            this.btnRemoveSelectedSSK.Text = "Ta bort";
            this.btnRemoveSelectedSSK.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedSSK.Click += new System.EventHandler(this.btnRemoveSelectedSSK_Click);
            // 
            // btnAddSelectedSSK
            // 
            this.btnAddSelectedSSK.Location = new System.Drawing.Point(112, 123);
            this.btnAddSelectedSSK.Name = "btnAddSelectedSSK";
            this.btnAddSelectedSSK.Size = new System.Drawing.Size(59, 23);
            this.btnAddSelectedSSK.TabIndex = 4;
            this.btnAddSelectedSSK.Text = "Lägg till";
            this.btnAddSelectedSSK.UseVisualStyleBackColor = true;
            this.btnAddSelectedSSK.Click += new System.EventHandler(this.btnAddSelectedSSK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Anmälda";
            // 
            // lbSelectedSSK
            // 
            this.lbSelectedSSK.FormattingEnabled = true;
            this.lbSelectedSSK.Location = new System.Drawing.Point(177, 42);
            this.lbSelectedSSK.Name = "lbSelectedSSK";
            this.lbSelectedSSK.Size = new System.Drawing.Size(116, 238);
            this.lbSelectedSSK.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tillgängliga";
            // 
            // lbAvailableSSK
            // 
            this.lbAvailableSSK.FormattingEnabled = true;
            this.lbAvailableSSK.Location = new System.Drawing.Point(6, 42);
            this.lbAvailableSSK.Name = "lbAvailableSSK";
            this.lbAvailableSSK.Size = new System.Drawing.Size(100, 238);
            this.lbAvailableSSK.TabIndex = 0;
            this.lbAvailableSSK.SelectedIndexChanged += new System.EventHandler(this.lbAvailableSSK_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveMeeting);
            this.groupBox3.Controls.Add(this.btnEditMeeting);
            this.groupBox3.Controls.Add(this.btnAddMeeting);
            this.groupBox3.Controls.Add(this.gbReccurence);
            this.groupBox3.Controls.Add(this.txtNameOfMeeting);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(146, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 296);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mötesinfo";
            // 
            // btnRemoveMeeting
            // 
            this.btnRemoveMeeting.Location = new System.Drawing.Point(165, 252);
            this.btnRemoveMeeting.Name = "btnRemoveMeeting";
            this.btnRemoveMeeting.Size = new System.Drawing.Size(64, 23);
            this.btnRemoveMeeting.TabIndex = 18;
            this.btnRemoveMeeting.Text = "Ta bort";
            this.btnRemoveMeeting.UseVisualStyleBackColor = true;
            this.btnRemoveMeeting.Click += new System.EventHandler(this.btnRemoveMeeting_Click);
            // 
            // btnEditMeeting
            // 
            this.btnEditMeeting.Location = new System.Drawing.Point(83, 252);
            this.btnEditMeeting.Name = "btnEditMeeting";
            this.btnEditMeeting.Size = new System.Drawing.Size(64, 23);
            this.btnEditMeeting.TabIndex = 17;
            this.btnEditMeeting.Text = "Ändra";
            this.btnEditMeeting.UseVisualStyleBackColor = true;
            this.btnEditMeeting.Click += new System.EventHandler(this.btnEditMeeting_Click);
            // 
            // gbReccurence
            // 
            this.gbReccurence.Controls.Add(this.cbWednesday);
            this.gbReccurence.Controls.Add(this.label5);
            this.gbReccurence.Controls.Add(this.cbMonday);
            this.gbReccurence.Controls.Add(this.dtpTimeOfMeeting);
            this.gbReccurence.Controls.Add(this.cbTuesday);
            this.gbReccurence.Controls.Add(this.label6);
            this.gbReccurence.Controls.Add(this.cbThursday);
            this.gbReccurence.Controls.Add(this.label7);
            this.gbReccurence.Controls.Add(this.cbFriday);
            this.gbReccurence.Controls.Add(this.txtWeeklyInterval);
            this.gbReccurence.Location = new System.Drawing.Point(0, 72);
            this.gbReccurence.Name = "gbReccurence";
            this.gbReccurence.Size = new System.Drawing.Size(235, 163);
            this.gbReccurence.TabIndex = 15;
            this.gbReccurence.TabStop = false;
            this.gbReccurence.Text = "Hur ofta";
            // 
            // cbWednesday
            // 
            this.cbWednesday.AutoSize = true;
            this.cbWednesday.Location = new System.Drawing.Point(147, 70);
            this.cbWednesday.Name = "cbWednesday";
            this.cbWednesday.Size = new System.Drawing.Size(63, 17);
            this.cbWednesday.TabIndex = 2;
            this.cbWednesday.Text = "Onsdag";
            this.cbWednesday.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Klockan: ";
            // 
            // cbMonday
            // 
            this.cbMonday.AutoSize = true;
            this.cbMonday.Location = new System.Drawing.Point(12, 70);
            this.cbMonday.Name = "cbMonday";
            this.cbMonday.Size = new System.Drawing.Size(65, 17);
            this.cbMonday.TabIndex = 0;
            this.cbMonday.Text = "Måndag";
            this.cbMonday.UseVisualStyleBackColor = true;
            // 
            // dtpTimeOfMeeting
            // 
            this.dtpTimeOfMeeting.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeOfMeeting.Location = new System.Drawing.Point(70, 131);
            this.dtpTimeOfMeeting.Name = "dtpTimeOfMeeting";
            this.dtpTimeOfMeeting.Size = new System.Drawing.Size(72, 20);
            this.dtpTimeOfMeeting.TabIndex = 8;
            this.dtpTimeOfMeeting.ValueChanged += new System.EventHandler(this.dtpTimeOfMeeting_ValueChanged);
            // 
            // cbTuesday
            // 
            this.cbTuesday.AutoSize = true;
            this.cbTuesday.Location = new System.Drawing.Point(83, 70);
            this.cbTuesday.Name = "cbTuesday";
            this.cbTuesday.Size = new System.Drawing.Size(58, 17);
            this.cbTuesday.TabIndex = 1;
            this.cbTuesday.Text = "Tisdag";
            this.cbTuesday.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = ":e vecka på:";
            // 
            // cbThursday
            // 
            this.cbThursday.AutoSize = true;
            this.cbThursday.Location = new System.Drawing.Point(12, 93);
            this.cbThursday.Name = "cbThursday";
            this.cbThursday.Size = new System.Drawing.Size(65, 17);
            this.cbThursday.TabIndex = 3;
            this.cbThursday.Text = "Torsdag";
            this.cbThursday.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Upprepa var";
            // 
            // cbFriday
            // 
            this.cbFriday.AutoSize = true;
            this.cbFriday.Location = new System.Drawing.Point(83, 93);
            this.cbFriday.Name = "cbFriday";
            this.cbFriday.Size = new System.Drawing.Size(59, 17);
            this.cbFriday.TabIndex = 4;
            this.cbFriday.Text = "Fredag";
            this.cbFriday.UseVisualStyleBackColor = true;
            // 
            // txtWeeklyInterval
            // 
            this.txtWeeklyInterval.Location = new System.Drawing.Point(79, 34);
            this.txtWeeklyInterval.Name = "txtWeeklyInterval";
            this.txtWeeklyInterval.Size = new System.Drawing.Size(32, 20);
            this.txtWeeklyInterval.TabIndex = 5;
            // 
            // txtNameOfMeeting
            // 
            this.txtNameOfMeeting.Location = new System.Drawing.Point(9, 36);
            this.txtNameOfMeeting.Name = "txtNameOfMeeting";
            this.txtNameOfMeeting.Size = new System.Drawing.Size(157, 20);
            this.txtNameOfMeeting.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mötesnamn";
            // 
            // RecurringMeetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 323);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecurringMeetings";
            this.Text = "RecurringMeetings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbReccurence.ResumeLayout(false);
            this.gbReccurence.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbMeetings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbAvailableSSK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveSelectedSSK;
        private System.Windows.Forms.Button btnAddSelectedSSK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbSelectedSSK;
        private System.Windows.Forms.Button btnAddMeeting;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbReccurence;
        private System.Windows.Forms.CheckBox cbWednesday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbMonday;
        private System.Windows.Forms.DateTimePicker dtpTimeOfMeeting;
        private System.Windows.Forms.CheckBox cbTuesday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbThursday;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbFriday;
        private System.Windows.Forms.TextBox txtWeeklyInterval;
        private System.Windows.Forms.TextBox txtNameOfMeeting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveMeeting;
        private System.Windows.Forms.Button btnEditMeeting;
    }
}