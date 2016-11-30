using Consumer.MQ;
using DataGenerator.Container;
using System;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixContainer container;
            try
            {
                container = new MatrixContainer();
                using (MQClient worker = new MQClient(container))
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
