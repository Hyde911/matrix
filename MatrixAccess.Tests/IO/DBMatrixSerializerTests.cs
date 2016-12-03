using Common.Generator;
using Common.MatrixIndetifiers;
using MatrixAccess.RavenDBTools;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
            List<float[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(matrixSize);

            serializer.SaveInputMatrix(matrix);

            List<float[][]> result = serializer.LoadInputMatrix();
            for (int i = 0; i < matrix.Count(); i++)
            {
                for (int j = 0; j < matrix[i].Count(); j++)
                {
                    for (int k = 0; k < matrix[i][j].Count(); k++)
                    {
                        Assert.AreEqual(matrix[i][j][k], result[i][j][k], 0.0000000001);
                    }
                }
            }
        }

        [Test]
        public void DBIntermediateSerializerTest()
        {
            List<float[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(matrixSize);
            matrix = matrix.GetRange(0, 1);
            serializer.SaveIntermediateMatrix(matrix);

            List<float[][]> result = serializer.LoadIntermediateMatrix();
            for (int i = 0; i < matrix.Count(); i++)
            {
                for (int j = 0; j < matrix[i].Count(); j++)
                {
                    for (int k = 0; k < matrix[i][j].Count(); k++)
                    {
                        Assert.AreEqual(matrix[i][j][k], result[i][j][k], 0.0000000001);
                    }
                }
            }
        }

        [Test]
        public void DBOutputSerializerTest()
        {
            List<float[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(matrixSize);
            matrix = matrix.GetRange(0, 1);
            serializer.SaveOutputMatrix(matrix);

            List<float[][]> result = serializer.LoadOutputMatrix();
            for (int i = 0; i < matrix.Count(); i++)
            {
                for (int j = 0; j < matrix[i].Count(); j++)
                {
                    for (int k = 0; k < matrix[i][j].Count(); k++)
                    {
                        Assert.AreEqual(matrix[i][j][k], result[i][j][k], 0.0000000001);
                    }
                }
            }
        }
    }
}
