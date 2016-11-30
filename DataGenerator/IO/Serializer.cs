using Common.Consts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DataGenerator.IO
{
    public class MatrixSerializer
    {
        public static void SaveInputMatrix(List<int[][]>matrix)
        {
            SaveMatrix(matrix, Paths.InputMatrix);
        }

        public static void SaveIntermediateMatrix(List<int[][]> matrix)
        {
            SaveMatrix(matrix, Paths.IntermediateMatrix);
        }

        public static void SaveOutputMatrix(List<int[][]> matrix)
        {
            SaveMatrix(matrix, Paths.OutputMatrix);
        }

        /// <summary>
        /// for tests only
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="path"></param>
        public static void SaveMatrix(List<int[][]>matrix, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(path))
            {
                serializer.Serialize(sw, matrix);
            }
        }

        public static List<int[][]> LoadInputMatrix()
        {
            return LoadMatrix(Paths.InputMatrix);
        }

        public static List<int[][]> LoadIntermediateMatrix()
        {
            return LoadMatrix(Paths.IntermediateMatrix);
        }

        public static List<int[][]> LoadOutputMatrix()
        {
            return LoadMatrix(Paths.OutputMatrix);
        }

        /// <summary>
        /// for tests only
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<int[][]> LoadMatrix(string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            List<int[][]> result;

            using (StreamReader sw = new StreamReader(path))
            {
                result = (List<int[][]>)serializer.Deserialize(sw, typeof(List<int[][]>));
            }

            return result;
        }
    }
}
