using Common.Results;
using DataGenerator.Container;
using System.Collections.Generic;
using System.Linq;

namespace MQReceiver.Matrix
{
    public class MatrixAssembler
    {
        private MatrixContainer container;
        private Dictionary <int, int[]> results = new Dictionary<int, int[]>();
        List<int[][]> output = new List<int[][]>();

        public MatrixAssembler(MatrixContainer container)
        {
            this.container = container;
        }

        public bool AddResult(CalculationResult result)
        {
            if (results.Count() == container.Size - 1)
            {
                results.Add(result.Row, result.Result);
                Assembly();
                //print();
                return false;
            }
            results.Add(result.Row, result.Result);
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

        public List<int[][]> GetOuput()
        {
            return output;
        }

        public void print()
        {
            foreach (int[][] list in output)
            {
                foreach (int[] arr in list)
                {
                   foreach (int i in arr)
                    {
                        System.Console.Write(i + "\t");
                    }
                    System.Console.WriteLine("");
                }
            }
        }
    }
}
