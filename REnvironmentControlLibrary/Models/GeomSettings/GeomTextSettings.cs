using REnvironmentControlLibrary.TypeConverters;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomTextSettings : GeomSettings
    {
        private Param<double> m_angle = new Param<double>("angle", false);
        private Param<string> m_hjust = new Param<string>("hjust", false);
        private Param<string> m_vjust = new Param<string>("vjust", false);
        private Param<string> m_check_overlap = new Param<string>("check_overlap", false);

        public GeomTextSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_angle.GetParamValue());
            settingsList.Add(m_hjust.GetParamValue());
            settingsList.Add(m_vjust.GetParamValue());
            settingsList.Add(m_check_overlap.GetParamValue());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = $"geom_text({content})";

            return geom;
        }

        [
        Category("Text"),
        ReadOnly(false),
        DisplayName("Angle"),
        Display(Order = 1),
        Description("Text angle.")
        ]
        public double Angle
        {
            get { return m_angle.Value; }
            set { m_angle.Value = value; }
        }

        [
        Category("Text"),
        ReadOnly(false),
        DisplayName("Horizontal alignment"),
        Display(Order = 2),
        Description("A number between 0 (right/bottom) and 1 (top/left) or a character ('left', 'middle', 'right', 'bottom', 'center', 'top').\nThere are two special alignments: 'inward' and 'outward'. Inward always aligns text towards the center, and outward aligns it away from the center.")
        ]
        public string HJust
        {
            get { return m_hjust.Value; }
            set { m_hjust.Value = value; }
        }

        [
        Category("Text"),
        ReadOnly(false),
        DisplayName("Vertical alignment"),
        Display(Order = 3),
        Description("A number between 0 (right/bottom) and 1 (top/left) or a character ('left', 'middle', 'right', 'bottom', 'center', 'top').\nThere are two special alignments: 'inward' and 'outward'. Inward always aligns text towards the center, and outward aligns it away from the center.")
        ]
        public string VJust
        {
            get { return m_vjust.Value; }
            set { m_vjust.Value = value; }
        }

        [
        Category("Text"),
        ReadOnly(false),
        DisplayName("Check overlap"),
        Display(Order = 4),
        Description("TRUE/FALSE."),
        TypeConverter(typeof(BoolConverter))
        ]
        public string CheckOverlap
        {
            get { return m_check_overlap.Value; }
            set { m_check_overlap.Value = value; }
        }
    }
}
