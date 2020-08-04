using System;
using System.Threading.Tasks;
using Entities.DB;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Documents;
using System.Linq;

namespace FunctionApp1
{
    public static class ProcessingOrder
    {
        [FunctionName("ProcessingOrder")]
        public static void Run([ServiceBusTrigger("orders", Connection = "AzureWebJobsServiceBus")] Orders order, [SignalR(HubName = "notifications")] IAsyncCollector<SignalRMessage> signalRMessages, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {order.ProductName}");

            //using (var ctx = new EventMessagingDemoContext())
            //{
            //    ctx.Orders.Add(order);
            //    ctx.SaveChanges();
            //}

            Task.Run(async () =>
            {
                var endpoint = Environment.GetEnvironmentVariable("DocDbEndpoint");
                var masterKey = Environment.GetEnvironmentVariable("DocDbMasterKey");
                using (var client = new DocumentClient(new Uri(endpoint), masterKey))
                {
                    Console.WriteLine("\r\n>>>>>>>>>>>>>>>> Creating Database <<<<<<<<<<<<<<<<<<<");
                    // Create new database Object  
                    //Id defines name of the database  
                    var databaseDefinition = new Database { Id = "EventMessagingDemo" };
                    var database = await client.CreateDatabaseIfNotExistsAsync(databaseDefinition);
                    Console.WriteLine("Database EventMessagingDemo created successfully");

                    //Create new database collection  
                    Console.WriteLine("\r\n>>>>>>>>>>>>>>>> Creating Collection <<<<<<<<<<<<<<<<<<<");
                    var collectionDefinition = new DocumentCollection { Id = "orders" };
                    var collection = await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("EventMessagingDemo"),
                        collectionDefinition);
                    Console.WriteLine("Collection orders created successfully");

                    //Insert new Document  
                    Console.WriteLine("\r\n>>>>>>>>>>>>>>>> Creating Document <<<<<<<<<<<<<<<<<<<");

                    Orders doc1Definition = new Orders();
                    doc1Definition.ProductName = order.ProductName;
                    doc1Definition.Quantity = order.Quantity;
                    doc1Definition.Status = order.Status;
                    //dynamic doc1Definition = new
                    //{
                    //    title = "Star War IV ",
                    //    rank = 600,
                    //    category = "Sci-fi"
                    //};
                    var document1 = await client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri("EventMessagingDemo", "orders"),
                        doc1Definition);

                    //Console.WriteLine("\r\n>>>>>>>>>>>> Querying Document <<<<<<<<<<<<<<<<<<<<");
                    //var response = client.CreateDocumentQuery(UriFactory.CreateDocumentCollectionUri("testDb", "testDocumentCollection"),
                    //    "select * from c").ToList();
                    //var document = response.First();
                    //Console.WriteLine($"Id:{document.id}");
                    //Console.WriteLine($"Title:{document.title}");
                    //Console.WriteLine($"Rank:{document.rank}");
                    //Console.WriteLine($"category:{document.category}");

                    //Console.WriteLine("\r\n>>>>>>>>>>>>>>>> Deleteing Collection <<<<<<<<<<<<<<<<<<<");
                    //await client.DeleteDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri("testDb", "testDocumentCollection"));

                    //Console.ReadKey();
                }

            }).Wait();

            signalRMessages.AddAsync(
                   new SignalRMessage
                   {
                       Target = "productOrdered",
                       Arguments = new[] { order }
                   });
        }
    }
}
