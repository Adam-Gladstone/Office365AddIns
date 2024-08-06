using REnvironmentControlLibrary.Models;
using System.Collections.Generic;
using System.Text;

namespace REnvironmentControlLibrary.ViewModel
{
    public class PlotViewModel
    {
        public static List<string> GeomTypes = new List<string>()
        {
            "", "point", "line", "bar", "col", "boxplot", "dotplot", "histogram", "density", "smooth"
        };

        public static List<string> Themes = new List<string>()
        {
            "", "grey", "gray", "bw", "linedraw", "light", "dark", "minimal", "classic", "void"
        };

        public DataSettings DataSettings { get; set; } = new DataSettings();

        private GeomSettings geomSettings = null;

        public LabelSettings LabelSettings { get; set; } = new LabelSettings();

        private ThemeSettings themeSettings = null;

        public PlotViewModel() { }

        public GeomSettings GetGeom(string geom)
        {
            if (geom == "point")
            {
                geomSettings = new GeomPointSettings(geom);
            }
            else if (geom == "line")
            {
                geomSettings = new GeomLineSettings(geom);
            }
            else
            {
                geomSettings = new GeomSettings(geom);
            }

            return geomSettings;
        }

        public void SetTheme(string theme)
        {
            themeSettings = new ThemeSettings(theme);
        }

        public string GetScript()
        {
            List<string> settings = new List<string>()
            {
                DataSettings.GetSettings(),
                geomSettings.GetSettings(),
                LabelSettings.GetSettings(),
                themeSettings.GetSettings()
            };

            int count = 0;
            StringBuilder sb = new StringBuilder();

            foreach (var setting in settings)
            {
                if (!string.IsNullOrEmpty(setting))
                {
                    count++;
                    if (count > 1)
                    {
                        sb.AppendLine(" + ");
                    }

                    sb.Append($"{setting}");
                }
            }

            string content = sb.ToString();

            string plot = $"plot(\n{content}\n)";
            return plot;
        }
    }
}
