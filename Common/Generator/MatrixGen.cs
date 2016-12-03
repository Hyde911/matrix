using System;
using System.Collections.Generic;

namespace Common.Generator
{
    public class MatrixGen
    {
        private static Random rand = new Random();

        public static double[][] GenerateMatix(int n, int m)
        {
            double[][] result = new double[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = rand.NextDouble();
                }
            }

            return result;
        }

        public static double[][] GenerateMatix(int n)
        {
            return GenerateMatix(n, n);
        }

        public static List<double[][]>GenerateMatrixForCalcuation(int n)
        {
            List<double[][]> result = new List<double[][]>(3);
            for (int i = 0; i < 3; i++)
            {
                result.Add(GenerateMatix(n));
            }
            return result;
        }
    }
}
