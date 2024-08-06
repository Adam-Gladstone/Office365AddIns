using REnvironmentControlLibrary.ViewModel;
using System;
using System.Windows.Forms;

namespace REnvironmentControlLibrary
{
    public partial class FormPlotSettings : Form
    {
        public PlotViewModel PlotViewModel { get; set; } = new PlotViewModel();

        public FormPlotSettings()
        {
            InitializeComponent();

            propertyGridData.SelectedObject = PlotViewModel.DataSettings;

            propertyGridLabels.SelectedObject = PlotViewModel.LabelSettings;

            // Populate any controls and bind property grids
            UpdateData(false);

            // Initial state of Ok and Cancel buttons
            OnUpdateUI();
        }

        void UpdateData(bool saveAndValidate)
        {
            if (saveAndValidate)
            {

            }
            else
            {
                // Geoms
                ComboBox comboBoxGeoms = (ComboBox)tabPageLayers1.Controls["comboBoxGeom"];
                comboBoxGeoms.Items.AddRange(PlotViewModel.GeomTypes.ToArray());
                comboBoxGeoms.SelectedIndex = 0;

                // Themes
                ComboBox comboBoxThemes = (ComboBox)tabPageTheme.Controls["comboBoxThemes"];
                comboBoxThemes.Items.AddRange(PlotViewModel.Themes.ToArray());
                comboBoxThemes.SelectedIndex = 0;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            UpdateData(true);

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void OnUpdateUI()
        {
            buttonOk.Enabled = true;
        }

        private void comboBoxGeom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxGeoms = (ComboBox)sender;
            if (comboBoxGeoms != null)
            {
                string geom = comboBoxGeoms.SelectedItem.ToString();

                propertyGridGeoms.SelectedObject = PlotViewModel.GetGeom(geom);
            }
        }

        private void comboBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxThemes = (ComboBox)sender;
            if (comboBoxThemes != null)
            {
                string theme = comboBoxThemes.SelectedItem.ToString();

                PlotViewModel.SetTheme(theme);
            }
        }
    }
}
