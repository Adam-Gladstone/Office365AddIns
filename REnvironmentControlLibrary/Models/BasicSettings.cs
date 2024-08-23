using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models
{
    public class BasicSettings : Settings
    {
        protected Param<double> m_alpha = new Param<double>("alpha", false);
        protected Param<string> m_colour = new Param<string>("colour", false);
        protected Param<string> m_fill = new Param<string>("fill", false);
        protected Param<string> m_group = new Param<string>("group", false);
        protected Param<string> m_shape = new Param<string>("shape", false);
        protected Param<double> m_size = new Param<double>("size", false);
        protected Param<double> m_stroke = new Param<double>("stroke", false);
        protected Param<string> m_stat = new Param<string>("stat", false);

        protected string m_name;

        public BasicSettings(string name)
        {
            m_name = name;
        }

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
            };

            return settingsList;
        }

        public override string GetSettings()
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
        public double Size
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
        public double Stroke
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


    }
}
