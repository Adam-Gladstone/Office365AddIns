using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace REnvironmentControlLibrary
{
    public enum MessageType
    {
        Information,
        Warning,
        Error
    }

    [ComVisible(true)]
    public partial class REnvironmentControlHost : UserControl
    {
        public REnvironmentControlHost()
        {
            InitializeComponent();
        }

        private REnvironmentPanel GetChildControl()
        {
            return (REnvironmentPanel)elementHost1.Child;
        }

        public void AddMessage(MessageType type, string message)
        {
            GetChildControl().AddMessage(type, message);
        }

        public void AddEnvironmentItem(string name, string contents)
        {
            GetChildControl().AddEnvironmentItem(name, contents);
        }

        public long RemoveEnvironmentItems(string[] names)
        {
            return GetChildControl().RemoveEnvironmentItems(names);
        }
    }
}
