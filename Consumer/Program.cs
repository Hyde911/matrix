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
