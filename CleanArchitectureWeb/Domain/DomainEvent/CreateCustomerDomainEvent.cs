using SharedKernel;

namespace CleanArchitectureWeb.Domain.DomainEvent;
public sealed record CreateCustomerDomainEvent(Guid Id) : IDomainEvent;


