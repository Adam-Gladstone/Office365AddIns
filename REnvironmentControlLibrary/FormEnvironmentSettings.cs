using System;
using System.Windows.Forms;

namespace REnvironmentControlLibrary
{
    public partial class FormEnvironmentSettings : Form
    {
        public string Home
        {
            get { return editRHome.Text; }
        }

        public string Path
        {
            get { return editRPath.Text; }
        }

        public FormEnvironmentSettings(string home, string path)
        {
            InitializeComponent();

            editRHome.Text = home;
            editRPath.Text = path;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonBrowseHome_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                editRHome.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void ButtonBrowsePath_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                editRPath.Text = FolderBrowserDialog.SelectedPath;
            }
        }
    }
}
