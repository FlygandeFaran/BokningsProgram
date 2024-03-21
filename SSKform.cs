using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BokningsProgram
{
    public partial class SSKform : Form
    {
        private SSKmanager _sskm;

        public SSKmanager sskm
        {
            get { return _sskm; }
            set { _sskm = value; }
        }

        public SSKform(SSKmanager sskm)
        {
            InitializeComponent();
            _sskm = sskm;
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            txtName.TabIndex = 0;
            txtHSAid.TabIndex = 1;
            UpdateCurrentSSKlistBox();
        }

        private void UpdateCurrentSSKlistBox()
        {
            lbCurrentSSK.Items.Clear();
            foreach (SSK ssk in _sskm.ListOfSSK)
            {
                lbCurrentSSK.Items.Add(ssk);
            }
        }

        private void btnAddSSK_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string HSAid = txtHSAid.Text;
            bool nameOK = CheckText(name);
            bool HSAidOK = CheckText(HSAid);
            if (nameOK && HSAidOK)
            {
                SSK newSSK = new SSK(name, HSAid, KompetensLevel.Pickline);
                _sskm.ListOfSSK.Add(newSSK);
            }
            UpdateCurrentSSKlistBox();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int n = lbCurrentSSK.SelectedIndex;
            SSK selectedSSK = _sskm.ListOfSSK.ElementAt(n);
            string name = txtName.Text;
            string HSAid = txtHSAid.Text;
            bool nameOK = CheckText(name);
            bool HSAidOK = CheckText(HSAid);
            if (nameOK && HSAidOK)
            {
                SSK newSSK = new SSK(name, HSAid, KompetensLevel.Pickline);
                _sskm.ListOfSSK.RemoveAt(n);
                _sskm.ListOfSSK.Insert(n, newSSK);
            }
            UpdateCurrentSSKlistBox();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _sskm.ListOfSSK.RemoveAt(lbCurrentSSK.SelectedIndex);
            UpdateCurrentSSKlistBox();
        }
        private bool CheckText(string input)
        {
            bool ok = false;
            if (!string.IsNullOrEmpty(input))
            {
                ok = true;
            }
            return ok;
        }

        private void lbCurrentSSK_SelectedIndexChanged(object sender, EventArgs e)
        {
            SSK selectedSSK = _sskm.ListOfSSK.ElementAt(lbCurrentSSK.SelectedIndex);

            txtName.Text = selectedSSK.Name;
            txtHSAid.Text = selectedSSK.HSAID;

            switch (selectedSSK.Kompetens)
            {
                case KompetensLevel.None:
                    rbLowKompetens.Checked = true;
                    rbHighKompetens.Checked = false;
                    break;
                case KompetensLevel.Pickline:
                    rbHighKompetens.Checked = true;
                    rbLowKompetens.Checked = false;
                    break;
                default:
                    break;
            }
        }
    }
}
