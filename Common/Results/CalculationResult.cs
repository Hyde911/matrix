using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Results
{
    public class CalculationResult
    {
        public int[] Result
        {
            private set;
            get;
        }

        public int Row
        {
            private set;
            get;
        }

        public long Time
        {
            private set;
            get;
        }

        public string WorkerId
        {
            private set;
            get;
        }

        public CalculationResult(int[] result, int row, long time, string workerId)
        {
            Result = result;
            Time = time;
            WorkerId = workerId;
            Row = row;
        }

        public static byte[] ToBytes(CalculationResult result)
        {
            var message = new StringBuilder("");
            JsonSerializer serializer = new JsonSerializer();
            using (StringWriter sw = new StringWriter(message))
            {
                serializer.Serialize(sw, result);
            }
            return Encoding.UTF8.GetBytes(message.ToString());
        }

        public static CalculationResult GetFromBytes(byte[] bytes)
        {
            string message = Encoding.UTF8.GetString(bytes);
            JsonSerializer serializer = new JsonSerializer();
            using (StringReader sr = new StringReader(message))
            {
                return (CalculationResult)serializer.Deserialize(sr, typeof(CalculationResult));
            }
        }

        public override int GetHashCode()
        {
            return Result[Result.Count()] * 11 + (int)(Time * 7) + Row * 13;
        }

        public override bool Equals(object obj)
        {
            CalculationResult other = obj as CalculationResult;
            if (other == null)
            {
                return false;
            }
            if (!WorkerId.Equals(other.WorkerId))
            {
                return false;
            }
            if (Time != other.Time)
            {
                return false;
            }
            if (Row != other.Row)
            {
                return false;
            }
            if (Result.Count() != other.Result.Count())
            {
                return false;
            }
            for (int i = 0; i < Result.Count(); i++)
            {
                if (Result[i] != other.Result[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
