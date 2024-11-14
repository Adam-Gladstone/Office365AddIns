using System.Collections.Generic;
using static REnvironmentControlLibrary.Models.BasicSettings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomSettings : Settings
    {
        private BasicSettings m_basicSettings = new BasicSettings();

        private AestheticSettings m_aesthetic = new AestheticSettings();


        protected string m_name;

        public GeomSettings(string name)
        {
            m_name = name;
        }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>() 
            {
                m_aesthetic.GetSettings(),
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

        [
        Category("Geoms"),
        ReadOnly(false),
        Description("Aesthetic Settings"),
        DisplayName("Aesthetic Settings"),
        Display(Order = 2),
        TypeConverter(typeof(AestheticConverter))]
        public AestheticSettings AestheticSettings
        {
            get { return m_aesthetic; }
            set { m_aesthetic = value; }
        }
    }
}
