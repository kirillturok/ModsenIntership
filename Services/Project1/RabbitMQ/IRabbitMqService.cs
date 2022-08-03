namespace Project1.RabbitMQ
{
    public interface IRabbitMqService : IDisposable
    {
        void SendMessage(object obj);
        void SendMessage(string message);
    }
}
