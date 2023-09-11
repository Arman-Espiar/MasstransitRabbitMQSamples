using ConsoleApp.Publisher;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<ProducerPublishEvent>();

//https://masstransit.io/documentation/configuration#host-options
builder.Services.AddMassTransit(x =>
{
	// A Transport
	x.UsingRabbitMq((context, cfg) =>
	{
	});
});

using IHost host = builder.Build();

Console.WriteLine("Enter the Message");
var message = Console.ReadLine();

await ExemplifyPublished(host.Services, message);

await host.RunAsync();


Console.WriteLine("CustomerRegistered Published.");



static async Task ExemplifyPublished(IServiceProvider hostProvider, string message)
{
	using IServiceScope serviceScope = hostProvider.CreateScope();
	IServiceProvider provider = serviceScope.ServiceProvider;
	ProducerPublishEvent producer = provider.GetRequiredService<ProducerPublishEvent>();


	await producer.PublishCustomerRegisteredAsync(NewId.NextGuid(), message);


	Console.WriteLine("Published.");



	Console.WriteLine();
}
