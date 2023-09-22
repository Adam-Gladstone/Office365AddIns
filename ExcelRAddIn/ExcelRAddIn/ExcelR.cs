using ExcelDna.Integration;
using RDotNetProxy;
using REngineWrapper;
using REnvironmentControlLibrary;
using System;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Numerics;

namespace ExcelRAddIn
{
    public static class ExcelRFunctions
    {
        private static EngineWrapper engineWrapper = null;

        [ExcelFunction(Name = "RScript.Evaluate",
                        Description = "Evaluate R script",
                        HelpTopic = "")]
        public static object[,] Evaluate(
            [ExcelArgument(Description = "R script")] string script,
            [ExcelArgument(Description = "Flag to indicate whether any output is suppressed")] string suppressOutput = "False"
            )
        {
            object[,] obj = null;

            try
            {
                Initialize();

                ScriptItem result = engineWrapper.Evaluate(script);
                if (result != null)
                {
                    switch (result.EvaluationType)
                    {
                        case EvaluationType.Unknown:
                        case EvaluationType.Exception:
                            obj = Convert.ReportException(result.Content);
                            break;

                        case EvaluationType.Empty:
                            {
                                string message = $"Empty expression from script: '{script.Substring(0, Math.Min(script.Length, 50))}'";
                                TaskPaneManager.AddMessage(MessageType.Information, message);

                                obj = Convert.ReportEmpty();
                            }
                            break;

                        case EvaluationType.Vector:
                        case EvaluationType.List:
                        case EvaluationType.Function:
                        case EvaluationType.Frame:
                        case EvaluationType.Matrix:
                        case EvaluationType.Language:
                        case EvaluationType.Factor:
                        case EvaluationType.Symbol:
                            {
                                TaskPaneManager.AddEnvironmentItem(result.Name, result.Content);

                                obj = Convert.ReportSuccess(result.Name);
                            }
                            break;

                        case EvaluationType.Value:
                            {
                                if(suppressOutput.ToLower() == "true")
                                {
                                    string message = $"Ignoring output from {result.Name}";
                                    TaskPaneManager.AddMessage(MessageType.Information, message);

                                    obj = Convert.ReportEmpty();
                                }
                                else
                                {
                                    obj = result.Data;
                                }
                            }
                            break;

                        case EvaluationType.Remove:
                            {
                                string[] itemsToRemove = engineWrapper.ExtractParameters(result.Name);

                                long itemsRemoved = TaskPaneManager.RemoveEnvironmentItems(itemsToRemove);

                                string message = $"Removed {itemsRemoved} {((itemsRemoved != 1) ? "items" : "item")} from the environment";
                                TaskPaneManager.AddMessage(MessageType.Information, message);

                                obj = Convert.ReportEmpty();
                            }
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    TaskPaneManager.AddMessage(MessageType.Error, "Unsupported script operation.");
                }

                return obj;
            }
            catch (Exception e)
            {
                TaskPaneManager.AddMessage(MessageType.Error, e.Message);

                obj = Convert.ReportException(e);
            }

            return obj;
        }

        private static void Initialize()
        {
            if (engineWrapper == null)
            {
                TaskPaneManager.AddMessage(MessageType.Information, "Initializing the R environment ...");

                string home = ConfigurationManager.AppSettings["R_HOME"].ToString();
                string path = ConfigurationManager.AppSettings["R_PATH"].ToString();

                if (string.IsNullOrEmpty(home))
                    home = Environment.GetEnvironmentVariable("R_HOME");

                if (string.IsNullOrEmpty(path))
                    path = Environment.GetEnvironmentVariable("R_PATH");

                if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(home))
                {
                    throw new Exception("R_HOME and/or path to R binaries are empty. Check the settings.");
                }

                engineWrapper = new EngineWrapper(path, home, HostType.Excel);

                TaskPaneManager.AddMessage(MessageType.Information, "Successfully initialized the R environment");
            }
        }

        [ExcelFunction(Name = "RScript.CreateVector",
                Description = "Create a vector of the specified type in R",
                HelpTopic = "")]
        public static object[,] CreateVector(
            [ExcelArgument(Description = "Name for the vector")] string name,
            [ExcelArgument(Description = "Values for the vector")] object[] values,
            [ExcelArgument(Description = "Type of the vector. Valid values are: 'character', 'complex', 'integer', 'logical', 'numeric'")] string type
            )
        {
            ScriptItem item = null;
            object[,] obj = null;

            try
            {
                Initialize();

                RType rtype = RType.none;
                Enum.TryParse(type.ToLower(), out rtype);

                switch (rtype)
                {
                    case RType.character:
                        {
                            string[] result = Array.ConvertAll(values, x => x.ToString());

                            item = engineWrapper.CreateCharacterVector(name, result);
                        }
                        break;
                    case RType.complex:
                        {
                            Complex[] result = Array.ConvertAll(values, x => Convert.ComplexParse(x.ToString()));

                            item = engineWrapper.CreateComplexVector(name, result);
                        }
                        break;
                    case RType.integer:
                        {
                            int[] result = Array.ConvertAll(values, x => System.Convert.ToInt32(x));

                            item = engineWrapper.CreateIntegerVector(name, result);
                        }
                        break;
                    case RType.logical:
                        {
                            bool[] result = Array.ConvertAll(values, x => System.Convert.ToBoolean(x));

                            item = engineWrapper.CreateLogicalVector(name, result);
                        }
                        break;
                    case RType.numeric:
                        {
                            double[] result = Array.ConvertAll(values, x => System.Convert.ToDouble(x));

                            item = engineWrapper.CreateNumericVector(name, result);
                        }
                        break;
                    default:
                        throw new Exception("Unrecognized R vector type.");
                }

                TaskPaneManager.AddEnvironmentItem(item.Name, item.Content);

                obj = Convert.ToObject(item);
            }
            catch (Exception e)
            {
                TaskPaneManager.AddMessage(MessageType.Error, e.Message);

                obj = Convert.ReportException(e);
            }

            return obj;
        }

