using System.Collections.Generic;
using System.ComponentModel;

namespace REnvironmentControlLibrary.Models
{
    public class GeomSettings : Settings
    {
        private string m_name;
        public GeomSettings(string name) 
        { 
            m_name = name;
        }

        public override string GetSettings()
        {
            string geom = string.Empty;
            if (!string.IsNullOrEmpty(m_name))
            {
                geom = $"geom_{m_name}()";
            }

            return geom;
        }
    }

    public class GeomPointSettings : GeomSettings
    {
        //
        // https://ggplot2.tidyverse.org/reference/geom_point.html
        //

        private Param<double> m_alpha = new Param<double>("alpha", false);
        private Param<string> m_colour = new Param<string>("colour", false);

        public GeomPointSettings(string name) : base(name) { }

        public override string GetSettings()
        {
            List<string> settings = new List<string>()
            {
                m_colour.GetParamValue(),
                m_alpha.GetParamValue()
            };

            string content = GetSettings(settings);

            string geom = string.Empty;
            if (!string.IsNullOrEmpty(content))
            {
                geom = $"geom_point({content})";
            }

            return geom;
        }

        [
        Category("Point Geom"),
        ReadOnly(false),
        Description("Alpha refers to the opacity of a geom. Values of alpha range from 0 to 1, with lower values corresponding to more transparent colors.")
        ]
        public double Alpha
        {
            get { return m_alpha.Value; }
            set { m_alpha.Value = value; }
        }

        [
        Category("Point Geom"),
        ReadOnly(false),
        Description("The border colour: a named colour or an RGB string #RRGGBB.")
        ]
        public string Colour
        {
            get { return m_colour.Value; }
            set { m_colour.Value = value; }
        }

    }

    public class GeomLineSettings : GeomSettings
    {
        private Param<double> m_alpha = new Param<double>("alpha", false);
        private Param<string> m_colour = new Param<string>("colour", false);
        private Param<double> m_size = new Param<double>("size", false);
        private Param<string> m_linetype = new Param<string>("linetype", false);

        public GeomLineSettings(string name) : base(name) { }

        public override string GetSettings()
        {
            List<string> settings = new List<string>()
            {
                m_colour.GetParamValue(),
                m_alpha.GetParamValue(),
                m_size.GetParamValue(),
                m_linetype.GetParamValue()
            };

            string content = GetSettings(settings);

            string geom = string.Empty;
            if (!string.IsNullOrEmpty(content))
            {
                geom = $"geom_line({content})";
            }

            return geom;
        }

        [
        Category("Line Geom"),
        ReadOnly(false),
        Description("Alpha refers to the opacity of a geom. Values of alpha range from 0 to 1, with lower values corresponding to more transparent colors.")
        ]
        public double Alpha
        {
            get { return m_alpha.Value; }
            set { m_alpha.Value = value; }
        }

        [
        Category("Line Geom"),
        ReadOnly(false),
        Description("The border colour: a named colour or an RGB string #RRGGBB.")
        ]
        public string Colour
        {
            get { return m_colour.Value; }
            set { m_colour.Value = value; }
        }

        [
        Category("Line Geom"),
        ReadOnly(false),
        Description("Size.")
        ]
        public double Size
        {
            get { return m_size.Value; }
            set { m_size.Value = value; }
        }

        [
        Category("Line Geom"),
        ReadOnly(false),
        Description("The linetype aesthetic can be specified with either an integer (0-6) or a name (0 = blank, 1 = solid, 2 = dashed, 3 = dotted, 4 = dotdash, 5 = longdash, 6 = twodash).")
        ]
        public string Linetype
        {
            get { return m_linetype.Value; }
            set { m_linetype.Value = value; }
        }
    }
}
