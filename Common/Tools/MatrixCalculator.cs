using Common.Results;
using System.Diagnostics;
using System.Linq;

namespace Common.Tools
{
    public static class MatrixCalculator
    {
        private static Stopwatch watch = new Stopwatch();
        /// <summary>
        /// calculates product of multiplication of vector and matrix
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static float[] CalculateRow(float[] m1, float[][] m2)
        {
            int rows = m1.Count();
            int columns = m2[0].Count();
            float[] result = new float[columns];

                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        result[j] += m1[k] * m2[k][j];
                    }
                }
        return result;
        }

        public static CalculationResult DoCalculation(float[]m1, float[][]m2, string id, int row)
        {
            float[] result;
            watch.Reset();
            watch.Start();
            result = CalculateRow(m1, m2);
            watch.Stop();
            return new CalculationResult(result, row, watch.ElapsedMilliseconds, id);
        }
    }
}
