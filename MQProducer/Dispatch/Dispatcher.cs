using Common.UOW;
using DataGenerator.Container;
using MQProducer.MQ;
using MQProducer.Tools;
using System;
using System.Diagnostics;
using System.IO;

namespace MQProducer.Dispatch
{
    public class Dispatcher
    {
        private MatrixAccessor container;
        private UOWGenerator uowGen;
        private MQClient MQClient;
        private long time;
        private Stopwatch stopwatch;

        public Dispatcher(MatrixAccessor container)
        {
            this.container = container;
            uowGen = new UOWGenerator(container);
            stopwatch = new Stopwatch();
        }

        public void Run()
        {
            stopwatch.Start();
            using (MQClient = new MQClient())
            {
                UnitOfWork uow = uowGen.GenerateUOWFirstCalc();
                while (uow != null)
                {
                    MQClient.Call(uow);
                    uow = uowGen.GenerateUOWFirstCalc();
                }

                MQClient.WatiForNotification();

                uow = uowGen.GenerateUOWSecondCalc();
                while (uow != null)
                {
                    MQClient.Call(uow);
                    uow = uowGen.GenerateUOWSecondCalc();
                }

                MQClient.WatiForNotification();
            }
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
            AddTimeToLog();
        }

        private void AddTimeToLog()
        {
            string path = Environment.CurrentDirectory + @"\logTime.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(string.Format("Overal calculation time: {0} [ms]", time));
            }
        }
    }
}
