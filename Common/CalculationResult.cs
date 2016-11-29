namespace Common
{
    public class CalculationResult
    {
        public int[] Result
        {
            private set;
            get;
        }

        public long Time
        {
            private set;
            get;
        }

        public string Id
        {
            private set;
            get;
        }

        public CalculationResult(int[]result, long time, string id)
        {
            Result = result;
            Time = time;
            Id = id;
        }
    }
}
