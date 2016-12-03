using Common.Consts;
using Common.Results;
using Common.UOW;
using DataGenerator.Container;
using MQWorker.Matrix;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace MQWorker.MQ
{
    public class MQClient : IDisposable
    {
        private IConnection connection;
        private IModel channel;
        private EventingBasicConsumer consumer;
        private Worker worker;

        public MQClient(InputMatrixContainer inputContainer)
        {
            worker = new Worker(inputContainer);

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
            channel.QueueDeclare(queue: Queues.MessageQueue, durable: false,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);
            channel.BasicQos(0, 1, false);
            consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: Queues.MessageQueue, noAck: false, consumer: consumer);

        }

        public void Run()
        {
            consumer.Received += (model, ea) =>
           {
               var body = ea.Body;
               CalculationResult result = worker.Calculate(UnitOfWork.GetFromBytes(ea.Body));
               var props = ea.BasicProperties;
               var id = props.CorrelationId;

                 //var messageBytes = Encoding.UTF8.GetBytes(message + " " + id);
                 channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

               channel.BasicPublish(exchange: "", routingKey: Queues.ReponseQueue, basicProperties: props, body: CalculationResult.ToBytes(result));

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
