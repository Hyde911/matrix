using Common.Results;
using NUnit.Framework;

namespace Common.Tests.Results
{
    [TestFixture]
    public class ResultsTests
    {
        private float[] ar1 = { 13, 86, 61, 3, 97 };
        private float[] ar2 = { 76, 8, 19, 46, 7 };
        private float[] ar3 = { 76, 8, 19, 46};
        private string id1 = "id1";
        private string id2 = "id2";
        private int row = 1;
        private long time1 = 63498646L;
        private long time2 = 634646L;

        [Test]
        public void ResultEqualityTests()
        {
            CalculationResult res1 = new CalculationResult(ar1, row, time1, id1);
            CalculationResult res2 = new CalculationResult(ar1, row, time1, id1);

            Assert.AreEqual(res1, res2);

            res1 = new CalculationResult(ar1, row, time1, id1);
            res2 = new CalculationResult(ar2, row, time1, id1);

            Assert.AreNotEqual(res1, res2);

            res1 = new CalculationResult(ar1, row, time1, id1);
            res2 = new CalculationResult(ar1, row, time2, id1);

            Assert.AreNotEqual(res1, res2);

            res1 = new CalculationResult(ar1, row, time1, id1);
            res2 = new CalculationResult(ar1, row, time1, id2);

            Assert.AreNotEqual(res1, res2);

            res1 = new CalculationResult(ar2, row, time1, id1);
            res2 = new CalculationResult(ar3, row, time1, id1);

            Assert.AreNotEqual(res1, res2);

        }

        [Test]
        public void ResultSerializationTests()
        {
            CalculationResult res1 = new CalculationResult(ar1, row, time1, id1);
            CalculationResult res2 = CalculationResult.GetFromBytes(CalculationResult.ToBytes(res1));

            Assert.AreEqual(res1, res2);
        }
    }
}
