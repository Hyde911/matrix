using Common.Tools;
using NUnit.Framework;

namespace Common.Tests.Tools
{
    [TestFixture]
    public class CalculatorTests
    {
        //private MatrixCalculator calc;
        private double[] m1;
        private double[][] m2;
        private double[] m3;

        [OneTimeSetUp]
        public void SetUp()
        {
            //calc = new MatrixCalculator();
            m1 = new double[] { 81, 20, 17, 39 };

            m2 = new double[4][];
            m2[0] = new double[] { 9, 13, 5, 71 };
            m2[1] = new double[] { 8, 43, 23, 41 };
            m2[2] = new double[] { 33, 53, 12, 44 };
            m2[3] = new double[] { 54, 21, 34, 32 };

            m3 = new double[]{3556, 3633, 2395, 8567 };
        }

        [Test]
        public void CalculateRowTest()
        {
            double[] result = MatrixCalculator.CalculateRow(m1, m2);
            CollectionAssert.AreEqual(m3, result);
        }
    }
}
