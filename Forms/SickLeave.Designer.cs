namespace BokningsProgram.Forms
{
    partial class SickLeave
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
            this.lbSSK = new System.Windows.Forms.ListBox();
            this.btnEditBookings = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnEditBookings);
            this.groupBox1.Controls.Add(this.lbSSK);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sjuksköterskor";
            // 
            // lbSSK
            // 
            this.lbSSK.FormattingEnabled = true;
            this.lbSSK.Location = new System.Drawing.Point(6, 19);
            this.lbSSK.Name = "lbSSK";
            this.lbSSK.Size = new System.Drawing.Size(190, 160);
            this.lbSSK.TabIndex = 0;
            // 
            // btnEditBookings
            // 
            this.btnEditBookings.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEditBookings.Location = new System.Drawing.Point(25, 185);
            this.btnEditBookings.Name = "btnEditBookings";
            this.btnEditBookings.Size = new System.Drawing.Size(75, 23);
            this.btnEditBookings.TabIndex = 1;
            this.btnEditBookings.Text = "Avboka";
            this.btnEditBookings.UseVisualStyleBackColor = true;
            this.btnEditBookings.Click += new System.EventHandler(this.btnEditBookings_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(106, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SickLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 241);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SickLeave";
            this.Text = "Åh nej vad tråkigt :(";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEditBookings;
        private System.Windows.Forms.ListBox lbSSK;
        private System.Windows.Forms.Button btnCancel;
    }
}