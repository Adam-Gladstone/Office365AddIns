using RDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace REngineWrapper
{
    public enum HostType
    {
        Excel,
        Word
    }

    public enum EvaluationType
    {
        Unknown,
        Exception,
        Value,
        Vector,
        List,
        Function,
        Frame,
        Matrix,
        Language,
        Factor,
        Symbol,
        Empty,
        Remove
    }

    public class TypeInfo
    {
        public TypeInfo(string type, string rclass)
        {
            _type = type;
            _rclass = rclass;
        }

        public string Type { get { return _type; } }
        public string RClass { get { return _rclass; } }

        public string GetSummaryType()
        {
            string summary;
            switch (_type)
            {
                case "character":
                    summary = "chr";
                    break;

                case "integer":
                    summary = "int";
                    break;

                case "double":
                    summary = (_rclass == "Date") ? "Date" : "num";
                    break;

                case "logical":
                    summary = "logi";
                    break;

                case "complex":
                    summary = "cplx";
                    break;

                default:
                    summary = string.Empty;
                    break;
            }
            return summary;
        }

        private readonly string _type;
        private readonly string _rclass;
    }

    // model
    public class ScriptItem
    {
        public EvaluationType EvaluationType { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public object[,] Data { get; set; }
    }

    public class EngineWrapper
    {
        private static readonly DateTime Origin = new DateTime(1970, 1, 1);

        public HostType HostType { get; private set; }

        public REngine Engine { get; private set; }

        public EngineWrapper(string path, string home, HostType host)
        {
            HostType = host;

            if (Engine == null)
            {
                REngine.SetEnvironmentVariables(path, home);

                Engine = REngine.GetInstance();
                Engine.Initialize();

                // https://github.com/rdotnet/rdotnet/issues/151
                // Workaround - explicitly include R libs in PATH so R environment can find them.
                // Not sure why R can't find them when we set this via Environment.SetEnvironmentVariable
                string normalized_path = path.Replace("\\", "/");
                Engine.Evaluate($"Sys.setenv(PATH = paste(\"{normalized_path}\", Sys.getenv(\"PATH\"), sep=\";\"))");
            }
        }

        ~EngineWrapper()
        {
            Engine?.Dispose();
        }

        public ScriptItem Evaluate(string script)
        {
            Tuple<bool, string, string> operationType = ExtractName(script);
            bool hasAssignment = operationType.Item1;
            string name = operationType.Item2;
            string function = operationType.Item3;

            try
            {
                SymbolicExpression expression = Engine.Evaluate(script);

                if (expression == null || expression.IsInvalid)
                {
                    return new ScriptItem()
                    {
                        EvaluationType = EvaluationType.Exception,
                        Name = name,
                        Content = "Invalid expression."
                    };
                }

                if (expression.Type == RDotNet.Internals.SymbolicExpressionType.Null)
                {
                    return new ScriptItem()
                    {
                        EvaluationType = (function == "rm") ? EvaluationType.Remove : EvaluationType.Empty,
                        Name = name
                    };
                }

                ScriptItem result = null;

                if (hasAssignment)
                {
                    result = GetSummary(expression, name, script, function);
                }
                else
                {
                    switch (HostType)
                    {
                        case HostType.Excel:
                            result = GetContentsAsObject(expression, name);
                            break;
                        case HostType.Word:
                            result = GetContentsAsString(expression, name, "");
                            break;
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return new ScriptItem()
                {
                    EvaluationType = EvaluationType.Exception,
                    Name = name,
                    Content = e.Message
                };
            }
        }

        private ScriptItem GetSummary(SymbolicExpression expression, string name, string script = "", string function = "")
        {
            try
            {
                TypeInfo ti = new TypeInfo(GetTypeOf(name), GetClassOf(name));

                ScriptItem result = null;

                if (expression.IsLanguage())
                {
                    result = GetSummary(expression.AsLanguage(), name, function);
                }
                else if (expression.IsDataFrame())
                {
                    result = GetSummary(expression.AsDataFrame(), name);
                }
                else if (expression.IsFactor())
                {
                    result = GetSummary(expression.AsFactor(), name);
                }
                else if (expression.IsFunction())
                {
                    result = GetSummary(expression.AsFunction(), name, script);
                }
                else if (expression.IsList())
                {
                    result = GetSummary(expression.AsList(), name);
                }
                else if (expression.IsMatrix())
                {
                    if (ti.Type == "double" || ti.Type == "integer")
                    {
                        result = GetMatrixSummary<NumericMatrix, double>(expression.AsNumericMatrix(), name, ti);
                    }
                    else if (ti.Type == "character")
                    {
                        result = GetMatrixSummary<CharacterMatrix, string>(expression.AsCharacterMatrix(), name, ti);
                    }
                    else if (ti.Type == "complex")
                    {
                        result = GetMatrixSummary<ComplexMatrix, Complex>(expression.AsComplexMatrix(), name, ti);
                    }
                    else
                    {
                        result = new ScriptItem()
                        {
                            EvaluationType = EvaluationType.Unknown,
                            Name = name,
                            Content = "Unable to display the summary. Unhandled matrix type."
                        };
                    }
                }
                else if (expression.IsVector())
                {
                    if (ti.Type == "double")
                    {
                        result = GetVectorSummary<DynamicVector, object>(expression.AsVector(), name, ti);
                    }
                    else if (ti.Type == "integer")
                    {
                        result = GetVectorSummary<IntegerVector, int>(expression.AsInteger(), name, ti);
                    }
                    else if (ti.Type == "logical")
                    {
                        result = GetVectorSummary<LogicalVector, bool>(expression.AsLogical(), name, ti);
                    }
                    else if (ti.Type == "complex")
                    {
                        result = GetVectorSummary<ComplexVector, Complex>(expression.AsComplex(), name, ti);
                    }
                    else if (ti.Type == "character")
                    {
                        result = GetVectorSummary<CharacterVector, string>(expression.AsCharacter(), name, ti);
                    }
                    else
                    {
                        result = new ScriptItem()
                        {
                            EvaluationType = EvaluationType.Unknown,
                            Name = name,
                            Content = "Unable to display the summary. Unhandled vector type."
                        };
                    }
                }
                else if (expression.IsSymbol())
                {
                    result = GetSummary(expression.AsSymbol(), name);
                }
                else if (expression.IsS4())
                {
                    result = GetSummary(expression.AsS4(), name, ti);
                }
                else if (expression.IsEnvironment())
                {
                    result = GetSummary(expression.AsEnvironment(), name);
                }
                else
                {
                    result = new ScriptItem()
                    {
                        EvaluationType = EvaluationType.Unknown,
                        Name = name,
                        Content = "Unable to summarize expression. Unknown expression type."
                    };
                }

                return result;
            }
            catch (Exception e)
            {
                return new ScriptItem()
                {
                    EvaluationType = EvaluationType.Exception,
                    Name = name,
                    Content = e.Message
                };
            }
        }

        //
        // Retrieve summary strings of the items added to the R environment. This emulates 
        // the formatting used in RStudio.
        //
        private ScriptItem GetSummary(DataFrame df, string name)
        {
            return new ScriptItem()
            {
                EvaluationType = EvaluationType.Frame,
                Name = name,
                Content = $"{df.GetRows().Count()} obs. of {df.ColumnCount} variables",
            };
        }

        private ScriptItem GetSummary(Factor f, string name)
        {
            ScriptItem result = new ScriptItem()
            {
                EvaluationType = EvaluationType.Factor,
                Name = name,
            };

            string[] levels = Engine.Evaluate($"levels({name})").AsCharacter().ToArray();

            result.Content = $"Factor w/ {levels.Count()} levels ";

            for (int i = 0; i < Math.Min(5, levels.Count()); i++)
            {
                if (i > 0)
                    result.Content += ", ";
                result.Content += $"\"{levels[i]}\"";
            }

            result.Content += ": ";

            IntegerVector v = (IntegerVector)f;
            int rows = v.Count();
            for (int r = 0; r < Math.Min(5, rows); r++)
            {
                if (r > 0)
                    result.Content += " ";
                result.Content += v[r].ToString();
            }

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetSummary(Function f, string name, string script)
        {
            return new ScriptItem()
            {
                EvaluationType = EvaluationType.Function,
                Name = name,
                Content = $"function {ExtractParameterList(script)}"
            };
        }

        private ScriptItem GetSummary(GenericVector v, string name)
        {
            return new ScriptItem()
            {
                EvaluationType = EvaluationType.List,
                Name = name,
                Content = $"List of {v.Count()}"
            };
        }

        private ScriptItem GetMatrixSummary(RawMatrix m, string name, TypeInfo ti)
        {
            ScriptItem result = new ScriptItem
            {
                EvaluationType = EvaluationType.Matrix,
                Name = name,
                Content = $"{ti.GetSummaryType()} [{1}:{m.RowCount}, {1}:{m.ColumnCount}] "
            };

            for (int c = 0; c < Math.Min(10, m.ColumnCount); c++)
            {
                if (c > 0)
                    result.Content += " ";

                for (int r = 0; r < Math.Min(10, m.RowCount); r++)
                {
                    if (r > 0)
                        result.Content += " ";

                    result.Content += GetValue(m[r, c], ti);
                }
            }

            return result;
        }

        private ScriptItem GetMatrixSummary<MatrixType, UnderlyingType>(MatrixType m, string name, TypeInfo ti)
            where MatrixType : Matrix<UnderlyingType>
        {
            ScriptItem result = new ScriptItem
            {
                EvaluationType = EvaluationType.Matrix,
                Name = name,
                Content = $"{ti.GetSummaryType()} [{1}:{m.RowCount}, {1}:{m.ColumnCount}] "
            };

            for (int c = 0; c < Math.Min(10, m.ColumnCount); c++)
            {
                if (c > 0)
                    result.Content += " ";

                for (int r = 0; r < Math.Min(10, m.RowCount); r++)
                {
                    if (r > 0)
                        result.Content += " ";

                    result.Content += GetValue(m[r, c], ti);
                }
            }

            return result;
        }

        private ScriptItem GetVectorSummary<VectorType, UnderlyingType>(VectorType v, string name, TypeInfo ti)
            where VectorType : Vector<UnderlyingType>
        {
            ScriptItem result = new ScriptItem()
            {
                EvaluationType = EvaluationType.Vector,
                Name = name
            };

            int rows = v.Count();

            result.Content = rows > 1 ? $"{ti.GetSummaryType()} [{1}:{rows}] " : "";

            for (int i = 0; i < Math.Min(10, rows); i++)
            {
                if (i > 0)
                    result.Content += " ";

                string value = GetValue(v[i], ti);

                result.Content += value;
            }

            return result;
        }

        private ScriptItem GetSummary(Symbol s, string name)
        {
            ScriptItem result = new ScriptItem()
            {
                EvaluationType = EvaluationType.Symbol,
                Name = name,
                Content = s.PrintName
            };

            return result;
        }

        private ScriptItem GetSummary(Language l, string name, string function)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Language, Name = name };

            Pairlist call = l.FunctionCall;
            if (call != null)
            {
                foreach (var item in call)
                {
                    if (item != null)
                    {
                        if (item.Type == RDotNet.Internals.SymbolicExpressionType.Symbol)
                        {
                            Symbol s = (Symbol)item;
                            function += s.PrintName;
                        }
                        else
                        {
                            function += item.PrintName.ToString();
                            function += ", ";
                        }
                    }
                }
            }

            result.Content = function;
            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetSummary(S4Object s4, string name, TypeInfo ti)
        {
            ScriptItem result = new ScriptItem
            {
                EvaluationType = EvaluationType.Symbol,
                Name = name,
                Content = $"Formal class {ti.RClass}"
            };

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetSummary(REnvironment e, string name)
        {
            ScriptItem result = new ScriptItem()
            {
                EvaluationType = EvaluationType.Symbol,
                Name = name,
                Content = "Environment"
            };

            return result;
        }

        //
        // Retrieve the contents from the evaluated script
        // 
        private ScriptItem GetContentsAsObject(SymbolicExpression expression, string name)
        {
            try
            {
                ScriptItem result = null;

                TypeInfo ti = new TypeInfo(GetTypeOf(name), GetClassOf(name));

                if (expression.IsLanguage())
                {
                    result = GetContentsAsObject(expression.AsLanguage(), name);
                }
                else if (expression.IsDataFrame())
                {
                    result = GetContentsAsObject(expression.AsDataFrame(), name, ti);
                }
                else if (expression.IsList())
                {
                    result = GetContentsAsObject(expression.AsList(), name);
                }
                else if (expression.IsMatrix())
                {
                    if (ti.Type == "double" || ti.Type == "integer")
                    {
                        result = GetMatrixContentsAsObject<NumericMatrix, double>(expression.AsNumericMatrix(), name, ti);
                    }
                    else if (ti.Type == "character")
                    {
                        result = GetMatrixContentsAsObject<CharacterMatrix, string>(expression.AsCharacterMatrix(), name, ti);
                    }
                    else if (ti.Type == "complex")
                    {
                        result = GetMatrixContentsAsObject<ComplexMatrix, Complex>(expression.AsComplexMatrix(), name, ti);
                    }
                    else
                    {
                        result = new ScriptItem()
                        {
                            EvaluationType = EvaluationType.Unknown,
                            Name = name,
                            Content = "Unable to display the contents. Unhandled matrix type."
                        };
                    }
                }
                else if (expression.IsFactor())
                {
                    result = GetContentsAsObject(expression.AsFactor(), name);
                }
                else if (expression.IsVector())
                {
                    if (ti.Type == "double")
                    {
                        result = GetVectorContentsAsObject<DynamicVector, object>(expression.AsVector(), name, ti);
                    }
                    else if (ti.Type == "integer")
                    {
                        result = GetVectorContentsAsObject<IntegerVector, int>(expression.AsInteger(), name, ti);
                    }
                    else if (ti.Type == "logical")
                    {
                        result = GetVectorContentsAsObject<LogicalVector, bool>(expression.AsLogical(), name, ti);
                    }
                    else if (ti.Type == "complex")
                    {
                        result = GetVectorContentsAsObject<ComplexVector, Complex>(expression.AsComplex(), name, ti);
                    }
                    else if (ti.Type == "character" || ti.Type == "language" || ti.Type == "closure")
                    {
                        result = GetVectorContentsAsObject<CharacterVector, string>(expression.AsCharacter(), name, ti);
                    }
                    else if (ti.Type == "symbol")
                    {
                        result = GetContentsAsObject(expression.AsSymbol(), name);
                    }
                    else
                    {
                        result = new ScriptItem()
                        {
                            EvaluationType = EvaluationType.Unknown,
                            Name = name,
                            Content = "Unable to display the contents. Unhandled vector type."
                        };
                    }
                }
                else if (expression.IsSymbol())
                {
                    result = GetContentsAsObject(expression.AsSymbol(), name);
                }
                else if (expression.IsFunction())
                {
                    result = GetContentsAsObject(expression.AsFunction(), name);
                }
                else if (expression.IsS4())
                {
                    result = GetContentsAsObject(expression.AsS4(), name);
                }
                else if (expression.IsEnvironment())
                {
                    result = GetContentsAsObject(expression.AsEnvironment(), name);
                }
                else
                {
                    result = new ScriptItem()
                    {
                        EvaluationType = EvaluationType.Unknown,
                        Name = name,
                        Content = "Unable to display the contents. Unknown expression type."
                    };
                }

                return result;
            }
            catch (Exception e)
            {
                return new ScriptItem()
                {
                    EvaluationType = EvaluationType.Exception,
                    Name = name,
                    Content = e.Message
                };
            }
        }

        private ScriptItem GetContentsAsObject(DataFrame df, string name, TypeInfo ti)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            int rows = df.GetRows().Count();
            int cols = df.ColumnCount;

            // Decorate rows and columns with names
            result.Data = new object[rows + 1, cols + 1];

            string[] colNames = df.ColumnNames;
            string[] rowNames = df.RowNames;

            result.Data[0, 0] = "Index";

            for (int r = 0; r < rows; r++)
            {
                result.Data[r + 1, 0] = rowNames[r];

                for (int c = 0; c < cols; c++)
                {
                    result.Data[0, c + 1] = colNames[c];

                    result.Data[r + 1, c + 1] = GetObject(df[r, c], ti);
                }
            }

            return result;
        }

        private ScriptItem GetMatrixContentsAsObject<MatrixType, UnderlyingType>(MatrixType m, string name, TypeInfo ti)
            where MatrixType : Matrix<UnderlyingType>
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            int rows = m.RowCount;
            int cols = m.ColumnCount;

            result.Data = new object[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    result.Data[r, c] = GetObject(m[r, c], ti);
                }
            }

            return result;
        }

        private ScriptItem GetVectorContentsAsObject<VectorType, UnderlyingType>(VectorType v, string name, TypeInfo ti)
            where VectorType : Vector<UnderlyingType>
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            int rows = v.Count();

            result.Data = new object[rows, 1];

            for (int r = 0; r < rows; r++)
            {
                result.Data[r, 0] = GetObject(v[r], ti);
            }

            return result;
        }

        private ScriptItem GetContentsAsObject(GenericVector v, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            int rows = v.Count();

            if (rows == 0)
            {
                result.Data = new object[1, 1];
                result.Data[0, 0] = $"List of {rows} {((rows != 1) ? "objects" : "object")}.";
            }
            else
            {
                string[] names = null;
                SymbolicExpression exp = Engine.Evaluate($"names({name})");
                if (exp != null && exp.Type != RDotNet.Internals.SymbolicExpressionType.Null)
                {
                    names = exp.AsCharacter().ToArray();
                }

                if (names != null && names.Length > 0)
                {
                    result.Data = new object[rows, 1];
                    for (int r = 0; r < rows; r++)
                    {
                        result.Data[r, 0] = names[r];
                    }
                }
                else
                {
                    result.Data = new object[1, 1];
                    result.Data[0, 0] = $"List of {rows} {((rows != 1) ? "objects" : "object")}.";
                }
            }

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetContentsAsObject(Factor f, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            string[] levels = Engine.Evaluate($"levels({name})").AsCharacter().ToArray();

            int rows = levels.Count();

            result.Data = new object[rows, 2];

            for (int r = 0; r < rows; r++)
            {
                result.Data[r, 0] = (r + 1).ToString();
                result.Data[r, 1] = levels[r];
            }

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetContentsAsObject(Language l, string name)
        {
            ScriptItem result = new ScriptItem
            {
                EvaluationType = EvaluationType.Value,
                Name = name,
                Data = new object[1, 1]
            };

            SymbolicExpression expression = Engine.Evaluate($"deparse({name})");
            if (expression != null && expression.Type != RDotNet.Internals.SymbolicExpressionType.Null)
            {
                ScriptItem item = GetContentsAsObject(expression, name);
                result.Data[0, 0] = item != null ? item.Data[0, 0] : "<empty>";
            }

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetContentsAsObject(Symbol s, string name)
        {
            ScriptItem result = new ScriptItem
            {
                EvaluationType = EvaluationType.Value,
                Name = name,
                Data = new object[1, 1]
            };

            SymbolicExpression expression = Engine.Evaluate($"deparse({name})");
            if (expression != null && expression.Type != RDotNet.Internals.SymbolicExpressionType.Null)
            {
                ScriptItem item = GetContentsAsObject(expression, name);
                result.Data[0, 0] = item != null ? item.Data[0, 0] : "<empty>";
            }

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetContentsAsObject(Function f, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            SymbolicExpression expression = Engine.Evaluate($"deparse({name})");
            if (expression != null && expression.Type != RDotNet.Internals.SymbolicExpressionType.Null)
            {
                ScriptItem item = GetContentsAsObject(expression, name);
                if (item.Data != null)
                {
                    int rows = item.Data.GetLength(0);
                    int cols = item.Data.GetLength(1);
                    result.Data = new object[rows, cols];

                    for (int r = 0; r < rows; r++)
                    {
                        result.Data[r, 0] = item.Data[r, 0];
                    }
                }
                else
                {
                    result.Data = new object[1, 1];
                    result.Data[0, 0] = "<empty>";
                }
            }

            return result;
        }

        private ScriptItem GetContentsAsObject(S4Object s4, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            string[] names = s4.SlotNames;

            if (names != null)
            {
                int rows = names.Length;
                result.Data = new object[rows, 1];

                for (int r = 0; r < rows; r++)
                {
                    result.Data[r, 0] = names[r];
                }
            }
            else
            {
                result.Data = new object[1, 1];
                result.Data[0, 0] = "No slot names in S4 class.";
            }
            return result;
        }

        private ScriptItem GetContentsAsObject(REnvironment e, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            string[] names = e.GetSymbolNames();

            if (names != null)
            {
                int rows = names.Length;
                result.Data = new object[rows, 1];

                for (int r = 0; r < rows; r++)
                {
                    result.Data[r, 0] = names[r];
                }
            }
            else
            {
                result.Data = new object[1, 1];
                result.Data[0, 0] = $"No symbol names in {name}.";
            }

            return result;
        }

        //
        // Retrieve the results of the evaluated script as a block of text (string)
        //
        private ScriptItem GetContentsAsString(SymbolicExpression expression, string name, string index)
        {
            try
            {
                ScriptItem result = null;

                TypeInfo ti = new TypeInfo(GetTypeOf(name), GetClassOf(name));

                if (expression.IsLanguage())
                {
                    result = GetContentsAsString(expression.AsLanguage(), name);
                }
                else if (expression.IsDataFrame())
                {
                    result = GetContentsAsString(expression.AsDataFrame(), name, ti);
                }
                else if (expression.IsList())
                {
                    result = GetContentsAsString(expression.AsList(), name, index);
                }
                else if (expression.IsMatrix())
                {
                    if (ti.Type == "double" || ti.Type == "integer")
                    {
                        result = GetMatrixContentsAsString<NumericMatrix, double>(expression.AsNumericMatrix(), name, ti);
                    }
                    else if (ti.Type == "character")
                    {
                        result = GetMatrixContentsAsString<CharacterMatrix, string>(expression.AsCharacterMatrix(), name, ti);
                    }
                    else if (ti.Type == "complex")
                    {
                        result = GetMatrixContentsAsString<ComplexMatrix, Complex>(expression.AsComplexMatrix(), name, ti);
                    }
                    else
                    {
                        result = new ScriptItem()
                        {
                            EvaluationType = EvaluationType.Unknown,
                            Name = name,
                            Content = "Unable to display the contents. Unhandled matrix type."
                        };
                    }
                }
                else if (expression.IsFactor())
                {
                    result = GetContentsAsString(expression.AsFactor(), name, ti);
                }
                else if (expression.IsVector())
                {
                    if (ti.Type == "double")
                    {
                        result = GetVectorContentsAsString<DynamicVector, object>(expression.AsVector(), name, ti);
                    }
                    else if (ti.Type == "integer")
                    {
                        result = GetVectorContentsAsString<IntegerVector, int>(expression.AsInteger(), name, ti);
                    }
                    else if (ti.Type == "logical")
                    {
                        result = GetVectorContentsAsString<LogicalVector, bool>(expression.AsLogical(), name, ti);
                    }
                    else if (ti.Type == "complex")
                    {
                        result = GetVectorContentsAsString<ComplexVector, Complex>(expression.AsComplex(), name, ti);
                    }
                    else if (ti.Type == "character" || ti.Type == "language" || ti.Type == "closure")
                    {
                        result = GetVectorContentsAsString<CharacterVector, string>(expression.AsCharacter(), name, ti);
                    }
                    else if (ti.Type == "symbol")
                    {
                        result = GetContentsAsString(expression.AsSymbol(), name);
                    }
                    else
                    {
                        result = new ScriptItem()
                        {
                            EvaluationType = EvaluationType.Unknown,
                            Name = name,
                            Content = "Unable to display the contents. Unhandled vector type."
                        };
                    }
                }
                else if (expression.IsSymbol())
                {
                    result = GetContentsAsString(expression.AsSymbol(), name);
                }
                else if (expression.IsFunction())
                {
                    result = GetContentsAsString(expression.AsFunction(), name);
                }
                else if (expression.IsS4())
                {
                    result = GetContentsAsString(expression.AsS4(), name, ti);
                }
                else if (expression.IsEnvironment())
                {
                    result = GetContentsAsString(expression.AsEnvironment(), name);
                }
                else
                {
                    result = new ScriptItem()
                    {
                        EvaluationType = EvaluationType.Unknown,
                        Name = name,
                        Content = "Unable to display the contents. Unknown expression type."
                    };
                }

                return result;
            }
            catch (Exception e)
            {
                return new ScriptItem()
                {
                    EvaluationType = EvaluationType.Exception,
                    Name = name,
                    Content = e.Message
                };
            }
        }

        private ScriptItem GetContentsAsString(DataFrame df, string name, TypeInfo ti)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            int rows = df.GetRows().Count();
            int cols = df.ColumnCount;

            StringBuilder sb = new StringBuilder();

            string[] colNames = df.ColumnNames;
            string[] rowNames = df.RowNames;

            string header = "Index\t";
            header += string.Join("\t", colNames);
            sb.AppendLine(header);

            for (int r = 0; r < rows; r++)
            {
                string row = "";

                // Add index or row name
                row += string.IsNullOrEmpty(rowNames[r]) ? (r + 1).ToString() : rowNames[r];
                row += '\t';

                for (int c = 0; c < cols; c++)
                {
                    if (c > 0)
                        row += '\t';

                    string value = GetValue(df[r, c], ti);

                    row += value;
                }
                sb.AppendLine(row);
            }
            result.Content = sb.ToString();

            return result;
        }

        private ScriptItem GetMatrixContentsAsString<MatrixType, UnderlyingType>(MatrixType m, string name, TypeInfo ti)
            where MatrixType : Matrix<UnderlyingType>
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            int rows = m.RowCount;
            int cols = m.ColumnCount;

            StringBuilder sb = new StringBuilder();

            string header = "\t";
            for (int c = 0; c < cols; c++)
            {
                if (c > 0)
                    header += '\t';
                header += $"[,{(c + 1)}]";
            }

            sb.AppendLine(header);

            for (int r = 0; r < rows; r++)
            {
                string row = $"[{(r + 1)},]\t";

                for (int c = 0; c < cols; c++)
                {
                    if (c > 0)
                        row += '\t';

                    string value = GetValue(m[r, c], ti);

                    row += value;
                }
                sb.AppendLine(row);
            }
            result.Content = sb.ToString();

            return result;
        }

        private ScriptItem GetVectorContentsAsString<VectorType, UnderlyingType>(VectorType v, string name, TypeInfo ti)
            where VectorType : Vector<UnderlyingType>
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            StringBuilder sb = new StringBuilder();

            int rows = v.Count();
            if (rows == 0)
            {
                string row = $"numeric({rows})";
                sb.AppendLine(row);
            }

            for (int r = 0; r < rows; r++)
            {
                string row = $"[{(r + 1)}]\t";
                string value = GetValue(v[r], ti);

                row += value;

                sb.AppendLine(row);
            }
            result.Content = sb.ToString();

            return result;
        }

        private ScriptItem GetContentsAsString(GenericVector v, string name, string index)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            StringBuilder sb = new StringBuilder();

            int rows = v.Count();
            if (rows == 0)
            {
                string row = "list()";  // Empty list
                sb.AppendLine(row);
            }
            else
            {
                string[] names = null;
                SymbolicExpression exp = Engine.Evaluate($"names({name})");
                if (exp != null && exp.Type != RDotNet.Internals.SymbolicExpressionType.Null)
                {
                    names = exp.AsCharacter().ToArray();
                }

                for (int r = 0; r < rows; r++)
                {
                    string row_num = $"[[{(r + 1)}]]";
                    string row_name = (names == null) ? "" : $"$'{names[r]}'";
                    string row_id = string.IsNullOrEmpty(row_name) ? row_num : row_name;
                    string attributeName = (names == null) ? $"{name}{row_num}" : $"{name}{row_name}";

                    string row = (names == null) ? $"{index}{row_num}" : row_name;
                    row += "\r\n";

                    SymbolicExpression expression = (SymbolicExpression)v[r];
                    ScriptItem item = GetContentsAsString(expression, attributeName, row_id);

                    row += item.Content;

                    sb.AppendLine(row);
                }
            }

            result.Content = sb.ToString();

            return result;
        }

        private ScriptItem GetContentsAsString(Factor f, string name, TypeInfo ti)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            string[] levels = Engine.Evaluate($"levels({name})").AsCharacter().ToArray();

            StringBuilder sb = new StringBuilder();

            IntegerVector v = (IntegerVector)f;
            int rows = v.Count();

            int r = 0;
            string row = $"[{(r + 1)}] ";
            for (; r < rows; r++)
            {
                if (r > 0)
                    row += " ";

                string value = GetValue(v[r], ti, levels);

                row += value;
            }
            sb.AppendLine(row);

            string levelString = "Levels: ";
            levelString += string.Join(" ", levels);
            sb.AppendLine(levelString);

            result.Content = sb.ToString();

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetContentsAsString(Language l, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            StringBuilder sb = new StringBuilder();

            SymbolicExpression expression = Engine.Evaluate($"deparse({name})");
            if (expression != null && expression.Type != RDotNet.Internals.SymbolicExpressionType.Null)
            {
                ScriptItem item = GetContentsAsString(expression, name, "");
                sb.AppendLine(item.Content);
            }

            result.Content = sb.ToString();

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetContentsAsString(Symbol s, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            StringBuilder sb = new StringBuilder();

            SymbolicExpression expression = Engine.Evaluate($"deparse({name})");
            if (expression != null && expression.Type != RDotNet.Internals.SymbolicExpressionType.Null)
            {
                ScriptItem item = GetContentsAsString(expression, name, "");
                sb.AppendLine(item.Content);
            }

            result.Content = sb.ToString();

            return result;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        private ScriptItem GetContentsAsString(Function f, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            StringBuilder sb = new StringBuilder();

            SymbolicExpression expression = Engine.Evaluate($"deparse({name})");
            if (expression != null && expression.Type != RDotNet.Internals.SymbolicExpressionType.Null)
            {
                ScriptItem item = GetContentsAsString(expression, name, "");
                sb.AppendLine(item.Content);
            }

            result.Content = sb.ToString();

            return result;
        }

        private ScriptItem GetContentsAsString(S4Object s4, string name, TypeInfo ti)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"An object of class \"{ti.RClass}\"");

            string[] names = s4.SlotNames;
            if (names != null)
            {
                int rows = names.Length;
                for (int r = 0; r < rows; r++)
                {
                    string slot_name = names[r];
                    string row_name = $"Slot \"{slot_name}\":";
                    sb.AppendLine(row_name);

                    SymbolicExpression expression = (SymbolicExpression)s4[slot_name];
                    string object_name = $"{name}@{slot_name}";
                    ScriptItem item = GetContentsAsString(expression, object_name, "");
                    sb.AppendLine(item.Content);
                }
            }
            else
            {
                sb.AppendLine("No slot names in S4 class.");
            }

            result.Content = sb.ToString();

            return result;
        }

        private ScriptItem GetContentsAsString(REnvironment e, string name)
        {
            ScriptItem result = new ScriptItem() { EvaluationType = EvaluationType.Value, Name = name };

            StringBuilder sb = new StringBuilder();

            string[] names = e.GetSymbolNames();
            if (names != null)
            {
                int rows = names.Length;
                for (int r = 0; r < rows; r++)
                {
                    sb.AppendLine(names[r]);
                }
            }
            else
            {
                sb.AppendLine($"No symbol names in environment {name}.");
            }

            result.Content = sb.ToString();

            return result;
        }

        //
        // Utility functions
        // 

        // Retrieve a complex number in a string format that Excel can process.
        public string GetComplexNumber(Complex c)
        {
            double real = c.Real;
            double imaginary = c.Imaginary;
            string sign = (imaginary >= 0.0) ? "+" : "-";
            imaginary = Math.Abs(imaginary);

            string s_real = double.IsInfinity(real) ? "Inf" : real.ToString();
            string s_imaginary = double.IsInfinity(imaginary) ? "Inf" : imaginary.ToString();

            string number = $"{s_real}{sign}{s_imaginary}i";
            return number;
        }

        private string GetTypeOf(string name)
        {
            string type = string.IsNullOrEmpty(name) ? "" : Engine.Evaluate($"typeof({name})").AsCharacter().First();
            return type;
        }

        private string GetClassOf(string name)
        {
            string cls = string.IsNullOrEmpty(name) ? "" : Engine.Evaluate($"class({name})").AsCharacter().First();
            return cls;
        }


        private Tuple<bool, string, string> ExtractName(string script)
        {
            string name;
            string function = "";
            bool hasAssignment = false;

            int pos = script.IndexOf("<-", 0);
            if (pos == -1)
            {
                pos = script.IndexOf("->", 0);
                if (pos == -1)
                {
                    // Assignments can occur within parameter lists
                    int pos_lparen = script.IndexOf('(');
                    pos = script.IndexOf("=", 0);
                    bool posBeforeLParenIfPresent = true;
                    if (pos_lparen > -1)
                        posBeforeLParenIfPresent = pos < pos_lparen;

                    if (pos != -1 && posBeforeLParenIfPresent)
                    {
                        hasAssignment = true;
                        name = script.Substring(0, pos);
                        function = script.Substring(pos + 1, script.Length - pos - 1);
                    }
                    else
                    {
                        name = script;
                        if (pos_lparen != -1)
                        {
                            function = script.Substring(0, pos_lparen);
                        }
                    }
                }
                else
                {
                    hasAssignment = true;
                    name = script.Substring(pos + 2, script.Length - (pos + 2));
                    function = script.Substring(0, pos);
                }
            }
            else
            {
                hasAssignment = true;
                name = script.Substring(0, pos);
                function = script.Substring(pos + 2, script.Length - (pos + 2));
            }

            return new Tuple<bool, string, string>(hasAssignment, name.Trim(), function.Trim());
        }

        private string ExtractParameterList(string script)
        {
            string parameters = "";

            int pos_start = script.IndexOf("(", 0);
            if (pos_start != -1)
            {
                int pos_end = script.IndexOf(")", pos_start + 1);
                if (pos_end != -1)
                {
                    parameters = script.Substring(pos_start, pos_end - pos_start + 1);
                }
            }

            return parameters.Trim();
        }

        private object GetObject(object obj, TypeInfo ti)
        {
            object value = null;

            if (obj != null)
            {
                if (ti.Type == "double" && ti.RClass == "Date")
                {
                    DateTime dateTime = Origin.AddDays((double)obj);
                    value = dateTime.ToString("yyyy-MM-dd");  // ISO 8601
                }
                else
                {
                    if (obj is string || obj is int || obj is long || obj is bool)
                    {
                        value = obj;
                    }
                    else if (obj is float || obj is double)
                    {
                        double d = (double)obj;
                        if (double.IsNaN(d))
                        {
                            value = string.Empty;
                        }
                        else
                        {
                            value = obj;
                        }
                    }
                    else if (obj is Complex c)
                    {
                        value = GetComplexNumber(c);
                    }
                    else
                    {
                        value = "<unhandled object type>";
                    }
                }
            }

            return value;
        }

        private string GetValue(object obj, TypeInfo ti, string[] levels = null)
        {
            bool hasLevels = levels != null && levels.Length > 0;

            string value = "";

            if (obj != null)
            {
                if (ti.Type == "double" && ti.RClass == "Date")
                {
                    DateTime dateTime = Origin.AddDays((double)obj);
                    value = $"\"{dateTime:yyyy-MM-dd}\"";   // ISO 8601
                }
                else
                {
                    if (obj is string)
                    {
                        value = $"\"{(string)obj}\"";
                    }
                    else if (obj is int || obj is long)
                    {
                        if (hasLevels)
                        {
                            int index = (int)obj;
                            value = levels[index - 1];
                        }
                        else
                        {
                            value = obj.ToString();
                        }
                    }
                    else if (obj is float || obj is double)
                    {
                        double d = (double)obj;
                        if (double.IsNaN(d))
                        {
                            value = "";
                        }
                        else
                        {
                            value = obj.ToString();
                        }
                    }
                    else if (obj is bool)
                    {
                        // False -> FALSE, True -> TRUE
                        value = obj.ToString().ToUpper();
                    }
                    else if (obj is Complex c)
                    {
                        value = GetComplexNumber(c);
                    }
                    else
                    {
                        value = "<unhandled object type>";
                    }
                }
            }

            return value;
        }

        public string[] ExtractParameters(string script)
        {
            string parameters = "";

            int pos_start = script.IndexOf("(", 0);
            if (pos_start != -1)
            {
                int pos_end = script.IndexOf(")", pos_start + 1);
                if (pos_end != -1)
                {
                    parameters = script.Substring(pos_start, pos_end - pos_start + 1);
                }
            }

            parameters = parameters.Trim(new char[] { '(', ')' });
            return parameters.Split(',');
        }

        //
        // Create containers
        //

        public ScriptItem CreateCharacterVector(string name, IEnumerable<string> vector)
        {
            CharacterVector v = Engine.CreateCharacterVector(vector);

            Engine.SetSymbol(name, v);

            ScriptItem item = GetSummary(v, name);

            return item;
        }

        public ScriptItem CreateComplexVector(string name, IEnumerable<Complex> vector)
        {
            ComplexVector v = Engine.CreateComplexVector(vector);

            Engine.SetSymbol(name, v);

            ScriptItem item = GetSummary(v, name);

            return item;
        }

        public ScriptItem CreateIntegerVector(string name, IEnumerable<int> vector)
        {
            IntegerVector v = Engine.CreateIntegerVector(vector);

            Engine.SetSymbol(name, v);

            ScriptItem item = GetSummary(v, name);

            return item;
        }

        public ScriptItem CreateLogicalVector(string name, IEnumerable<bool> vector)
        {
            LogicalVector v = Engine.CreateLogicalVector(vector);

            Engine.SetSymbol(name, v);

            ScriptItem item = GetSummary(v, name);

            return item;
        }

        public ScriptItem CreateNumericVector(string name, IEnumerable<double> vector)
        {
            NumericVector v = Engine.CreateNumericVector(vector);

            Engine.SetSymbol(name, v);

            ScriptItem item = GetSummary(v, name);

            return item;
        }

        public ScriptItem CreateCharacterMatrix(string name, string[,] matrix)
        {
            CharacterMatrix m = Engine.CreateCharacterMatrix(matrix);

            Engine.SetSymbol(name, m);

            ScriptItem item = GetSummary(m, name);

            return item;
        }

        public ScriptItem CreateComplexMatrix(string name, Complex[,] matrix)
        {
            //
            // NOTE The call to the base ctor is specified incorrectly
            // line 111, C:\Users\adam_\AppData\Local\Temp\MetadataAsSource\2b4382f34fb14c828e29b569c0d4a54c\DecompilationMetadataAsSourceFileProvider\92e76432b2af44f6881f0596eb34e6c8\ComplexMatrix.cs
            // SymbolicExpressionType.CharacterVector  <-- should be ComplexVector

            // m = MatrixSize = 2 x 2; RObjectType = CharacterVector
            // ComplexMatrix m = Engine.CreateComplexMatrix(matrix);

            // Workaround for the issue above. We need the correct type in order to unpack the matrix items
            // into a summary string. GetSummary sees the matrix as a CharacterVector and casts the expression
            // accordingly using .AsCharacterMatrix(). The exception is caused when accessing the matrix elements
            // via m[r, c].
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            ComplexMatrix m = Engine.CreateComplexMatrix(rows, cols);

            for (int c = 0; c < cols; c++) {
                for (int r = 0; r < rows; r++) {
                    m[r, c] = matrix[r, c];
                }
            }

            Engine.SetSymbol(name, m);

            ScriptItem item = GetSummary(m, name);

            return item;
        }

        public ScriptItem CreateIntegerMatrix(string name, int[,] matrix)
        {
            IntegerMatrix m = Engine.CreateIntegerMatrix(matrix);

            Engine.SetSymbol(name, m);

            ScriptItem item = GetSummary(m, name);

            return item;
        }

        public ScriptItem CreateLogicalMatrix(string name, bool[,] matrix)
        {
            LogicalMatrix m = Engine.CreateLogicalMatrix(matrix);

            Engine.SetSymbol(name, m);

            ScriptItem item = GetSummary(m, name);

            return item;
        }

        public ScriptItem CreateNumericMatrix(string name, double[,] matrix)
        {
            NumericMatrix m = Engine.CreateNumericMatrix(matrix);

            Engine.SetSymbol(name, m);

            ScriptItem item = GetSummary(m, name);

            return item;
        }

        public ScriptItem CreateDataFrame(string name, IEnumerable[] values, string[] headers)
        {
            var df = Engine.CreateDataFrame(values, headers);

            Engine.SetSymbol(name, df);

            ScriptItem item = GetSummary(df, name);

            return item;
        }

    }
}
