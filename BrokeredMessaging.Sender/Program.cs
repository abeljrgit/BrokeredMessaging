using Azure.Messaging.ServiceBus;

string ConnectionString = "Endpoint=sb://brokeredmessagingsb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gn0+loDQPc6oVBgfAeQ8FeUep8pVdMnuP+ASbFU/kOo=";
string QueueName = "demoqueue";

string Sentence = "Microsoft Azure Service Bus.";

// Create a service bus client
var client = new ServiceBusClient(ConnectionString);

// Create a service bus sender
var sender = client.CreateSender(QueueName);

// Send some messages
Console.WriteLine("Sending messages...");
foreach(var character in Sentence)
{
    var message = new ServiceBusMessage(character.ToString());
    await sender.SendMessageAsync(message);
    Console.WriteLine($"    Sent:{ character }");
}

// Close the sender
await sender.CloseAsync();


Console.WriteLine("Sent messages.");
Console.ReadLine();