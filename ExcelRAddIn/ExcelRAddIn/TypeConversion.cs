using REngineWrapper;
using System;
using System.Numerics;

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
    }
}
