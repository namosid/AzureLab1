using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace ProcessDeviceData
{
    public static class ProcessDeviceData
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("ProcessDeviceData")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "IoTHubEndpoint")]EventData message, ILogger log)
        {
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
            //const string ServiceBusConnectionString = "Endpoint=sb://sidservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DEXmEuelPwvHMIRbOk1zLWa1juHjOelhEmvvzjiLRO4=";
            //const string QueueName = "orders";

            //IQueueClient queueClient;

            //queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            //var message1 = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message.Body.Array)));
            //message1.ContentType = "application/json";

            //queueClient.SendAsync(message1);
        }
    }
}