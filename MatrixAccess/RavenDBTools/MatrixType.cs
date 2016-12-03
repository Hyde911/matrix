using System.Collections.Generic;

namespace MatrixAccess.RavenDBTools
{
    internal class MatrixType
    {
        public List<float[][]> Data
        {
            private set; get;
        }

        public MatrixType(List<float[][]> data)
        {
            Data = data;
        }
    }
}
