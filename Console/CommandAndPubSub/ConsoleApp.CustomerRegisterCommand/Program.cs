// producers send commands
//https://masstransit.io/documentation/concepts/producers#send-endpoint

using ConsoleApp.CustomerRegisterCommand;

using MassTransit;

using MessageContracts;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


//Di in console app https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<ProducerCommand>();

//https://masstransit.io/documentation/configuration#host-options
builder.Services.AddMassTransit(x =>
{
	// A Transport
	x.UsingRabbitMq((context, cfg) =>
	{
	});
});

using IHost host = builder.Build();

Console.WriteLine("Enter the First Name");
var firstName = Console.ReadLine();

Console.WriteLine("Enter the Last Name");
var lastName = Console.ReadLine();

Console.WriteLine("Enter the Email");
var email = Console.ReadLine();


var newCustomer = new RegisterCustomerCommand
{
	Id = NewId.NextGuid(),
	FirstName = firstName,
	LastName = lastName,
	Email = email,
	RegisteredDateTime = DateTime.UtcNow
};
await ExemplifySendCommand(host.Services, newCustomer);
await host.RunAsync();


static async Task ExemplifySendCommand(IServiceProvider hostProvider, RegisterCustomerCommand newCustomer)
{
	using IServiceScope serviceScope = hostProvider.CreateScope();
	IServiceProvider provider = serviceScope.ServiceProvider;
	ProducerCommand producer = provider.GetRequiredService<ProducerCommand>();


	await producer.SendNewCustomerAsync(newCustomer);


	Console.WriteLine("Command Sent.");



	Console.WriteLine();
}
