using RabbitMQ.Client;

namespace Blog.Application.services.RabbitMq
{
    public interface IRabbitMqUtil
    {
        Task PublishRabbitMessageQueue(string routingKey, string evenData);

        Task ListenRabbitMessageQueue(IModel channel, string routingKey, CancellationToken stoppingToken);
    }
}