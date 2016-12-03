using Common.Generator;
using Common.Interfaces;
using Common.MatrixIndetifiers;
using MatrixAccess.RavenDBTools;
using System;
using System.Linq;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            IMatrixSerializer serializer;
            if (args.Count() < 1)
            {
                throw new Exception("Matrix size has not been provide");
            }
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                serializer.SaveInputMatrix(MatrixGen.GenerateMatrixForCalcuation(int.Parse(args[0])));
            }
        }
    }
}
