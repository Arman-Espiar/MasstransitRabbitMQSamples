//https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
using ConsoleApp.SubscriberB;

using MassTransit;

using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

//https://masstransit.io/documentation/configuration#host-options
builder.Services.AddMassTransit(x =>
{
	x.AddConsumer<EventConsumerB>();

	// A Transport
	x.UsingRabbitMq((context, cfg) =>
	{
		//Automatic receive endpoint configuration by calling ConfigureEndpoints is highly recommended.
		//https://masstransit.io/documentation/concepts/consumers#message-consumers
		cfg.ConfigureEndpoints(context);
	});
});

using IHost host = builder.Build();


await host.RunAsync();


Console.WriteLine("Event Received.");



Console.WriteLine();