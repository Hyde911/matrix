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

            InputMatrixContainer inputContainer;
                inputContainer = new InputMatrixContainer();
                using (MQClient client = new MQClient(inputContainer))
                {
                    client.Run();
                }
        }
    }
}
