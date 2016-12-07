using Common.Results;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MQReceiver.Logger
{
    public class WorkerTimeLogger
    {
        private List<LogInfo> wokersTimeLog;

        public WorkerTimeLogger()
        {
            wokersTimeLog = new List<LogInfo>();
        }

        public void LogWorkerTime(CalculationResult result)
        {
            var log = new LogInfo(result.WorkerId);
            if (!wokersTimeLog.Contains(log))
            {
                wokersTimeLog.Add(log);
            }
            log = wokersTimeLog.Where(a => a.Equals(log)).FirstOrDefault();
            log.NumberOfIterations += 1;
            log.Time += result.Time;
        }

        public void SaveLog(StreamWriter writer)
        {
            foreach (LogInfo log in wokersTimeLog)
            {
                writer.WriteLine(log.ToString());
            }
        }
    }
}
