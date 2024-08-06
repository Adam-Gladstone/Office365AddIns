namespace REnvironmentControlLibrary
{
    partial class FormCreatePlot
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
            this.labelDataFrame = new System.Windows.Forms.Label();
            this.textBoxDataFrame = new System.Windows.Forms.TextBox();
            this.groupBoxAesthetic = new System.Windows.Forms.GroupBox();
            this.labelXData = new System.Windows.Forms.Label();
            this.textBoxXData = new System.Windows.Forms.TextBox();
            this.labelYData = new System.Windows.Forms.Label();
            this.textBoxYData = new System.Windows.Forms.TextBox();
            this.labelColour = new System.Windows.Forms.Label();
            this.textBoxColour = new System.Windows.Forms.TextBox();
            this.labelFill = new System.Windows.Forms.Label();
            this.textBoxFill = new System.Windows.Forms.TextBox();
            this.labelGroup = new System.Windows.Forms.Label();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.labelShape = new System.Windows.Forms.Label();
            this.textBoxShape = new System.Windows.Forms.TextBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.labelChartType = new System.Windows.Forms.Label();
            this.comboBoxChartTypes = new System.Windows.Forms.ComboBox();
            this.labelTheme = new System.Windows.Forms.Label();
            this.comboBoxThemes = new System.Windows.Forms.ComboBox();
            this.groupBoxLabels = new System.Windows.Forms.GroupBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.textBoxSubtitle = new System.Windows.Forms.TextBox();
            this.textBoxYLabel = new System.Windows.Forms.TextBox();
            this.labelYLabel = new System.Windows.Forms.Label();
            this.textBoxXLabel = new System.Windows.Forms.TextBox();
            this.labelXLabel = new System.Windows.Forms.Label();
            this.textBoxCaption = new System.Windows.Forms.TextBox();
            this.labelCaption = new System.Windows.Forms.Label();
            this.groupBoxAesthetic.SuspendLayout();
            this.groupBoxLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(356, 490);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(437, 490);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelDataFrame
            // 
            this.labelDataFrame.AutoSize = true;
            this.labelDataFrame.Location = new System.Drawing.Point(13, 13);
            this.labelDataFrame.Name = "labelDataFrame";
            this.labelDataFrame.Size = new System.Drawing.Size(78, 16);
            this.labelDataFrame.TabIndex = 2;
            this.labelDataFrame.Text = "DataFrame:";
            // 
            // textBoxDataFrame
            // 
            this.textBoxDataFrame.Location = new System.Drawing.Point(96, 11);
            this.textBoxDataFrame.Name = "textBoxDataFrame";
            this.textBoxDataFrame.Size = new System.Drawing.Size(162, 22);
            this.textBoxDataFrame.TabIndex = 3;
            this.textBoxDataFrame.TextChanged += new System.EventHandler(this.textBoxDataFrame_TextChanged);
            // 
            // groupBoxAesthetic
            // 
            this.groupBoxAesthetic.Controls.Add(this.textBoxSize);
            this.groupBoxAesthetic.Controls.Add(this.labelSize);
            this.groupBoxAesthetic.Controls.Add(this.textBoxShape);
            this.groupBoxAesthetic.Controls.Add(this.labelShape);
            this.groupBoxAesthetic.Controls.Add(this.textBoxGroup);
            this.groupBoxAesthetic.Controls.Add(this.labelGroup);
            this.groupBoxAesthetic.Controls.Add(this.textBoxFill);
            this.groupBoxAesthetic.Controls.Add(this.labelFill);
            this.groupBoxAesthetic.Controls.Add(this.textBoxColour);
            this.groupBoxAesthetic.Controls.Add(this.labelColour);
            this.groupBoxAesthetic.Controls.Add(this.textBoxYData);
            this.groupBoxAesthetic.Controls.Add(this.labelYData);
            this.groupBoxAesthetic.Controls.Add(this.textBoxXData);
            this.groupBoxAesthetic.Controls.Add(this.labelXData);
            this.groupBoxAesthetic.Location = new System.Drawing.Point(16, 48);
            this.groupBoxAesthetic.Name = "groupBoxAesthetic";
            this.groupBoxAesthetic.Size = new System.Drawing.Size(496, 176);
            this.groupBoxAesthetic.TabIndex = 4;
            this.groupBoxAesthetic.TabStop = false;
            this.groupBoxAesthetic.Text = " Aesthetic ";
            // 
            // labelXData
            // 
            this.labelXData.AutoSize = true;
            this.labelXData.Location = new System.Drawing.Point(23, 31);
            this.labelXData.Name = "labelXData";
            this.labelXData.Size = new System.Drawing.Size(50, 16);
            this.labelXData.TabIndex = 0;
            this.labelXData.Text = "X Data:";
            // 
            // textBoxXData
            // 
            this.textBoxXData.Location = new System.Drawing.Point(78, 28);
            this.textBoxXData.Name = "textBoxXData";
            this.textBoxXData.Size = new System.Drawing.Size(162, 22);
            this.textBoxXData.TabIndex = 1;
            this.textBoxXData.TextChanged += new System.EventHandler(this.textBoxXData_TextChanged);
            // 
            // labelYData
            // 
            this.labelYData.AutoSize = true;
            this.labelYData.Location = new System.Drawing.Point(23, 69);
            this.labelYData.Name = "labelYData";
            this.labelYData.Size = new System.Drawing.Size(51, 16);
            this.labelYData.TabIndex = 2;
            this.labelYData.Text = "Y Data:";
            // 
            // textBoxYData
            // 
            this.textBoxYData.Location = new System.Drawing.Point(78, 66);
            this.textBoxYData.Name = "textBoxYData";
            this.textBoxYData.Size = new System.Drawing.Size(162, 22);
            this.textBoxYData.TabIndex = 3;
            this.textBoxYData.TextChanged += new System.EventHandler(this.textBoxYData_TextChanged);
            // 
            // labelColour
            // 
            this.labelColour.AutoSize = true;
            this.labelColour.Location = new System.Drawing.Point(23, 107);
            this.labelColour.Name = "labelColour";
            this.labelColour.Size = new System.Drawing.Size(49, 16);
            this.labelColour.TabIndex = 4;
            this.labelColour.Text = "Colour:";
            // 
            // textBoxColour
            // 
            this.textBoxColour.Location = new System.Drawing.Point(78, 104);
            this.textBoxColour.Name = "textBoxColour";
            this.textBoxColour.Size = new System.Drawing.Size(162, 22);
            this.textBoxColour.TabIndex = 5;
            // 
            // labelFill
            // 
            this.labelFill.AutoSize = true;
            this.labelFill.Location = new System.Drawing.Point(23, 145);
            this.labelFill.Name = "labelFill";
            this.labelFill.Size = new System.Drawing.Size(27, 16);
            this.labelFill.TabIndex = 6;
            this.labelFill.Text = "Fill:";
            // 
            // textBoxFill
            // 
            this.textBoxFill.Location = new System.Drawing.Point(78, 142);
            this.textBoxFill.Name = "textBoxFill";
            this.textBoxFill.Size = new System.Drawing.Size(162, 22);
            this.textBoxFill.TabIndex = 7;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(259, 31);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(47, 16);
            this.labelGroup.TabIndex = 8;
            this.labelGroup.Text = "Group:";
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Location = new System.Drawing.Point(310, 28);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.Size = new System.Drawing.Size(162, 22);
            this.textBoxGroup.TabIndex = 9;
            // 
            // labelShape
            // 
            this.labelShape.AutoSize = true;
            this.labelShape.Location = new System.Drawing.Point(259, 69);
            this.labelShape.Name = "labelShape";
            this.labelShape.Size = new System.Drawing.Size(50, 16);
            this.labelShape.TabIndex = 10;
            this.labelShape.Text = "Shape:";
            // 
            // textBoxShape
            // 
            this.textBoxShape.Location = new System.Drawing.Point(310, 66);
            this.textBoxShape.Name = "textBoxShape";
            this.textBoxShape.Size = new System.Drawing.Size(162, 22);
            this.textBoxShape.TabIndex = 11;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(259, 107);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(36, 16);
            this.labelSize.TabIndex = 12;
            this.labelSize.Text = "Size:";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(310, 104);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(162, 22);
            this.textBoxSize.TabIndex = 13;
            // 
            // labelChartType
            // 
            this.labelChartType.AutoSize = true;
            this.labelChartType.Location = new System.Drawing.Point(13, 243);
            this.labelChartType.Name = "labelChartType";
            this.labelChartType.Size = new System.Drawing.Size(76, 16);
            this.labelChartType.TabIndex = 5;
            this.labelChartType.Text = "Chart Type:";
            // 
            // comboBoxChartTypes
            // 
            this.comboBoxChartTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChartTypes.FormattingEnabled = true;
            this.comboBoxChartTypes.Location = new System.Drawing.Point(93, 239);
            this.comboBoxChartTypes.Name = "comboBoxChartTypes";
            this.comboBoxChartTypes.Size = new System.Drawing.Size(163, 24);
            this.comboBoxChartTypes.TabIndex = 6;
            this.comboBoxChartTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxChartTypes_SelectedIndexChanged);
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Location = new System.Drawing.Point(272, 243);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(53, 16);
            this.labelTheme.TabIndex = 7;
            this.labelTheme.Text = "Theme:";
            // 
            // comboBoxThemes
            // 
            this.comboBoxThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThemes.FormattingEnabled = true;
            this.comboBoxThemes.Location = new System.Drawing.Point(326, 239);
            this.comboBoxThemes.Name = "comboBoxThemes";
            this.comboBoxThemes.Size = new System.Drawing.Size(163, 24);
            this.comboBoxThemes.TabIndex = 8;
            // 
            // groupBoxLabels
            // 
            this.groupBoxLabels.Controls.Add(this.textBoxCaption);
            this.groupBoxLabels.Controls.Add(this.labelCaption);
            this.groupBoxLabels.Controls.Add(this.textBoxYLabel);
            this.groupBoxLabels.Controls.Add(this.labelYLabel);
            this.groupBoxLabels.Controls.Add(this.textBoxXLabel);
            this.groupBoxLabels.Controls.Add(this.labelXLabel);
            this.groupBoxLabels.Controls.Add(this.textBoxSubtitle);
            this.groupBoxLabels.Controls.Add(this.labelSubtitle);
            this.groupBoxLabels.Controls.Add(this.textBoxTitle);
            this.groupBoxLabels.Controls.Add(this.labelTitle);
            this.groupBoxLabels.Location = new System.Drawing.Point(16, 287);
            this.groupBoxLabels.Name = "groupBoxLabels";
            this.groupBoxLabels.Size = new System.Drawing.Size(496, 187);
            this.groupBoxLabels.TabIndex = 9;
            this.groupBoxLabels.TabStop = false;
            this.groupBoxLabels.Text = " Labels ";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(23, 34);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(36, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(83, 31);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(162, 22);
            this.textBoxTitle.TabIndex = 1;
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Location = new System.Drawing.Point(23, 72);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(54, 16);
            this.labelSubtitle.TabIndex = 2;
            this.labelSubtitle.Text = "Subtitle:";
            // 
            // textBoxSubtitle
            // 
            this.textBoxSubtitle.Location = new System.Drawing.Point(83, 69);
            this.textBoxSubtitle.Name = "textBoxSubtitle";
            this.textBoxSubtitle.Size = new System.Drawing.Size(162, 22);
            this.textBoxSubtitle.TabIndex = 3;
            // 
            // textBoxYLabel
            // 
            this.textBoxYLabel.Location = new System.Drawing.Point(85, 145);
            this.textBoxYLabel.Name = "textBoxYLabel";
            this.textBoxYLabel.Size = new System.Drawing.Size(162, 22);
            this.textBoxYLabel.TabIndex = 7;
            // 
            // labelYLabel
            // 
            this.labelYLabel.AutoSize = true;
            this.labelYLabel.Location = new System.Drawing.Point(25, 148);
            this.labelYLabel.Name = "labelYLabel";
            this.labelYLabel.Size = new System.Drawing.Size(56, 16);
            this.labelYLabel.TabIndex = 6;
            this.labelYLabel.Text = "Y Label:";
            // 
            // textBoxXLabel
            // 
            this.textBoxXLabel.Location = new System.Drawing.Point(85, 107);
            this.textBoxXLabel.Name = "textBoxXLabel";
            this.textBoxXLabel.Size = new System.Drawing.Size(162, 22);
            this.textBoxXLabel.TabIndex = 5;
            // 
            // labelXLabel
            // 
            this.labelXLabel.AutoSize = true;
            this.labelXLabel.Location = new System.Drawing.Point(25, 110);
            this.labelXLabel.Name = "labelXLabel";
            this.labelXLabel.Size = new System.Drawing.Size(55, 16);
            this.labelXLabel.TabIndex = 4;
            this.labelXLabel.Text = "X Label:";
            // 
            // textBoxCaption
            // 
            this.textBoxCaption.Location = new System.Drawing.Point(310, 28);
            this.textBoxCaption.Name = "textBoxCaption";
            this.textBoxCaption.Size = new System.Drawing.Size(162, 22);
            this.textBoxCaption.TabIndex = 9;
            // 
            // labelCaption
            // 
            this.labelCaption.AutoSize = true;
            this.labelCaption.Location = new System.Drawing.Point(250, 31);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(56, 16);
            this.labelCaption.TabIndex = 8;
            this.labelCaption.Text = "Caption:";
            // 
            // FormCreatePlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 525);
            this.Controls.Add(this.groupBoxLabels);
            this.Controls.Add(this.comboBoxThemes);
            this.Controls.Add(this.labelTheme);
            this.Controls.Add(this.comboBoxChartTypes);
            this.Controls.Add(this.labelChartType);
            this.Controls.Add(this.groupBoxAesthetic);
            this.Controls.Add(this.textBoxDataFrame);
            this.Controls.Add(this.labelDataFrame);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormCreatePlot";
            this.Text = "Create Plot";
            this.groupBoxAesthetic.ResumeLayout(false);
            this.groupBoxAesthetic.PerformLayout();
            this.groupBoxLabels.ResumeLayout(false);
            this.groupBoxLabels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDataFrame;
        private System.Windows.Forms.TextBox textBoxDataFrame;
        private System.Windows.Forms.GroupBox groupBoxAesthetic;
        private System.Windows.Forms.TextBox textBoxXData;
        private System.Windows.Forms.Label labelXData;
        private System.Windows.Forms.Label labelColour;
        private System.Windows.Forms.TextBox textBoxYData;
        private System.Windows.Forms.Label labelYData;
        private System.Windows.Forms.TextBox textBoxShape;
        private System.Windows.Forms.Label labelShape;
        private System.Windows.Forms.TextBox textBoxGroup;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.TextBox textBoxFill;
        private System.Windows.Forms.Label labelFill;
        private System.Windows.Forms.TextBox textBoxColour;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelChartType;
        private System.Windows.Forms.ComboBox comboBoxChartTypes;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.ComboBox comboBoxThemes;
        private System.Windows.Forms.GroupBox groupBoxLabels;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxYLabel;
        private System.Windows.Forms.Label labelYLabel;
        private System.Windows.Forms.TextBox textBoxXLabel;
        private System.Windows.Forms.Label labelXLabel;
        private System.Windows.Forms.TextBox textBoxSubtitle;
        private System.Windows.Forms.TextBox textBoxCaption;
        private System.Windows.Forms.Label labelCaption;
    }
}