namespace REnvironmentControlLibrary.Models
{
    public class ThemeSettings : Settings
    {
        private string m_name;
        public ThemeSettings(string name)
        {
            m_name = name;
        }

        public override string GetSettings()
        {
            string theme = string.Empty;
            if (!string.IsNullOrEmpty(m_name))
            {
                theme = $"theme_{m_name}()";
            }

            return theme;
        }
    }
}
