using Common.Generator;
using Common.MatrixIndetifiers;
using MatrixAccess.RavenDBTools;
using NUnit.Framework;
using System.Collections.Generic;

namespace MatrixAccess.Tests.IO
{
    [TestFixture]
    public class DBMatrixSerializerTests
    {
        private RavenDBMatrixSerializer serializer;
        private int matrixSize = 50;

        [SetUp]
        public void SetUp()
        {
            serializer = new RavenDBMatrixSerializer(new TestIdentifiers());
        }

        [TearDown]
        public void TearDown()
        {
            serializer.DeleteAllData();
            serializer.Dispose();
        }

        [Test]
        public void DBInputSerializerTest()
        {
            List<int[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(matrixSize);

            serializer.SaveInputMatrix(matrix);

            List<int[][]> result = serializer.LoadInputMatrix();
            CollectionAssert.AreEqual(matrix, result);
        }

        [Test]
        public void DBIntermediateSerializerTest()
        {
            List<int[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(matrixSize);
            matrix = matrix.GetRange(0, 1);
            serializer.SaveIntermediateMatrix(matrix);

            List<int[][]> result = serializer.LoadIntermediateMatrix();
            CollectionAssert.AreEqual(matrix, result);
        }

        [Test]
        public void DBOutputSerializerTest()
        {
            List<int[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(matrixSize);
            matrix = matrix.GetRange(0, 1);
            serializer.SaveOutputMatrix(matrix);

            List<int[][]> result = serializer.LoadOutputMatrix();
            CollectionAssert.AreEqual(matrix, result);
        }
    }
}
