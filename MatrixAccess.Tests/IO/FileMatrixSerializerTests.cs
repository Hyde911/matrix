using DataGenerator.IO;
using MatrixGenerator.Generator;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace MatrixAccess.Tests.Tests
{
    [TestFixture]
    public class FileMatrixSerializerTests
    {
        private FileMatrixSerializer serializer;

        [OneTimeSetUp]
        public void SetUp()
        {
            serializer = new FileMatrixSerializer();
        }

        [Test]
        public void InputFileSerializerTest()
        {
            string path = @"D:\test.txt";
            List<int[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(10);

            serializer.SaveMatrix(matrix, path);

            List<int[][]> result = serializer.LoadMatrix(path);
            CollectionAssert.AreEqual(matrix, result);

            File.Delete(path);
        }
    }
}
