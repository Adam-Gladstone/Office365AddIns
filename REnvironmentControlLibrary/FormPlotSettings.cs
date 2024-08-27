using REnvironmentControlLibrary.Models.GeomSettings;
using REnvironmentControlLibrary.ViewModel;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace REnvironmentControlLibrary
{
    public partial class FormPlotSettings : Form
    {
        public PlotViewModel PlotViewModel { get; set; } = new PlotViewModel();

        public FormPlotSettings()
        {
            InitializeComponent();

            // Data
            propertyGridData.SelectedObject = PlotViewModel.DataSettings;
            if (propertyGridData.PropertySort == PropertySort.CategorizedAlphabetical)
            {
                propertyGridData.PropertySort = PropertySort.Categorized;
            }

            // Geoms are handled separately

            // Labels
            propertyGridLabels.SelectedObject = PlotViewModel.LabelSettings;
            if (propertyGridLabels.PropertySort == PropertySort.CategorizedAlphabetical)
            {
                propertyGridLabels.PropertySort = PropertySort.Categorized;
            }

            // Scales and Coords and Themes are not bound to a property grid until comboBox changes
            if (propertyGridXScales.PropertySort == PropertySort.CategorizedAlphabetical)
            {
                propertyGridXScales.PropertySort = PropertySort.Categorized;
            }

            if (propertyGridYScales.PropertySort == PropertySort.CategorizedAlphabetical)
            {
                propertyGridYScales.PropertySort = PropertySort.Categorized;
            }

            if (propertyGridCoords.PropertySort == PropertySort.CategorizedAlphabetical)
            {
                propertyGridCoords.PropertySort = PropertySort.Categorized;
            }

            if (propertyGridThemes.PropertySort == PropertySort.CategorizedAlphabetical)
            {
                propertyGridThemes.PropertySort = PropertySort.Categorized;
            }

            // Facets
            propertyGridFacets.SelectedObject = PlotViewModel.FacetSettings;
            if (propertyGridFacets.PropertySort == PropertySort.CategorizedAlphabetical)
            {
                propertyGridFacets.PropertySort = PropertySort.Categorized;
            }

            UpdateData(false);

            OnUpdateUI();
        }

        void UpdateData(bool saveAndValidate)
        {
            if (saveAndValidate)
            {

            }
            else
            {
                ComboBox comboBoxGeoms = (ComboBox)tabPageLayers.Controls["comboBoxGeom"];
                comboBoxGeoms.Items.AddRange(PlotViewModel.GeomTypes.ToArray());
                comboBoxGeoms.SelectedIndex = 0;

                ComboBox comboBoxXScales = (ComboBox)tabPageScales.Controls["comboBoxXScales"];
                comboBoxXScales.Items.AddRange(PlotViewModel.XScales.ToArray());
                comboBoxXScales.SelectedIndex = 0;

                ComboBox comboBoxYScales = (ComboBox)tabPageScales.Controls["comboBoxYScales"];
                comboBoxYScales.Items.AddRange(PlotViewModel.YScales.ToArray());
                comboBoxYScales.SelectedIndex = 0;

                ComboBox comboBoxCoords = (ComboBox)tabPageCoords.Controls["comboBoxCoords"];
                comboBoxCoords.Items.AddRange(PlotViewModel.Coords.ToArray());
                comboBoxCoords.SelectedIndex = 0;

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
            buttonUp.Enabled = false;
            buttonDown.Enabled = false;

            buttonOk.Enabled = true;
        }

        private void comboBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxThemes = (ComboBox)sender;
            if (comboBoxThemes != null)
            {
                string theme = comboBoxThemes.SelectedItem.ToString();

                if(!string.IsNullOrEmpty(theme))
                {
                    PlotViewModel.SetTheme(theme);
                    propertyGridThemes.SelectedObject = PlotViewModel.ThemeSettings;
                }
                else
                {
                    propertyGridThemes.SelectedObject = null;
                }
            }
        }

        private void comboBoxXScales_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxXScales = (ComboBox)sender;
            if (comboBoxXScales != null)
            {
                string scale = comboBoxXScales.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(scale))
                {
                    PlotViewModel.SetXScale(scale);

                    propertyGridXScales.SelectedObject = PlotViewModel.XScaleSettings;
                }
                else
                {
                    propertyGridXScales.SelectedObject = null;
                }
            }
        }

        private void comboBoxYScales_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxYScales = (ComboBox)sender;
            if (comboBoxYScales != null)
            {
                string scale = comboBoxYScales.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(scale))
                {
                    PlotViewModel.SetYScale(scale);

                    propertyGridYScales.SelectedObject = PlotViewModel.YScaleSettings;
                }
                else
                {
                    propertyGridYScales.SelectedObject = null;
                }
            }
        }

        private void comboBoxCoords_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxCoords = (ComboBox)sender;
            if (comboBoxCoords != null)
            {
                string coords = comboBoxCoords.SelectedItem.ToString();

                if(!string.IsNullOrEmpty(coords))
                {
                    PlotViewModel.SetCoords(coords);

                    propertyGridCoords.SelectedObject = PlotViewModel.CoordSettings;
                }
                else
                {
                    propertyGridCoords.SelectedObject = null;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ComboBox comboBoxGeoms = (ComboBox)tabPageLayers.Controls["comboBoxGeom"];
            string geom = comboBoxGeoms.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(geom))
            {
                Tuple<string, GeomSettings> item = PlotViewModel.AddGeom(geom);

                string _geom = item.Item1;
                GeomSettings geomSettings = item.Item2;

                string content = geomSettings.GetSettings();

                ListViewItem lvi = listViewGeoms.Items.Add(geom);
                lvi.SubItems.Add(content);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewGeoms.SelectedItems != null && listViewGeoms.SelectedItems.Count > 0) 
            {
                ListViewItem lvi = listViewGeoms.SelectedItems[0];

                int index = lvi.Index;

                PlotViewModel.DeleteGeom(index);
                
                listViewGeoms.Items.Remove(lvi);
            }
        }

        private void listViewGeoms_DoubleClick(object sender, EventArgs e)
        {
            if (listViewGeoms.SelectedItems != null && listViewGeoms.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listViewGeoms.SelectedItems[0];

                int index = lvi.Index;
                string geom = lvi.Text;
                Debug.WriteLine($"Selected geom [{index}]:\t{geom}.");

                FormGeomSettings formGeomSettings = new FormGeomSettings();
                Tuple<string, GeomSettings> item = PlotViewModel.GetGeom(index, geom);

                string _geom = item.Item1;
                GeomSettings geomSettings = item.Item2;

                formGeomSettings.SetPropertyGrid(geomSettings);

                DialogResult res = formGeomSettings.ShowDialog();
                if (res == DialogResult.OK) 
                {
                    string content = geomSettings.GetSettings();

                    lvi.SubItems[1].Text = content;
                }
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            // not implemented
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            // not implemented
        }

        private void listViewGeoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGeoms.SelectedItems != null && listViewGeoms.SelectedItems.Count > 0)
            {
                OnUpdateUI();
            }
        }
    }
}
