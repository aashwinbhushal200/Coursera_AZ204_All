// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");
//azure bash commands for service bus :
az servicebus namespace authorization-rule keys list \
    --resource-group learn-59f4c7a8-ab91-4336-8f23-85afe040a082 \
    --name RootManageSharedAccessKey \
    --query primaryConnectionString \
    --output tsv \
    --namespace-name<namespace-name>
//output: Endpoint=sb://salesteamapp2023.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=HeGSIjpPZYjoxJN40+hbWLg0Xsj6SHPUh+ASbJBovI8==
//Endpoint=sb://salesteamapp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=xMYFwR2IfgAcqMYccAX1r8cAkq8mTSzai+ASbM6ypa8=

//Send a message to the queue
cd ~/mslearn-connect-services-together/implement-message-workflows-with-service-bus/src/start
dotnet run --project./privatemessagesender

/*You've written code that sends a message about individual sales to a Service Bus queue.
In the salesforce distributed application, you should write this code in the mobile app that sales
personnel use on devices.
You've also written code that receives a message from the Service Bus queue.
In the salesforce distributed application, you should write this code in the web service that 
runs in Azure and processes received messages.*/
