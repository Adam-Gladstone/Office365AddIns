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

        public GeomSmoothSettings(string name) : base(name) { }

        public override string GetSettings()
        {
            List<string> settingsList = new List<string>()
            {
                m_method.GetParamValue(),
                m_formula.GetParamValue(),
                m_se.GetParamValue(),
            };

            string content = GetSettings(settingsList);

            string geom = $"geom_smooth({content})";

            return geom;
        }

        [
        Category("geom_smooth"),
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
        Category("geom_smooth"),
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
        Category("geom_smooth"),
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
    }
}
