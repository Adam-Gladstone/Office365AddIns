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
            this.tabControlPlot = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.propertyGridData = new System.Windows.Forms.PropertyGrid();
            this.tabPageLayers1 = new System.Windows.Forms.TabPage();
            this.propertyGridGeoms = new System.Windows.Forms.PropertyGrid();
            this.labelGeom = new System.Windows.Forms.Label();
            this.comboBoxGeom = new System.Windows.Forms.ComboBox();
            this.tabPageLayers2 = new System.Windows.Forms.TabPage();
            this.tabPageLabels = new System.Windows.Forms.TabPage();
            this.propertyGridLabels = new System.Windows.Forms.PropertyGrid();
            this.tabPageScales = new System.Windows.Forms.TabPage();
            this.tabPageCoords = new System.Windows.Forms.TabPage();
            this.tabPageFacets = new System.Windows.Forms.TabPage();
            this.tabPageTheme = new System.Windows.Forms.TabPage();
            this.comboBoxThemes = new System.Windows.Forms.ComboBox();
            this.labelTheme = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlPlot.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabPageLayers1.SuspendLayout();
            this.tabPageLabels.SuspendLayout();
            this.tabPageTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPlot
            // 
            this.tabControlPlot.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlPlot.Controls.Add(this.tabPageData);
            this.tabControlPlot.Controls.Add(this.tabPageLayers1);
            this.tabControlPlot.Controls.Add(this.tabPageLayers2);
            this.tabControlPlot.Controls.Add(this.tabPageLabels);
            this.tabControlPlot.Controls.Add(this.tabPageScales);
            this.tabControlPlot.Controls.Add(this.tabPageCoords);
            this.tabControlPlot.Controls.Add(this.tabPageFacets);
            this.tabControlPlot.Controls.Add(this.tabPageTheme);
            this.tabControlPlot.Location = new System.Drawing.Point(12, 12);
            this.tabControlPlot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlPlot.Name = "tabControlPlot";
            this.tabControlPlot.SelectedIndex = 0;
            this.tabControlPlot.Size = new System.Drawing.Size(461, 558);
            this.tabControlPlot.TabIndex = 0;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.propertyGridData);
            this.tabPageData.Location = new System.Drawing.Point(4, 4);
            this.tabPageData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageData.Size = new System.Drawing.Size(453, 529);
            this.tabPageData.TabIndex = 5;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // propertyGridData
            // 
            this.propertyGridData.Location = new System.Drawing.Point(6, 5);
            this.propertyGridData.Name = "propertyGridData";
            this.propertyGridData.Size = new System.Drawing.Size(441, 519);
            this.propertyGridData.TabIndex = 8;
            // 
            // tabPageLayers1
            // 
            this.tabPageLayers1.Controls.Add(this.propertyGridGeoms);
            this.tabPageLayers1.Controls.Add(this.labelGeom);
            this.tabPageLayers1.Controls.Add(this.comboBoxGeom);
            this.tabPageLayers1.Location = new System.Drawing.Point(4, 4);
            this.tabPageLayers1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageLayers1.Name = "tabPageLayers1";
            this.tabPageLayers1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageLayers1.Size = new System.Drawing.Size(453, 529);
            this.tabPageLayers1.TabIndex = 0;
            this.tabPageLayers1.Text = "Layers I";
            this.tabPageLayers1.UseVisualStyleBackColor = true;
            // 
            // propertyGridGeoms
            // 
            this.propertyGridGeoms.Location = new System.Drawing.Point(9, 37);
            this.propertyGridGeoms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.propertyGridGeoms.Name = "propertyGridGeoms";
            this.propertyGridGeoms.Size = new System.Drawing.Size(438, 488);
            this.propertyGridGeoms.TabIndex = 5;
            // 
            // labelGeom
            // 
            this.labelGeom.AutoSize = true;
            this.labelGeom.Location = new System.Drawing.Point(6, 12);
            this.labelGeom.Name = "labelGeom";
            this.labelGeom.Size = new System.Drawing.Size(66, 15);
            this.labelGeom.TabIndex = 4;
            this.labelGeom.Text = "Geometry: ";
            // 
            // comboBoxGeom
            // 
            this.comboBoxGeom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGeom.FormattingEnabled = true;
            this.comboBoxGeom.Location = new System.Drawing.Point(84, 9);
            this.comboBoxGeom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGeom.Name = "comboBoxGeom";
            this.comboBoxGeom.Size = new System.Drawing.Size(312, 24);
            this.comboBoxGeom.TabIndex = 3;
            this.comboBoxGeom.SelectedIndexChanged += new System.EventHandler(this.comboBoxGeom_SelectedIndexChanged);
            // 
            // tabPageLayers2
            // 
            this.tabPageLayers2.Location = new System.Drawing.Point(4, 4);
            this.tabPageLayers2.Name = "tabPageLayers2";
            this.tabPageLayers2.Size = new System.Drawing.Size(453, 529);
            this.tabPageLayers2.TabIndex = 7;
            this.tabPageLayers2.Text = "Layers II";
            this.tabPageLayers2.UseVisualStyleBackColor = true;
            // 
            // tabPageLabels
            // 
            this.tabPageLabels.Controls.Add(this.propertyGridLabels);
            this.tabPageLabels.Location = new System.Drawing.Point(4, 4);
            this.tabPageLabels.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageLabels.Name = "tabPageLabels";
            this.tabPageLabels.Size = new System.Drawing.Size(453, 529);
            this.tabPageLabels.TabIndex = 6;
            this.tabPageLabels.Text = "Labels";
            this.tabPageLabels.UseVisualStyleBackColor = true;
            // 
            // propertyGridLabels
            // 
            this.propertyGridLabels.Location = new System.Drawing.Point(4, 4);
            this.propertyGridLabels.Name = "propertyGridLabels";
            this.propertyGridLabels.Size = new System.Drawing.Size(446, 522);
            this.propertyGridLabels.TabIndex = 0;
            // 
            // tabPageScales
            // 
            this.tabPageScales.Location = new System.Drawing.Point(4, 4);
            this.tabPageScales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageScales.Name = "tabPageScales";
            this.tabPageScales.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageScales.Size = new System.Drawing.Size(453, 529);
            this.tabPageScales.TabIndex = 1;
            this.tabPageScales.Text = "Scales";
            this.tabPageScales.UseVisualStyleBackColor = true;
            // 
            // tabPageCoords
            // 
            this.tabPageCoords.Location = new System.Drawing.Point(4, 4);
            this.tabPageCoords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageCoords.Name = "tabPageCoords";
            this.tabPageCoords.Size = new System.Drawing.Size(453, 529);
            this.tabPageCoords.TabIndex = 2;
            this.tabPageCoords.Text = "Coords";
            this.tabPageCoords.UseVisualStyleBackColor = true;
            // 
            // tabPageFacets
            // 
            this.tabPageFacets.Location = new System.Drawing.Point(4, 4);
            this.tabPageFacets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageFacets.Name = "tabPageFacets";
            this.tabPageFacets.Size = new System.Drawing.Size(453, 529);
            this.tabPageFacets.TabIndex = 3;
            this.tabPageFacets.Text = "Facets";
            this.tabPageFacets.UseVisualStyleBackColor = true;
            // 
            // tabPageTheme
            // 
            this.tabPageTheme.Controls.Add(this.comboBoxThemes);
            this.tabPageTheme.Controls.Add(this.labelTheme);
            this.tabPageTheme.Location = new System.Drawing.Point(4, 4);
            this.tabPageTheme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageTheme.Name = "tabPageTheme";
            this.tabPageTheme.Size = new System.Drawing.Size(453, 529);
            this.tabPageTheme.TabIndex = 4;
            this.tabPageTheme.Text = "Theme";
            this.tabPageTheme.UseVisualStyleBackColor = true;
            // 
            // comboBoxThemes
            // 
            this.comboBoxThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThemes.FormattingEnabled = true;
            this.comboBoxThemes.Location = new System.Drawing.Point(68, 12);
            this.comboBoxThemes.Name = "comboBoxThemes";
            this.comboBoxThemes.Size = new System.Drawing.Size(218, 24);
            this.comboBoxThemes.TabIndex = 10;
            this.comboBoxThemes.SelectedIndexChanged += new System.EventHandler(this.comboBoxThemes_SelectedIndexChanged);
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Location = new System.Drawing.Point(9, 16);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(49, 15);
            this.labelTheme.TabIndex = 9;
            this.labelTheme.Text = "Theme:";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(232, 574);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(116, 37);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(353, 574);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(116, 37);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormPlotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 617);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControlPlot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPlotSettings";
            this.Text = "Plot Settings";
            this.tabControlPlot.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageLayers1.ResumeLayout(false);
            this.tabPageLayers1.PerformLayout();
            this.tabPageLabels.ResumeLayout(false);
            this.tabPageTheme.ResumeLayout(false);
            this.tabPageTheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPlot;
        private System.Windows.Forms.TabPage tabPageLayers1;
        private System.Windows.Forms.TabPage tabPageScales;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage tabPageCoords;
        private System.Windows.Forms.TabPage tabPageFacets;
        private System.Windows.Forms.TabPage tabPageTheme;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TabPage tabPageLabels;
        private System.Windows.Forms.PropertyGrid propertyGridData;
        private System.Windows.Forms.TabPage tabPageLayers2;
        private System.Windows.Forms.PropertyGrid propertyGridGeoms;
        private System.Windows.Forms.Label labelGeom;
        private System.Windows.Forms.ComboBox comboBoxGeom;
        private System.Windows.Forms.PropertyGrid propertyGridLabels;
        private System.Windows.Forms.ComboBox comboBoxThemes;
        private System.Windows.Forms.Label labelTheme;
    }
}