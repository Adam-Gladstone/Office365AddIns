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

        public AestheticSettings() : base("") { }

        public override string GetSettings()
        {
            List<string> settingsList = new List<string>()
            {
                m_x.GetParamValue(),
                m_y.GetParamValue(),
                m_xmin.GetParamValue(),
                m_xmax.GetParamValue(),
                m_ymin.GetParamValue(),
                m_ymax.GetParamValue(),
                m_xend.GetParamValue(),
                m_yend.GetParamValue(),
            };

            settingsList.AddRange(BuildSettingsList());

            string content = GetSettings(settingsList);

            string aesData = string.Empty;
            if (!string.IsNullOrEmpty(content))
            {
                aesData = $"mapping = aes({content})";
            }

            return aesData;
        }

        public override string ToString()
        {
            string content = GetSettings(BuildSettingsList());
            return content;
        }

        [
        Category("Aesthetic"),
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
        Category("Aesthetic"),
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
        Category("Aesthetic"),
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
        Category("Aesthetic"),
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
        Category("Aesthetic"),
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
        Category("Aesthetic"),
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
        Category("Aesthetic"),
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
        Category("Aesthetic"),
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
