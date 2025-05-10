namespace CleanArchitectureWeb.Application.GetCustomerList;

public sealed record CustomerResponse(Guid id,
        string firstName,
        string lastName,
        string email,
        string address,
        string phoneNumber);

