namespace BokningsProgram
{
    partial class SSKform
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnAddSSK = new System.Windows.Forms.Button();
            this.rbLowKompetens = new System.Windows.Forms.RadioButton();
            this.rbHighKompetens = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbCurrentSSK = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHSAid = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCurrentSSK);
            this.groupBox1.Location = new System.Drawing.Point(143, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Befintliga sköterskor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtHSAid);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnChange);
            this.groupBox2.Controls.Add(this.btnAddSSK);
            this.groupBox2.Controls.Add(this.rbLowKompetens);
            this.groupBox2.Controls.Add(this.rbHighKompetens);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 265);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lägg till ny sköterska";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(6, 231);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Ta bort";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(6, 202);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "Ändra";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnAddSSK
            // 
            this.btnAddSSK.Location = new System.Drawing.Point(6, 173);
            this.btnAddSSK.Name = "btnAddSSK";
            this.btnAddSSK.Size = new System.Drawing.Size(75, 23);
            this.btnAddSSK.TabIndex = 5;
            this.btnAddSSK.Text = "Lägg till";
            this.btnAddSSK.UseVisualStyleBackColor = true;
            this.btnAddSSK.Click += new System.EventHandler(this.btnAddSSK_Click);
            // 
            // rbLowKompetens
            // 
            this.rbLowKompetens.AutoSize = true;
            this.rbLowKompetens.Checked = true;
            this.rbLowKompetens.Location = new System.Drawing.Point(6, 150);
            this.rbLowKompetens.Name = "rbLowKompetens";
            this.rbLowKompetens.Size = new System.Drawing.Size(98, 17);
            this.rbLowKompetens.TabIndex = 4;
            this.rbLowKompetens.TabStop = true;
            this.rbLowKompetens.Text = "Låg kompetens";
            this.rbLowKompetens.UseVisualStyleBackColor = true;
            // 
            // rbHighKompetens
            // 
            this.rbHighKompetens.AutoSize = true;
            this.rbHighKompetens.Location = new System.Drawing.Point(6, 127);
            this.rbHighKompetens.Name = "rbHighKompetens";
            this.rbHighKompetens.Size = new System.Drawing.Size(100, 17);
            this.rbHighKompetens.TabIndex = 3;
            this.rbHighKompetens.Text = "Hög kompetens";
            this.rbHighKompetens.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kompetens";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Namn";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 45);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            // 
            // lbCurrentSSK
            // 
            this.lbCurrentSSK.FormattingEnabled = true;
            this.lbCurrentSSK.Location = new System.Drawing.Point(7, 20);
            this.lbCurrentSSK.Name = "lbCurrentSSK";
            this.lbCurrentSSK.Size = new System.Drawing.Size(120, 238);
            this.lbCurrentSSK.TabIndex = 0;
            this.lbCurrentSSK.SelectedIndexChanged += new System.EventHandler(this.lbCurrentSSK_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "HSA-ID";
            // 
            // txtHSAid
            // 
            this.txtHSAid.Location = new System.Drawing.Point(6, 84);
            this.txtHSAid.Name = "txtHSAid";
            this.txtHSAid.Size = new System.Drawing.Size(100, 20);
            this.txtHSAid.TabIndex = 8;
            // 
            // SSKform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 288);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SSKform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Redigera sköterskor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnAddSSK;
        private System.Windows.Forms.RadioButton rbLowKompetens;
        private System.Windows.Forms.RadioButton rbHighKompetens;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbCurrentSSK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHSAid;
    }
}