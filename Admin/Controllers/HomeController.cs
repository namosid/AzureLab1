using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;
using Entities.DB;
using EventMessagingDemo.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using SignalRChat.Hubs;
using System.Configuration;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using Newtonsoft.Json.Linq;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<OrderModel> orderList = new List<OrderModel>();

            //using (var ctx = new EventMessagingDemoContext())
            //{
            //    var orders = ctx.Orders.ToList();

            //    orderList = orders.Select(x => new OrderModel
            //    {
            //        OrderId = x.OrderId,
            //        ProductName = x.ProductName,
            //        Quantity = (int)x.Quantity,
            //        Status = x.Status
            //    }).ToList();
            //}

            var endpoint = "https://sidtestcosmos.documents.azure.com:443/";
            var masterKey = "EaGaB6g0mhzG6CgD1YU5CK238qIry21pKCF7VfUVoha1p95d3BdeDuQqd2A3e3Mfe22TASTHNHqsR3VHtVxFYw==";
            using (var client = new DocumentClient(new Uri(endpoint), masterKey))
            {
                Console.WriteLine("\r\n>>>>>>>>>>>> Querying Document <<<<<<<<<<<<<<<<<<<<");
                var response = client.CreateDocumentQuery(UriFactory.CreateDocumentCollectionUri("EventMessagingDemo", "orders"),
                    "select * from c").ToList();
                foreach (var document in response)
                {
                    OrderModel mydata = new OrderModel();
                    mydata.OrderId = document.OrderId;
                    mydata.ProductName = document.ProductName;
                    mydata.Quantity = document.Quantity;
                    mydata.Status = document.Status;
                    orderList.Add(mydata);
                }
            }

            return View($"OrderList", orderList);
        }

        public string ChangeOrderStatus(int orderId, int status)
        {
            string orderStatus = "";

            orderStatus = status == 1 ? "Order Accepted" : "Order Rejected";

            var endpoint = "https://sidtestcosmos.documents.azure.com:443/";
            var masterKey = "EaGaB6g0mhzG6CgD1YU5CK238qIry21pKCF7VfUVoha1p95d3BdeDuQqd2A3e3Mfe22TASTHNHqsR3VHtVxFYw==";
            using (var client = new DocumentClient(new Uri(endpoint), masterKey))
            {
                var project = (Document)client.CreateDocumentQuery<dynamic>(UriFactory.CreateDocumentCollectionUri("EventMessagingDemo", "orders"))
            .AsEnumerable().Where(item => item.OrderId == orderId)
            .First();
                var gate = project?.GetPropertyValue<dynamic>("IdeaInitiatedGate");
                project?.SetPropertyValue("IdeaInitiatedGate", new JObject { { "Status", orderStatus } });
                var document = client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri("EventMessagingDemo", "orders", project?.Id), project).Result.Resource;
            }


            //using (var ctx = new EventMessagingDemoContext())
            //{
            //    var orders = ctx.Orders.Find(orderId);

            //    orders.Status = orderStatus;

            //    ctx.SaveChanges();
            //}

            UpdateServiceBus(orderStatus);

            return "Order Updated";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private void UpdateServiceBus(string statusMessage)
        {
            const string ServiceBusConnectionString = "Endpoint=sb://sidservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=DEXmEuelPwvHMIRbOk1zLWa1juHjOelhEmvvzjiLRO4=";
            const string QueueName = "orderstatus";

            IQueueClient queueClient;

            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);



            var message = new Message(Encoding.UTF8.GetBytes(statusMessage));
            message.ContentType = "application/json";

            queueClient.SendAsync(message);

        }
    }
}
