using SharedKernel;

namespace CleanArchitectureWeb.Application.GetCustomerList;
public sealed record GetCustomerQuery() : IQuery<IReadOnlyList<CustomerResponse>>;

