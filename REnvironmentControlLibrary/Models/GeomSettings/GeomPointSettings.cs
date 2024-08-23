using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REnvironmentControlLibrary.Models.GeomSettings
{
    public class GeomPointSettings : GeomSettings
    {
        private AestheticSettings m_aesthetic = new AestheticSettings();

        public GeomPointSettings(string name) : base(name) { }

        public override string GetSettings()
        {
            string content = GetSettings(BuildSettingsList());

            string aes = m_aesthetic.GetSettings();
            if (!string.IsNullOrEmpty(aes))
            {
                if(!string.IsNullOrEmpty(content))
                    content += ", ";

                content += aes;
            }

            string geom = $"geom_point({content})";

            return geom;
        }

        [
        Category("geom_point"),
        ReadOnly(false),
        Description("Aesthetic Settings"),
        DisplayName("Aesthetic Settings"),
        Display(Order = 6),
        TypeConverter(typeof(AestheticConverter))]
        public AestheticSettings AestheticSettings
        {
            get { return m_aesthetic; }
            set { m_aesthetic = value; }
        }
    }
}
