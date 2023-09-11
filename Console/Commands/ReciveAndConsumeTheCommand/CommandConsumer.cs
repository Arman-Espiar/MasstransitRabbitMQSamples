using MassTransit;

using MessageContracts;

namespace ReceiveAndConsumeTheCommand;
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
		return Task.CompletedTask;
	}
}
