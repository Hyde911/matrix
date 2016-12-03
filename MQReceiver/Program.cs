using DataGenerator.Container;
using MQReceiver.MQ;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            //DependencyFactory factory = new DependencyFactory();

            //var serilaize = factory.Container

            MatrixContainer container;
                container = new MatrixContainer();
                using (MQClient client = new MQClient(container))
                {
                    client.Run();
                }
        }
    }
}
