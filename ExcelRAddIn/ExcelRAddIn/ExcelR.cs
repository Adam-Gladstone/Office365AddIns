using ExcelDna.Integration;

using RDotNetProxy;
using REngineWrapper;
using REnvironmentControlLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;


namespace ExcelRAddIn
{
    public static class Script
    {
        private static EngineWrapper engineWrapper = null;

        public static EngineWrapper EngineWrapper { get => engineWrapper; set => engineWrapper = value; }


        [ExcelFunction(Name = "RScript.Evaluate",
                        Description = "Evaluate R script",
                        HelpTopic = "")]
        public static object[,] Evaluate(
            [ExcelArgument(Description = "R script")] string script,
            [ExcelArgument(Description = "Flag to indicate whether any output is suppressed")] bool suppressOutput = false
            )
        {
            object[,] obj;

            try
            {
                Initialize();

                ScriptItem result = EngineWrapper.Evaluate(script);

                obj = ProcessResult(result, script, suppressOutput);

            }
            catch (Exception e)
            {
                TaskPaneManager.AddMessage(MessageType.Error, e.Message);

                obj = Convert.ReportException(e);
            }

            return obj;
        }

        public static void Initialize()
        {
            if (EngineWrapper == null)
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

                EngineWrapper = new EngineWrapper(path, home, HostType.Excel);

                TaskPaneManager.AddMessage(MessageType.Information, "Successfully initialized the R environment");

                LoadDefaultPackages();
            }
        }

        public static object[,] ProcessResult(ScriptItem result, string script, bool suppressOutput)
        {
            object[,] obj = null;

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
                            if (suppressOutput)
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
                            string[] itemsToRemove = EngineWrapper.ExtractParameters(result.Name);

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

        // load any 'default' packages
        private static void LoadDefaultPackages()
        {
            var packages = new List<string>(ConfigurationManager.AppSettings["packages"].Split(new char[] { ';' }));
            foreach (string package in packages)
            {
                if(string.IsNullOrEmpty(package)) 
                    continue;

                string script = $"library({package})";
                ScriptItem result = EngineWrapper.Evaluate(script);
                if (result.EvaluationType == EvaluationType.Exception)
                {
                    TaskPaneManager.AddMessage(MessageType.Error, result.Content);
                }
                else
                {
                    _ = ProcessResult(result, script, true);
                }
            }
        }

