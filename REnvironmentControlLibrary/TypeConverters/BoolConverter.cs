using System.Collections.Specialized;
using System.ComponentModel;

namespace REnvironmentControlLibrary.TypeConverters
{
    public static class BoolValues
    {
        private static HybridDictionary values;

        static BoolValues()
        {
            values = new HybridDictionary
            {
                { "TRUE", "TRUE" },
                { "FALSE", "TRUE" }
            };
        }

        public static HybridDictionary Dictionary { get { return values; } }
    }

    public class BoolConverter : TypeConverter
    {
        public BoolConverter()
        {
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            StandardValuesCollection svc = new StandardValuesCollection(BoolValues.Dictionary.Keys);
            return svc;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                return value;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
