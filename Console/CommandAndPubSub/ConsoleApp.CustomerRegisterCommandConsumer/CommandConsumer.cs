using MassTransit;

using MessageContracts;

namespace ConsoleApp.CustomerRegisterCommandConsumerAndPublishEvent;
public class CommandConsumer : IConsumer<RegisterCustomerCommand>
{
	//A command tells a service to do something, and typically a command should only be consumed by a single consumer.
	//https://masstransit.io/documentation/concepts/messages#commands
	public Task Consume(ConsumeContext<RegisterCustomerCommand> context)
	{
		Console.WriteLine("Command Received.");
		Console.WriteLine();

		Console.WriteLine($"Message Id = {context.MessageId}");
		Console.WriteLine(context.Message.Id);
		Console.WriteLine(context.Message.FirstName);
		Console.WriteLine(context.Message.LastName);
		Console.WriteLine(context.Message.Email);
		Console.WriteLine(context.Message.RegisteredDateTime);

		//The same rules for endpoints apply, the closest instance of the publish endpoint should be used. So the ConsumeContext for consumers, and IBus for applications that are published outside of a consumer context.
		//https://masstransit.io/documentation/concepts/producers#publish
		//Consumer publish Event
		return context.Publish<CustomerRegistered>(new()
		{
			CustomerId = context.Message.Id,
			Message = $"{context.Message.FirstName} {context.Message.LastName}"
		});


	}
}
