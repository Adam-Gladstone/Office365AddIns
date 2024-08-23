using System.Collections.Generic;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomSettings : BasicSettings
    {
        public GeomSettings(string name) : base(name) { }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = string.Empty;
            if (!string.IsNullOrEmpty(m_name))
            {
                geom = $"geom_{m_name}({content})";
            }

            return geom;
        }
    }
}
