using REnvironmentControlLibrary.TypeConverters;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomDotplotSettings : GeomSettings
    {
        private Param<double> m_binwidth = new Param<double>("binwidth", false);
        private Param<string> m_binaxis = new Param<string>("binaxis", false);
        private Param<string> m_method = new Param<string>("method", false);
        private Param<string> m_binpositions = new Param<string>("binpositions", false);
        private Param<string> m_stackdir = new Param<string>("stackdir", false);
        private Param<double> m_stackratio = new Param<double>("stackratio", false);
        private Param<double> m_dotsize = new Param<double>("dotsize", false);
        private Param<string> m_stackgroups = new Param<string>("stackgroups", false);
        private Param<string> m_origin = new Param<string>("origin", false);
        private Param<string> m_right = new Param<string>("right", false);
        private Param<double> m_width = new Param<double>("width", false);
        private Param<string> m_drop = new Param<string>("drop", false);

        private AestheticSettings m_aesthetic = new AestheticSettings();

        public GeomDotplotSettings(string name) : base(name) { }

        protected override List<string> BuildSettingsList()
        {
            List<string> settingsList = base.BuildSettingsList();

            settingsList.Add(m_binwidth.GetParamValue());
            settingsList.Add(m_binaxis.GetParamValue());
            settingsList.Add(m_method.GetParamValue());
            settingsList.Add(m_binpositions.GetParamValue());
            settingsList.Add(m_stackdir.GetParamValue());
            settingsList.Add(m_stackratio.GetParamValue());
            settingsList.Add(m_dotsize.GetParamValue());
            settingsList.Add(m_stackgroups.GetParamValue());
            settingsList.Add(m_origin.GetParamValue());
            settingsList.Add(m_right.GetParamValue());
            settingsList.Add(m_width.GetParamValue());
            settingsList.Add(m_drop.GetParamValue());

            settingsList.Add(m_aesthetic.GetSettings());

            return settingsList;
        }

        public override string GetSettings()
        {
            List<string> settingsList = BuildSettingsList();

            string content = GetSettings(settingsList);

            string geom = $"geom_dotplot({content})";

            return geom;
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Bin width"),
        Display(Order = 0),
        Description("When method is 'dotdensity', this specifies maximum bin width. When method is 'histodot', this specifies bin width.")
        ]
        public double Binwidth
        {
            get { return m_binwidth.Value; }
            set { m_binwidth.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Bin axis"),
        Display(Order = 1),
        Description("The axis to bin along, 'x' (default) or 'y'.")
        ]
        public string Binaxis
        {
            get { return m_binaxis.Value; }
            set { m_binaxis.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Method"),
        Display(Order = 2),
        Description("'dotdensity' (default) for dot-density binning, or 'histodot' for fixed bin widths.")
        ]
        public string Method
        {
            get { return m_method.Value; }
            set { m_method.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Bin positions"),
        Display(Order = 3),
        Description("When method is 'dotdensity', 'bygroup' (default) determines positions of the bins for each group separately. 'all' determines positions of the bins with all the data taken together")
        ]
        public string Binpositions
        {
            get { return m_binpositions.Value; }
            set { m_binpositions.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Stack direction"),
        Display(Order = 4),
        Description("The direction to stack the dots. 'up' (default), 'down', 'center', 'centerwhole' (centered, but with dots aligned).")
        ]
        public string Stackdir
        {
            get { return m_stackdir.Value; }
            set { m_stackdir.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Stack ratio"),
        Display(Order = 5),
        Description("How close to stack the dots. Default is 1, where dots just touch. Use smaller values for closer, overlapping dots.")
        ]
        public double Stackratio
        {
            get { return m_stackratio.Value; }
            set { m_stackratio.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Dot size"),
        Display(Order = 6),
        Description("The diameter of the dots relative to binwidth, default 1.")
        ]
        public double Dotsize
        {
            get { return m_dotsize.Value; }
            set { m_dotsize.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Stack groups"),
        Display(Order = 7),
        Description("Should dots be stacked across groups?"),
        TypeConverter(typeof(BoolConverter))
        ]
        public string Stackgroups
        {
            get { return m_stackgroups.Value; }
            set { m_stackgroups.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Origin"),
        Display(Order = 8),
        Description("When method is 'histodot', origin of first bin.")
        ]
        public string Origin
        {
            get { return m_origin.Value; }
            set { m_origin.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Right"),
        Display(Order = 9),
        Description("When method is 'histodot', should intervals be closed on the right (a, b], or not [a, b)."),
        TypeConverter(typeof(BoolConverter))
        ]
        public string Right
        {
            get { return m_right.Value; }
            set { m_right.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        DisplayName("Width"),
        Display(Order = 10),
        Description("When binaxis is 'y', the spacing of the dot stacks for dodging.")
        ]
        public double Width
        {
            get { return m_width.Value; }
            set { m_width.Value = value; }
        }

        [
        Category("Dotplot"),
        ReadOnly(false),
        Description("Aesthetic Settings"),
        DisplayName("Aesthetic Settings"),
        Display(Order = 11),
        TypeConverter(typeof(AestheticConverter))]
        public AestheticSettings AestheticSettings
        {
            get { return m_aesthetic; }
            set { m_aesthetic = value; }
        }
    }
}
