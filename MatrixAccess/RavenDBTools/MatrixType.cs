using System.Collections.Generic;

namespace MatrixAccess.RavenDBTools
{
    internal class MatrixType
    {
        public List<int[][]> Data
        {
            private set; get;
        }

        public MatrixType(List<int[][]> data)
        {
            Data = data;
        }
    }
}
