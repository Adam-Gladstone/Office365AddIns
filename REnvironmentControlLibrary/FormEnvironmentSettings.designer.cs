namespace REnvironmentControlLibrary
{
    partial class FormEnvironmentSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnvironmentSettings));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelRHome = new System.Windows.Forms.Label();
            this.ButtonBrowseHome = new System.Windows.Forms.Button();
            this.editRHome = new System.Windows.Forms.TextBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelRPath = new System.Windows.Forms.Label();
            this.editRPath = new System.Windows.Forms.TextBox();
            this.ButtonBrowsePath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvPackages = new System.Windows.Forms.ListView();
            this.colPackages = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxPackageName = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(167, 341);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 19);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.toolTip.SetToolTip(this.btnOk, "Save any changes");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(228, 341);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.toolTip.SetToolTip(this.btnCancel, "Cancel any changes");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelRHome
            // 
            this.labelRHome.AutoSize = true;
            this.labelRHome.Location = new System.Drawing.Point(10, 13);
            this.labelRHome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRHome.Name = "labelRHome";
            this.labelRHome.Size = new System.Drawing.Size(56, 15);
            this.labelRHome.TabIndex = 2;
            this.labelRHome.Text = "R Home:";
            // 
            // ButtonBrowseHome
            // 
            this.ButtonBrowseHome.Location = new System.Drawing.Point(262, 11);
            this.ButtonBrowseHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonBrowseHome.Name = "ButtonBrowseHome";
            this.ButtonBrowseHome.Size = new System.Drawing.Size(22, 19);
            this.ButtonBrowseHome.TabIndex = 4;
            this.ButtonBrowseHome.Text = "...";
            this.toolTip.SetToolTip(this.ButtonBrowseHome, "Browse for folder");
            this.ButtonBrowseHome.UseVisualStyleBackColor = true;
            this.ButtonBrowseHome.Click += new System.EventHandler(this.ButtonBrowseHome_Click);
            // 
            // editRHome
            // 
            this.editRHome.Location = new System.Drawing.Point(59, 11);
            this.editRHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editRHome.Name = "editRHome";
            this.editRHome.ReadOnly = true;
            this.editRHome.Size = new System.Drawing.Size(194, 20);
            this.editRHome.TabIndex = 3;
            this.toolTip.SetToolTip(this.editRHome, "The base R directory");
            // 
            // labelRPath
            // 
            this.labelRPath.AutoSize = true;
            this.labelRPath.Location = new System.Drawing.Point(12, 48);
            this.labelRPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRPath.Name = "labelRPath";
            this.labelRPath.Size = new System.Drawing.Size(47, 15);
            this.labelRPath.TabIndex = 5;
            this.labelRPath.Text = "R Path:";
            // 
            // editRPath
            // 
            this.editRPath.Location = new System.Drawing.Point(59, 46);
            this.editRPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editRPath.Name = "editRPath";
            this.editRPath.ReadOnly = true;
            this.editRPath.Size = new System.Drawing.Size(194, 20);
            this.editRPath.TabIndex = 6;
            this.toolTip.SetToolTip(this.editRPath, "The directory where R.exe resides");
            // 
            // ButtonBrowsePath
            // 
            this.ButtonBrowsePath.Location = new System.Drawing.Point(262, 46);
            this.ButtonBrowsePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonBrowsePath.Name = "ButtonBrowsePath";
            this.ButtonBrowsePath.Size = new System.Drawing.Size(22, 19);
            this.ButtonBrowsePath.TabIndex = 7;
            this.ButtonBrowsePath.Text = "...";
            this.toolTip.SetToolTip(this.ButtonBrowsePath, "Browse for folder");
            this.ButtonBrowsePath.UseVisualStyleBackColor = true;
            this.ButtonBrowsePath.Click += new System.EventHandler(this.ButtonBrowsePath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvPackages);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Controls.Add(this.textBoxPackageName);
            this.groupBox1.Location = new System.Drawing.Point(14, 87);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(269, 240);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Packages to Load";
            // 
            // lvPackages
            // 
            this.lvPackages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPackages});
            this.lvPackages.GridLines = true;
            this.lvPackages.HideSelection = false;
            this.lvPackages.Location = new System.Drawing.Point(16, 65);
            this.lvPackages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvPackages.Name = "lvPackages";
            this.lvPackages.Size = new System.Drawing.Size(238, 159);
            this.lvPackages.SmallImageList = this.imageList;
            this.lvPackages.TabIndex = 13;
            this.toolTip.SetToolTip(this.lvPackages, "List of packages to load during initialisation");
            this.lvPackages.UseCompatibleStateImageBehavior = false;
            this.lvPackages.View = System.Windows.Forms.View.Details;
            this.lvPackages.SelectedIndexChanged += new System.EventHandler(this.lvPackages_SelectedIndexChanged);
            // 
            // colPackages
            // 
            this.colPackages.Text = "Packages";
            this.colPackages.Width = 200;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "script.256x224.png");
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(234, 31);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(20, 19);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "-";
            this.toolTip.SetToolTip(this.btnRemove, "Remove package from the list");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(214, 31);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(20, 19);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "+";
            this.toolTip.SetToolTip(this.btnAdd, "Add package to the list");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(14, 32);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 15);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "Name:";
            // 
            // textBoxPackageName
            // 
            this.textBoxPackageName.Location = new System.Drawing.Point(54, 31);
            this.textBoxPackageName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPackageName.Name = "textBoxPackageName";
            this.textBoxPackageName.Size = new System.Drawing.Size(156, 20);
            this.textBoxPackageName.TabIndex = 10;
            this.toolTip.SetToolTip(this.textBoxPackageName, "A valid R package name");
            // 
            // FormEnvironmentSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(298, 370);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonBrowsePath);
            this.Controls.Add(this.editRPath);
            this.Controls.Add(this.labelRPath);
            this.Controls.Add(this.editRHome);
            this.Controls.Add(this.ButtonBrowseHome);
            this.Controls.Add(this.labelRHome);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnvironmentSettings";
            this.Text = "R Environment Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelRHome;
        private System.Windows.Forms.Button ButtonBrowseHome;
        private System.Windows.Forms.TextBox editRHome;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Label labelRPath;
        private System.Windows.Forms.TextBox editRPath;
        private System.Windows.Forms.Button ButtonBrowsePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxPackageName;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView lvPackages;
        private System.Windows.Forms.ColumnHeader colPackages;
        private System.Windows.Forms.ToolTip toolTip;
    }
}