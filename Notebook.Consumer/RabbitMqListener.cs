using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Notebook.Domain.Settings;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Notebook.Consumer
{
    public class RabbitMqListener //: BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IOptions<RabbitMqSettings> _options;

        public RabbitMqListener(IOptions<RabbitMqSettings> options)
        {
            _options = options;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection(); // подключение к кролику
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_options.Value.QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                // durable сохраняет состоояние при сбоях
                // exclusive ограничение кол-ва получателей, способных подключиться к очереди
                // autoDelete автоудаление очереди если нет подключенных получателей
        }
/*
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested(); // если есть запрос на отмену, то выбрасывается исключение

            var consumer = new EventingBasicConsumer(_channel); // создание получателя и подключение к каналу RabbitMq
            consumer.Received += (obj, basicDeliver) =>
            {
                var content = Encoding.UTF8.GetString(basicDeliver.Body.ToArray());
                Debug.WriteLine($"Получено сообщение: {content}");
                
                _channel.BasicAck(basicDeliver.DeliveryTag, false);//  Подтверждение получения сообщения, чтобы удалить сообщение из очерреди
            };
            _channel.BasicConsume(_options.Value.QueueName, false, consumer);
            
            return Task.CompletedTask;
        }
        */
    }
}