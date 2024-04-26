using REngineWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ExcelRAddIn
{
    public enum RType
    {
        none = 0,
        character,
        complex,
        integer,
        logical,
        numeric,
    }

    public static class Convert
    {
        public static object[,] ReportException(Exception e)
        {
            object[,] obj = new object[1, 1];
            obj[0, 0] = "Exception: " + e.Message;
            return obj;
        }

        public static object[,] ReportException(string exception)
        {
            object[,] obj = new object[1, 1];
            obj[0, 0] = "Exception: " + exception;
            return obj;
        }

        public static object[,] ReportSuccess(string name)
        {
            object[,] obj = new object[1, 1];
            obj[0, 0] = string.IsNullOrEmpty(name) ? "OK" : name;
            return obj;
        }

        public static object[,] ReportEmpty()
        {
            object[,] obj = new object[1, 1];
            obj[0, 0] = "OK";
            return obj;
        }


        // Output a single string item
        public static object[,] ToObject(ScriptItem item)
        {
            object[,] obj = new object[1, 1];
            obj[0, 0] = item.Name;
            return obj;
        }

        //
        // Parse complex numbers input as strings
        // (x, y) or (x+yi) or (x+yj) or (x-yi) or (x-yj)
        //
        public static Complex ComplexParse(string text)
        {
            string[] parts;
            string parsedText = text.Trim();
            if (parsedText.StartsWith("(") && parsedText.EndsWith(")"))
            {
                parsedText = parsedText.Substring(1, parsedText.Length - 2).Trim(); // Drop parentheses
            }

            if (parsedText.Contains("+") && (parsedText.EndsWith("i") || parsedText.EndsWith("j")))
            {
                parts = parsedText.Split('+');
                if (parts.Length == 2)
                    return
                        new Complex(
                            real: double.Parse(parts[0].Trim()),
                            imaginary: double.Parse(parts[1].Substring(0, parts[1].Length - 1).Trim())
                            );

                throw new ArgumentException("Complex number format not recognised (multiple '+' chars)");
            }
            else if (parsedText.Substring(1).Contains("-") && (parsedText.EndsWith("i") || parsedText.EndsWith("j")))   // (x-yi) or (x-yj) // Beware of (-x-yi) or (-x-yj)
            {
                parts = parsedText.Substring(1).Split('-');
                if (parts.Length == 2)
                    return
                        new Complex(
                            real: double.Parse(parsedText.Substring(0, 1) + parts[0].Trim()),
                            imaginary: -double.Parse(parts[1].Substring(0, parts[1].Length - 1).Trim())
                            );

                throw new ArgumentException("Complex number format not recognised (multiple '+' chars)");
            }
            else if (parsedText.Contains(","))  // Hopefully in the form x, y
            {
                parts = parsedText.Split(',');
                if (parts.Length == 2)
                    return
                        new Complex(
                            real: Double.Parse(parts[0].Trim()),
                            imaginary: Double.Parse(parts[1].Trim())
                            );

                // Too many commas. Can only diambiguate if one is followed by a space
                int ix = parsedText.IndexOf(", ");
                if (ix < 1)     // ", " not found or there is an empty real part
                    throw new ArgumentException("Complex number format not recognised (ambiguous use of commas)");

                return
                    new Complex(
                        real: double.Parse(parsedText.Substring(0, ix).Trim()),
                        imaginary: double.Parse(parsedText.Substring(ix + 1).Trim())
                        );
            }
            else
                throw new ArgumentException("Complex number format not recognised");
        }

        //
        // Convert all elements of a two-dimensional array
        //
        public static TOutput[,] ConvertAll<TInput, TOutput>(TInput[,] array, Converter<TInput, TOutput> converter)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            var output = new TOutput[array.GetLongLength(0), array.GetLongLength(1)];
            for (long row = 0; row < array.GetLongLength(0); row++)
            {
                for (long column = 0; column < array.GetLongLength(1); column++)
                {
                    output[row, column] = converter(array[row, column]);
                }
            }
            return output;
        }

        public static Dictionary<string, object> GetParameters(object[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            for (long row = 0; row < array.GetLongLength(0); row++)
            {
                string key = array[row, 0].ToString();
                if (key == "ExcelDna.Integration.ExcelMissing")
                    continue;

                if (!string.IsNullOrEmpty(key))
                {
                    object value = array[row, 1];
                    if(value is null || value is ExcelDna.Integration.ExcelEmpty)
                    {
                        continue;
                    }
                    else
                    {
                        parameters[key] = value;
                    }
                }
            }

            return parameters;
        }

        public static string ToParameterList(Dictionary<string, object> parameters)
        {
            StringBuilder sb = new StringBuilder();

            string[] keys = parameters.Keys.ToArray();
            int count = 0;

            foreach (string key in keys)
            {
                if (count > 0 && count < keys.Length)
                {
                    sb.Append(',');
                }

                object value = parameters[key];

                Type systemType = value.GetType();

                if (systemType == typeof(double) || systemType == typeof(int))
                {
                    sb.Append($"{key} = {value}");
                }
                else if (systemType == typeof(bool))
                {
                    sb.Append($"{key} = {(System.Convert.ToBoolean(value) == true ? "TRUE" : "FALSE")}");
                }
                else if (systemType == typeof(Complex))
                {
                    sb.Append($"{key} = {value}");
                }
                else if (systemType == typeof(string))
                {
                    string s = (string)value;
                    s.Trim();

                    if ((s.Substring(0, 2) == "c("))
                    {
                        sb.Append($"{key} = {s}");
                    }
                    else if ((s.Substring(0, 1) == "^"))
                    {
                        sb.Append($"{key} = {s.Substring(1, s.Length - 1)}");
                    }
                    else
                    {
                        sb.Append($"{key} = \'{value}\'");
                    }
                }
                else
                {
                    throw new Exception($"Unrecognised type ({systemType}) for the value corresponding to the key: {key}");
                }

                ++count;
            }

            return sb.ToString();
        }
    }
}
