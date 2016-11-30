using DataGenerator.Generator;
using DataGenerator.IO;
using System.Collections.Generic;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[][]> matrix = MatrixGenerator.GenerateMatrixForCalcuation(int.Parse(args[0]));
            Serializer.SaveMatrix(matrix);
        }
    }
}
