using MassTransit;

using MessageContracts;

namespace ConsoleApp.Subscriber2;
public class EventConsumer2 : IConsumer<CustomerRegistered>
{
	public Task Consume(ConsumeContext<CustomerRegistered> context)
	{
		Console.WriteLine("Event Received.");
		Console.WriteLine();

		Console.WriteLine($"Subscriber 2 Consuming Context - {context.MessageId}");
		Console.WriteLine($"Consumer Id: {context.Message.CustomerId}");
		Console.WriteLine($"Message: {context.Message.Message}");
		Console.WriteLine($"Subscriber 2 Consumed Context");
		return Task.CompletedTask;
	}
}
