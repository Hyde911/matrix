using DataGenerator.Container;
using MQReceiver.Logger;
using MQReceiver.MQ;
using System;
using System.IO;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            //DependencyFactory factory = new DependencyFactory();

            //var serilaize = factory.Container
            WorkerTimeLogger logger = new WorkerTimeLogger();
            MatrixAccessor inputContainer;
            inputContainer = new MatrixAccessor();
            using (MQClient client = new MQClient(inputContainer, logger))
            {
                client.Run();
            }
            string path = Environment.CurrentDirectory + @"\log.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                logger.SaveLog(sw);
            }

        }
    }
}
