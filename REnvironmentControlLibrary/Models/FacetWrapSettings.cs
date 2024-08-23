using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models
{
    public class FacetWrapSettings : Settings
    {
        private Param<string> m_facets = new Param<string>("facets", false);
        private Param<int> m_nrow = new Param<int>("nrow", false);
        private Param<int> m_ncol = new Param<int>("ncol", false);
        private Param<string> m_dir = new Param<string>("dir", false);
        private Param<string> m_strip_position = new Param<string>("strip.position", false);

        public FacetWrapSettings()
        {
        }

        protected virtual List<string> BuildSettingsList()
        {
            List<string> settingsList = new List<string>()
            {
                m_facets.GetParamValue(),
                m_nrow.GetParamValue(),
                m_ncol.GetParamValue(),
                m_dir.GetParamValue(),
                m_strip_position.GetParamValue(),
            };

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string facet = string.Empty;
            if (!string.IsNullOrEmpty(content))
            {
                facet = $"facet_wrap({content})";
            }

            return facet;
        }

        [
        Category("Facets"),
        ReadOnly(false),
        DisplayName("Facets"),
        Display(Order = 0),
        Description("A set of variables or expressions quoted by vars() and defining faceting groups on the rows or columns dimension.")
        ]
        public string Title
        {
            get { return m_facets.Value; }
            set { m_facets.Value = value; }
        }

        [
        Category("Facets"),
        ReadOnly(false),
        DisplayName("Rows"),
        Display(Order = 1),
        Description("Number of rows.")
        ]
        public int Nrows
        {
            get { return m_nrow.Value; }
            set { m_nrow.Value = value; }
        }

        [
        Category("Facets"),
        ReadOnly(false),
        DisplayName("Columns"),
        Display(Order = 2),
        Description("Number of columns.")
        ]
        public int Ncols
        {
            get { return m_ncol.Value; }
            set { m_ncol.Value = value; }
        }

        [
        Category("Facets"),
        ReadOnly(false),
        DisplayName("Direction"),
        Display(Order = 3),
        Description("Direction: either 'h' for horizontal, the default, or 'v', for vertical.")
        ]
        public string Direction
        {
            get { return m_dir.Value; }
            set { m_dir.Value = value; }
        }

        [
        Category("Facets"),
        ReadOnly(false),
        DisplayName("Strip Position"),
        Display(Order = 4),
        Description("Label positions: 'top', 'bottom', 'left', 'right'.")
        ]
        public string StripPosition
        {
            get { return m_strip_position.Value; }
            set { m_strip_position.Value = value; }
        }
    }
}
