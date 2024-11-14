using NUnit.Framework;
using REngineWrapper;

namespace RDotNetProxyTest
{
    public class TestSummary
    {
        private static EngineWrapper m_engineWrapper = null;

        public TestSummary()
        {
            string path = @"D:\R\R-4.4.1\bin\x64";
            string home = @"D:\R\R-4.4.1";

            m_engineWrapper = new EngineWrapper(path, home, HostType.Word);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNumericVectorSummary()
        {
            // Arrange
            string script = "z <- rnorm(50)";
            string target = "num [1:50]";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Substring(0, 10), target);
        }

        [Test]
        public void TestIntegerVectorSummary()
        {
            // Arrange
            int begin = 1;
            int end = 15;
            string target = $"int [{begin}:{end}] 1 2 3 4 5 6 7 8 9 10";
            string script = "v <- 1:15";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestCharacterVectorSummary()
        {
            // Arrange
            string target = "chr [1:12] \"Jan\" \"Feb\" \"Mar\" \"Apr\" \"May\" \"Jun\" \"Jul\" \"Aug\" \"Sep\" \"Oct\"";
            string script = "months = c(\"Jan\", \"Feb\", \"Mar\", \"Apr\", \"May\", \"Jun\", \"Jul\", \"Aug\", \"Sep\", \"Oct\", \"Nov\", \"Dec\")";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestDateVectorSummary()
        {
            // Arrange
            string target = "Date [1:2] \"1963-02-12\" \"1968-07-13\"";
            string script = "birthday_dates <- as.Date(c('1963-02-12', '1968-07-13'))";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestLogicalVectorSummary()
        {
            // Arrange
            string target = "logi [1:3] FALSE TRUE FALSE";
            string script = "l = c(FALSE, TRUE, FALSE)";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestComplexVectorSummary()
        {
            // Arrange
            string target = "cplx [1:7] Inf+0i Inf+0i Inf+0i 1+0i 0+0i 0+0i 0+0i";
            string script = "im = 0i ^ (-3:3)";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestFactorSummary()
        {
            // Arrange
            string target = "Factor w/ 12 levels \"Jan\", \"Feb\", \"Mar\", \"Apr\", \"May\": 12 4 1 3";
            string script1 = "month_levels =  c(\"Jan\", \"Feb\", \"Mar\", \"Apr\", \"May\", \"Jun\", \"Jul\", \"Aug\", \"Sep\", \"Oct\", \"Nov\", \"Dec\")";
            string script2 = "months <- c(\"Dec\", \"Apr\", \"Jan\", \"Mar\")";
            string script3 = "res <- factor(months, levels = month_levels)";
            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            ScriptItem result = m_engineWrapper.Evaluate(script3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestDataFrameSummary()
        {
            // Arrange
            string target = "50 obs. of 2 variables";

            string script1 = "x <- rnorm(50)";
            string script2 = "y <- rnorm(50)";
            string script3 = "w <- 1 + sqrt(x)/2";
            string script4 = "df <- data.frame(x=x, y=x + rnorm(x)*w)";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            _ = m_engineWrapper.Evaluate(script3);
            ScriptItem result = m_engineWrapper.Evaluate(script4);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestFunctionSummary()
        {
            // Arrange
            string target = "function (x, y)";
            string script = "mult = function(x, y) { x * y }";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestListSummary()
        {
            // Arrange
            string target = "List of 12";

            string script1 = "x <- rnorm(50)";
            string script2 = "y <- rnorm(50)";
            string script3 = "w <- 1 + sqrt(abs(x))/2";
            string script4 = "df <- data.frame(x=x, y=x + rnorm(x)*w)";
            string script5 = "fm <- lm(y ~ x, data=df)";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            _ = m_engineWrapper.Evaluate(script3);
            _ = m_engineWrapper.Evaluate(script4);
            ScriptItem result = m_engineWrapper.Evaluate(script5);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestNumericMatrixSummary()
        {
            // Arrange
            string target = "num [1:10, 1:5]";

            string script1 = "x <- rnorm(50)";
            string script2 = "m10x5 = matrix(data=x, 10, 5)";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Substring(0, 15), target);
        }

        [Test]
        public void TestCharacterMatrixSummary()
        {
            // Arrange
            string target = "chr [1:2, 1:2] \"this\" \"is\" \"a\" \"test\"";

            string script1 = "s = c(\"this\", \"is\", \"a\", \"test\")";
            string script2 = "ms = matrix(s, 2, 2)";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestComplexMatrixSummary()
        {
            // Arrange
            string target = "cplx [1:4, 1:3] -1+0i 0-1i 1+0i 0+1i -1+0i 0-1i 1+0i 0+1i -1+0i 0-1i 1+0i 0+1i";
            string script = "cm = matrix(1i^ (-6:5), nrow = 4)";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestDateSummary()
        {
            // Arrange
            string target = "\"1963-02-12\"";
            string script = "dt <- as.Date('1963-02-12')";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }
    }
}