using System;
using System.Windows.Media.Imaging;

namespace REnvironmentControlLibrary.Models
{
    public class EnvironmentMessage
    {
        public string Message { get; set; }
        public MessageType Type { get; set; }

        public BitmapImage MessageIcon { get; set; }

        public EnvironmentMessage(MessageType type, string message)
        {
            // The assets have been added to the project as resources

            Type = type;

            Uri uriSource;
            if (Type == MessageType.Information)
            {
                uriSource = new Uri(@"/REnvironmentControlLibrary;component/Assets/information.png", UriKind.Relative);
            }
            else if (Type == MessageType.Warning)
            {
                uriSource = new Uri(@"/REnvironmentControlLibrary;component/Assets/warning.png", UriKind.Relative);
            }
            else if (Type == MessageType.Error)
            {
                uriSource = new Uri(@"/REnvironmentControlLibrary;component/Assets/error.png", UriKind.Relative);
            }
            else
            {
                uriSource = new Uri(@"/REnvironmentControlLibrary;component/Assets/information.png", UriKind.Relative);
            }

            MessageIcon = new BitmapImage(uriSource);

            Message = message;
        }
    }

    public class EnvironmentItem
    {
        public string Name { get; set; }
        public string Contents { get; set; }

        public EnvironmentItem(string name, string contents)
        {
            Name = name;
            Contents = contents;
        }
    }
}
