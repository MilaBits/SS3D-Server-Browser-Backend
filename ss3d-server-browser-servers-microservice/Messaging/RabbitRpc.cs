using System.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ss3d_server_browser_servers_microservice.Data;
using ss3d_server_browser_shared.Models.Servers;
using Utf8Json;

namespace ss3d_server_browser_servers_microservice.Messaging
{
    public class RabbitRpc : BackgroundService
    {
        private readonly ILogger _logger;
        public static IConnection Connection { get; private set; }
        public static IModel Channel { get; private set; }

        private ServersDbHelper _serversDbHelper;

        private const string ServersQueueName = "rpc.getservers";
        private string HostName;/* = "rabbitmq";*/
        private const int Port = 5672;

        public RabbitRpc(ILoggerFactory loggerFactory)
        {
            HostName = Startup.CurrentConfiguration["RabbitHost"];

            _logger = loggerFactory.CreateLogger<RabbitRpc>();
            _serversDbHelper = new ServersDbHelper(_logger);
            RegisterRpcQueue(ServersQueueName);
        }

        public void RegisterRpcQueue(string queueName)
        {
            // Connection setup
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = HostName,
                Port = Port
            };

            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();

            Channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            Channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            _logger.LogInformation($" [x] {queueName} queue registered");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (model, ea) =>
            {
                _logger.LogInformation(" [x] Received server list request from gateway");
                ConsumerReceived(model, ea);
                _logger.LogInformation(" [x] Sending servers list to gateway");
            };

            Channel.BasicConsume(queue: ServersQueueName, autoAck: false, consumer: consumer);
            return Task.CompletedTask;
        }

        private void ConsumerReceived(object model, BasicDeliverEventArgs ea)
        {
            var props = ea.BasicProperties;
            var replyProps = Channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;

            string message = Encoding.UTF8.GetString(ea.Body.ToArray());
            
            _logger.LogInformation($" [x] request: '{message}'");
            
            RpcDataServersRequest request = JsonSerializer.Deserialize<RpcDataServersRequest>(message);

            RpcDataServersResponse response = new RpcDataServersResponse()
                {GameServers = _serversDbHelper.Get(request)};

            string jsonObject = JsonSerializer.ToJsonString(response);
            _logger.LogInformation($" [x] response: '{response.GameServers.Length}'");

            byte[] body = Encoding.UTF8.GetBytes(jsonObject);

            Channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: body);
            Channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        }

        public override void Dispose()
        {
            Channel.Close();
            Connection.Close();
            base.Dispose();
        }
    }
}