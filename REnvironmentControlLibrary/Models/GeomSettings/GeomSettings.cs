using System.Collections.Generic;
using static REnvironmentControlLibrary.Models.BasicSettings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomSettings : Settings
    {
        private BasicSettings m_basicSettings = new BasicSettings();

        protected string m_name;

        public GeomSettings(string name)
        {
            m_name = name;
        }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>() 
            { 
                m_basicSettings.GetSettings() 
            };

            return settingsList;
        }

        public override string GetSettings()
        {
            string content = GetSettings(BuildSettingsList());

            string geom = string.Empty;
            if (!string.IsNullOrEmpty(m_name))
            {
                geom = $"geom_{m_name}({content})";
            }

            return geom;
        }

        [
        Category("Geoms"),
        ReadOnly(false),
        Description("Basic Settings"),
        DisplayName("Basic Settings"),
        Display(Order = 1),
        TypeConverter(typeof(BasicSettingsConverter))]
        public BasicSettings BasicSettings
        {
            get { return m_basicSettings; }
            set { m_basicSettings = value; }
        }
    }
}
