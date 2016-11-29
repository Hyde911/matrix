namespace Producer
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            int[] m1 = new int[] { 81, 20, 17, 39 };
            var message = new StringBuilder("");
            JsonSerializer serializer = new JsonSerializer();
            using (StringWriter sw = new StringWriter(message))
            {
                serializer.Serialize(sw, m1);
            }
            
            using (Client client = new Client())
            {
                client.Call(message.ToString());
            }
        }
    }
}
