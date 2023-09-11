// Di in console app https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
using ConsoleApp.CustomerRegisterCommandConsumerAndPublishEvent;

using MassTransit;

using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

//https://masstransit.io/documentation/configuration#host-options
builder.Services.AddMassTransit(x =>
{
	x.AddConsumer<CommandConsumer>();

	// A Transport
	x.UsingRabbitMq((context, cfg) =>
	{
		//https://masstransit.io/documentation/configuration#receive-endpoints
		cfg.ReceiveEndpoint("customer-register-command-queue", e =>
		{
			e.ConfigureConsumer<CommandConsumer>(context);
		});
	});
});

using IHost host = builder.Build();


await host.RunAsync();


