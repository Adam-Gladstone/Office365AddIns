using REnvironmentControlLibrary.TypeConverters;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomBoxplotSettings : GeomSettings
    {
        private Param<string> m_notch = new Param<string>("notch", false);
        private Param<string> m_varwidth = new Param<string>("varwidth", false);
        private Param<string> m_outliers = new Param<string>("outliers", false);

        public GeomBoxplotSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_notch.GetParamValue());
            settingsList.Add(m_varwidth.GetParamValue());
            settingsList.Add(m_outliers.GetParamValue());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = $"geom_boxplot({content})";

            return geom;
        }

        [
        Category("Boxplot"),
        ReadOnly(false),
        DisplayName("Notch"),
        Display(Order = 0),
        Description("If FALSE (default) make a standard box plot. If TRUE, make a notched box plot."),
        DefaultValue("FALSE"),
        TypeConverter(typeof(BoolConverter)),
        ]
        public string Notch
        {
            get { return m_notch.Value; }
            set { m_notch.Value = value; }
        }

        [
        Category("Boxplot"),
        ReadOnly(false),
        DisplayName("Varwidth"),
        Display(Order = 1),
        Description("If FALSE (default) make a standard box plot. If TRUE, boxes are drawn with widths proportional to the square-roots of the number of observations in the groups (possibly weighted, using the weight aesthetic)."),
        DefaultValue("FALSE"),
        TypeConverter(typeof(BoolConverter)),
        ]
        public string Varwidth
        {
            get { return m_varwidth.Value; }
            set { m_varwidth.Value = value; }
        }

        [
        Category("Boxplot"),
        ReadOnly(false),
        DisplayName("Outliers"),
        Display(Order = 2),
        Description("Whether to display (TRUE) or discard (FALSE) outliers from the plot."),
        DefaultValue("TRUE"),
        TypeConverter(typeof(BoolConverter)),
        ]
        public string Outliers
        {
            get { return m_outliers.Value; }
            set { m_outliers.Value = value; }
        }
    }
}
