using ExcelDna.Integration;
using REngineWrapper;
using System;
using System.Collections.Generic;

namespace ExcelRAddIn
{
    public static class Forecast
    {
        // Generic function to construct an R script from input parameters
        private static object[,] EvaluateModel(string function, string modelName, string seriesName, object[,] modelParams)
        {
            object[,] results;

            try
            {
                Script.Initialize();

                string model = Model.ModelName(modelName);

                Dictionary<string, object> parameters = Convert.GetParameters(modelParams);

                string parameterList = $"{seriesName}, {Convert.ToParameterList(parameters)}";

                string script = $"{model} = {function}({parameterList})";

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
        // Moving Average
        //
        [ExcelFunction(Name = "Forecast.MA",
                        Description = "Moving average smoothing.",
                        HelpTopic = "")]
        public static object[,] MA(
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            object[,] results;
            try
            {
                Script.Initialize();

                Dictionary<string, object> parameters = Convert.GetParameters(modelParams);

                string parameterList = $"{seriesName}, {Convert.ToParameterList(parameters)}";

                string script = $"ma({parameterList})";

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
        // Simple Exponential Smoothing
        //
        [ExcelFunction(Name = "Forecast.SES",
                        Description = "Simple Exponential Smoothing.",
                        HelpTopic = "")]
        public static object[,] SES(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("ses", modelName, seriesName, modelParams);
        }

        //
        // Holt Exponential Smoothing
        //
        [ExcelFunction(Name = "Forecast.Holt",
                        Description = "Holt Exponential Smoothing.",
                        HelpTopic = "")]
        public static object[,] Holt(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("holt", modelName, seriesName, modelParams);
        }

        //
        // Holt-Winters Exponential Smoothing
        //
        [ExcelFunction(Name = "Forecast.HW",
                        Description = "Holt-Winters Exponential Smoothing.",
                        HelpTopic = "")]
        public static object[,] HW(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("hw", modelName, seriesName, modelParams);
        }

        //
        // ETS - Exponential smoothing state space model
        //
        [ExcelFunction(Name = "Forecast.AutoETS",
                        Description = "Exponential smoothing state space model.",
                        HelpTopic = "")]
        public static object[,] AutoETS(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("ets", modelName, seriesName, modelParams);
        }

        //
        // ARIMA - Auto-Regressive Integrated Moving Average model
        //
        [ExcelFunction(Name = "Forecast.Arima",
                        Description = "Auto-Regressive Integrated Moving Average model.",
                        HelpTopic = "")]
        public static object[,] Arima(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("Arima", modelName, seriesName, modelParams);
        }

        //
        // Auto ARIMA - Fit best ARIMA model to univariate time series
        //
        [ExcelFunction(Name = "Forecast.AutoArima",
                        Description = "Fit best ARIMA model to univariate time series.",
                        HelpTopic = "")]
        public static object[,] AutoArima(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("auto.arima", modelName, seriesName, modelParams);
        }

        //
        // Forecast - generic function for forecasting from time series or time series models
        //
        [ExcelFunction(Name = "Forecast.FC",
                        Description = "Generic function for forecasting from time series or time series models.",
                        HelpTopic = "")]
        public static object[,] FC(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("forecast", modelName, seriesName, modelParams);
        }

        //
        // meanf - mean forecast
        //
        [ExcelFunction(Name = "Forecast.meanf",
                        Description = "Mean forecast.",
                        HelpTopic = "")]
        public static object[,] Meanf(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("meanf", modelName, seriesName, modelParams);
        }

        //
        // rwf - forecasts and prediction intervals for a random walk with drift model
        //
        [ExcelFunction(Name = "Forecast.rwf",
                        Description = "Forecasts and prediction intervals for a random walk with drift model.",
                        HelpTopic = "")]
        public static object[,] Rwf(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("rwf", modelName, seriesName, modelParams);
        }

        //
        // splinef - local linear forecasts and prediction intervals using cubic smoothing splines
        //
        [ExcelFunction(Name = "Forecast.splinef",
                        Description = "Local linear forecasts and prediction intervals using cubic smoothing splines.",
                        HelpTopic = "")]
        public static object[,] Splinef(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("splinef", modelName, seriesName, modelParams);
        }

        //
        // thetaf - forecasts and prediction intervals for a theta method forecast
        //
        [ExcelFunction(Name = "Forecast.thetaf",
                        Description = "Forecasts and prediction intervals for a theta method forecast.",
                        HelpTopic = "")]
        public static object[,] Thetaf(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("thetaf", modelName, seriesName, modelParams);
        }

        //
        // croston - forecasts and other information for Croston's forecasts
        //
        [ExcelFunction(Name = "Forecast.Croston",
                        Description = "Forecasts and other information for Croston’s forecasts.",
                        HelpTopic = "")]
        public static object[,] Croston(
            [ExcelArgument(Description = "A unique name for this model")] string modelName,
            [ExcelArgument(Description = "A vector of observations")] string seriesName,
            [ExcelArgument(Description = "A 2D array containing optional parameter names and corresponding values")] object[,] modelParams
            )
        {
            return EvaluateModel("croston", modelName, seriesName, modelParams);
        }
    }
}
