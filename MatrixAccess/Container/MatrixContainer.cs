using Common.Interfaces;
using Common.MatrixIndetifiers;
using MatrixAccess.RavenDBTools;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Container
{
    public class InputMatrixContainer
    {
        private IMatrixSerializer serializer;
        public List<int[][]> matrixes;
        
        public int Size
        {
            private set;
            get;
        }

        public InputMatrixContainer()
        {
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                matrixes = serializer.LoadInputMatrix();
            }
            Size = matrixes[0].Count();
        }
    }
}
