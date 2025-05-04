using CleanArchitectureWeb.Domain.Entities;
using CleanArchitectureWeb.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWeb.Infrastructure.Repositories;
internal sealed class CustomerRepository(CleanArchitectureDbContext dbContext) : ICustomerRepository
{
    public void Add(Customer customer)
    {
        dbContext.Customers.Add(customer);
    }

    public async Task<Customer?> CheckDuplicated(string firstName, string lastName, CancellationToken cancellationToken = default)
    {
        return await dbContext.Customers.FirstOrDefaultAsync(
            customer => customer.FirstName == new FirstName(firstName)
            && customer.LastName == new LastName(lastName), cancellationToken);
    }

    public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Customers.FirstOrDefaultAsync(
             customer => customer.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Customer>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Customers.ToListAsync(cancellationToken);
    }

    public void Remove(Customer customer)
    {
        dbContext.Customers.Remove(customer);
    }

    public void Update(Customer customer)
    {
        dbContext?.Customers.Update(customer);
    }
}

