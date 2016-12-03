using Common.Results;
using System.Collections.Generic;
using System.IO;

namespace MQReceiver.Logger
{
    public class WorkerTimeLogger
    {
        private Dictionary<string, long> wokersTimeLog;

        public WorkerTimeLogger()
        {
            wokersTimeLog = new Dictionary<string, long>();
        }

        public void LogWorkerTime(CalculationResult result)
        {
            if (!wokersTimeLog.ContainsKey(result.WorkerId)){
                wokersTimeLog.Add(result.WorkerId, 0L);
            }
            wokersTimeLog[result.WorkerId] += result.Time;
        }

        public void SaveLog(StreamWriter writer)
        {
            foreach (KeyValuePair<string, long>kp in wokersTimeLog)
            {
                writer.WriteLine(string.Format("worker id {0}: \t {1}", kp.Key, kp.Value));
            }
        }
    }
}
