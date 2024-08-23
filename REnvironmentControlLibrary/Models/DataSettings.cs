using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models
{
    public class DataSettings : Settings
    {
        private Param<string> m_data = new Param<string>("data");

        private AestheticSettings m_aesthetic = new AestheticSettings();

        public DataSettings() { }

        public override string GetSettings()
        {
            string aes = m_aesthetic.GetSettings();

            string plotData = string.Empty;

            if (!string.IsNullOrEmpty(aes))
            {
                plotData = $"ggplot({m_data.GetParamValue()}, {aes})";
            }
            else
            {
                plotData = $"ggplot({m_data.GetParamValue()})";
            }

            return plotData;
        }

        [
        Category("Data"),
        ReadOnly(false),
        Description("The name of the DataFrame."),
        DisplayName("Data Frame"),
        Display(Order = 0)
        ]
        public string DataFrame
        {
            get { return m_data.Value; }
            set { m_data.Value = value; }
        }

        [
        Category("Data"),
        ReadOnly(false),
        Description("Aesthetic Settings"),
        DisplayName("Aesthetic Settings"),
        Display(Order = 1),
        TypeConverter(typeof(AestheticConverter))]
        public AestheticSettings AestheticSettings
        {
            get { return m_aesthetic; }
            set { m_aesthetic = value; }
        }

    }
}
