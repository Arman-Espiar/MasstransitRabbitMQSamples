using MassTransit;

using MessageContracts;

namespace ConsoleApp.SubscriberB;
public class EventConsumerB : IConsumer<CustomerRegistered>
{
	public Task Consume(ConsumeContext<CustomerRegistered> context)
	{
		Console.WriteLine($"Subscriber B Consuming Context - {context.MessageId}");
		Console.WriteLine($"Consumer Id: {context.Message.CustomerId}");
		Console.WriteLine($"Message: {context.Message.Message}");
		Console.WriteLine($"Subscriber B Consumed Context");
		return Task.CompletedTask;
	}
}
