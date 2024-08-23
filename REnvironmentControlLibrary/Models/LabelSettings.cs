using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models
{
    public class LabelSettings : Settings
    {
        private Param<string> m_title = new Param<string>("title", false);
        private Param<string> m_subtitle = new Param<string>("subtitle", false);
        private Param<string> m_x_label = new Param<string>("x", false);
        private Param<string> m_y_label = new Param<string>("y", false);
        private Param<string> m_caption = new Param<string>("caption", false);

        public LabelSettings() { }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>()
            {
                m_title.GetParamValue(true),
                m_subtitle.GetParamValue(true),
                m_x_label.GetParamValue(true),
                m_y_label.GetParamValue(true),
                m_caption.GetParamValue(true)
            };

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string labels = string.Empty;
            if(!string.IsNullOrEmpty(content))
            {
                labels = $"\tlabs({content})";
            }
            return labels;
        }

        [
        Category("Labels"),
        ReadOnly(false),
        DisplayName("Title"), 
        Display(Order = 0),
        Description("A title for the plot.")
        ]
        public string Title
        {
            get { return m_title.Value; }
            set { m_title.Value = value; }
        }

        [
        Category("Labels"),
        ReadOnly(false),
        DisplayName("Subtitle"),
        Display(Order = 1),
        Description("A subtitle for the plot.")
        ]
        public string Subtitle
        {
            get { return m_subtitle.Value; }
            set { m_subtitle.Value = value; }
        }

        [
        Category("Labels"),
        ReadOnly(false),
        DisplayName("X Label"),
        Display(Order = 2),
        Description("Label for the x-axis.")
        ]
        public string X
        {
            get { return m_x_label.Value; }
            set { m_x_label.Value = value; }
        }

        [
        Category("Labels"),
        ReadOnly(false),
        DisplayName("Y Label"),
        Display(Order = 3),
        Description("Label for the y-axis.")
        ]
        public string Y
        {
            get { return m_y_label.Value; }
            set { m_y_label.Value = value; }
        }

        [
        Category("Labels"),
        ReadOnly(false),
        DisplayName("Caption"),
        Display(Order = 4),
        Description("A caption for the plot.")
        ]
        public string Caption
        {
            get { return m_caption.Value; }
            set { m_caption.Value = value; }
        }
    }
}
