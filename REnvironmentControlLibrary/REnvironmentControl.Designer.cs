namespace REnvironmentControlLibrary
{
    partial class REnvironmentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewEnvironment = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderContents = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.columnHeaderMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewEnvironment);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewMessages);
            this.splitContainer1.Size = new System.Drawing.Size(471, 710);
            this.splitContainer1.SplitterDistance = 455;
            this.splitContainer1.TabIndex = 0;
            // 
            // listViewEnvironment
            // 
            this.listViewEnvironment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderContents});
            this.listViewEnvironment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEnvironment.FullRowSelect = true;
            this.listViewEnvironment.GridLines = true;
            this.listViewEnvironment.HideSelection = false;
            this.listViewEnvironment.Location = new System.Drawing.Point(0, 0);
            this.listViewEnvironment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewEnvironment.Name = "listViewEnvironment";
            this.listViewEnvironment.ShowItemToolTips = true;
            this.listViewEnvironment.Size = new System.Drawing.Size(471, 455);
            this.listViewEnvironment.TabIndex = 0;
            this.listViewEnvironment.UseCompatibleStateImageBehavior = false;
            this.listViewEnvironment.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 84;
            // 
            // columnHeaderContents
            // 
            this.columnHeaderContents.Text = "Contents";
            this.columnHeaderContents.Width = 232;
            // 
            // listViewMessages
            // 
            this.listViewMessages.BackColor = System.Drawing.SystemColors.MenuText;
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMessage});
            this.listViewMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMessages.ForeColor = System.Drawing.Color.LawnGreen;
            this.listViewMessages.HideSelection = false;
            this.listViewMessages.Location = new System.Drawing.Point(0, 0);
            this.listViewMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.ShowItemToolTips = true;
            this.listViewMessages.Size = new System.Drawing.Size(471, 251);
            this.listViewMessages.SmallImageList = this.imageList;
            this.listViewMessages.TabIndex = 0;
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderMessage
            // 
            this.columnHeaderMessage.Text = "Messages";
            this.columnHeaderMessage.Width = 319;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // RScriptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RScriptControl";
            this.Size = new System.Drawing.Size(471, 710);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewEnvironment;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderContents;
        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ColumnHeader columnHeaderMessage;
        private System.Windows.Forms.ImageList imageList;
    }
}
