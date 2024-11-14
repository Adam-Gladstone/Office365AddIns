using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace REnvironmentControlLibrary.Models
{
    [
    Serializable,
    TypeConverter(typeof(BasicSettingsConverter))
    ]
    public class BasicSettings : Settings
    {
        private Param<double> m_alpha = new Param<double>("alpha", false);
        private Param<string> m_colour = new Param<string>("colour", false);
        private Param<string> m_fill = new Param<string>("fill", false);
        private Param<string> m_group = new Param<string>("group", false);
        private Param<string> m_shape = new Param<string>("shape", false);
        private Param<string> m_size = new Param<string>("size", false);
        private Param<string> m_stroke = new Param<string>("stroke", false);
        private Param<string> m_stat = new Param<string>("stat", false);
        private Param<string> m_linetype = new Param<string>("linetype", false);
        private Param<double> m_linewidth = new Param<double>("linewidth", false);
        private Param<string> m_lineend = new Param<string>("lineend", false);
        private Param<string> m_linejoin = new Param<string>("linejoin", false);
        private Param<double> m_linemitre = new Param<double>("linemitre", false);
        private Param<string> m_font_family = new Param<string>("fontfamily", false);
        private Param<string> m_font_face = new Param<string>("fontface", false);
        private Param<double> m_font_size = new Param<double>("fontsize", false);
        private Param<string> m_justification = new Param<string>("justification", false);

        public BasicSettings() { }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>()
            {
                m_alpha.GetParamValue(),
                m_colour.GetParamValue(),
                m_fill.GetParamValue(),
                m_group.GetParamValue(),
                m_shape.GetParamValue(),
                m_size.GetParamValue(),
                m_stroke.GetParamValue(),
                m_stat.GetParamValue(),
                m_linetype.GetParamValue(),
                m_linewidth.GetParamValue(),
                m_lineend.GetParamValue(),
                m_linejoin.GetParamValue(),
                m_linemitre.GetParamValue(),
                m_font_family.GetParamValue(),
                m_font_face.GetParamValue(),
                m_font_size.GetParamValue(),
                m_justification.GetParamValue(),
            };

            return settingsList;
        }

        public override string GetSettings()
        {
            string content = GetSettings(BuildSettingsList());
            return content;
        }

        public override string ToString()
        {
            string content = GetSettings(BuildSettingsList());
            return content;
        }

        [
        Category("Basic Settings"),
        ReadOnly(false),
        DisplayName("Alpha"),
        Display(Order = 0),
        Description("Alpha refers to the opacity of a geom. Values of alpha range from 0 to 1, with lower values corresponding to more transparent colors.")
        ]
        public double Alpha
        {
            get { return m_alpha.Value; }
            set { m_alpha.Value = value; }
        }

        [
        Category("Basic Settings"),
        ReadOnly(false),
        DisplayName("Colour"),
        Display(Order = 1),
        Description("The border colour: a named colour or an RGB string #RRGGBB.")
        ]
        public string Colour
        {
            get { return m_colour.Value; }
            set { m_colour.Value = value; }
        }

        [
        Category("Basic Settings"),
        ReadOnly(false),
        DisplayName("Fill"),
        Display(Order = 2),
        Description("The interior fill colour: a named colour or an RGB string #RRGGBB.")
        ]
        public string Fill
        {
            get { return m_fill.Value; }
            set { m_fill.Value = value; }
        }

        [
        Category("Basic Settings"),
        ReadOnly(false),
        DisplayName("Group"),
        Display(Order = 3),
        Description("A group.")
        ]
        public string Group
        {
            get { return m_group.Value; }
            set { m_group.Value = value; }
        }

        [
        Category("Basic Settings"),
        ReadOnly(false),
        DisplayName("Shape"),
        Display(Order = 4),
        Description("A shape. An integer (between 0 and 25), a single character used as the plotting symbol, or a '.' to draw the smallest rectangle that is visible (i.e., about one pixel).")
        ]
        public string Shape
        {
            get { return m_shape.Value; }
            set { m_shape.Value = value; }
        }

        [
        Category("Basic Settings"),
        ReadOnly(false),
        DisplayName("Size"),
        Display(Order = 5),
        Description("A size. A numerical value (in millimetres) or a mapping to a continuous variable.")
        ]
        public string Size
        {
            get { return m_size.Value; }
            set { m_size.Value = value; }
        }

        [
        Category("Basic Settings"),
        ReadOnly(false),
        DisplayName("Stroke"),
        Display(Order = 6),
        Description("A number.")
        ]
        public string Stroke
        {
            get { return m_stroke.Value; }
            set { m_stroke.Value = value; }
        }

        [
        Category("Basic Settings"),
        ReadOnly(false),
        DisplayName("Stat"),
        Display(Order = 7),
        Description("The statistical transformation to use on the data for this layer. (e.g. stat = 'identity', stat = 'bin'")
        ]
        public string Stat
        {
            get { return m_stat.Value; }
            set { m_stat.Value = value; }
        }

        [
        Category("Basic Settings"),
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
        Category("Basic Settings"),
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
        Category("Basic Settings"),
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
        Category("Basic Settings"),
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
        Category("Basic Settings"),
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
        Category("Font Settings"),
        ReadOnly(false),
        DisplayName("Font family"),
        Display(Order = 11),
        Description("One of: 'sans', 'serif', 'mono'.")
        ]
        public string FontFamily
        {
            get { return m_font_family.Value; }
            set { m_font_family.Value = value; }
        }

        [
        Category("Font Settings"),
        ReadOnly(false),
        DisplayName("Font face"),
        Display(Order = 12),
        Description("One of: 'plain', 'bold', 'italic', 'bold.italic'.")
        ]
        public string FontFace
        {
            get { return m_font_face.Value; }
            set { m_font_face.Value = value; }
        }

        [
        Category("Font Settings"),
        ReadOnly(false),
        DisplayName("Font size"),
        Display(Order = 13),
        Description("A number of points.")
        ]
        public double FontSize
        {
            get { return m_font_size.Value; }
            set { m_font_size.Value = value; }
        }

        [
        Category("Font Settings"),
        ReadOnly(false),
        DisplayName("Justification"),
        Display(Order = 14),
        Description("Horizontal and vertical justification have the same parameterisation, either a string ('top', 'middle', 'bottom', 'left', 'center', 'right') or a number between 0 and 1.")
        ]
        public string Justification
        {
            get { return m_justification.Value; }
            set { m_justification.Value = value; }
        }

        internal class BasicSettingsConverter : ExpandableObjectConverter
        {
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
            {
                if (destType == typeof(string) && value is BasicSettings)
                {
                    BasicSettings component = (BasicSettings)value;
                    return component.ToString();
                }
                return base.ConvertTo(context, culture, value, destType);
            }
        }
    }
}
