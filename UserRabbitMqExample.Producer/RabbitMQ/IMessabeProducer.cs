namespace UserRabbitMqExample.Producer.RabbitMQ
{
    public interface IMessabeProducer
    {
        void SendMessabe<T>(T message);
    }
}
