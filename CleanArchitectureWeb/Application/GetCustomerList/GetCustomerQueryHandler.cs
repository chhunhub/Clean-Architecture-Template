using CleanArchitectureWeb.Domain.Repositories;
using SharedKernel;

namespace CleanArchitectureWeb.Application.GetCustomerList;
public sealed class GetCustomerQueryHandler
    (ICustomerRepository customerRepository)
    : IQueryHandler<GetCustomerQuery, IReadOnlyList<CustomerResponse>>
{
    public async Task<Result<IReadOnlyList<CustomerResponse>>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customers = await customerRepository.GetListAsync(cancellationToken);
        if (!customers.Any())
        {
            return Result.Failure<IReadOnlyList<CustomerResponse>>(Error.NotExist("Customer doesn't exist!"));
        }
        return customers.Select(
            customer => new CustomerResponse(
                customer.Id,
                customer.FirstName.Value,
                customer.LastName.Value,
                customer.Email.Value,
                customer.Address.Value,
                customer.PhoneNumber.Value)).ToList();
    }
}
