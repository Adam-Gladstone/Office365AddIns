using ExcelDna.Integration;
using REngineWrapper;
using System;

namespace ExcelRAddIn
{
    public static class Model
    {
        //
        // Get list of results for a specific model
        //
        [ExcelFunction(Name = "Model.Results",
                        Description = "Retrieve a list of the computed results for the specified model.",
                        HelpTopic = "")]
        public static object[,] Results(
            [ExcelArgument(Description = "The model name")] string modelName
            )
        {
            object[,] results;
            try
            {
                Script.Initialize();

                string script = $"{ModelName(modelName)}";

                ScriptItem result = Script.EngineWrapper.Evaluate(script);

                results = Script.ProcessResult(result, script, false);
            }
            catch (Exception e)
            {
                results = Convert.ReportException(e);
            }

            return results;
        }

        //
        // Get a named result for a specified model
        //
        [ExcelFunction(Name = "Model.Result",
                        Description = "Get a named result for the specified model.",
                        HelpTopic = "")]
        public static object[,] Result(
            [ExcelArgument(Description = "The model name")] string modelName,
            [ExcelArgument(Description = "The result key")] string result1,
            [ExcelArgument(Description = "The sub-result key")] string result2,
            [ExcelArgument(Description = "Flag to indicate whether to return the results as a data frame")] bool asDataFrame = false
            )
        {
            object[,] results;
            try
            {
                Script.Initialize();

                string components = string.Empty;

                if (string.IsNullOrEmpty(result1))
                {
                    components = $"{ModelName(modelName)}";
                }
                else
                {
                    components = $"{ModelName(modelName)}${ResultKey(result1)}";
                    if (!string.IsNullOrEmpty(result2))
                    {
                        components += $"${ResultKey(result2)}";
                    }
                }

                string script = asDataFrame ? $"as.data.frame({components})" : $"({components})";

                ScriptItem res = Script.EngineWrapper.Evaluate(script);

                results = Script.ProcessResult(res, script, false);
            }
            catch (Exception e)
            {
                results = Convert.ReportException(e);
            }

            return results;
        }

        //
        // Accuracy function
        //
        [ExcelFunction(Name = "Model.Accuracy",
                        Description = "Retrieve accuracy measures for a forecast model.",
                        HelpTopic = "")]
        public static object[,] Accuracy(
            [ExcelArgument(Description = "A unique name for this model")] string modelName
            )
        {
            object[,] results;

            try
            {
                Script.Initialize();

                string _modelName = ModelName(modelName);

                string script = $"as.data.frame(accuracy({_modelName}))";

                ScriptItem result = Script.EngineWrapper.Evaluate(script);

                results = Script.ProcessResult(result, script, false);
            }
            catch (Exception e)
            {
                results = Convert.ReportException(e);
            }

            return results;
        }

        public static string ModelName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("The model name is empty.");
            }
            return name;
        }

        public static string ResultKey(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                throw new ArgumentException("The result key is empty.");
            }
            return result;
        }

        public static double? GetValue(double value)
        {
            if (value == 0.0)
                return null;
            else
                return value;
        }
    }
}
