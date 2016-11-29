using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Worker worker = new Worker())
            {
                worker.Receive();
            }
        }
    }
}
