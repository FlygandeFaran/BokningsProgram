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
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbHighKompetens = new System.Windows.Forms.RadioButton();
            this.rbLowKompetens = new System.Windows.Forms.RadioButton();
            this.btnAddSSK = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnTaBort = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 204);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(143, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 240);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Befintliga sköterskor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTaBort);
            this.groupBox2.Controls.Add(this.btnChange);
            this.groupBox2.Controls.Add(this.btnAddSSK);
            this.groupBox2.Controls.Add(this.rbLowKompetens);
            this.groupBox2.Controls.Add(this.rbHighKompetens);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 240);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lägg till ny sköterska";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kompetens";
            // 
            // rbHighKompetens
            // 
            this.rbHighKompetens.AutoSize = true;
            this.rbHighKompetens.Location = new System.Drawing.Point(9, 99);
            this.rbHighKompetens.Name = "rbHighKompetens";
            this.rbHighKompetens.Size = new System.Drawing.Size(100, 17);
            this.rbHighKompetens.TabIndex = 3;
            this.rbHighKompetens.Text = "Hög kompetens";
            this.rbHighKompetens.UseVisualStyleBackColor = true;
            // 
            // rbLowKompetens
            // 
            this.rbLowKompetens.AutoSize = true;
            this.rbLowKompetens.Checked = true;
            this.rbLowKompetens.Location = new System.Drawing.Point(9, 122);
            this.rbLowKompetens.Name = "rbLowKompetens";
            this.rbLowKompetens.Size = new System.Drawing.Size(98, 17);
            this.rbLowKompetens.TabIndex = 4;
            this.rbLowKompetens.TabStop = true;
            this.rbLowKompetens.Text = "Låg kompetens";
            this.rbLowKompetens.UseVisualStyleBackColor = true;
            // 
            // btnAddSSK
            // 
            this.btnAddSSK.Location = new System.Drawing.Point(9, 145);
            this.btnAddSSK.Name = "btnAddSSK";
            this.btnAddSSK.Size = new System.Drawing.Size(75, 23);
            this.btnAddSSK.TabIndex = 5;
            this.btnAddSSK.Text = "Lägg till";
            this.btnAddSSK.UseVisualStyleBackColor = true;
            this.btnAddSSK.Click += new System.EventHandler(this.btnAddSSK_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(9, 174);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "Ändra";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnTaBort
            // 
            this.btnTaBort.Location = new System.Drawing.Point(9, 203);
            this.btnTaBort.Name = "btnTaBort";
            this.btnTaBort.Size = new System.Drawing.Size(75, 23);
            this.btnTaBort.TabIndex = 7;
            this.btnTaBort.Text = "Ta bort";
            this.btnTaBort.UseVisualStyleBackColor = true;
            this.btnTaBort.Click += new System.EventHandler(this.btnTaBort_Click);
            // 
            // SSKform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 268);
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

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTaBort;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnAddSSK;
        private System.Windows.Forms.RadioButton rbLowKompetens;
        private System.Windows.Forms.RadioButton rbHighKompetens;
        private System.Windows.Forms.Label label2;
    }
}