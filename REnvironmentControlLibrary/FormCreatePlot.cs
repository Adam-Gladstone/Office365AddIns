using REnvironmentControlLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REnvironmentControlLibrary
{
    public partial class FormCreatePlot : Form
    {
        public Plot Plot { get; set; }

        public FormCreatePlot()
        {
            Plot = new Plot();

            InitializeComponent();
            
            UpdateData(false);
        }

        void UpdateData(bool saveAndValidate)
        {
            if (saveAndValidate)
            {
                Plot.DataFrame = textBoxDataFrame.Text;

                // Aesthetic
                Plot.XData = textBoxXData.Text;
                Plot.YData = textBoxYData.Text;
                Plot.Colour = textBoxColour.Text;
                Plot.Fill = textBoxFill.Text;
                Plot.Group = textBoxGroup.Text;
                Plot.Shape = textBoxShape.Text;
                Plot.Size = textBoxSize.Text;

                Plot.ChartType = comboBoxChartTypes.SelectedItem.ToString();
                Plot.Theme = comboBoxThemes.SelectedItem.ToString();

                // Labels
                Plot.Title = textBoxTitle.Text;
                Plot.Subtitle = textBoxSubtitle.Text;
                Plot.Xlabel = textBoxXLabel.Text;
                Plot.Ylabel = textBoxYLabel.Text;
                Plot.Caption = textBoxCaption.Text;
            }
            else
            {
                comboBoxChartTypes.Items.AddRange(Plot.ChartTypes.ToArray());
                comboBoxThemes.Items.AddRange(Plot.Themes.ToArray());

                comboBoxChartTypes.SelectedIndex = 0;
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

        private void textBoxDataFrame_TextChanged(object sender, EventArgs e)
        {
            OnUpdateUI();
        }

        private void textBoxXData_TextChanged(object sender, EventArgs e)
        {
            OnUpdateUI();
        }

        private void textBoxYData_TextChanged(object sender, EventArgs e)
        {
        }
        private void comboBoxChartTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnUpdateUI();
        }

        void OnUpdateUI()
        {
            buttonOk.Enabled = 
                (textBoxDataFrame.Text.Length > 0 && 
                textBoxXData.Text.Length > 0 && !string.IsNullOrEmpty(comboBoxChartTypes.SelectedItem.ToString())) 
                ? true : false;
        }

    }
}
