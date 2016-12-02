using MatrixAccess.IO;
using MatrixGenerator.Generator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAccess.Tests.IO
{
    [TestFixture]
    public class DBMatrixSerializerTests
    {
        DBMatrixSerializer serializer;

        [OneTimeSetUp]
        public void SetUp()
        {
            serializer = new DBMatrixSerializer();
        }

        [Test]
        public void DBInputFileSerializerTest()
        {
            List<int[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(10);

            serializer.SaveInputMatrix(matrix);

            List<int[][]> result = serializer.LoadInputMatrix();
            CollectionAssert.AreEqual(matrix, result);

        }
    }
}
