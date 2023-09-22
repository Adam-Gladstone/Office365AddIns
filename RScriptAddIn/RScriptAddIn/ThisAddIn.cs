using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using REnvironmentControlLibrary;

namespace RScriptAddIn
{
    public partial class ThisAddIn
    {
        private REnvironmentControl m_environmentControl;
        private Microsoft.Office.Tools.CustomTaskPane taskPaneValue;

        public REnvironmentControl REnvironmentControl
        {
            get
            {
                return m_environmentControl;
            }
        }

        public Microsoft.Office.Tools.CustomTaskPane TaskPane
        {
            get
            {
                return taskPaneValue;
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            m_environmentControl = new REnvironmentControl();
            taskPaneValue = this.CustomTaskPanes.Add(m_environmentControl, "R-Script AddIn");
            taskPaneValue.Visible = true;
            taskPaneValue.VisibleChanged += new EventHandler(TaskPaneValue_VisibleChanged);
        }
        private void TaskPaneValue_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons.ToolRibbon.ToggleButtonShow.Checked = taskPaneValue.Visible;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
