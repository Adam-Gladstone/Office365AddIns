namespace RScriptAddIn
{
    partial class ToolRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ToolRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolRibbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.ToggleButtonShow = this.Factory.CreateRibbonToggleButton();
            this.ButtonRunScript = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.ButtonSettings = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.ToggleButtonShow);
            this.group1.Items.Add(this.ButtonRunScript);
            this.group1.Items.Add(this.separator1);
            this.group1.Items.Add(this.ButtonSettings);
            this.group1.Label = "R Tools";
            this.group1.Name = "group1";
            // 
            // ToggleButtonShow
            // 
            this.ToggleButtonShow.Label = "Show Task Pane";
            this.ToggleButtonShow.Name = "ToggleButtonShow";
            this.ToggleButtonShow.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ToggleButtonShow_Click);
            // 
            // ButtonRunScript
            // 
            this.ButtonRunScript.Image = ((System.Drawing.Image)(resources.GetObject("ButtonRunScript.Image")));
            this.ButtonRunScript.Label = "Run Script";
            this.ButtonRunScript.Name = "ButtonRunScript";
            this.ButtonRunScript.ShowImage = true;
            this.ButtonRunScript.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonRunScript_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // ButtonSettings
            // 
            this.ButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSettings.Image")));
            this.ButtonSettings.Label = "Settings";
            this.ButtonSettings.Name = "ButtonSettings";
            this.ButtonSettings.ShowImage = true;
            this.ButtonSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonSettings_Click);
            // 
            // ToolRibbon
            // 
            this.Name = "ToolRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ToolRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ButtonRunScript;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ToggleButtonShow;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ButtonSettings;
    }

    partial class ThisRibbonCollection
    {
        internal ToolRibbon ToolRibbon
        {
            get { return this.GetRibbon<ToolRibbon>(); }
        }
    }
}
