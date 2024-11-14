using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace REnvironmentControlLibrary.Models
{
    internal class DataSettingsConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is DataSettings)
            {
                DataSettings component = (DataSettings)value;
                return component.ToString();
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    [
    Serializable,
    TypeConverter(typeof(DataSettingsConverter))
    ]
    public class DataSettings : Settings
    {
        private Param<string> m_data = new Param<string>("data");

        private AestheticSettings m_aesthetic = new AestheticSettings();

        public DataSettings() { }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>
            {
                m_data.GetParamValue(),
                m_aesthetic.GetSettings()
            };

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string plotData = $"ggplot({content})";

            return plotData;
        }

        public override string ToString()
        {
            string content = GetSettings(BuildSettingsList());
            return content;
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
