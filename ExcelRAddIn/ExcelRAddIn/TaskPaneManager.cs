using ExcelDna.Integration.CustomUI;

using REnvironmentControlLibrary;

namespace ExcelRAddIn
{
    internal static class TaskPaneManager
    {
        // The custom task pane hosts the REnvironmentControl
        static readonly CustomTaskPane m_taskPane;

        static TaskPaneManager()
        {
            if (m_taskPane == null)
            {
                // Make a new one using ExcelDna.Integration.CustomUI.CustomTaskPaneFactory 
                m_taskPane = CustomTaskPaneFactory.CreateCustomTaskPane(typeof(REnvironmentControl), "Excel R AddIn");

                m_taskPane.Visible = true;
                m_taskPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionRight;
                m_taskPane.DockPositionStateChange += TaskPane_DockPositionStateChange;
                m_taskPane.VisibleStateChange += TaskPane_VisibleStateChange;
            }
        }

        public static void ShowHideTaskPane()
        {
            if (!m_taskPane.Visible)
            {
                m_taskPane.Visible = true;
            }
            else
            {
                m_taskPane.Visible = false;
            }
        }

        static void TaskPane_VisibleStateChange(CustomTaskPane CustomTaskPaneInst)
        {
        }

        static void TaskPane_DockPositionStateChange(CustomTaskPane CustomTaskPaneInst)
        {
        }

        public static void AddMessage(MessageType type, string message)
        {
            ((REnvironmentControl)m_taskPane.ContentControl).AddMessage(type, message);
        }

        public static void AddEnvironmentItem(string name, string contents)
        {
            ((REnvironmentControl)m_taskPane.ContentControl).AddEnvironmentItem(name, contents);
        }

        public static long RemoveEnvironmentItems(string[] names)
        {
            return ((REnvironmentControl)m_taskPane.ContentControl).RemoveEnvironmentItems(names);
        }
    }
}
