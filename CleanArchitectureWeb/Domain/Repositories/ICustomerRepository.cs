using CleanArchitectureWeb.Domain.Entities;

namespace CleanArchitectureWeb.Domain.Repositories;
public interface ICustomerRepository
{
    Task<IReadOnlyList<Customer>> GetListAsync(CancellationToken cancellationToken = default);
    Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Customer?> CheckDuplicated(string firstName, string lastName, CancellationToken cancellationToken = default);
    void Add(Customer customer);
    void Update(Customer customer);
    void Remove(Customer customer);
}

