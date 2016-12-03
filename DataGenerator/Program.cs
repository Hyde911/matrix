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
                throw new Exception("Matrix size has not been provided");
            }
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                serializer.DeleteAllData();
                serializer.SaveInputMatrix(MatrixGen.GenerateMatrixForCalcuation(int.Parse(args[0])));
            }
        }
    }
}
