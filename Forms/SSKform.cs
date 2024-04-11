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

        public SSKform()
        {
            _sskm = new SSKmanager();
            _sskm.ImportFromXml();
            InitializeComponent();
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
            _sskm.ExportToXml();
        }
        private void btnAddSSK_Click(object sender, EventArgs e)
        {
            bool databaseOK = CheckIfSSKhasUpdated(); //kontrollerar om databasen har uppdaterats innan man har hunnit addera en ny SSK
            if (databaseOK)
            {
                string name = txtName.Text;
                string HSAid = txtHSAid.Text;
                bool nameOK = CheckText(name);
                bool HSAidOK = CheckText(HSAid);
                if (nameOK && HSAidOK)
                {
                    SSK newSSK;
                    if (rbHighKompetens.Checked)
                        newSSK = new SSK(name, HSAid, KompetensLevel.Pickline);
                    else
                        newSSK = new SSK(name, HSAid, KompetensLevel.None);

                    _sskm.ListOfSSK.Add(newSSK);
                }
            }
            else
            {
                _sskm.ImportFromXml();
                MessageBox.Show("Databasen har uppdaterats under tiden, dubbelkolla att din SSK inte har lagts in av någon annan i listan innan du lägger till en SSK");
            }
            UpdateCurrentSSKlistBox();
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (CheckIfSSKhasUpdated())
            {
                int n = lbCurrentSSK.SelectedIndex;
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
            }
            else
            {
                _sskm.ImportFromXml();
                MessageBox.Show("Databasen har uppdaterats under tiden, dubbelkolla att din SSK inte har lagts in av någon annan i listan innan du lägger till en SSK");
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
        private bool CheckIfSSKhasUpdated() //Kontrollerar om databasen av SSK har uppdaterats
        {
            bool ok = true;
            SSKmanager tempSSKmanager = new SSKmanager();
            tempSSKmanager.ImportFromXml();
            if (tempSSKmanager.ListOfSSK.Count == _sskm.ListOfSSK.Count)
            {
                for (int i = 0; i < tempSSKmanager.ListOfSSK.Count; i++)
                {
                    if (tempSSKmanager.ListOfSSK.ElementAt(i).HSAID != _sskm.ListOfSSK.ElementAt(i).HSAID ||
                        tempSSKmanager.ListOfSSK.ElementAt(i).Name != _sskm.ListOfSSK.ElementAt(i).Name ||
                        tempSSKmanager.ListOfSSK.ElementAt(i).Kompetens != _sskm.ListOfSSK.ElementAt(i).Kompetens)
                    {
                        ok = false;
                    }
                }
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
