using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Project2.RabbitMQ
{
    public class RabbitMqListener : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqListener()
        {
            var factory = new ConnectionFactory { HostName = "rabbitmq" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                queue: "MyQueue", 
                durable: false, 
                exclusive: false, 
                autoDelete: false, 
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                Console.WriteLine($"New message: {content}");

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume("MyQueue", false, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
	}
}
