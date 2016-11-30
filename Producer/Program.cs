namespace Producer
{
    using DataGenerator.Container;
    using Dispatch;
    using Matrix;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            MatrixContainer container;
            try
            {
                container = new MatrixContainer();
            }catch (Exception ex)
            {
                System.Console.WriteLine("Producer cannot open input file");
                return;
            }
            Dispatcher dispatcher = new Dispatcher(container);

            dispatcher.Run();
            //int[] m1 = new int[] { 81, 20, 17, 39 };
            //var message = new StringBuilder("");
            //JsonSerializer serializer = new JsonSerializer();
            //using (StringWriter sw = new StringWriter(message))
            //{
            //    serializer.Serialize(sw, m1);
            //}

            //using (Client client = new Client())
            //{
            //    client.Call(message.ToString());
            //}
        }
    }
}
