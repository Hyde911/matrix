using Common.Tools;
using NUnit.Framework;

namespace Common.Tests.Tools
{
    [TestFixture]
    public class CalculatorTests
    {
        private MatrixCalculator calc;
        private int[] m1;
        private int[][] m2;
        private int[] m3;

        [OneTimeSetUp]
        public void SetUp()
        {
            calc = new MatrixCalculator();
            m1 = new int[] { 81, 20, 17, 39 };

            m2 = new int[4][];
            m2[0] = new int[] { 9, 13, 5, 71 };
            m2[1] = new int[] { 8, 43, 23, 41 };
            m2[2] = new int[] { 33, 53, 12, 44 };
            m2[3] = new int[] { 54, 21, 34, 32 };

            m3 = new int []{3556, 3633, 2395, 8567 };
        }

        [Test]
        public void CalculateRowTest()
        {
            int[] result = calc.CalculateRow(m1, m2);
            CollectionAssert.AreEqual(m3, result);
        }
    }
}
