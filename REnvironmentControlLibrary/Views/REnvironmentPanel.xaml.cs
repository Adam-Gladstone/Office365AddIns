using REnvironmentControlLibrary.ViewModel;
using System.Windows.Controls;

namespace REnvironmentControlLibrary
{
    /// <summary>
    /// Interaction logic for REnvironmentPanel.xaml
    /// </summary>
    public partial class REnvironmentPanel : UserControl
    {
        public EnvironmentViewModel ViewModel { get; set; }

        public REnvironmentPanel()
        {
            InitializeComponent();

            ViewModel = new EnvironmentViewModel();

            DataContext = ViewModel;
        }

        public void AddMessage(MessageType type, string message)
        {
            ViewModel.AddMessage(type, message);
        }

        public void AddEnvironmentItem(string name, string contents)
        {
            ViewModel.AddEnvironmentItem(name, contents);
        }

        public long RemoveEnvironmentItems(string[] names)
        {
            return ViewModel.RemoveEnvironmentItems(names);
        }
    }
}
