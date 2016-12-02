using DataGenerator.Container;
using MatrixAccess;
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
                container = new MatrixContainer();
                using (MQClient client = new MQClient(container))
                {
                    client.Run();
                }
        }
    }
}
