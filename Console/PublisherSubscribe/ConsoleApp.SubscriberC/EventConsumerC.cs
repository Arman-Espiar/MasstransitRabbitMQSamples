using MassTransit;

using MessageContracts;

namespace ConsoleApp.SubscriberC;
public class EventConsumerC : IConsumer<CustomerRegistered>
{
	public Task Consume(ConsumeContext<CustomerRegistered> context)
	{
		Console.WriteLine($"Subscriber C Consuming Context - {context.MessageId}");
		Console.WriteLine($"Consumer Id: {context.Message.CustomerId}");
		Console.WriteLine($"Message: {context.Message.Message}");
		Console.WriteLine($"Subscriber C Consumed Context");
		return Task.CompletedTask;
	}
}
