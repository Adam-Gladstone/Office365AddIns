using System.Collections.Generic;
using System.Text;

namespace REnvironmentControlLibrary.Models
{
    public abstract class Settings
    {
        public abstract string GetSettings();

        public string GetSettings(List<string> settings) 
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();

            foreach (var setting in settings)
            {
                if (!string.IsNullOrEmpty(setting))
                {
                    count++;
                    if (count > 1)
                    {
                        sb.Append(", ");
                    }

                    sb.Append($"{setting}");
                }
            }

            return sb.ToString();
        }
    }
}
