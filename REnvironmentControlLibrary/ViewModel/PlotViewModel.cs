using REnvironmentControlLibrary.Models;
using REnvironmentControlLibrary.Models.GeomSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REnvironmentControlLibrary.ViewModel
{
    public class PlotViewModel
    {
        public static List<string> GeomTypes = new List<string>()
        {
            "", "abline", "area", "bar", "boxplot", "col", "contour", "crossbar", "density", "density2d", "dotplot",
            "errorbar", "histogram", "hline", "interval", "jitter", "line", "linerange", "path", "point", "pointrange",
            "polygon", "quantile", "ribbon", "rug", "segment", "smooth", "step", "text", "tile", "vline"
        };

        public static List<string> Scales = new List<string>()
        {
            "", "x_continuous", "y_continuous", "x_log10", "y_log10", "x_reverse", "y_reverse", "x_sqrt", "y_sqrt", "x_binned", "y_binned",
            // "x_date", "y_date", "x_datetime", "y_datetime", "x_time", "y_time"
        };

        public static List<string> Coords = new List<string>()
        {
            "", "cartesian", "flip", "fixed"
        };

        public static List<string> Themes = new List<string>()
        {
            "", "grey", "gray", "bw", "linedraw", "light", "dark", "minimal", "classic", "void"
        };

        private List<Tuple<string, GeomSettings>> listGeoms = new List<Tuple<string, GeomSettings>>();

        public int GeomsCount() { return listGeoms.Count; }

        public DataSettings DataSettings { get; set; } = new DataSettings();

        public LabelSettings LabelSettings { get; set; } = new LabelSettings();

        public CoordSettings CoordSettings { get; set; } = new CoordSettings("");

        public ScaleSettings ScaleSettings { get; set; } = new ScaleSettings("");

        public ThemeSettings ThemeSettings { get; set; } = new ThemeSettings("");

        public FacetWrapSettings FacetSettings { get; set; } = new FacetWrapSettings();

        public PlotViewModel() { }

        public Tuple<string, GeomSettings> AddGeom(string geom)
        {
            GeomSettings geomSettings = null;

            switch (geom)
            {
                case "point":
                    geomSettings = new GeomPointSettings(geom);
                    break;

                case "line":
                    geomSettings = new GeomLineSettings(geom);
                    break;

                case "smooth":
                    geomSettings = new GeomSmoothSettings(geom);
                    break;

                case "abline":
                    geomSettings = new GeomAblineSettings(geom);
                    break;

                case "vline":
                    geomSettings = new GeomVlineSettings(geom);
                    break;

                case "hline":
                    geomSettings = new GeomHlineSettings(geom);
                    break;

                case "boxplot":
                    geomSettings = new GeomBoxplotSettings(geom);
                    break;

                case "dotplot":
                    geomSettings = new GeomDotplotSettings(geom);
                    break;

                default:
                    geomSettings = new GeomSettings(geom);
                    break;
            }

            Tuple<string, GeomSettings> item = new Tuple<string, GeomSettings>(geom, geomSettings);
            listGeoms.Add(item);
            
            return item;
        }

        public void DeleteGeom(int index)
        {
            listGeoms.RemoveAt(index);
        }

        public Tuple<string, GeomSettings> GetGeom(int index, string geom)
        {
            Tuple<string, GeomSettings> item = listGeoms.ElementAt(index);

            return item;
        }

        private string GetGeomSettings()
        {
            string geoms = string.Empty;
            if (listGeoms.Count > 0)
            {
                int count = 0;
                StringBuilder sb = new StringBuilder();

                foreach (var item in listGeoms) 
                {
                    GeomSettings geom = item.Item2;

                    string setting = geom.GetSettings();
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
                geoms = sb.ToString();
            }

            return geoms;
        }

        public void SetTheme(string theme)
        {
            ThemeSettings = new ThemeSettings(theme);
        }

        public void SetScale(string scale)
        {
            ScaleSettings = new ScaleSettings(scale);
        }

        public void SetCoords(string coords)
        {
            CoordSettings = new CoordSettings(coords);
        }

        public string GetScript()
        {
            List<string> settings = new List<string>()
            {
                DataSettings.GetSettings(),
                GetGeomSettings(),
                LabelSettings.GetSettings(),
                ScaleSettings.GetSettings(),
                CoordSettings.GetSettings(),
                FacetSettings.GetSettings(),
                ThemeSettings.GetSettings()
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
