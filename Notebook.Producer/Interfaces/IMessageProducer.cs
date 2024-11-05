namespace Notebook.Producer.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message, string routingKey, string? exchange = default);
        // routingKey позволяет exchange-ру определить в какую очередь положить сообщение
        // exchange - очередь?
    }
}