using System;
using Entities.DB;
using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ProcessOrder
{
    public static class OrderProcessing
    {
        [FunctionName("OrderProcessing")]
        public static void Run([ServiceBusTrigger("orders")]Orders order, [SignalR(HubName = "notifications")] IAsyncCollector<SignalRMessage> signalRMessages, ILogger log)
        {

            log.LogInformation($"C# ServiceBus queue trigger function processed message: {order.ProductName}");

            using (var ctx = new EventMessagingDemoContext())
            {
                ctx.Orders.Add(order);
                ctx.SaveChanges();
            }
            signalRMessages.AddAsync(
                   new SignalRMessage
                   {
                       Target = "productOrdered",
                       Arguments = new[] { order }
                   });
        }
    }
}
