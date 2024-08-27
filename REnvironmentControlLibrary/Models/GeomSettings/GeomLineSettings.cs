using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomLineSettings : GeomSettings
    {
        private AestheticSettings m_aesthetic = new AestheticSettings();

        public GeomLineSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_aesthetic.GetSettings());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = $"geom_line({content})";

            return geom;
        }

        [
        Category("Line"),
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
