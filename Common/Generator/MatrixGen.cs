using System;
using System.Collections.Generic;

namespace Common.Generator
{
    public class MatrixGen
    {
        private static Random rand = new Random();

        public static int[][] GenerateMatix(int n, int m, int range)
        {
            int[][] result = new int[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    result[i][j] = rand.Next(range);
                }
            }

            return result;
        }

        public static int[][] GenerateMatix(int n, int range)
        {
            return GenerateMatix(n, n, range);
        }

        public static List<int[][]>GenerateMatrixForCalcuation(int n)
        {
            List<int[][]> result = new List<int[][]>(3);
            for (int i = 0; i < 3; i++)
            {
                result.Add(GenerateMatix(n, 1000));
            }
            return result;
        }
    }
}
