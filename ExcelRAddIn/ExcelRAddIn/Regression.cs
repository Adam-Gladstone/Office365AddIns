using ExcelDna.Integration;
using REngineWrapper;
using System;
using System.Collections.Generic;

namespace ExcelRAddIn
{
    public static class Regression
    {
        //
        // Linear Modelling
        //
        [ExcelFunction(Name = "Regression.LM",
                        Description = "Fit a linear model to the data.",
                        HelpTopic = "")]
        public static object[,] LM(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A formula")] string formula,
            [ExcelArgument(Description = "A data frame")] string dataFrame,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            object[,] results;

            try
            {
                Script.Initialize();

                string model = Model.ModelName(modelName);

                Dictionary<string, object> parameters = Convert.GetParameters(modelParams);

                string parameterList = Convert.ToParameterList(parameters);

                string script = $"{model} = lm({formula}, data = {dataFrame}, {parameterList})";

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
        // Generalised Linear Modelling
        //
        [ExcelFunction(Name = "Regression.GLM",
                        Description = "Fit a generalised linear model to the data.",
                        HelpTopic = "")]
        public static object[,] GLM(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A formula")] string formula,
            [ExcelArgument(Description = "A data frame")] string dataFrame,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            object[,] results;

            try
            {
                Script.Initialize();

                string model = Model.ModelName(modelName);

                Dictionary<string, object> parameters = Convert.GetParameters(modelParams);

                string parameterList = Convert.ToParameterList(parameters);

                string script = $"{model} = glm({formula}, data = {dataFrame}, {parameterList})";

                ScriptItem result = Script.EngineWrapper.Evaluate(script);

                results = Script.ProcessResult(result, script, false);
            }
            catch (Exception e)
            {
                results = Convert.ReportException(e);
            }

            return results;
        }
    }
}
