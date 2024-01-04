//Service Bus Queue trigger: C#. ReceiveOrders
using System.Text;

public static void Run(string myQueueItem, TraceWriter log)

{
    var message = JObject.Parse(myQueueItem);

    log.Info($"{message["type"]} order for {message["quantity"]} of item {message["item"]}");

}

//

#r "Microsoft.ServiceBus"

#r "Newtonsoft.Json"

using System.Text;

using Microsoft.ServiceBus.Messaging;

using Newtonsoft.Json.Linq;

public async static Task Run(TimerInfo myTimer, TraceWriter log)

//Timer trigger: C#.
{ 
    var random = new Random();

    var client = QueueClient.CreateFromConnectionString(System.Environment.GetEnvironmentVariable("SERVICE_BUS_CONNECTION_STRING"), "orders");

    var json = JObject.FromObject(new
    {

        type = "purchase",

        item = random.Next(1000),

        quantity = random.Next(20)

    }).ToString();

    await client.SendAsync(new BrokeredMessage(new MemoryStream(Encoding.UTF8.GetBytes(json)))
    {

        ContentType = "application/json"

    });

}