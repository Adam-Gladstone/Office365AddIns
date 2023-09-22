using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace REnvironmentControlLibrary
{
    public enum MessageType
    {
        Information,
        Warning,
        Error
    }

    [ComVisible(true)]
    public partial class REnvironmentControl : UserControl
    {
        public REnvironmentControl()
        {
            InitializeComponent();

            Bitmap bitmap0 = Bitmap.FromHicon(SystemIcons.Information.Handle);
            Bitmap bitmap1 = Bitmap.FromHicon(SystemIcons.Warning.Handle);
            Bitmap bitmap2 = Bitmap.FromHicon(SystemIcons.Error.Handle);

            imageList.Images.Add(bitmap0);
            imageList.Images.Add(bitmap1);
            imageList.Images.Add(bitmap2);
        }

        public ListView Messages
        {
            get { return listViewMessages; }
        }

        public void AddMessage(MessageType type, string message)
        {
            ListViewItem item = new ListViewItem
            {
                ImageIndex = (int)type,
                Text = message,
                Tag = type
            };

            listViewMessages.Items.Add(item);
        }

        public void AddEnvironmentItem(string name, string contents)
        {
            ListViewItem item = listViewEnvironment.FindItemWithText(name);
            if (item != null)
            {
                item.SubItems.Clear();

                item.Text = name;
                item.SubItems.Add(contents);
            }
            else
            {
                item = new ListViewItem
                {
                    Text = name
                };

                item.SubItems.Add(contents);
                this.listViewEnvironment.Items.Add(item);
            }
        }

        public long RemoveEnvironmentItems(string[] names)
        {
            long count = 0;
            foreach (string name in names)
            {
                string trimmed_name = name.Trim();
                trimmed_name = trimmed_name.Trim(new char[] { '\'' });
                ListViewItem item = listViewEnvironment.FindItemWithText(trimmed_name);
                if (item != null)
                {
                    item.Remove();
                    count++;
                }
            }
            return count;
        }
    }
}
