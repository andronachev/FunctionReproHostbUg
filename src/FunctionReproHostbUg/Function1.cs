using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using EventStore.ClientAPI;

namespace FunctionReproHostbUg
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            Microsoft.Extensions.Logging.ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            using (var eventStoreConnection = EventStoreConnection.Create(@"ConnectTo=tcp://admin:changeit@127.0.0.0:1113; HeartBeatTimeout=500"))
            {
                eventStoreConnection.ConnectAsync().Wait();

            }

            return (ActionResult)new OkObjectResult($"Hello world");
        }
    }
}
