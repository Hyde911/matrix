using DataGenerator.Container;
using MQWorker.MQ;
using System;

namespace MQConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixAccessor inputContainer;
            try
            {
                inputContainer = new MatrixAccessor();
                using (MQClient worker = new MQClient(inputContainer))
                {
                    worker.Run();
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Worker could not load input matrixes");
            }


        }
    }
}
