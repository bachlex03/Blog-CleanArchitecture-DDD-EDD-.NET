using System.Text;
using Blog.Application.services.RabbitMq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Blog.Infrastructure.RabbitMq
{
    public class RabbitMqUtil : IRabbitMqUtil
    {
        public async Task PublishRabbitMessageQueue(string routingKey, string evenData)
        {
            Console.WriteLine("evenData: " + evenData);
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "WDb3#Je9h4q6l",
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            var body = Encoding.UTF8.GetBytes(evenData);

            Console.WriteLine("routingKey: " + routingKey);
            Console.WriteLine("body: " + body);


            channel.BasicPublish(exchange: "example.exchange", routingKey: routingKey, basicProperties: null, body: body);

            await Task.CompletedTask;
        }

        public async Task ListenRabbitMessageQueue(IModel channel, string routingKey, CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += async (channel, ea) =>
            {
                var body = Encoding.UTF8.GetString(ea.Body.ToArray());

                // some logic
                Console.WriteLine("ListenRabbitMessageQueue body:" + body);
            };

            channel.BasicConsume(queue: "api.auth", autoAck: true, consumer: consumer);

            await Task.CompletedTask;
        }
    }
}