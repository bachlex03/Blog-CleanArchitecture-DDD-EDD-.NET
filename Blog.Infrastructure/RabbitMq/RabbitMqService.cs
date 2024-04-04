using Blog.Application.services.RabbitMq;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace Blog.Infrastructure.RabbitMq
{
    public class RabbitMqService : BackgroundService
    {
        private readonly IRabbitMqUtil _rabbitMqUtil;

        private IModel _channel;

        private IConnection _connection;

        public RabbitMqService(IRabbitMqUtil rabbitMqUtil)
        {
            this._rabbitMqUtil = rabbitMqUtil;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "WDb3#Je9h4q6l",
                DispatchConsumersAsync = true,
            };

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();

            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabbitMqUtil.ListenRabbitMessageQueue(_channel, "api.auth", stoppingToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);

            _connection.Close();
        }
    }
}