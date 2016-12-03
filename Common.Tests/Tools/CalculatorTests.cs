using Common.Tools;
using NUnit.Framework;

namespace Common.Tests.Tools
{
    [TestFixture]
    public class CalculatorTests
    {
        //private MatrixCalculator calc;
        private float[] m1;
        private float[][] m2;
        private float[] m3;

        [OneTimeSetUp]
        public void SetUp()
        {
            //calc = new MatrixCalculator();
            m1 = new float[] { 81, 20, 17, 39 };

            m2 = new float[4][];
            m2[0] = new float[] { 9, 13, 5, 71 };
            m2[1] = new float[] { 8, 43, 23, 41 };
            m2[2] = new float[] { 33, 53, 12, 44 };
            m2[3] = new float[] { 54, 21, 34, 32 };

            m3 = new float[]{3556, 3633, 2395, 8567 };
        }

        [Test]
        public void CalculateRowTest()
        {
            float[] result = MatrixCalculator.CalculateRow(m1, m2);
            CollectionAssert.AreEqual(m3, result);
        }
    }
}
