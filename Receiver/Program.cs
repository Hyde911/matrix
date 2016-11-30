using DataGenerator.Container;
using Receiver.MQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixContainer container;
            try
            {
                container = new MatrixContainer();
                using (MQClient client = new MQClient(container))
                {
                    client.Run();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Receiver cannot open input file");
                return;
            }
        }
    }
}
