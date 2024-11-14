using NUnit.Framework;
using REngineWrapper;
using System.Text;

namespace RDotNetProxyTest
{
    public class TestContentsWord
    {
        private static EngineWrapper m_engineWrapper = null;

        public TestContentsWord()
        {
            string path = @"D:\R\R-4.4.1\bin\x64";
            string home = @"D:\R\R-4.4.1";
            HostType host = HostType.Word;

            m_engineWrapper = new EngineWrapper(path, home, host);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDataFrameContents1()
        {
            // Arrange
            string target = "Index\tmonth\ttemperature\thumidity\train\r\n1\t\"January\"\t20.37\t88\t72\r\n2\t\"February\"\t18.56\t86\t33.9\r\n3\t\"March\"\t18.4\t81\t37.5\r\n4\t\"April\"\t21.96\t79\t36.6\r\n5\t\"May\"\t29.53\t80\t31\r\n6\t\"June\"\t28.16\t78\t16.6\r\n7\t\"July\"\t36.38\t71\t1.2\r\n8\t\"August\"\t36.62\t69\t6.8\r\n9\t\"September\"\t40.03\t78\t36.8\r\n10\t\"October\"\t27.59\t82\t30.8\r\n11\t\"November\"\t22.15\t85\t38.5\r\n12\t\"December\"\t19.85\t83\t22.7\r\n";

            string script1 = "temp <- c(20.37, 18.56, 18.4, 21.96, 29.53, 28.16, 36.38, 36.62, 40.03, 27.59, 22.15, 19.85)";
            string script2 = "humidity <- c(88, 86, 81, 79, 80, 78, 71, 69, 78, 82, 85, 83)";
            string script3 = "rain <- c(72, 33.9, 37.5, 36.6, 31.0, 16.6, 1.2, 6.8, 36.8, 30.8, 38.5, 22.7)";
            string script4 = "month <- c(\"January\", \"February\", \"March\", \"April\", \"May\", \"June\", \"July\", \"August\", \"September\", \"October\", \"November\", \"December\")";
            string script5 = "data <- data.frame(month = month, temperature = temp, humidity = humidity, rain = rain)";
            string script6 = "data";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            _ = m_engineWrapper.Evaluate(script3);
            _ = m_engineWrapper.Evaluate(script4);
            _ = m_engineWrapper.Evaluate(script5);

            ScriptItem result = m_engineWrapper.Evaluate(script6);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestDataFrameContents2()
        {
            // Arrange
            string target = "Index\tmpg\tcyl\tdisp\thp\tdrat\twt\tqsec\tvs\tam\tgear\tcarb\r\nMazda RX4\t21\t6\t160\t110\t3.9\t2.62\t16.46\t0\t1\t4\t4\r\nMazda RX4 Wag\t21\t6\t160\t110\t3.9\t2.875\t17.02\t0\t1\t4\t4\r\nDatsun 710\t22.8\t4\t108\t93\t3.85\t2.32\t18.61\t1\t1\t4\t1\r\nHornet 4 Drive\t21.4\t6\t258\t110\t3.08\t3.215\t19.44\t1\t0\t3\t1\r\nHornet Sportabout\t18.7\t8\t360\t175\t3.15\t3.44\t17.02\t0\t0\t3\t2\r\nValiant\t18.1\t6\t225\t105\t2.76\t3.46\t20.22\t1\t0\t3\t1\r\nDuster 360\t14.3\t8\t360\t245\t3.21\t3.57\t15.84\t0\t0\t3\t4\r\nMerc 240D\t24.4\t4\t146.7\t62\t3.69\t3.19\t20\t1\t0\t4\t2\r\nMerc 230\t22.8\t4\t140.8\t95\t3.92\t3.15\t22.9\t1\t0\t4\t2\r\nMerc 280\t19.2\t6\t167.6\t123\t3.92\t3.44\t18.3\t1\t0\t4\t4\r\nMerc 280C\t17.8\t6\t167.6\t123\t3.92\t3.44\t18.9\t1\t0\t4\t4\r\nMerc 450SE\t16.4\t8\t275.8\t180\t3.07\t4.07\t17.4\t0\t0\t3\t3\r\nMerc 450SL\t17.3\t8\t275.8\t180\t3.07\t3.73\t17.6\t0\t0\t3\t3\r\nMerc 450SLC\t15.2\t8\t275.8\t180\t3.07\t3.78\t18\t0\t0\t3\t3\r\nCadillac Fleetwood\t10.4\t8\t472\t205\t2.93\t5.25\t17.98\t0\t0\t3\t4\r\nLincoln Continental\t10.4\t8\t460\t215\t3\t5.424\t17.82\t0\t0\t3\t4\r\nChrysler Imperial\t14.7\t8\t440\t230\t3.23\t5.345\t17.42\t0\t0\t3\t4\r\nFiat 128\t32.4\t4\t78.7\t66\t4.08\t2.2\t19.47\t1\t1\t4\t1\r\nHonda Civic\t30.4\t4\t75.7\t52\t4.93\t1.615\t18.52\t1\t1\t4\t2\r\nToyota Corolla\t33.9\t4\t71.1\t65\t4.22\t1.835\t19.9\t1\t1\t4\t1\r\nToyota Corona\t21.5\t4\t120.1\t97\t3.7\t2.465\t20.01\t1\t0\t3\t1\r\nDodge Challenger\t15.5\t8\t318\t150\t2.76\t3.52\t16.87\t0\t0\t3\t2\r\nAMC Javelin\t15.2\t8\t304\t150\t3.15\t3.435\t17.3\t0\t0\t3\t2\r\nCamaro Z28\t13.3\t8\t350\t245\t3.73\t3.84\t15.41\t0\t0\t3\t4\r\nPontiac Firebird\t19.2\t8\t400\t175\t3.08\t3.845\t17.05\t0\t0\t3\t2\r\nFiat X1-9\t27.3\t4\t79\t66\t4.08\t1.935\t18.9\t1\t1\t4\t1\r\nPorsche 914-2\t26\t4\t120.3\t91\t4.43\t2.14\t16.7\t0\t1\t5\t2\r\nLotus Europa\t30.4\t4\t95.1\t113\t3.77\t1.513\t16.9\t1\t1\t5\t2\r\nFord Pantera L\t15.8\t8\t351\t264\t4.22\t3.17\t14.5\t0\t1\t5\t4\r\nFerrari Dino\t19.7\t6\t145\t175\t3.62\t2.77\t15.5\t0\t1\t5\t6\r\nMaserati Bora\t15\t8\t301\t335\t3.54\t3.57\t14.6\t0\t1\t5\t8\r\nVolvo 142E\t21.4\t4\t121\t109\t4.11\t2.78\t18.6\t1\t1\t4\t2\r\n";
            string script = "datasets::mtcars";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestFactorContents()
        {
            // Arrange
            string target = "[1] Dec Apr Jan Mar\r\nLevels: Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec\r\n";
            string script1 = "month_levels =  c(\"Jan\", \"Feb\", \"Mar\", \"Apr\", \"May\", \"Jun\", \"Jul\", \"Aug\", \"Sep\", \"Oct\", \"Nov\", \"Dec\")";
            string script2 = "months <- c(\"Dec\", \"Apr\", \"Jan\", \"Mar\")";
            string script3 = "res <- factor(months, levels = month_levels)";
            string script4 = "res";

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
        public void TestListUnnamedContents()
        {
            // Arrange
            string target = "[[1]]\r\n[1]\t2\r\n\r\n[[2]]\r\n[1]\t\"hello\"\r\n\r\n[[3]]\r\n[1]\t3\r\n[2]\t5\r\n[3]\t4\r\n\r\n[[4]]\r\n[1]\t1\r\n[2]\t2\r\n[3]\t3\r\n[4]\t4\r\n[5]\t5\r\n\r\n[[5]]\r\n[[5]][[1]]\r\n[1]\tFALSE\r\n\r\n[[5]][[2]]\r\n[1]\t\"this\"\r\n[2]\t\"is\"\r\n[3]\t\"a\"\r\n[4]\t\"list\"\r\n\r\n[[5]][[3]]\r\n[1]\tFALSE\r\n[2]\tTRUE\r\n[3]\tTRUE\r\n[4]\tTRUE\r\n[5]\tFALSE\r\n\r\n\r\n";
            string script1 = "contents <- list(2, \"hello\", c(3,5,4), 1:5, list(FALSE, c(\"this\", \"is\",\"a\",\"list\"), c(FALSE,TRUE,TRUE,TRUE,FALSE)))";
            string script2 = "contents";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestListNamedContents()
        {
            // Arrange
            string target = "$'a_number'\r\n[1]\t2\r\n\r\n$'a_string'\r\n[1]\t\"hello\"\r\n\r\n$'num_vector'\r\n[1]\t3\r\n[2]\t5\r\n[3]\t4\r\n\r\n$'int_vector'\r\n[1]\t1\r\n[2]\t2\r\n[3]\t3\r\n[4]\t4\r\n[5]\t5\r\n\r\n$'another_list'\r\n$'another_list'[[1]]\r\n[1]\tFALSE\r\n\r\n$'another_list'[[2]]\r\n[1]\t\"this\"\r\n[2]\t\"is\"\r\n[3]\t\"a\"\r\n[4]\t\"list\"\r\n\r\n$'another_list'[[3]]\r\n[1]\tFALSE\r\n[2]\tTRUE\r\n[3]\tTRUE\r\n[4]\tTRUE\r\n[5]\tFALSE\r\n\r\n\r\n";
            string script1 = "contents <- list(2, \"hello\", c(3,5,4), 1:5, list(FALSE, c(\"this\", \"is\",\"a\",\"list\"), c(FALSE,TRUE,TRUE,TRUE,FALSE)))";
            string script2 = "names(contents) <- c('a_number', 'a_string', 'num_vector', 'int_vector', 'another_list')";
            string script3 = "contents";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            ScriptItem result = m_engineWrapper.Evaluate(script3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestNumericMatrixContents()
        {
            // Arrange
            string target = "\t[,1]\t[,2]\t[,3]\r\n[1,]\t-0.34180658\t2.1111479\t-0.8190803\r\n[2,]\t-0.01864779\t1.4969163\t1.0727442\r\n[3,]\t1.28198919\t-0.2296665\t-0.1584962\r\n";

            string script1 = "x <- c(-0.34180658, -0.01864779, 1.28198919, 2.1111479, 1.4969163, -0.2296665, -0.8190803, 1.0727442, -0.1584962)";
            string script2 = "mx = matrix(data=x, 3, 3)";
            string script3 = "mx";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            ScriptItem result = m_engineWrapper.Evaluate(script3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestCharacterMatrixContents()
        {
            // Arrange
            string target = "\t[,1]\t[,2]\r\n[1,]\t\"this\"\t\"a\"\r\n[2,]\t\"is\"\t\"test\"\r\n";

            string script1 = "s = c(\"this\", \"is\", \"a\", \"test\")";
            string script2 = "ms = matrix(s, 2, 2)";
            string script3 = "ms";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            _ = m_engineWrapper.Evaluate(script2);
            ScriptItem result = m_engineWrapper.Evaluate(script3);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestComplexMatrixContents()
        {
            // Arrange
            string target = "\t[,1]\t[,2]\t[,3]\r\n[1,]\t-1+0i\t-1+0i\t-1+0i\r\n[2,]\t0-1i\t0-1i\t0-1i\r\n[3,]\t1+0i\t1+0i\t1+0i\r\n[4,]\t0+1i\t0+1i\t0+1i\r\n";

            string script1 = "cm = matrix(1i^ (-6:5), nrow = 4)";
            string script2 = "cm";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestNumericVectorContents()
        {
            // Arrange
            string target = "[1]\t-0.34180658\r\n[2]\t-0.01864779\r\n[3]\t1.28198919\r\n[4]\t2.1111479\r\n[5]\t1.4969163\r\n[6]\t-0.2296665\r\n[7]\t-0.8190803\r\n[8]\t1.0727442\r\n[9]\t-0.1584962\r\n";

            string script1 = "x <- c(-0.34180658, -0.01864779, 1.28198919, 2.1111479, 1.4969163, -0.2296665, -0.8190803, 1.0727442, -0.1584962)";
            string script2 = "x";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestIntegerVectorContents()
        {
            // Arrange: add 'x' to the environment
            m_engineWrapper.Evaluate("x <- 1:15");

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 15; i++)
            {
                sb.AppendLine($"[{i}]\t{i}");
            }

            string target = sb.ToString();
            string script = "x";

            // Act
            ScriptItem result = m_engineWrapper.Evaluate(script);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestCharacterVectorContents()
        {
            // Arrange
            string target = "[1]\t\"Jan\"\r\n[2]\t\"Feb\"\r\n[3]\t\"Mar\"\r\n[4]\t\"Apr\"\r\n[5]\t\"May\"\r\n[6]\t\"Jun\"\r\n[7]\t\"Jul\"\r\n[8]\t\"Aug\"\r\n[9]\t\"Sep\"\r\n[10]\t\"Oct\"\r\n[11]\t\"Nov\"\r\n[12]\t\"Dec\"\r\n";
            string script1 = "months = c(\"Jan\", \"Feb\", \"Mar\", \"Apr\", \"May\", \"Jun\", \"Jul\", \"Aug\", \"Sep\", \"Oct\", \"Nov\", \"Dec\")";
            string script2 = "months";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestLogicalVectorContents()
        {
            // Arrange
            string target = "[1]\tFALSE\r\n[2]\tTRUE\r\n[3]\tFALSE\r\n";
            string script1 = "l = c(FALSE, TRUE, FALSE)";
            string script2 = "l";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }

        [Test]
        public void TestComplexVectorContents()
        {
            // Arrange
            string target = "[1]\tInf+0i\r\n[2]\tInf+0i\r\n[3]\tInf+0i\r\n[4]\t1+0i\r\n[5]\t0+0i\r\n[6]\t0+0i\r\n[7]\t0+0i\r\n";

            string script1 = "im = 0i ^ (-3:3)";
            string script2 = "im";

            // Act
            _ = m_engineWrapper.Evaluate(script1);
            ScriptItem result = m_engineWrapper.Evaluate(script2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content, target);
        }
    }
}
