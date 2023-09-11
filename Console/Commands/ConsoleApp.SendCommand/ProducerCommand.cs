using MassTransit;

using MessageContracts;

namespace ConsoleApp.SendCommand;
public class ProducerCommand
{
	private readonly ISendEndpointProvider _endEndpointProvider;

	public ProducerCommand(ISendEndpointProvider endEndpointProvider)
	{
		_endEndpointProvider = endEndpointProvider;
	}
	public async Task SendNewCustomerAsync(RegisterCustomerCommand newCustomer)
	{
		var endpoint = await _endEndpointProvider.GetSendEndpoint(new Uri("queue:send-command-queue"));

		await endpoint.Send(newCustomer);
	}
}
