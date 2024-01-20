using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UserRabbitMqExample.Producer.RabbitMQ
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IConfiguration _conf;
        public MessageProducer(IConfiguration configuration)
        {
            _conf = configuration;
        }
        public void SendMessabe<T>(T message)
        {
            var host = _conf.GetValue<string>("ProducerHost") ?? "127.0.0.1";
            var factory = new ConnectionFactory() { HostName = host };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("user", exclusive: false);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(routingKey: "user", body: body, exchange: "");
        }

        public void SendMessabe<T>(T message, string textMessage)
        {
            var host = _conf.GetValue<string>("ProducerHost") ?? "127.0.0.1";
            var factory = new ConnectionFactory() { HostName = host };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("user", exclusive: false);

            var obj = new
            {
                msg = textMessage,
                body = message
            };

            var json = JsonSerializer.Serialize(obj);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(routingKey: "user", body: body, exchange: "");
        }
    }
}
