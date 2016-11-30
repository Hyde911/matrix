using Common.Results;
using System.Diagnostics;
using System.Linq;

namespace Common.Tools
{
    public class MatrixCalculator
    {
        private Stopwatch watch = new Stopwatch();
        /// <summary>
        /// calculates product of multiplication of vector and matrix
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public int[] CalculateRow(int[] m1, int[][] m2)
        {
            int rows = m1.Count();
            int columns = m2[0].Count();
            int[] result = new int[columns];

                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        result[j] += m1[k] * m2[k][j];
                    }
                }
        return result;
        }

        public CalculationResult DoCalculation(int[]m1, int[][]m2, string id, int row)
        {
            int[] result;
            watch.Reset();
            watch.Start();
            result = CalculateRow(m1, m2);
            watch.Stop();
            return new CalculationResult(result, row, watch.ElapsedMilliseconds, id);
        }
    }
}
