using System;
using System.Collections.Generic;

namespace DataGenerator.Generator
{
    public class MatrixGenerator
    {
        public static int[][] GenerateMatix(int n, int m, int range)
        {
            Random rand = new Random();
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
            List<int[][]> result = new List<int[][]>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(GenerateMatix(n, 1000));
            }
            return result;
        }
    }
}
