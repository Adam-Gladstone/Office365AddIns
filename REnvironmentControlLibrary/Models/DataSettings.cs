using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace REnvironmentControlLibrary.Models
{
    public class DataSettings : Settings
    {
        private Param<string> m_data = new Param<string>("data");

        private Param<string> m_x = new Param<string>("x");

        private Param<string> m_y = new Param<string>("y", false);
        private Param<string> m_colour = new Param<string>("colour", false);
        private Param<string> m_fill = new Param<string>("fill", false);
        private Param<string> m_group = new Param<string>("group", false);
        private Param<string> m_shape = new Param<string>("shape", false);
        private Param<double> m_size = new Param<double>("size", false);

        public DataSettings() { }

        public override string GetSettings()
        {
            List<string> settings = new List<string>()
            {
                m_colour.GetParamValue(),
                m_fill.GetParamValue(),
                m_group.GetParamValue(),
                m_shape.GetParamValue(), // e.g shape = factor(cyl)
                m_size.GetParamValue(),
                m_x.GetParamValue(),
                m_y.GetParamValue()
            };

            string content = GetSettings(settings);

            string aes = string.Empty;
            if (!string.IsNullOrEmpty(content))
            {
                aes = $"mapping = aes({content})";
            }

            string plotData = $"ggplot({m_data.GetParamValue()}, {aes})";

            return plotData;
        }

        [
        Category("Data"),
        ReadOnly(false),
        Description("The name of the DataFrame.")
        ]
        public string DataFrame
        {
            get { return m_data.Value; }
            set { m_data.Value = value; }
        }

        [
        Category("Mapping"),
        ReadOnly(false),
        Description("The x data.")
        ]
        public string X
        {
            get { return m_x.Value; }
            set { m_x.Value = value; }
        }

        [
        Category("Mapping"),
        ReadOnly(false),
        Description("The y data.")
        ]
        public string Y
        {
            get { return m_y.Value; }
            set { m_y.Value = value; }
        }

        [
        Category("Mapping"),
        ReadOnly(false),
        Description("The border colour: a named colour or an RGB string #RRGGBB.")
        ]
        public string Colour
        {
            get { return m_colour.Value; }
            set { m_colour.Value = value; }
        }

        [
        Category("Mapping"),
        ReadOnly(false),
        Description("The interior fill colour: a named colour or an RGB string #RRGGBB.")
        ]
        public string Fill
        {
            get { return m_fill.Value; }
            set { m_fill.Value = value; }
        }

        [
        Category("Mapping"),
        ReadOnly(false),
        Description("A group.")
        ]
        public string Group
        {
            get { return m_group.Value; }
            set { m_group.Value = value; }
        }

        [
        Category("Mapping"),
        ReadOnly(false),
        Description("A shape.")
        ]
        public string Shape
        {
            get { return m_shape.Value; }
            set { m_shape.Value = value; }
        }

        [
        Category("Mapping"),
        ReadOnly(false),
        Description("A size.")
        ]
        public double Size
        {
            get { return m_size.Value; }
            set { m_size.Value = value; }
        }
    }
}
