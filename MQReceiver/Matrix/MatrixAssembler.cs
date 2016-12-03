using Common.Results;
using DataGenerator.Container;
using System.Collections.Generic;
using System.Linq;

namespace MQReceiver.Matrix
{
    public class MatrixAssembler
    {
        private MatrixAccessor container;
        private Dictionary <int, int[]> results = new Dictionary<int, int[]>();
        List<int[][]> result = new List<int[][]>();
        private bool isOutput = false;

        public MatrixAssembler(MatrixAccessor container)
        {
            this.container = container;
        }

        public bool AddResult(CalculationResult result)
        {
            if (results.Count() == container.Size - 1)
            {
                results.Add(result.Row, result.Result);
                Assembly();
                if (!isOutput)
                {
                    container.SaveIntermediateMatrix(this.result);
                    isOutput = true;
                    results.Clear();
                    this.result.Clear();
                }
                else
                {
                    container.SaveOutputMatrix(this.result);
                    return isOutput;
                }
                return isOutput;
            }
            results.Add(result.Row, result.Result);
            return isOutput;
        }

        private void Assembly()
        {
            int[][]res = new int[container.Size][];

            for (int i = 0; i < container.Size; i++)
            {
                res[i] = results[i];
            }
            result.Add(res);
        }

        public List<int[][]> GetOuput()
        {
            return result;
        }

        public void print()
        {
            foreach (int[][] list in result)
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
