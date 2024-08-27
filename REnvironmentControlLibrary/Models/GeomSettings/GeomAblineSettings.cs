using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomAblineSettings : GeomSettings
    {
        private Param<double> m_intercept = new Param<double>("intercept", false);
        private Param<double> m_slope = new Param<double>("slope", false);

        private AestheticSettings m_aesthetic = new AestheticSettings();

        public GeomAblineSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_intercept.GetParamValue());
            settingsList.Add(m_slope.GetParamValue());

            settingsList.Add(m_aesthetic.GetSettings());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = $"geom_abline({content})";

            return geom;
        }

        [
        Category("ABline"),
        ReadOnly(false),
        DisplayName("Intercept"),
        Display(Order = 12),
        Description("A numeric value.")
        ]
        public double Intercept
        {
            get { return m_intercept.Value; }
            set { m_intercept.Value = value; }
        }

        [
        Category("ABline"),
        ReadOnly(false),
        DisplayName("Slope"),
        Display(Order = 13),
        Description("A numeric value.")
        ]
        public double Slope
        {
            get { return m_slope.Value; }
            set { m_slope.Value = value; }
        }

        [
        Category("ABline"),
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
