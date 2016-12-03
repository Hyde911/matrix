using Common.Interfaces;
using Common.MatrixIndetifiers;
using MatrixAccess.RavenDBTools;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Container
{
    public class MatrixContainer
    {
        private IMatrixSerializer serializer;
        public List<int[][]> matrixes;
        
        public int Size
        {
            private set;
            get;
        }

        public MatrixContainer()
        {
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                matrixes = serializer.LoadInputMatrix();
            }
            Size = matrixes[0].Count();
        }
    }
}
