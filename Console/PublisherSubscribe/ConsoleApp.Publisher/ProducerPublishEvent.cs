using MassTransit;

using MessageContracts;

namespace ConsoleApp.Publisher;
public class ProducerPublishEvent
{
	private readonly IPublishEndpoint _publishEndpoint;

	public ProducerPublishEvent(IPublishEndpoint publishEndpoint)
	{
		_publishEndpoint = publishEndpoint;
	}

	public Task PublishCustomerRegisteredAsync(Guid customerId, string message)
	{
		return _publishEndpoint.Publish<CustomerRegistered>(new()
		{
			CustomerId = customerId,
			Message = message
		});
	}
}
