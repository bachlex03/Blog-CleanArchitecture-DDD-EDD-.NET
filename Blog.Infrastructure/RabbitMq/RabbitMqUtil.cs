using System.Text;
using Blog.Application.services.RabbitMq;
using RabbitMQ.Client;

namespace Blog.Infrastructure.RabbitMqUtilTest
{
    public class RabbitMqUtil : IRabbitMqUtil
    {
        public async Task PublishRabbitMessageQueue(string routingKey, string evenData)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "WDb3#Je9h4q6l",
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            var body = Encoding.UTF8.GetBytes(evenData);

            Console.WriteLine("routingKey ", routingKey);
            Console.WriteLine("body ", body);


            channel.BasicPublish(exchange: "example.exchange", routingKey: routingKey, basicProperties: null, body: body);

            await Task.CompletedTask;
        }
    }
}