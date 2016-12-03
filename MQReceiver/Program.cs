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

            MatrixAccessor inputContainer;
                inputContainer = new MatrixAccessor();
                using (MQClient client = new MQClient(inputContainer))
                {
                    client.Run();
                }
        }
    }
}