        [ExcelFunction(Name = "RScript.CreateMatrix",
                Description = "Create a matrix of the specified type in R",
                HelpTopic = "")]
        public static object[,] CreateMatrix(
            [ExcelArgument(Description = "Name for the matrix")] string name,
            [ExcelArgument(Description = "Values for the matrix")] object[,] values,
            [ExcelArgument(Description = "Type of the matrix. Valid values are: 'character', 'complex', 'integer', 'logical', 'numeric'")] string type
            )
        {
            ScriptItem item = null;
            object[,] obj = null;

            try
            {
                Initialize();

                RType rtype = RType.none;
                Enum.TryParse(type.ToLower(), out rtype);

                switch (rtype)
                {
                    case RType.character:
                        {
                            string[,] result = Convert.ConvertAll(values, x => x.ToString());

                            item = engineWrapper.CreateCharacterMatrix(name, result);
                        }
                        break;
                    case RType.complex:
                        {
                            Complex[,] result = Convert.ConvertAll(values, x => Convert.ComplexParse(x.ToString()));

                            item = engineWrapper.CreateComplexMatrix(name, result);
                        }
                        break;
                    case RType.integer:
                        {
                            int[,] result = Convert.ConvertAll(values, x => System.Convert.ToInt32(x));

                            item = engineWrapper.CreateIntegerMatrix(name, result);
                        }
                        break;
                    case RType.logical:
                        {
                            bool[,] result = Convert.ConvertAll(values, x => System.Convert.ToBoolean(x));

                            item = engineWrapper.CreateLogicalMatrix(name, result);
                        }
                        break;
                    case RType.numeric:
                        {
                            double[,] result = Convert.ConvertAll(values, x => System.Convert.ToDouble(x));

                            item = engineWrapper.CreateNumericMatrix(name, result);
                        }
                        break;
                    default:
                        throw new Exception("Unrecognized R matrix type.");
                }

                TaskPaneManager.AddEnvironmentItem(item.Name, item.Content);

                obj = Convert.ToObject(item);
            }
            catch (Exception e)
            {
                TaskPaneManager.AddMessage(MessageType.Error, e.Message);

                obj = Convert.ReportException(e);
            }

            return obj;
        }

        [ExcelFunction(Name = "RScript.CreateDataFrame",
                Description = "Create a data frame from the supplied table",
                HelpTopic = "")]
        public static object[,] CreateDataFrame(
            [ExcelArgument(Description = "Name for the data frame")] string name,
            [ExcelArgument(Description = "Values for the data frame")] object[,] values,
            [ExcelArgument(Description = "Vector of column headers")] object[] headers,
            [ExcelArgument(Description = "Vector of column types")] object[] types
            )
        {
            ScriptItem item = null;
            object[,] obj = null;

            try
            {
                Initialize();

                string[] columnNames = Array.ConvertAll(headers, x => x.ToString());
                string[] columnTypes = Array.ConvertAll(types, x => x.ToString());

                int rows = values.GetLength(0);
                int cols = values.GetLength(1);

                if (!(cols == columnNames.Length && cols == columnTypes.Length && columnNames.Length == columnTypes.Length))
                {
                    throw new Exception($"The number of column names ({columnNames.Length}), column types ({columnTypes.Length}) and columns ({cols}) must be the same.");
                }

                IEnumerable[] columns = new IEnumerable[cols];

                for (int c = 0; c < cols; c++)
                {
                    object[] arr = Utility.SliceColumn(values, c).ToArray();

                    string type = columnTypes[c];
                    RType rtype = RType.none;
                    Enum.TryParse(type.ToLower(), out rtype);

                    switch (rtype)
                    {
                        case RType.character:
                            columns[c] = Array.ConvertAll(arr, x => x.ToString());
                            break;
                        case RType.complex:
                            columns[c] = Array.ConvertAll(arr, x => Convert.ComplexParse(x.ToString()));
                            break;
                        case RType.integer:
                            columns[c] = Array.ConvertAll(arr, x => System.Convert.ToInt32(x));
                            break;
                        case RType.logical:
                            columns[c] = Array.ConvertAll(arr, x => System.Convert.ToBoolean(x));
                            break;
                        case RType.numeric:
                            columns[c] = Array.ConvertAll(arr, x => System.Convert.ToDouble(x));
                            break;
                        default:
                            throw new Exception("Unrecognized type.");
                    }
                }

                item = engineWrapper.CreateDataFrame(name, columns, columnNames);

                TaskPaneManager.AddEnvironmentItem(item.Name, item.Content);

                obj = Convert.ToObject(item);
            }
            catch (Exception e)
            {
                TaskPaneManager.AddMessage(MessageType.Error, e.Message);

                obj = Convert.ReportException(e);
            }

            return obj;
        }
    }
}
