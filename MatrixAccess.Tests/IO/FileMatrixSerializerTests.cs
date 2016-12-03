using Common.Generator;
using MatrixAccess.FilesTools;
using NUnit.Framework;
using System.Collections.Generic;

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
            List<int[][]> matrix = MatrixGen.GenerateMatrixForCalcuation(1024);

            serializer.SaveMatrix(matrix, path);

            List<int[][]> result = serializer.LoadMatrix(path);
            CollectionAssert.AreEqual(matrix, result);

            //File.Delete(path);
        }
    }
}
