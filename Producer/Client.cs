using Common.Consts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Producer
{
    public class Client : IDisposable
    {
        private IConnection connection;
        private IModel channel;
        private EventingBasicConsumer consumer;

        public Client()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: Queues.ReponseQueue);
            consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: Queues.ReponseQueue, noAck: false, consumer: consumer);
            
        }

        public void Call(string message)
        {
            var corelationId = Guid.NewGuid().ToString();
            var props = channel.CreateBasicProperties();
            props.ReplyTo = Queues.ReponseQueue;
            props.CorrelationId = corelationId;

            var messageBytes = Encoding.UTF8.GetBytes(message);
            Console.WriteLine(string.Format("sending {0}", message));
            channel.BasicPublish(exchange: "", routingKey: Queues.MessageQueue, basicProperties: props, body: messageBytes);

            consumer.Received += (model, ea) =>
                            {
                                var body = ea.Body;
                                var reply = Encoding.UTF8.GetString(body);
                                Console.WriteLine("reply " + reply);
                            };
            Console.ReadLine();
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
            }
            if (channel != null)
            {
                channel.Dispose();
            }
        }
    }
}
