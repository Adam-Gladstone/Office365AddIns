using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models
{
    public class ScaleSettings : Settings
    {
        private Param<string> m_breaks = new Param<string>("breaks");
        private Param<string> m_minor_breaks = new Param<string>("minor.breaks");
        private Param<int> m_nbreaks = new Param<int>("nbreaks");
        private Param<string> m_labels = new Param<string>("labels");
        private Param<string> m_limits = new Param<string>("limits");
        private Param<string> m_expand = new Param<string>("expand");
        private Param<string> m_oob = new Param<string>("oob");
        private Param<string> m_transform = new Param<string>("transform");
        private Param<string> m_position = new Param<string>("position");

        private string m_name;
        public ScaleSettings(string name)
        {
            m_name = name;
        }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>()
            {
                m_breaks.GetParamValue(),
                m_minor_breaks.GetParamValue(),
                m_nbreaks.GetParamValue(),
                m_labels.GetParamValue(),
                m_limits.GetParamValue(),
                m_expand.GetParamValue(),
                m_oob.GetParamValue(),
                m_transform.GetParamValue(),
                m_position.GetParamValue(),
            };

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string scale = string.Empty;
            if (!string.IsNullOrEmpty(m_name))
            {
                scale = $"scale_{m_name}({content})";
            }

            return scale;
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("NULL for no breaks; or a numeric vector of positions, or a function that takes the limits as input and returns breaks as output."),
        DisplayName("Breaks"),
        Display(Order = 0)
        ]
        public string Breaks
        {
            get { return m_breaks.Value; }
            set { m_breaks.Value = value; }
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("NULL for no breaks; or a numeric vector of positions, or a function that takes the limits as input and returns breaks as output."),
        DisplayName("Minor Breaks"),
        Display(Order = 1)
        ]
        public string MinorBreaks
        {
            get { return m_minor_breaks.Value; }
            set { m_minor_breaks.Value = value; }
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("An integer guiding the number of major breaks."),
        DisplayName("Number of Breaks"),
        Display(Order = 2)
        ]
        public int NumberBreaks
        {
            get { return m_nbreaks.Value; }
            set { m_nbreaks.Value = value; }
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("A character vector giving labels (must be same length as breaks) or an expression vector (must be the same length as breaks)."),
        DisplayName("Labels"),
        Display(Order = 3)
        ]
        public string Labels
        {
            get { return m_labels.Value; }
            set { m_labels.Value = value; }
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("A numeric vector of length two providing limits of the scale."),
        DisplayName("Limits"),
        Display(Order = 4)
        ]
        public string Limits
        {
            get { return m_limits.Value; }
            set { m_limits.Value = value; }
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("For position scales, a vector of range expansion constants used to add some padding around the data to ensure that they are placed some distance away from the axes."),
        DisplayName("Expand"),
        Display(Order = 5),
        ]
        public string Expand
        {
            get { return m_expand.Value; }
            set { m_expand.Value = value; }
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("Handles limits outside of the scale limits (out of bounds)."),
        DisplayName("Out of Bounds"),
        Display(Order = 6),
        ]
        public string Oob
        {
            get { return m_oob.Value; }
            set { m_oob.Value = value; }
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("For continuous scales, the name of a transformation object or the object itself."),
        DisplayName("Transform"),
        Display(Order = 7),
        ]
        public string Transform
        {
            get { return m_transform.Value; }
            set { m_transform.Value = value; }
        }

        [
        Category("Scales"),
        ReadOnly(false),
        Description("For position scales, the position of the axis. 'left' or 'right' for y axes, 'top' or 'bottom' for x axes."),
        DisplayName("Position"),
        Display(Order = 8),
        ]
        public string Position
        {
            get { return m_position.Value; }
            set { m_position.Value = value; }
        }
    }
}
