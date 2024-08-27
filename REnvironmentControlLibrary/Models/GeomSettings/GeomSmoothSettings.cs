using REnvironmentControlLibrary.TypeConverters;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomSmoothSettings : GeomSettings
    {
        private Param<string> m_method = new Param<string>("method", false);
        private Param<string> m_formula = new Param<string>("formula", false);
        private Param<string> m_se = new Param<string>("se", false);

        private AestheticSettings m_aesthetic = new AestheticSettings();

        public GeomSmoothSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_method.GetParamValue());
            settingsList.Add(m_formula.GetParamValue());
            settingsList.Add(m_se.GetParamValue());

            settingsList.Add(m_aesthetic.GetSettings());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = $"geom_smooth({content})";

            return geom;
        }

        [
        Category("Smoother"),
        ReadOnly(false),
        DisplayName("Method"),
        Display(Order = 0),
        Description("Smoothing function to use. Either NULL or a character vector, e.g. 'lm', 'glm', 'gam', 'loess'...")
        ]
        public string Method
        {
            get { return m_method.Value; }
            set { m_method.Value = value; }
        }

        [
        Category("Smoother"),
        ReadOnly(false),
        DisplayName("Formula"),
        Display(Order = 1),
        Description("Formula to use in smoothing function, eg. y ~ x, y ~ poly(x, 2), y ~ log(x). NULL by default.")
        ]
        public string Formula
        {
            get { return m_formula.Value; }
            set { m_formula.Value = value; }
        }

        [
        Category("Smoother"),
        ReadOnly(false),
        DisplayName("Confidence Interval"),
        Display(Order = 2),
        Description("Display confidence interval around smooth. TRUE by default."),
        DefaultValue("TRUE"),
        TypeConverter(typeof(BoolConverter)),
        ]
        public string Se
        {
            get { return m_se.Value; }
            set { m_se.Value = value; }
        }

        [
        Category("Smoother"),
        ReadOnly(false),
        Description("Aesthetic Settings"),
        DisplayName("Aesthetic Settings"),
        Display(Order = 6),
        TypeConverter(typeof(AestheticConverter))]
        public AestheticSettings AestheticSettings
        {
            get { return m_aesthetic; }
            set { m_aesthetic = value; }
        }
    }
}
