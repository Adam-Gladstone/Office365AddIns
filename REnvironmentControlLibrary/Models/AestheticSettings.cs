using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace REnvironmentControlLibrary.Models
{
    [
    Serializable,
    TypeConverter(typeof(AestheticConverter))
    ]
    public class AestheticSettings : BasicSettings
    {
        private Param<string> m_x = new Param<string>("x");
        private Param<string> m_y = new Param<string>("y", false);
        private Param<string> m_xmin = new Param<string>("xmin", false);
        private Param<string> m_xmax = new Param<string>("xmax", false);
        private Param<string> m_ymin = new Param<string>("ymin", false);
        private Param<string> m_ymax = new Param<string>("ymax", false);
        private Param<string> m_xend = new Param<string>("xend", false);
        private Param<string> m_yend = new Param<string>("yend", false);
        private Param<string> m_xintercept = new Param<string>("xintercept", false);
        private Param<string> m_yintercept = new Param<string>("yintercept", false);
        private Param<string> m_xmin_final = new Param<string>("xmin_final", false);
        private Param<string> m_ymin_final = new Param<string>("ymin_final", false);
        private Param<string> m_xmax_final = new Param<string>("xmax_final", false);
        private Param<string> m_ymax_final = new Param<string>("ymax_final", false);
        private Param<string> m_xlower = new Param<string>("xlower", false);
        private Param<string> m_lower = new Param<string>("lower", false);
        private Param<string> m_xmiddle = new Param<string>("xmiddle", false);
        private Param<string> m_middle = new Param<string>("middle", false);
        private Param<string> m_xupper = new Param<string>("xupper", false);
        private Param<string> m_upper = new Param<string>("upper", false);
        private Param<string> m_x0 = new Param<string>("x0", false);
        private Param<string> m_y0 = new Param<string>("y0", false);
        private Param<string> m_label = new Param<string>("label", false);
        private Param<string> m_family = new Param<string>("family", false);
        private Param<string> m_fontface = new Param<string>("fontface", false);


        public AestheticSettings() { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>
            {
                m_x.GetParamValue(),
                m_y.GetParamValue(),
                m_xmin.GetParamValue(),
                m_xmax.GetParamValue(),
                m_ymin.GetParamValue(),
                m_ymax.GetParamValue(),
                m_xend.GetParamValue(),
                m_yend.GetParamValue(),
                m_xintercept.GetParamValue(),
                m_yintercept.GetParamValue(),
                m_xmin_final.GetParamValue(),
                m_xmax_final.GetParamValue(),
                m_ymin_final.GetParamValue(),
                m_ymax_final.GetParamValue(),
                m_xlower.GetParamValue(),
                m_lower.GetParamValue(),
                m_xmiddle.GetParamValue(),
                m_middle.GetParamValue(),
                m_xupper.GetParamValue(),
                m_upper.GetParamValue(),
                m_x0.GetParamValue(),
                m_y0.GetParamValue(),
                m_label.GetParamValue(),
                m_family.GetParamValue(),
                m_fontface.GetParamValue()
            };

            settingsList.AddRange(base.BuildSettingsList());

            return settingsList;
        }

        public override string GetSettings()
        {
            string content = GetSettings(BuildSettingsList());

            string aesData = string.Empty;
            if (!string.IsNullOrEmpty(content))
            {
                aesData = $"aes({content})";
            }

            return aesData;
        }

        public override string ToString()
        {
            string content = GetSettings(BuildSettingsList());
            return content;
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Data"),
        Display(Order = 0),
        Description("The x data.")
        ]
        public string X
        {
            get { return m_x.Value; }
            set { m_x.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Y Data"),
        Display(Order = 1),
        Description("The y data.")
        ]
        public string Y
        {
            get { return m_y.Value; }
            set { m_y.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Minimim"),
        Display(Order = 2),
        Description("Used to specify the position of annotations and to represent rectangular areas.")
        ]
        public string Xmin
        {
            get { return m_xmin.Value; }
            set { m_xmin.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Maximum"),
        Display(Order = 3),
        Description("Used to specify the position of annotations and to represent rectangular areas.")
        ]
        public string Xmax
        {
            get { return m_xmax.Value; }
            set { m_xmax.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Y Minimim"),
        Display(Order = 4),
        Description("Used to specify the position of annotations and to represent rectangular areas.")
        ]
        public string Ymin
        {
            get { return m_ymin.Value; }
            set { m_ymin.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Y Maximum"),
        Display(Order = 5),
        Description("Used to specify the position of annotations and to represent rectangular areas.")
        ]
        public string Ymax
        {
            get { return m_ymax.Value; }
            set { m_ymax.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X End"),
        Display(Order = 6),
        Description("Used to specify the position of annotations and to represent rectangular areas.")
        ]
        public string Xend
        {
            get { return m_xend.Value; }
            set { m_xend.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Y End"),
        Display(Order = 7),
        Description("Used to specify the position of annotations and to represent rectangular areas.")
        ]
        public string Yend
        {
            get { return m_yend.Value; }
            set { m_yend.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Intercept"),
        Display(Order = 8),
        Description("X Intercept")
        ]
        public string XIntercept
        {
            get { return m_xintercept.Value; }
            set { m_xintercept.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Y Intercept"),
        Display(Order = 9),
        Description("Y Intercept")
        ]
        public string YIntercept
        {
	        get { return m_yintercept.Value; }
            set { m_yintercept.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Min Final"),
        Display(Order = 10),
        Description("X Min Final")
        ]
        public string XMinFinal
        {
            get { return m_xmin_final.Value; }
            set { m_xmin_final.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Y Min Final"),
        Display(Order = 11),
        Description("Y Min Final")
        ]
        public string YMinFinal
        {
            get { return m_ymin_final.Value; }
            set { m_ymin_final.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Max Final"),
        Display(Order = 12),
        Description("X Max Final")
        ]
        public string XMaxFinal
        {
            get { return m_xmax_final.Value; }
            set { m_xmax_final.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Y Max Final"),
        Display(Order = 13),
        Description("Y Max Final")
        ]
        public string YMaxFinal
        {
            get { return m_ymax_final.Value; }
            set { m_ymax_final.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Lower"),
        Display(Order = 14),
        Description("X Lower")
        ]
        public string XLower
        {
            get { return m_xlower.Value; }
            set { m_xlower.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Lower"),
        Display(Order = 15),
        Description("Lower")
        ]
        public string Lower
        {
            get { return m_lower.Value; }
            set { m_lower.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Middle"),
        Display(Order = 16),
        Description("X Middle")
        ]
        public string XMiddle
        {
            get { return m_xmiddle.Value; }
            set { m_xmiddle.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Middle"),
        Display(Order = 17),
        Description("Middle")
        ]
        public string Middle
        {
            get { return m_middle.Value; }
            set { m_middle.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X Upper"),
        Display(Order = 18),
        Description("X Upper")
        ]
        public string XUpper
        {
            get { return m_xupper.Value; }
            set { m_xupper.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Upper"),
        Display(Order = 19),
        Description("Upper")
        ]
        public string Upper
        {
            get { return m_upper.Value; }
            set { m_upper.Value = value; }
        }

        [
        Category("X Aesthetics"),
        ReadOnly(false),
        DisplayName("X0"),
        Display(Order = 20),
        Description("x0")
        ]
        public string X0
        {
            get { return m_x0.Value; }
            set { m_x0.Value = value; }
        }

        [
        Category("Y Aesthetics"),
        ReadOnly(false),
        DisplayName("Y0"),
        Display(Order = 21),
        Description("y0")
        ]
        public string Y0
        {
            get { return m_y0.Value; }
            set { m_y0.Value = value; }
        }

        [
        Category("Aesthetics"),
        ReadOnly(false),
        DisplayName("Label"),
        Display(Order = 22),
        Description("Text label.")
        ]
        public string Label
        {
            get { return m_label.Value; }
            set { m_label.Value = value; }
        }

        [
        Category("Aesthetics"),
        ReadOnly(false),
        DisplayName("Font family"),
        Display(Order = 23),
        Description("One of: 'sans', 'serif', 'mono'.")
        ]
        public string Family
        {
            get { return m_family.Value; }
            set { m_family.Value = value; }
        }

        [
        Category("Aesthetics"),
        ReadOnly(false),
        DisplayName("Font face"),
        Display(Order = 24),
        Description("One of: 'plain', 'bold', 'italic', 'bold.italic'.")
        ]
        public string Face
        {
            get { return m_fontface.Value; }
            set { m_fontface.Value = value; }
        }

    }
    internal class AestheticConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is AestheticSettings)
            {
                AestheticSettings component = (AestheticSettings)value;
                return component.ToString();
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
