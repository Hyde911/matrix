using System;
using System.Collections.Generic;

namespace Common.Generator
{
    public class MatrixGen
    {
        private static Random rand = new Random();

        public static float[][] GenerateMatix(int n, int m)
        {
            float[][] result = new float[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new float[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = (float)rand.NextDouble();
                }
            }

            return result;
        }

        public static float[][] GenerateMatix(int n)
        {
            return GenerateMatix(n, n);
        }

        public static List<float[][]>GenerateMatrixForCalcuation(int n)
        {
            List<float[][]> result = new List<float[][]>(3);
            for (int i = 0; i < 3; i++)
            {
                result.Add(GenerateMatix(n));
            }
            return result;
        }
    }
}
