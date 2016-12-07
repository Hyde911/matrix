namespace Common.Results
{
    public class LogInfo
    {
        public LogInfo(string id)
        {
            ID = id;
        }

        public string ID { private set; get; }
        
        public long Time { set; get; }

        public int NumberOfIterations { set; get; }

        public override bool Equals(object obj)
        {
            LogInfo other = obj as LogInfo;
            if (other == null)
            {
                return false;
            }
            if (ID.Equals(other.ID)){
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (int)(Time * 11) + NumberOfIterations * 13;
        }

        public override string ToString()
        {
            return string.Format("Worker id: {0}, perfomed {1} calculations in {2} [ms] ({3} ms per calculation)", ID, NumberOfIterations, Time, Time/NumberOfIterations);
        }
    }
}
