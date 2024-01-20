namespace UserRabbitMqExample.Producer.RabbitMQ
{
    public interface IMessageProducer
    {
        void SendMessabe<T>(T message);
        void SendMessabe<T>(T message, string textMessage);
    }
}
