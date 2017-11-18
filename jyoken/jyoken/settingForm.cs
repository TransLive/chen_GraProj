using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jyoken
{
    public partial class SettingForm : Form
    {
        MainForm mainForm;
        public SettingForm(MainForm mainForm,string mecabLocation)
        {
            InitializeComponent();
            txtBoxMecabLocation.Text = mecabLocation;
            this.mainForm = mainForm;
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Select file";
            dialog.Filter = "All(*.exe)|*.exe";
            txtBoxMecabLocation.Text = dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ? dialog.FileName : txtBoxMecabLocation.Text;
            if(txtBoxMecabLocation.Text != null)
            {
                btnMecabLocationConfirm.Enabled = true;
            }
        }

        private void btnMecabLocationConfirm_Click(object sender, EventArgs e)
        {
            mainForm.receiveData = txtBoxMecabLocation.Text;
            this.Close();
        }
    }
}
