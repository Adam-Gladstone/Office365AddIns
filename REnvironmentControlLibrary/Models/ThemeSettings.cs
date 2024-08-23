using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace REnvironmentControlLibrary.Models
{
    public class ThemeSettings : Settings
    {
        private Param<int> m_base_size = new Param<int>("base_size");
        private Param<string> m_base_family = new Param<string>("base_family");
        private Param<int> m_base_line_size = new Param<int>("base_line_size");
        private Param<int> m_base_rect_size = new Param<int>("base_rect_size");

        private string m_name;
        public ThemeSettings(string name)
        {
            m_name = name;
        }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>()
            {
                m_base_size.GetParamValue(),
                m_base_family.GetParamValue(),
                m_base_line_size.GetParamValue(),
                m_base_rect_size.GetParamValue(),
            };

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string theme = string.Empty;
            if (!string.IsNullOrEmpty(m_name))
            {
                theme = $"theme_{m_name}({content})";
            }

            return theme;
        }

        [
        Category("Themes"),
        ReadOnly(false),
        Description("Base font size, given in pts."),
        DisplayName("Base Size"),
        Display(Order = 0)
        ]
        public int BaseSize
        {
            get { return m_base_size.Value; }
            set { m_base_size.Value = value; }
        }

        [
        Category("Themes"),
        ReadOnly(false),
        Description("Base font family."),
        DisplayName("Base Family"),
        Display(Order = 1)
        ]
        public string BaseFamily
        {
            get { return m_base_family.Value; }
            set { m_base_family.Value = value; }
        }

        [
        Category("Themes"),
        ReadOnly(false),
        Description("Base size for line elements."),
        DisplayName("Base Line Size"),
        Display(Order = 2)
        ]
        public int BaseLineSize
        {
            get { return m_base_line_size.Value; }
            set { m_base_line_size.Value = value; }
        }

        [
        Category("Themes"),
        ReadOnly(false),
        Description("Base size for rect elements."),
        DisplayName("Base Rect Size"),
        Display(Order = 3)
        ]
        public int BaseRectSize
        {
            get { return m_base_rect_size.Value; }
            set { m_base_rect_size.Value = value; }
        }
    }
}
