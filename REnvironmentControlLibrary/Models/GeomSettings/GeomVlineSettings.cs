using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomVlineSettings : GeomLineSettings
    {
        private Param<string> m_xintercept = new Param<string>("xintercept", false);

        public GeomVlineSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_xintercept.GetParamValue());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = $"geom_vline({content})";

            return geom;
        }

        [
        Category("geom_vline"),
        ReadOnly(false),
        DisplayName("X Intercept"),
        Display(Order = 12),
        Description("A numeric value.")
        ]
        public string XIntercept
        {
            get { return m_xintercept.Value; }
            set { m_xintercept.Value = value; }
        }
    }
}
