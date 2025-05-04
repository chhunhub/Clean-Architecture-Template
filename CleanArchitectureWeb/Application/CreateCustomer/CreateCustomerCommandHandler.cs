using CleanArchitectureWeb.Domain.Abstractions;
using CleanArchitectureWeb.Domain.Entities;
using CleanArchitectureWeb.Domain.Repositories;
using MediatR;

namespace CleanArchitectureWeb.Application.CreateCustomer;
internal sealed class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCustomerCommand, Guid>
{
    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.CheckDuplicated(firstName: request.firstName, lastName: request.lastName, cancellationToken);
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }
        var CreateCustomer = Customer.CreateCustomer(
            new FirstName(request.firstName),
            new LastName(request.lastName),
            new Email(request.email),
            new Address(request.address),
            new PhoneNumber(request.phonenumber));
        customerRepository.Add(CreateCustomer);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return customer.Id;
    }
}

