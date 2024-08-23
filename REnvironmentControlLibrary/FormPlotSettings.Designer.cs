namespace REnvironmentControlLibrary
{
    partial class FormPlotSettings
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabPageTheme = new System.Windows.Forms.TabPage();
            this.propertyGridThemes = new System.Windows.Forms.PropertyGrid();
            this.comboBoxThemes = new System.Windows.Forms.ComboBox();
            this.labelTheme = new System.Windows.Forms.Label();
            this.tabPageFacets = new System.Windows.Forms.TabPage();
            this.tabPageCoords = new System.Windows.Forms.TabPage();
            this.propertyGridCoords = new System.Windows.Forms.PropertyGrid();
            this.comboBoxCoords = new System.Windows.Forms.ComboBox();
            this.labelCoords = new System.Windows.Forms.Label();
            this.tabPageScales = new System.Windows.Forms.TabPage();
            this.propertyGridScales = new System.Windows.Forms.PropertyGrid();
            this.comboBoxScales = new System.Windows.Forms.ComboBox();
            this.labelScales = new System.Windows.Forms.Label();
            this.tabPageLabels = new System.Windows.Forms.TabPage();
            this.propertyGridLabels = new System.Windows.Forms.PropertyGrid();
            this.tabPageLayers = new System.Windows.Forms.TabPage();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listViewGeoms = new System.Windows.Forms.ListView();
            this.columnHeaderGeom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelGeom = new System.Windows.Forms.Label();
            this.comboBoxGeom = new System.Windows.Forms.ComboBox();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.propertyGridData = new System.Windows.Forms.PropertyGrid();
            this.tabControlPlot = new System.Windows.Forms.TabControl();
            this.propertyGridFacets = new System.Windows.Forms.PropertyGrid();
            this.tabPageTheme.SuspendLayout();
            this.tabPageFacets.SuspendLayout();
            this.tabPageCoords.SuspendLayout();
            this.tabPageScales.SuspendLayout();
            this.tabPageLabels.SuspendLayout();
            this.tabPageLayers.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabControlPlot.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(174, 466);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(87, 30);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(265, 466);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 30);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabPageTheme
            // 
            this.tabPageTheme.Controls.Add(this.propertyGridThemes);
            this.tabPageTheme.Controls.Add(this.comboBoxThemes);
            this.tabPageTheme.Controls.Add(this.labelTheme);
            this.tabPageTheme.Location = new System.Drawing.Point(4, 4);
            this.tabPageTheme.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageTheme.Name = "tabPageTheme";
            this.tabPageTheme.Size = new System.Drawing.Size(345, 426);
            this.tabPageTheme.TabIndex = 4;
            this.tabPageTheme.Text = "Theme";
            this.tabPageTheme.UseVisualStyleBackColor = true;
            // 
            // propertyGridThemes
            // 
            this.propertyGridThemes.Location = new System.Drawing.Point(-1, 28);
            this.propertyGridThemes.Name = "propertyGridThemes";
            this.propertyGridThemes.Size = new System.Drawing.Size(343, 395);
            this.propertyGridThemes.TabIndex = 11;
            // 
            // comboBoxThemes
            // 
            this.comboBoxThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThemes.FormattingEnabled = true;
            this.comboBoxThemes.Location = new System.Drawing.Point(55, 2);
            this.comboBoxThemes.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxThemes.Name = "comboBoxThemes";
            this.comboBoxThemes.Size = new System.Drawing.Size(164, 21);
            this.comboBoxThemes.TabIndex = 10;
            this.comboBoxThemes.SelectedIndexChanged += new System.EventHandler(this.comboBoxThemes_SelectedIndexChanged);
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Location = new System.Drawing.Point(2, 4);
            this.labelTheme.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(49, 15);
            this.labelTheme.TabIndex = 9;
            this.labelTheme.Text = "Theme:";
            // 
            // tabPageFacets
            // 
            this.tabPageFacets.Controls.Add(this.propertyGridFacets);
            this.tabPageFacets.Location = new System.Drawing.Point(4, 4);
            this.tabPageFacets.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageFacets.Name = "tabPageFacets";
            this.tabPageFacets.Size = new System.Drawing.Size(345, 426);
            this.tabPageFacets.TabIndex = 3;
            this.tabPageFacets.Text = "Facets";
            this.tabPageFacets.UseVisualStyleBackColor = true;
            // 
            // tabPageCoords
            // 
            this.tabPageCoords.Controls.Add(this.propertyGridCoords);
            this.tabPageCoords.Controls.Add(this.comboBoxCoords);
            this.tabPageCoords.Controls.Add(this.labelCoords);
            this.tabPageCoords.Location = new System.Drawing.Point(4, 4);
            this.tabPageCoords.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageCoords.Name = "tabPageCoords";
            this.tabPageCoords.Size = new System.Drawing.Size(345, 426);
            this.tabPageCoords.TabIndex = 2;
            this.tabPageCoords.Text = "Coords";
            this.tabPageCoords.UseVisualStyleBackColor = true;
            // 
            // propertyGridCoords
            // 
            this.propertyGridCoords.Location = new System.Drawing.Point(6, 30);
            this.propertyGridCoords.Name = "propertyGridCoords";
            this.propertyGridCoords.Size = new System.Drawing.Size(336, 393);
            this.propertyGridCoords.TabIndex = 2;
            // 
            // comboBoxCoords
            // 
            this.comboBoxCoords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCoords.FormattingEnabled = true;
            this.comboBoxCoords.Location = new System.Drawing.Point(88, 3);
            this.comboBoxCoords.Name = "comboBoxCoords";
            this.comboBoxCoords.Size = new System.Drawing.Size(178, 21);
            this.comboBoxCoords.TabIndex = 1;
            this.comboBoxCoords.SelectedIndexChanged += new System.EventHandler(this.comboBoxCoords_SelectedIndexChanged);
            // 
            // labelCoords
            // 
            this.labelCoords.AutoSize = true;
            this.labelCoords.Location = new System.Drawing.Point(3, 6);
            this.labelCoords.Name = "labelCoords";
            this.labelCoords.Size = new System.Drawing.Size(79, 15);
            this.labelCoords.TabIndex = 0;
            this.labelCoords.Text = "Coordinates: ";
            // 
            // tabPageScales
            // 
            this.tabPageScales.Controls.Add(this.propertyGridScales);
            this.tabPageScales.Controls.Add(this.comboBoxScales);
            this.tabPageScales.Controls.Add(this.labelScales);
            this.tabPageScales.Location = new System.Drawing.Point(4, 4);
            this.tabPageScales.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageScales.Name = "tabPageScales";
            this.tabPageScales.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageScales.Size = new System.Drawing.Size(345, 426);
            this.tabPageScales.TabIndex = 1;
            this.tabPageScales.Text = "Scales";
            this.tabPageScales.UseVisualStyleBackColor = true;
            // 
            // propertyGridScales
            // 
            this.propertyGridScales.Location = new System.Drawing.Point(3, 30);
            this.propertyGridScales.Name = "propertyGridScales";
            this.propertyGridScales.Size = new System.Drawing.Size(339, 391);
            this.propertyGridScales.TabIndex = 2;
            // 
            // comboBoxScales
            // 
            this.comboBoxScales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScales.FormattingEnabled = true;
            this.comboBoxScales.Location = new System.Drawing.Point(62, 3);
            this.comboBoxScales.Name = "comboBoxScales";
            this.comboBoxScales.Size = new System.Drawing.Size(186, 21);
            this.comboBoxScales.TabIndex = 1;
            this.comboBoxScales.SelectedIndexChanged += new System.EventHandler(this.comboBoxScales_SelectedIndexChanged);
            // 
            // labelScales
            // 
            this.labelScales.AutoSize = true;
            this.labelScales.Location = new System.Drawing.Point(5, 5);
            this.labelScales.Name = "labelScales";
            this.labelScales.Size = new System.Drawing.Size(50, 15);
            this.labelScales.TabIndex = 0;
            this.labelScales.Text = "Scales: ";
            // 
            // tabPageLabels
            // 
            this.tabPageLabels.Controls.Add(this.propertyGridLabels);
            this.tabPageLabels.Location = new System.Drawing.Point(4, 4);
            this.tabPageLabels.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageLabels.Name = "tabPageLabels";
            this.tabPageLabels.Size = new System.Drawing.Size(345, 426);
            this.tabPageLabels.TabIndex = 6;
            this.tabPageLabels.Text = "Labels";
            this.tabPageLabels.UseVisualStyleBackColor = true;
            // 
            // propertyGridLabels
            // 
            this.propertyGridLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridLabels.Location = new System.Drawing.Point(0, 0);
            this.propertyGridLabels.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGridLabels.Name = "propertyGridLabels";
            this.propertyGridLabels.Size = new System.Drawing.Size(345, 426);
            this.propertyGridLabels.TabIndex = 0;
            // 
            // tabPageLayers
            // 
            this.tabPageLayers.Controls.Add(this.buttonDown);
            this.tabPageLayers.Controls.Add(this.buttonUp);
            this.tabPageLayers.Controls.Add(this.buttonDelete);
            this.tabPageLayers.Controls.Add(this.buttonAdd);
            this.tabPageLayers.Controls.Add(this.listViewGeoms);
            this.tabPageLayers.Controls.Add(this.labelGeom);
            this.tabPageLayers.Controls.Add(this.comboBoxGeom);
            this.tabPageLayers.Location = new System.Drawing.Point(4, 4);
            this.tabPageLayers.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageLayers.Name = "tabPageLayers";
            this.tabPageLayers.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageLayers.Size = new System.Drawing.Size(345, 426);
            this.tabPageLayers.TabIndex = 0;
            this.tabPageLayers.Text = "Layers";
            this.tabPageLayers.UseVisualStyleBackColor = true;
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(292, 398);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(36, 23);
            this.buttonDown.TabIndex = 6;
            this.buttonDown.Text = "˅";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(250, 398);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(36, 23);
            this.buttonUp.TabIndex = 5;
            this.buttonUp.Text = "˄";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(283, 9);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(56, 28);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(222, 9);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(56, 28);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listViewGeoms
            // 
            this.listViewGeoms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderGeom,
            this.columnHeaderContent});
            this.listViewGeoms.FullRowSelect = true;
            this.listViewGeoms.GridLines = true;
            this.listViewGeoms.HideSelection = false;
            this.listViewGeoms.Location = new System.Drawing.Point(7, 41);
            this.listViewGeoms.Margin = new System.Windows.Forms.Padding(2);
            this.listViewGeoms.Name = "listViewGeoms";
            this.listViewGeoms.Size = new System.Drawing.Size(332, 337);
            this.listViewGeoms.TabIndex = 4;
            this.listViewGeoms.UseCompatibleStateImageBehavior = false;
            this.listViewGeoms.View = System.Windows.Forms.View.Details;
            this.listViewGeoms.SelectedIndexChanged += new System.EventHandler(this.listViewGeoms_SelectedIndexChanged);
            this.listViewGeoms.DoubleClick += new System.EventHandler(this.listViewGeoms_DoubleClick);
            // 
            // columnHeaderGeom
            // 
            this.columnHeaderGeom.Text = "Geom";
            this.columnHeaderGeom.Width = 90;
            // 
            // columnHeaderContent
            // 
            this.columnHeaderContent.Text = "Content";
            this.columnHeaderContent.Width = 305;
            // 
            // labelGeom
            // 
            this.labelGeom.AutoSize = true;
            this.labelGeom.Location = new System.Drawing.Point(4, 13);
            this.labelGeom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGeom.Name = "labelGeom";
            this.labelGeom.Size = new System.Drawing.Size(66, 15);
            this.labelGeom.TabIndex = 0;
            this.labelGeom.Text = "Geometry: ";
            // 
            // comboBoxGeom
            // 
            this.comboBoxGeom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGeom.FormattingEnabled = true;
            this.comboBoxGeom.Location = new System.Drawing.Point(70, 11);
            this.comboBoxGeom.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGeom.Name = "comboBoxGeom";
            this.comboBoxGeom.Size = new System.Drawing.Size(144, 21);
            this.comboBoxGeom.TabIndex = 1;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.propertyGridData);
            this.tabPageData.Location = new System.Drawing.Point(4, 4);
            this.tabPageData.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageData.Size = new System.Drawing.Size(345, 426);
            this.tabPageData.TabIndex = 5;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // propertyGridData
            // 
            this.propertyGridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridData.Location = new System.Drawing.Point(2, 2);
            this.propertyGridData.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGridData.Name = "propertyGridData";
            this.propertyGridData.Size = new System.Drawing.Size(341, 422);
            this.propertyGridData.TabIndex = 8;
            // 
            // tabControlPlot
            // 
            this.tabControlPlot.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlPlot.Controls.Add(this.tabPageData);
            this.tabControlPlot.Controls.Add(this.tabPageLayers);
            this.tabControlPlot.Controls.Add(this.tabPageLabels);
            this.tabControlPlot.Controls.Add(this.tabPageScales);
            this.tabControlPlot.Controls.Add(this.tabPageCoords);
            this.tabControlPlot.Controls.Add(this.tabPageFacets);
            this.tabControlPlot.Controls.Add(this.tabPageTheme);
            this.tabControlPlot.Location = new System.Drawing.Point(9, 10);
            this.tabControlPlot.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlPlot.Name = "tabControlPlot";
            this.tabControlPlot.SelectedIndex = 0;
            this.tabControlPlot.Size = new System.Drawing.Size(353, 452);
            this.tabControlPlot.TabIndex = 0;
            // 
            // propertyGridFacets
            // 
            this.propertyGridFacets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridFacets.Location = new System.Drawing.Point(0, 0);
            this.propertyGridFacets.Name = "propertyGridFacets";
            this.propertyGridFacets.Size = new System.Drawing.Size(345, 426);
            this.propertyGridFacets.TabIndex = 0;
            // 
            // FormPlotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 507);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControlPlot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPlotSettings";
            this.Text = "Plot Settings";
            this.tabPageTheme.ResumeLayout(false);
            this.tabPageTheme.PerformLayout();
            this.tabPageFacets.ResumeLayout(false);
            this.tabPageCoords.ResumeLayout(false);
            this.tabPageCoords.PerformLayout();
            this.tabPageScales.ResumeLayout(false);
            this.tabPageScales.PerformLayout();
            this.tabPageLabels.ResumeLayout(false);
            this.tabPageLayers.ResumeLayout(false);
            this.tabPageLayers.PerformLayout();
            this.tabPageData.ResumeLayout(false);
            this.tabControlPlot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage tabPageTheme;
        private System.Windows.Forms.ComboBox comboBoxThemes;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.TabPage tabPageFacets;
        private System.Windows.Forms.TabPage tabPageCoords;
        private System.Windows.Forms.TabPage tabPageScales;
        private System.Windows.Forms.PropertyGrid propertyGridScales;
        private System.Windows.Forms.ComboBox comboBoxScales;
        private System.Windows.Forms.Label labelScales;
        private System.Windows.Forms.TabPage tabPageLabels;
        private System.Windows.Forms.PropertyGrid propertyGridLabels;
        private System.Windows.Forms.TabPage tabPageLayers;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListView listViewGeoms;
        private System.Windows.Forms.ColumnHeader columnHeaderGeom;
        private System.Windows.Forms.ColumnHeader columnHeaderContent;
        private System.Windows.Forms.Label labelGeom;
        private System.Windows.Forms.ComboBox comboBoxGeom;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.PropertyGrid propertyGridData;
        private System.Windows.Forms.TabControl tabControlPlot;
        private System.Windows.Forms.PropertyGrid propertyGridCoords;
        private System.Windows.Forms.ComboBox comboBoxCoords;
        private System.Windows.Forms.Label labelCoords;
        private System.Windows.Forms.PropertyGrid propertyGridThemes;
        private System.Windows.Forms.PropertyGrid propertyGridFacets;
    }
}