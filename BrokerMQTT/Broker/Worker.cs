using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Server;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Broker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var optionsBuilder = new MqttServerOptionsBuilder()
.WithConnectionBacklog(100)
.WithDefaultEndpointPort(1883).WithApplicationMessageInterceptor(new messange()).WithConnectionValidator(new validator()).WithClientMessageQueueInterceptor(new queew());

            var mqttServer = new MqttFactory().CreateMqttServer();

            mqttServer.StartAsync(optionsBuilder.Build());

            await Task.Delay(1000, stoppingToken);

        }
    }

    public class messange : IMqttServerApplicationMessageInterceptor
    {
        public Task InterceptApplicationMessagePublishAsync(MqttApplicationMessageInterceptorContext context)
        {
            
            return Task.CompletedTask;
        }
    }
    public class validator : IMqttServerConnectionValidator
    {
        public Task ValidateConnectionAsync(MqttConnectionValidatorContext context)
        {
            return Task.CompletedTask;
        }
    }

    public class queew : IMqttServerClientMessageQueueInterceptor
    {
        public Task InterceptClientMessageQueueEnqueueAsync(MqttClientMessageQueueInterceptorContext context)
        {
            return Task.CompletedTask;
        }

    }
}
