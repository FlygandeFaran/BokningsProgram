using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            foreach (KompetensLevel enumValue in Enum.GetValues(typeof(KompetensLevel)))
            {
                // Add each enum value to the CheckedListBox
                clbKompetenser.Items.Add(enumValue);
            }
            UpdateCurrentSSKlistBox();
            InitializeCustomComponents();
        }
        private void InitializeCustomComponents()
        {
            clbKompetenser.ItemCheck += CheckedListBox_ItemCheck;
        }
        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                // Disable other items if the first item is checked
                for (int i = 1; i < clbKompetenser.Items.Count; i++)
                {
                    clbKompetenser.SetItemChecked(i, false);
                    clbKompetenser.SetItemCheckState(i, CheckState.Indeterminate);
                }
            }
            else if (e.Index == 0 && e.NewValue == CheckState.Unchecked)
            {
                // Enable other items if the first item is unchecked
                for (int i = 1; i < clbKompetenser.Items.Count; i++)
                {
                    clbKompetenser.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            else if (e.Index > 0 && e.NewValue == CheckState.Checked)
            {
                // Disable the first item if any other item is checked
                clbKompetenser.SetItemChecked(0, false);
                clbKompetenser.SetItemCheckState(0, CheckState.Indeterminate);
            }
            else if (e.Index > 0 && e.NewValue == CheckState.Unchecked)
            {
                // Enable the first item if all other items are unchecked
                bool anyChecked = false;
                for (int i = 1; i < clbKompetenser.Items.Count; i++)
                {
                    if (clbKompetenser.GetItemChecked(i))
                    {
                        anyChecked = true;
                        break;
                    }
                }
                if (!anyChecked)
                {
                    clbKompetenser.SetItemCheckState(0, CheckState.Unchecked);
                }
            }
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
                    List<KompetensLevel> kompetenser = new List<KompetensLevel>();
                    if (clbKompetenser.GetItemChecked(0))
                        kompetenser.Add(KompetensLevel.None);
                    if (clbKompetenser.GetItemChecked(1))
                        kompetenser.Add(KompetensLevel.Tablett);
                    if (clbKompetenser.GetItemChecked(2))
                        kompetenser.Add(KompetensLevel.Telefon);
                    if (clbKompetenser.GetItemChecked(3))
                        kompetenser.Add(KompetensLevel.Piccline);
                    
                    newSSK = new SSK(name, HSAid, kompetenser);

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
                    List<KompetensLevel> kompetenser = new List<KompetensLevel>();
                    if (clbKompetenser.GetItemChecked(0))
                        kompetenser.Add(KompetensLevel.None);
                    if (clbKompetenser.GetItemChecked(1))
                        kompetenser.Add(KompetensLevel.Tablett);
                    if (clbKompetenser.GetItemChecked(2))
                        kompetenser.Add(KompetensLevel.Telefon);
                    if (clbKompetenser.GetItemChecked(3))
                        kompetenser.Add(KompetensLevel.Piccline);
                    SSK newSSK = new SSK(name, HSAid, kompetenser);
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
                        !HaveIdenticalKompetensList(_sskm.ListOfSSK.ElementAt(i), tempSSKmanager.ListOfSSK.ElementAt(i)))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }
        private bool HaveIdenticalKompetensList(SSK original, SSK other)
        {
            for (int i = 0; i < other.Kompetenser.Count; i++)
            {
                if (original.Kompetenser[i] != other.Kompetenser[i])
                    return false;
            }
            return true;
        }
        private void lbCurrentSSK_SelectedIndexChanged(object sender, EventArgs e)
        {
            SSK selectedSSK = _sskm.ListOfSSK.ElementAt(lbCurrentSSK.SelectedIndex);

            txtName.Text = selectedSSK.Name;
            txtHSAid.Text = selectedSSK.HSAID;

            for (int i = 0; i < Enum.GetValues(typeof(KompetensLevel)).Length; i++)
            {
                clbKompetenser.SetItemChecked(i, false);
            }

            foreach (var kompetens in selectedSSK.Kompetenser)
            {
                switch (kompetens)
                {
                    case KompetensLevel.None:
                        clbKompetenser.SetItemChecked(0, true);
                        break;
                    case KompetensLevel.Tablett:
                        clbKompetenser.SetItemChecked(1, true);
                        break;
                    case KompetensLevel.Telefon:
                        clbKompetenser.SetItemChecked(2, true);
                        break;
                    case KompetensLevel.Piccline:
                        clbKompetenser.SetItemChecked(3, true);
                        break;
                    default:
                        break;
                }
            }
        }

        private void clbKompetenser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkItem = clbKompetenser.Items[0];
        }
    }
}
