using System.Windows.Forms;

namespace REnvironmentControlLibrary
{
    public partial class FormGeomSettings : Form
    {
        public FormGeomSettings()
        {
            InitializeComponent();
        }

        public void SetPropertyGrid(object obj)
        {
            propertyGridGeoms.SelectedObject = obj;

            if (propertyGridGeoms.PropertySort == PropertySort.CategorizedAlphabetical)
            {
                propertyGridGeoms.PropertySort = PropertySort.Categorized;
            }
        }
    }
}
