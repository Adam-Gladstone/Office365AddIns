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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelRHome = new System.Windows.Forms.Label();
            this.ButtonBrowseHome = new System.Windows.Forms.Button();
            this.editRHome = new System.Windows.Forms.TextBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelRPath = new System.Windows.Forms.Label();
            this.editRPath = new System.Windows.Forms.TextBox();
            this.ButtonBrowsePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(223, 420);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(304, 420);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelRHome
            // 
            this.labelRHome.AutoSize = true;
            this.labelRHome.Location = new System.Drawing.Point(13, 16);
            this.labelRHome.Name = "labelRHome";
            this.labelRHome.Size = new System.Drawing.Size(60, 16);
            this.labelRHome.TabIndex = 2;
            this.labelRHome.Text = "R Home:";
            // 
            // ButtonBrowseHome
            // 
            this.ButtonBrowseHome.Location = new System.Drawing.Point(349, 14);
            this.ButtonBrowseHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonBrowseHome.Name = "ButtonBrowseHome";
            this.ButtonBrowseHome.Size = new System.Drawing.Size(29, 23);
            this.ButtonBrowseHome.TabIndex = 4;
            this.ButtonBrowseHome.Text = "...";
            this.ButtonBrowseHome.UseVisualStyleBackColor = true;
            this.ButtonBrowseHome.Click += new System.EventHandler(this.ButtonBrowseHome_Click);
            // 
            // editRHome
            // 
            this.editRHome.Location = new System.Drawing.Point(79, 14);
            this.editRHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editRHome.Name = "editRHome";
            this.editRHome.ReadOnly = true;
            this.editRHome.Size = new System.Drawing.Size(257, 22);
            this.editRHome.TabIndex = 3;
            // 
            // labelRPath
            // 
            this.labelRPath.AutoSize = true;
            this.labelRPath.Location = new System.Drawing.Point(16, 59);
            this.labelRPath.Name = "labelRPath";
            this.labelRPath.Size = new System.Drawing.Size(50, 16);
            this.labelRPath.TabIndex = 5;
            this.labelRPath.Text = "R Path:";
            // 
            // editRPath
            // 
            this.editRPath.Location = new System.Drawing.Point(79, 57);
            this.editRPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editRPath.Name = "editRPath";
            this.editRPath.ReadOnly = true;
            this.editRPath.Size = new System.Drawing.Size(257, 22);
            this.editRPath.TabIndex = 6;
            // 
            // ButtonBrowsePath
            // 
            this.ButtonBrowsePath.Location = new System.Drawing.Point(349, 57);
            this.ButtonBrowsePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonBrowsePath.Name = "ButtonBrowsePath";
            this.ButtonBrowsePath.Size = new System.Drawing.Size(29, 23);
            this.ButtonBrowsePath.TabIndex = 7;
            this.ButtonBrowsePath.Text = "...";
            this.ButtonBrowsePath.UseVisualStyleBackColor = true;
            this.ButtonBrowsePath.Click += new System.EventHandler(this.ButtonBrowsePath_Click);
            // 
            // FormEnvironmentSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(397, 455);
            this.Controls.Add(this.ButtonBrowsePath);
            this.Controls.Add(this.editRPath);
            this.Controls.Add(this.labelRPath);
            this.Controls.Add(this.editRHome);
            this.Controls.Add(this.ButtonBrowseHome);
            this.Controls.Add(this.labelRHome);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnvironmentSettings";
            this.Text = "R Environment Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
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
    }
}