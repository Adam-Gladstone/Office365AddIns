using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomLineSettings : GeomSettings
    {
        private Param<string> m_linetype = new Param<string>("linetype", false);
        private Param<double> m_linewidth = new Param<double>("linewidth", false);
        private Param<string> m_lineend = new Param<string>("lineend", false);
        private Param<string> m_linejoin = new Param<string>("linejoin", false);
        private Param<double> m_linemitre = new Param<double>("linemitre", false);

        private AestheticSettings m_aesthetic = new AestheticSettings();

        public GeomLineSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_linetype.GetParamValue());
            settingsList.Add(m_linewidth.GetParamValue());
            settingsList.Add(m_lineend.GetParamValue());
            settingsList.Add(m_linejoin.GetParamValue());
            settingsList.Add(m_linemitre.GetParamValue());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string aes = m_aesthetic.GetSettings();
            if (!string.IsNullOrEmpty(aes))
            {
                if (!string.IsNullOrEmpty(content))
                    content += ", ";

                content += aes;
            }

            string geom = $"geom_line({content})";

            return geom;
        }

        [
        Category("geom_line"),
        ReadOnly(false),
        DisplayName("Line Type"),
        Display(Order = 6),
        Description("The linetype aesthetic can be specified with either an integer (0-6) or a name (0 = blank, 1 = solid, 2 = dashed, 3 = dotted, 4 = dotdash, 5 = longdash, 6 = twodash).")
        ]
        public string Linetype
        {
            get { return m_linetype.Value; }
            set { m_linetype.Value = value; }
        }

        [
        Category("geom_line"),
        ReadOnly(false),
        DisplayName("Line Width"),
        Display(Order = 7),
        Description("A numeric value.")
        ]
        public double Linewidth
        {
            get { return m_linewidth.Value; }
            set { m_linewidth.Value = value; }
        }

        [
        Category("geom_line"),
        ReadOnly(false),
        DisplayName("Line End"),
        Display(Order = 8),
        Description("Line end style (round, butt, square).")
        ]
        public string Lineend
        {
            get { return m_lineend.Value; }
            set { m_lineend.Value = value; }
        }

        [
        Category("geom_line"),
        ReadOnly(false),
        DisplayName("Line Join"),
        Display(Order = 9),
        Description("Line join style (round, mitre, bevel).")
        ]
        public string Linejoin
        {
            get { return m_linejoin.Value; }
            set { m_linejoin.Value = value; }
        }

        [
        Category("geom_line"),
        ReadOnly(false),
        DisplayName("Line Mitre"),
        Display(Order = 10),
        Description("A numeric value greater than 1.")
        ]
        public double Linemitre
        {
            get { return m_linemitre.Value; }
            set { m_linemitre.Value = value; }
        }

        [
        Category("geom_line"),
        ReadOnly(false),
        Description("Aesthetic Settings"),
        DisplayName("Aesthetic Settings"),
        Display(Order = 11),
        TypeConverter(typeof(AestheticConverter))]
        public AestheticSettings AestheticSettings
        {
            get { return m_aesthetic; }
            set { m_aesthetic = value; }
        }
    }
}
