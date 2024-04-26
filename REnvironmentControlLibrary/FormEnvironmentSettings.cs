using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
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

        public string Packages
        {
            get 
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < lvPackages.Items.Count; ++i)
                {
                    if (i > 0)
                        sb.Append(";");

                    sb.Append($"{lvPackages.Items[i].Text}");
                }

                return sb.ToString();
            }
        }

        public FormEnvironmentSettings(string home, string path, string defaultPackages)
        {
            InitializeComponent();

            editRHome.Text = home;
            editRPath.Text = path;

            if(!string.IsNullOrEmpty(defaultPackages)) 
            {
                var packages = new List<string>(defaultPackages.Split(new char[] { ';' }));
                foreach (string package in packages)
                {
                    Add(package);
                }
            }
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

        private void Add(string package)
        {
            if (string.IsNullOrEmpty(package))
                return;

            ListViewItem lvi = lvPackages.FindItemWithText(package);
            if (lvi == null)
            {
                lvi = new ListViewItem();
            }

            lvi.Text = package;
            lvi.ImageIndex = 0;

            lvPackages.Items.Add(lvi);
        }

        private void Remove(string package)
        {
            if (string.IsNullOrEmpty(package))
                return;

            ListViewItem lvi = lvPackages.FindItemWithText(package);

            if (lvi != null)
            {
                lvPackages.Items.Remove(lvi);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add(textBoxPackageName.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove(textBoxPackageName.Text);

            if (lvPackages.Items.Count > 0)
            {
                lvPackages.Items[0].Selected = true;
                lvPackages.Select();
            }
        }

        private void lvPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection packages = lvPackages.SelectedItems;

            foreach (ListViewItem item in packages)
            {
                textBoxPackageName.Text = item.Text;
            }
        }
    }
}
