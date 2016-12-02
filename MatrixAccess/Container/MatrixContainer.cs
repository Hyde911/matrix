using DataGenerator.IO;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Container
{
    public class MatrixContainer
    {
        public List<int[][]> matrixes;
        
        public int Size
        {
            private set;
            get;
        }

        public MatrixContainer()
        {
            //matrixes = MatrixSerializer.LoadInputMatrix();
            //Size = matrixes[0].Count();
        }
    }
}