        // 'character', 'complex', 'integer', 'logical', 'numeric'
        private static RType DetermineType(object value, string rtype)
        {
            RType type = RType.none;

            bool result = false;
            // This could be user-supplied or "ExcelDna.Integration.ExcelMissing"
            if (!string.IsNullOrEmpty(rtype))
            {
                result = Enum.TryParse(rtype.ToLower(), out type);
            }

            if(!result)
            {
                Type systemType = value.GetType();

                if (systemType == typeof(double))
                {
                    type = RType.numeric;
                }
                else if (systemType == typeof(bool))
                {
                    type = RType.logical;
                }
                else if (systemType == typeof(int))
                {
                    type = RType.integer;
                }
                else if (systemType == typeof(Complex))
                {
                    type = RType.complex;
                }
                else if (systemType == typeof(string))
                {
                    type = RType.character;
                }
            }

            return type;
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

                RType rtype = DetermineType(values[0], type);

                switch (rtype)
                {
                    case RType.character:
                        {
                            string[] result = Array.ConvertAll(values, x => x.ToString());

                            item = EngineWrapper.CreateCharacterVector(name, result);
                        }
                        break;
                    case RType.complex:
                        {
                            Complex[] result = Array.ConvertAll(values, x => Convert.ComplexParse(x.ToString()));

                            item = EngineWrapper.CreateComplexVector(name, result);
                        }
                        break;
                    case RType.integer:
                        {
                            int[] result = Array.ConvertAll(values, x => System.Convert.ToInt32(x));

                            item = EngineWrapper.CreateIntegerVector(name, result);
                        }
                        break;
                    case RType.logical:
                        {
                            bool[] result = Array.ConvertAll(values, x => System.Convert.ToBoolean(x));

                            item = EngineWrapper.CreateLogicalVector(name, result);
                        }
                        break;
                    case RType.numeric:
                        {
                            double[] result = Array.ConvertAll(values, x => System.Convert.ToDouble(x));

                            item = EngineWrapper.CreateNumericVector(name, result);
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

                RType rtype = DetermineType(values[0, 0], type);

                switch (rtype)
                {
                    case RType.character:
                        {
                            string[,] result = Convert.ConvertAll(values, x => x.ToString());

                            item = EngineWrapper.CreateCharacterMatrix(name, result);
                        }
                        break;
                    case RType.complex:
                        {
                            Complex[,] result = Convert.ConvertAll(values, x => Convert.ComplexParse(x.ToString()));

                            item = EngineWrapper.CreateComplexMatrix(name, result);
                        }
                        break;
                    case RType.integer:
                        {
                            int[,] result = Convert.ConvertAll(values, x => System.Convert.ToInt32(x));

                            item = EngineWrapper.CreateIntegerMatrix(name, result);
                        }
                        break;
                    case RType.logical:
                        {
                            bool[,] result = Convert.ConvertAll(values, x => System.Convert.ToBoolean(x));

                            item = EngineWrapper.CreateLogicalMatrix(name, result);
                        }
                        break;
                    case RType.numeric:
                        {
                            double[,] result = Convert.ConvertAll(values, x => System.Convert.ToDouble(x));

                            item = EngineWrapper.CreateNumericMatrix(name, result);
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
                string[] columnTypes = null;

                if (types[0].ToString() != "ExcelDna.Integration.ExcelMissing")
                    columnTypes = Array.ConvertAll(types, x => x.ToString());

                int rows = values.GetLength(0);
                int cols = values.GetLength(1);

                if(columnTypes != null)
                {
                    if (!(cols == columnNames.Length && cols == columnTypes.Length && columnNames.Length == columnTypes.Length))
                    {
                        throw new Exception($"The number of column names ({columnNames.Length}), column types ({columnTypes.Length}) and columns ({cols}) must be the same.");
                    }
                }

                IEnumerable[] columns = new IEnumerable[cols];

                for (int c = 0; c < cols; c++)
                {
                    object[] arr = Utility.SliceColumn(values, c).ToArray();

                    string type = columnTypes != null ? columnTypes[c] : string.Empty;

                    RType rtype = DetermineType(arr[0], type);

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

                item = EngineWrapper.CreateDataFrame(name, columns, columnNames);

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

        [ExcelFunction(Name = "RScript.Params",
                        Description = "Display a list of parameters for a function",
                        HelpTopic = "")]
        public static object[,] Params(
            [ExcelArgument(Description = "Function name")] string functionName,
            [ExcelArgument(Description = "Flag to indicate whether to return types")] bool showTypes = false,
            [ExcelArgument(Description = "Flag to indicate whether to return default values")] bool showDefaults = false
            )
        {
            object[,] obj;

            try
            {
                Initialize();

                string parameterList = "params";
                string script = $"{parameterList} = as.list(formals({FunctionName(functionName)}))";

                ScriptItem result = EngineWrapper.Evaluate(script);

                if(result.EvaluationType == EvaluationType.Exception)
                {
                    obj = ProcessResult(result, script, false);
                }
                else
                {
                    result = EngineWrapper.Evaluate($"{parameterList}");

                    object[,] parameters = ProcessResult(result, script, false);

                    int rows = parameters.GetLength(0);
                    int columns = 1;
                    columns += (showTypes) ? 1 : 0;
                    columns += (showDefaults) ? 1 : 0;
                    int typesColumn = 1;
                    int defaultsColumn = (showTypes) ? 2 : 1;

                    obj = new object[rows, columns];

                    for (int row = 0; row < rows; row++)
                    {
                        string parameterName = parameters[row, 0].ToString();
                        obj[row, 0] = parameterName;

                        if (showTypes)
                        {
                            ScriptItem si = EngineWrapper.Evaluate($"typeof({parameterList}${parameterName})");
                            obj[row, typesColumn] = si.Data[0, 0];
                        }

                        if (showDefaults)
                        {
                            ScriptItem si = EngineWrapper.Evaluate($"{parameterList}${parameterName}");
                            obj[row, defaultsColumn] = (si.Data == null || si.EvaluationType == EvaluationType.Empty) ? "<missing>" : si.Data[0, 0];
                        }
                    }
                }

                EngineWrapper.Evaluate($"rm({parameterList})");
            }
            catch (Exception e)
            {
                TaskPaneManager.AddMessage(MessageType.Error, e.Message);

                obj = Convert.ReportException(e);
            }

            return obj;
        }

        //
        // Generic function evaluation
        //
        [ExcelFunction(Name = "RScript.Function",
                        Description = "Evaluate the supplied function with the parameters.",
                        HelpTopic = "")]
        public static object[,] Function(
            [ExcelArgument(Description = "The return value")] string returnValue,
            [ExcelArgument(Description = "A unique name for this model")] string functionName,
            [ExcelArgument(Description = "A 2D array containing parameter names and corresponding values")] object[,] objectParams
            )
        {
            return EvaluateFunction(returnValue, functionName, objectParams);
        }

        // Generic function to evaluate the named function using the parameters
        private static object[,] EvaluateFunction(string returnValue, string functionName, object[,] objectParams)
        {
            object[,] results;

            try
            {
                Initialize();

                Dictionary<string, object> parameters = Convert.GetParameters(objectParams);

                string parameterList = Convert.ToParameterList(parameters);

                string script = $"{Model.ModelName(returnValue)} = {FunctionName(functionName)}({parameterList})";

                ScriptItem result = EngineWrapper.Evaluate(script);

                results = ProcessResult(result, script, false);
            }
            catch (Exception e)
            {
                results = Convert.ReportException(e);
            }

            return results;
        }

        private static string FunctionName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The function name is empty.");
            }
            return name;
        }

    }
}
