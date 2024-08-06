using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REnvironmentControlLibrary.Models
{
    public class Plot
    {
        public static List<string> ChartTypes = new List<string>() 
        { 
            "", "point", "line", "bar", "col", "boxplot", "dotplot", "histogram", "density", "smooth"
        };
        
        public static List<string> Themes = new List<string>() 
        { 
            "", "grey", "gray", "bw", "linedraw", "light", "dark", "minimal", "classic", "void"
        };

        public string DataFrame { get; set; }
        public string XData { get; set; }
        public string YData { get; set; }
        public string Colour { get; set; }
        public string Fill { get; set; }
        public string Group { get; set; }
        public string Shape { get; set; }
        public string Size { get; set; }


        public string ChartType { get; set; }

        public string Theme { get; set; }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Xlabel { get; set; }
        public string Ylabel { get; set; }
        public string Caption { get; set; }

        public string GetScript()
        {
            string colour = String.Empty;
            if (!string.IsNullOrEmpty(Colour))
            {
                colour = $"colour = '{Colour}', ";
            }

            string fill = String.Empty;
            if (!string.IsNullOrEmpty(Fill))
            {
                fill = $"fill = '{Fill}', ";
            }

            string group = String.Empty;
            if (!string.IsNullOrEmpty(Group))
            {
                group = $"group = '{Group}', ";
            }

            string shape = String.Empty;
            if (!string.IsNullOrEmpty(Shape))
            {
                shape = $"shape = {Shape}, "; // e.g shape = factor(cyl)
            }

            string size = String.Empty;
            if (!string.IsNullOrEmpty(Size))
            {
                size = $"size = {Size} ";
            }

            string aesData;
            if (string.IsNullOrEmpty(YData))
            {
                aesData = $"mapping = aes(x = {XData}, {colour}{fill}{group}{shape}{size})";
            }
            else
            {
                aesData = $"mapping = aes(x = {XData}, y = {YData}, {colour}{fill}{group}{shape}{size})";
            }

            string plotData = $"ggplot(data = {DataFrame}, {aesData})";

            string title = String.Empty;
            if(!string.IsNullOrEmpty(Title))
            {
                title = $"title = '{Title}', ";
            }

            string subtitle = String.Empty;
            if (!string.IsNullOrEmpty(Subtitle))
            {
                subtitle = $"subtitle = '{Subtitle}', ";
            }

            string x_label = String.Empty;
            if (!string.IsNullOrEmpty(Xlabel))
            {
                x_label = $"x = '{Xlabel}', ";
            }

            string y_label = String.Empty;
            if (!string.IsNullOrEmpty(Ylabel))
            {
                y_label = $"y = '{Ylabel}', ";
            }

            string caption = String.Empty;
            if (!string.IsNullOrEmpty(Caption))
            {
                caption = $"caption = '{Caption}' ";
            }

            string labels = String.Empty;
            if (string.IsNullOrEmpty(title) &&
                string.IsNullOrEmpty(subtitle) &&
                string.IsNullOrEmpty(x_label) &&
                string.IsNullOrEmpty(y_label) &&
                string.IsNullOrEmpty(caption))
            {
            }
            else
            {
                labels = $" + \n\tlabs({title}{subtitle}{x_label}{y_label}{caption})\n";
            }

            string chartType = $" + \n\tgeom_{ChartType}()";

            string theme = String.Empty;
            if (!string.IsNullOrEmpty(Theme))
            {
                theme = $" + \n\ttheme_{Theme}()";
            }

            string plot = String.Empty;
            if (string.IsNullOrEmpty(Theme))
            {
                plot = $"plot(\n\t{plotData}{chartType}{labels}\n)";
            }
            else
            {
                plot = $"plot(\n\t{plotData}{chartType}{theme}{labels}\n)";
            }

            return plot;
        }
    }
}
