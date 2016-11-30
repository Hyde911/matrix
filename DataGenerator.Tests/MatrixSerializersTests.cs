using DataGenerator.Generator;
using DataGenerator.IO;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace DataGenerator.Tests.Tests
{
    [TestFixture]
    public class MatrixSerializersTests
    {
        [Test]
        public void SerializerTest()
        {
            string path = @"D:\test.txt";
            List<int[][]> matrix = MatrixGenerator.GenerateMatrixForCalcuation(10);

            MatrixSerializer.SaveMatrix(matrix, path);

            List<int[][]> result = MatrixSerializer.LoadMatrix(path);
            CollectionAssert.AreEqual(matrix, result);

            File.Delete(path);
        }
    }
}
