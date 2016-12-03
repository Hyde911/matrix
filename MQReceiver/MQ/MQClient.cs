using Common.Consts;
using Common.Results;
using DataGenerator.Container;
using MQReceiver.Matrix;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace MQReceiver.MQ
{
    public class MQClient : IDisposable
    {
        private IConnection connection;
        private IModel channel;
        private EventingBasicConsumer consumer;
        private MatrixAssembler assembler;

        public MQClient(InputMatrixContainer container)
        {
            assembler = new MatrixAssembler(container);

            var factory = new ConnectionFactory()
            {
                HostName = MQServerConfig.IP,
                Port = MQServerConfig.PORT,
                UserName = MQServerConfig.USER,
                Password = MQServerConfig.USER,
                VirtualHost = MQServerConfig.VHOST
            };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: Queues.ReponseQueue, exclusive: false);
            consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: Queues.ReponseQueue, noAck: false, consumer: consumer);

        }

        public void Run()
        {
            Console.WriteLine("Receiver running...");
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                CalculationResult result = CalculationResult.GetFromBytes(ea.Body);
                var props = ea.BasicProperties;
                var id = props.CorrelationId;
                Console.WriteLine("Received result, adding to assembly");
                assembler.AddResult(result);
                //var messageBytes = Encoding.UTF8.GetBytes(message + " " + id);
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
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
