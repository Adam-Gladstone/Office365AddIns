using NUnit.Framework;
using RDotNetProxy;
using REngineWrapper;
using System.Linq;
using System.Numerics;

namespace RDotNetProxyTest
{
    public class TestContentsExcel
    {
        private static EngineWrapper m_engineWrapper = null;

        // Script to fit a simple linear model. This allows us to test a variety
        // of results being returned to Excel from R.NET
        private void EvaluateStandardLinearModel()
        {
            string[] scripts = new string[4]
            {
                "x <- c(1,2,3,4,5,6,7,8,9,10)",
                "y <- c(2,3,3,5,7,1,2,3,7,9)",
                "df <- data.frame(x=x, y=y)",
                "fm <- lm(y ~ x, data=df)"
            };

            foreach (string script in scripts)
            {
                _ = m_engineWrapper.Evaluate(script);
            }
        }

        private void CreateTestLists()
        {
            string[] scripts = new string[3]
            {
                "list_data1 <- list(\"Red\", \"Green\", c(21,32,11), TRUE, 51.23, 119.1)",
                "list_data2 <- list(c(\"Jan\",\"Feb\",\"Mar\"), matrix(c(3,9,5,1,-2,8), nrow = 2), list(\"green\",12.3))",
                "names(list_data2) <- c(\"1st Quarter\", \"A_Matrix\", \"A Inner list\")"
            };

            foreach (string script in scripts)
            {
                _ = m_engineWrapper.Evaluate(script);
            }
        }

        public TestContentsExcel()
        {
            string path = @"D:\R\R-4.3.0\bin\x64";
            string home = @"D:\R\R-4.3.0";
            HostType host = HostType.Excel;

            m_engineWrapper = new EngineWrapper(path, home, host);
        }

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestLanguageContents()
        {
            // Arrange
            EvaluateStandardLinearModel();
            string script = "fm$call";
            string target = "lm(formula = y ~ x, data = df)";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data[0, 0].ToString(), target);
        }

        [Test]
        public void TestDataFrameContents()
        {
            // Arrange
            EvaluateStandardLinearModel();
            string script = "df";

            object[,] target = new object[11, 3] {
                { "Index", "x", "y" },
                { "1", 1, 2 },
                { "2", 2, 3 },
                { "3", 3, 3 },
                { "4", 4, 5 },
                { "5", 5, 7 },
                { "6", 6, 1 },
                { "7", 7, 2 },
                { "8", 8, 3 },
                { "9", 9, 7 },
                { "10", 10, 9 }
            };

            object[] target_col0 = Utility.SliceColumn(target, 0).ToArray();
            object[] target_col1 = Utility.SliceColumn(target, 1).ToArray();
            object[] target_col2 = Utility.SliceColumn(target, 2).ToArray();

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);

            object[] result_col0 = Utility.SliceColumn(result.Data, 0).ToArray();
            object[] result_col1 = Utility.SliceColumn(result.Data, 1).ToArray();
            object[] result_col2 = Utility.SliceColumn(result.Data, 2).ToArray();

