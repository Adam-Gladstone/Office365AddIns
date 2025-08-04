using REnvironmentControlLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace REnvironmentControlLibrary.ViewModel
{
    public class EnvironmentViewModel
    {
        public ObservableCollection<EnvironmentItem> EnvironmentItems { get; set; }

        public ObservableCollection<EnvironmentMessage> Messages { get; set; }

        public EnvironmentViewModel() 
        {
            EnvironmentItems = new ObservableCollection<EnvironmentItem>();
            Messages = new ObservableCollection<EnvironmentMessage>();
        }

        public void AddMessage(MessageType type, string message)
        {
            Messages.Add(new EnvironmentMessage(type, message));
        }

        public void AddEnvironmentItem(string name, string contents)
        {
            EnvironmentItem item = EnvironmentItems.ToList().Find(x => x.Name == name);
            if (item != null)
            {
                // Remove previous item with the same name
                EnvironmentItems.Remove(item);
            }

            item = new EnvironmentItem(name, contents);

            EnvironmentItems.Add(item);
        }

        public long RemoveEnvironmentItems(string[] names)
        {
            long count = 0;

            foreach (string name in names)
            {
                string trimmed_name = name.Trim();
                trimmed_name = trimmed_name.Trim(new char[] { '\'' });

                EnvironmentItem item = EnvironmentItems.ToList().Find(x => x.Name == trimmed_name);
                if (item != null)
                {
                    EnvironmentItems.Remove(item);
                    count++;
                }
            }
            return count;
        }
    }
}
