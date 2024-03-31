using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Application.services.RabbitMq
{
    public interface IRabbitMqUtil
    {
        Task PublishRabbitMessageQueue(string routingKey, string evenData);
    }
}