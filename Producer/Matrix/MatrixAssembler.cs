using DataGenerator.Container;
using System.Collections.Generic;
using System.Linq;

namespace Producer.Matrix
{
    public class MatrixAssembler
    {
        private MatrixContainer container;
        private List<int[]> results = new List<int[]>();
        List<int[][]> output = new List<int[][]>();

        public MatrixAssembler(MatrixContainer container)
        {
            this.container = container;
        }

        public bool AddResult(int[] res)
        {
            if (results.Count() == container.Size)
            {
                Assembly();
                return false;
            }
            results.Add(res);
            return true;
        }

        private void Assembly()
        {
            int[][]res = new int[container.Size][];

            for (int i = 0; i < container.Size; i++)
            {
                res[i] = results[i];
            }
            output.Add(res);
        }

        List<int[][]> GetOuput()
        {
            return output;
        }
    }
}