            Assert.AreEqual(result_col0, target_col0);
            Assert.AreEqual(result_col1, target_col1);
            Assert.AreEqual(result_col2, target_col2);
        }

        [Test]
        public void TestListContents()
        {
            // Arrange
            EvaluateStandardLinearModel();
            string script = "fm";

            object[] target = new object[12] {
                "coefficients",
                "residuals",
                "effects",
                "rank",
                "fitted.values",
                "assign",
                "qr",
                "df.residual",
                "xlevels",
                "call",
                "terms",
                "model"
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);

            object[] result_col0 = Utility.SliceColumn(result.Data, 0).ToArray();

            Assert.AreEqual(result_col0, target);
        }

        [Test]
        public void TestEmptyListContents()
        {
            string script1 = "empty_list <- list()";
            string script2 = "empty_list";

            object[] target = new object[1] {
                "List of 0 objects."
            };

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data[0, 0], target[0]);
        }

        [Test]
        public void TestUnnamedListContents()
        {
            // Arrange
            CreateTestLists();
            string script = "list_data1";
            string target = "List of 6 objects.";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data[0, 0], target);
        }

        [Test]
        public void TestUnnamedListAccess()
        {
            // Arrange
            CreateTestLists();
            string script = "list_data1[[3]]";
            object[] target = new object[3] { 21, 32, 11 };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            object[] int_vector = Utility.SliceColumn(result.Data, 0).ToArray();
            Assert.AreEqual(int_vector, target);
        }

        [Test]
        public void TestNamedListContents()
        {
            // Arrange
            CreateTestLists();
            string script = "list_data2";

            object[] target = new object[3] {
                "1st Quarter",
                "A_Matrix",
                "A Inner list"
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);

            object[] string_vector = Utility.SliceColumn(result.Data, 0).ToArray();
            Assert.AreEqual(string_vector, target);
        }

        [Test]
        public void TestNamedListAccess()
        {
            // Arrange
            CreateTestLists();
            string script = "list_data2$A_Matrix";

            object[,] target = new object[2, 3] {
                { 3, 5, -2 },
                { 9, 1, 8 }
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data, target);
        }

        [Test]
        public void TestIntegerMatrixContents()
        {
            // Arrange
            string script = "matrix(c(5,10,15,20,25,30,35,40,45), nrow = 3)";

            object[,] target = new object[3, 3] {
                { 5,  20, 35 },
                { 10, 25, 40 },
                { 15, 30, 45 }
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data, target);
        }

        [Test]
        public void TestDoubleMatrixContents()
        {
            // Arrange
            string script = "matrix(c(5.1,10.2,15.3,20.4,25.5,30.6,35.7,40.8,45.9), nrow = 3)";

            object[,] target = new object[3, 3] {
                { 5.1,  20.4, 35.7 },
                { 10.2, 25.5, 40.8 },
                { 15.3, 30.6, 45.9 }
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data, target);
        }

        [Test]
        public void TestMatrixAccessContents()
        {
            // Arrange
            string script1 = "mat <- matrix(c(5,10,15,20,25,30,35,40,45), nrow = 3)";
            string script2 = "mat[1,]"; // row 1
            string script3 = "mat[,3]"; // col 3

            object[,] target = new object[3, 3] {
                { 5,  20, 35 },
                { 10, 25, 40 },
                { 15, 30, 45 }
            };

            object[] target_row1 = Utility.SliceRow(target, 0).ToArray();
            object[] target_col3 = Utility.SliceColumn(target, 2).ToArray();

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);

            object[] result_row1 = Utility.SliceColumn(result.Data, 0).ToArray();
            Assert.AreEqual(result_row1, target_row1);

            result = m_engineWrapper.Evaluate(script3);

            // Assert
            Assert.IsNotNull(result);

            object[] result_col3 = Utility.SliceColumn(result.Data, 0).ToArray();
            Assert.AreEqual(result_col3, target_col3);
        }

        [Test]
        public void TestCharacterMatrixContents()
        {
            // Arrange
            string script = "matrix(c(\"this\",\"is\",\"a\",\"test\"), nrow = 2)";

            object[,] target = new object[2, 2] {
                { "this", "a"  },
                { "is", "test" }
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data, target);
        }

        [Test]
        public void TestComplexMatrixContents()
        {
            // Arrange
            string script = "matrix(c(1, 2, 2+3i, 5), ncol = 2)";

            Complex[,] target = new Complex[2, 2] {
                { new Complex(1, 0), new Complex(2, 3) },
                { new Complex(2, 0), new Complex(5, 0) }
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);

            int rows = target.GetLength(0);
            int cols = target.GetLength(1);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    string complex = m_engineWrapper.GetComplexNumber(target[r, c]);
                    Assert.AreEqual(result.Data[r, c], complex);
                }
            }
        }

        [Test]
        public void TestFactorContents()
        {
            // Arrange
            string script1 = "gender <- c(\"Male\",\"Female\",\"Female\",\"Male\",\"Female\")";
            string script2 = "gender.factor <- factor(gender)";
            string script3 = "gender.factor";

            object[,] target = new object[2, 2] {
                { "1", "Female" },
                { "2", "Male" }
            };

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            ScriptItem result = m_engineWrapper.Evaluate(script3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data, target);
        }

        [Test]
        public void TestNumericVectorContents()
        {
            // Arrange
            string script1 = "i <- 1:10";
            string script2 = "i";

            object[] target_vector = new object[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            object[] numeric_vector = Utility.SliceColumn(result.Data, 0).ToArray();
            Assert.IsNotNull(result);
            Assert.AreEqual(numeric_vector, target_vector);
        }

        [Test]
        public void TestDynamicVectorContents()
        {
            // Arrange
            string script = "c(-1.2563, 0.2585, 2.2038, -0.0479, -2.2372, -0.0241, -1.8789, -1.2418, 0.2613, -0.8173)";

            object[] target_vector = new object[10] {
                -1.2563, 0.2585, 2.2038, -0.0479, -2.2372,
                -0.0241, -1.8789, -1.2418, 0.2613, -0.8173
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            object[] numeric_vector = Utility.SliceColumn(result.Data, 0).ToArray();
            Assert.IsNotNull(result);
            Assert.AreEqual(numeric_vector, target_vector);
        }

        [Test]
        public void TestLogicalVectorContents()
        {
            // Arrange
            string script = "c(FALSE, FALSE, TRUE, FALSE, TRUE)";

            object[] target_vector = new object[5] {
                false, false, true, false, true
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            object[] numeric_vector = Utility.SliceColumn(result.Data, 0).ToArray();
            Assert.IsNotNull(result);
            Assert.AreEqual(numeric_vector, target_vector);
        }

        [Test]
        public void TestComplexVectorContents()
        {
            // Arrange
            string script = "c(-1.2563-0.5202i, 0.2585+0.5388i, 2.2038+0.2251i, -0.0479-1.5559i,-2.2372-0.2356i)";

            Complex[] target_vector = new Complex[5] {
                new Complex(-1.2563, -0.5202),
                new Complex(0.2585, 0.5388),
                new Complex(2.2038, 0.2251),
                new Complex(-0.0479, -1.5559),
                new Complex(-2.2372, -0.2356)
            };

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);

            int rows = target_vector.Length;
            for (int r = 0; r < rows; r++)
            {
                string complex = m_engineWrapper.GetComplexNumber(target_vector[r]);
                Assert.AreEqual(result.Data[r, 0], complex);
            }
        }

        [Test]
        public void TestSymbolVectorContents()
        {
            // Arrange
            string script1 = "mult <- function(a, b) { return (a * b) }";
            string script2 = "mult(1:10, 1:10)";
            string script3 = "mult";

            object[,] target = new object[4, 1] {
                { "function (a, b) " },
                { "{" },
                { "    return(a * b)" },
                { "}" }
            };

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            ScriptItem result = m_engineWrapper.Evaluate(script3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data, target);
        }

        [Test]
        public void TestSymbolContents()
        {
            // Arrange
            EvaluateStandardLinearModel();
            string script = "fm$terms";

            string target = "y ~ x";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Data[0, 0].ToString(), target);
        }
    }
}
