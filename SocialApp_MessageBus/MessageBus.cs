using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MicroService_MessageBus
{
    public class MessageBus : IMessageBus
    {
        // Connection string to the service bus in Azure
        private readonly string connectionString = "Endpoint=sb://imessage.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DXfLyRiYThMwlt8SRggZHkgtvBIYpfltN+ASbFoshPs=";

        public async Task PublishMessage(object message, string queue_topicname)
        {
            
            await using var client = new ServiceBusClient(connectionString);

            
            await using var sender = client.CreateSender(queue_topicname);

            
            var jsonMessage = JsonConvert.SerializeObject(message);

            
            var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                
                MessageId = Guid.NewGuid().ToString(),
            };

            
            await sender.SendMessageAsync(serviceBusMessage);
        }
    }
}
