using REnvironmentControlLibrary.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace REnvironmentControlLibrary.Models
{
    internal class CoordSettingsConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(string) && value is CoordSettings)
            {
                CoordSettings component = (CoordSettings)value;
                return component.ToString();
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }

    [
    Serializable,
    TypeConverter(typeof(CoordSettingsConverter))
    ]

    public class CoordSettings : Settings
    {
        private Param<string> m_xlim = new Param<string>("xlim");
        private Param<string> m_ylim = new Param<string>("ylim");
        private Param<string> m_expand = new Param<string>("expand");

        private string m_name;
        public CoordSettings(string name)
        {
            m_name = name;
        }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>()
            {
                m_xlim.GetParamValue(),
                m_ylim.GetParamValue(),
                m_expand.GetParamValue(),
            };

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string coord = string.Empty;
            if (!string.IsNullOrEmpty(m_name))
            {
                coord = $"coord_{m_name}({content})";
            }

            return coord;
        }

        public override string ToString()
        {
            string content = GetSettings(BuildSettingsList());
            return content;
        }

        [
        Category("Coords"),
        ReadOnly(false),
        Description("Limits for the x axis (e.g: c(0, 1))."),
        DisplayName("X lim"),
        Display(Order = 0)
        ]
        public string Xlim
        {
            get { return m_xlim.Value; }
            set { m_xlim.Value = value; }
        }

        [
        Category("Coords"),
        ReadOnly(false),
        Description("Limits for the y axis (e.g: c(0, 1))."),
        DisplayName("Y lim"),
        Display(Order = 1)
        ]
        public string Ylim
        {
            get { return m_ylim.Value; }
            set { m_ylim.Value = value; }
        }

        [
        Category("Coords"),
        ReadOnly(false),
        Description("If TRUE, the default, adds a small expansion factor to the limits to ensure that data and axes don't overlap. If FALSE, limits are taken exactly from the data or xlim/ylim."),
        DisplayName("Expand"),
        Display(Order = 2),
        TypeConverter(typeof(BoolConverter)),
        DefaultValue("TRUE")
        ]
        public string Expand
        {
            get { return m_expand.Value; }
            set { m_expand.Value = value; }
        }
    }
}
