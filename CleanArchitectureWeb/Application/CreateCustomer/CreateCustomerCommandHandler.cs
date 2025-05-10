using CleanArchitectureWeb.Domain.Entities;
using CleanArchitectureWeb.Domain.Repositories;
using SharedKernel;

namespace CleanArchitectureWeb.Application.CreateCustomer;
internal sealed class CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository) : ICommandHandler<CreateCustomerCommand, Guid>
{

    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {

        var CreateCustomer = Customer.CreateCustomer(
            new FirstName(request.firstName),
            new LastName(request.lastName),
            new Email(request.email),
            new Address(request.address),
            new PhoneNumber(request.phonenumber));
        customerRepository.Add(CreateCustomer);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return CreateCustomer.Id;
    }
}

