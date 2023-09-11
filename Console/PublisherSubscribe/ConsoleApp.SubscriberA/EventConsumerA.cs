using MassTransit;

using MessageContracts;

namespace ConsoleApp.Subscriber2;
public class EventConsumerA : IConsumer<CustomerRegistered>
{
	public Task Consume(ConsumeContext<CustomerRegistered> context)
	{
		Console.WriteLine($"Subscriber A Consuming Context - {context.MessageId}");
		Console.WriteLine($"Consumer Id: {context.Message.CustomerId}");
		Console.WriteLine($"Message: {context.Message.Message}");
		Console.WriteLine($"Subscriber A Consumed Context");
		return Task.CompletedTask;
	}
}
