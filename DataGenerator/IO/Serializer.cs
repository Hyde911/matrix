using Common.Consts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DataGenerator.IO
{
    public class Serializer
    {
        public static void SaveMatrix(List<int[][]>matrix)
        {
            SaveMatrix(matrix, Paths.MatrixFilePath);
        }

        public static void SaveMatrix(List<int[][]>matrix, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(path))
            {
                serializer.Serialize(sw, matrix);
            }
        }
    }
}
