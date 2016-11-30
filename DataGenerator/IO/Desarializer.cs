using Common.Consts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DataGenerator.IO
{
    public class Desarializer
    {
        public static List<int[][]> LoadMatrix()
        {
            return LoadMatrix(Paths.MatrixFilePath);
        }

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
