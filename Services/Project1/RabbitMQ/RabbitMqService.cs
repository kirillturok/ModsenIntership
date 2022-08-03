using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Project1.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "MyQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                routingKey: "MyQueue",
                basicProperties: null,
                body: body);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
