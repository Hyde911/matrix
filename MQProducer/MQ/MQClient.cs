using Common.Consts;
using Common.UOW;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace MQProducer.MQ
{
    public class MQClient : IDisposable
    {
        private IConnection connection;
        private IModel channel;
        private IModel channelNotification;
        private EventingBasicConsumer consumer;


        public MQClient()
        {
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
            channelNotification = connection.CreateModel();

            channel.QueueDeclare(queue: Queues.MessageQueue, autoDelete:true, exclusive:false);
            channelNotification.QueueDeclare(queue: Queues.NotificationQueue,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: true,
                                 arguments: null);
            channelNotification.BasicQos(0, 1, false);
            consumer = new EventingBasicConsumer(channelNotification);
            channelNotification.BasicConsume(queue: Queues.NotificationQueue, noAck: true, consumer: consumer);
            
        }

        public void Call(UnitOfWork uow)
        {
            var corelationId = Guid.NewGuid().ToString();
            var props = channel.CreateBasicProperties();
            props.ReplyTo = Queues.ReponseQueue;
            props.CorrelationId = corelationId;
            var b = UnitOfWork.ToBytes(uow);
            if (uow.Row % 32 == 0)
            {
                Console.WriteLine(string.Format("Sending UOW: {0}", uow.ToString()));
            }
            channel.BasicPublish(exchange: "", routingKey: Queues.MessageQueue, basicProperties: props, body: UnitOfWork.ToBytes(uow));

        }

        public void WatiForNotification()
        {
            bool notified = false;

            while (!notified)
            {
                consumer.Received += (model, ea) =>
                {
                    notified = true;
                };
            }
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

