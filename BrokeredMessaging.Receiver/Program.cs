using Azure.Messaging.ServiceBus;

string ConnectionString = "Endpoint=sb://brokeredmessagingsb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gn0+loDQPc6oVBgfAeQ8FeUep8pVdMnuP+ASbFU/kOo=";
string QueueName = "demoqueue";

// Create a service bus client
var client = new ServiceBusClient(ConnectionString);

// Create a service bus receiver
var receiver = client.CreateReceiver(QueueName);

// Receive the messages
Console.WriteLine("Receive messages...");

while (true)
{
    var message =await receiver.ReceiveMessageAsync();

    if(message != null)
    {
        Console.Write(message.Body.ToString());

        // Complete the message
        await receiver.CompleteMessageAsync(message);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("All messages received.");
        break;
    }
};

// Close the receiver
await receiver.CloseAsync();