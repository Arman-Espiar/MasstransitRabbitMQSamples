// Di in console app https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage
using MassTransit;

using Microsoft.Extensions.Hosting;

using ReceiveAndConsumeTheCommand;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

//https://masstransit.io/documentation/configuration#host-options
builder.Services.AddMassTransit(x =>
{
	x.AddConsumer<CommandConsumer>();

	// A Transport
	x.UsingRabbitMq((context, cfg) =>
	{
		//https://masstransit.io/documentation/configuration#receive-endpoints
		cfg.ReceiveEndpoint("send-command-queue", e =>
		{
			e.ConfigureConsumer<CommandConsumer>(context);
		});
	});
});

using IHost host = builder.Build();


await host.RunAsync();


