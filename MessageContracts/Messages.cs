namespace MessageContracts;

//You can use Records, Interfaces and Classes for messages
//https://masstransit.io/documentation/concepts/messages#message-types


/// <summary>
/// RegisterCustomer Command
/// https://masstransit.io/documentation/concepts/messages#commands
/// </summary>
public record RegisterCustomerCommand
{
	public Guid Id { get; init; }
	public required string FirstName { get; init; }
	public required string LastName { get; init; }
	public required string Email { get; init; }
	public required DateTime RegisteredDateTime { get; init; }
}


/// <summary>
///  CustomerRegistered event
///  https://masstransit.io/documentation/concepts/messages#events
/// </summary>
public record CustomerRegistered
{
	public Guid CustomerId { get; init; }
	public required string Message { get; init; }
}