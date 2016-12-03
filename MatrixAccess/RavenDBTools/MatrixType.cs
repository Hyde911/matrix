using System.Collections.Generic;

namespace MatrixAccess.RavenDBTools
{
    internal class MatrixType
    {
        public List<double[][]> Data
        {
            private set; get;
        }

        public MatrixType(List<double[][]> data)
        {
            Data = data;
        }
    }
}
