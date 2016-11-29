using Common.Consts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    public class Worker : IDisposable
    {
        private IConnection connection;
        private IModel channel;
        private EventingBasicConsumer consumer;

        public Worker()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: Queues.MessageQueue, durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);
            channel.BasicQos(0, 1, false);
            consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: Queues.MessageQueue, noAck: false, consumer: consumer);
            
        }

        public void Receive()
        {
             consumer.Received +=  (model, ea) =>
             {
                 var body = ea.Body;
                 var message = Encoding.UTF8.GetString(body);
                 Console.WriteLine("received " + message);
                 var props = ea.BasicProperties;
                 var id = props.CorrelationId;

                 var messageBytes = Encoding.UTF8.GetBytes(message + " " + id);
                 channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                 channel.BasicPublish(exchange: "", routingKey: Queues.ReponseQueue, basicProperties: props, body: messageBytes);

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
