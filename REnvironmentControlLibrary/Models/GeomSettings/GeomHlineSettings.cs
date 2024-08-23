using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomHlineSettings : GeomLineSettings
    {
        private Param<string> m_yintercept = new Param<string>("yintercept", false);

        public GeomHlineSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_yintercept.GetParamValue());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = $"geom_hline({content})";

            return geom;
        }

        [
        Category("geom_hline"),
        ReadOnly(false),
        DisplayName("Y Intercept"),
        Display(Order = 12),
        Description("A numeric value.")
        ]
        public string YIntercept
        {
            get { return m_yintercept.Value; }
            set { m_yintercept.Value = value; }
        }
    }
}
