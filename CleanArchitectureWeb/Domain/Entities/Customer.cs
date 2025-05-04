using CleanArchitectureWeb.Domain.Abstractions;
using CleanArchitectureWeb.Domain.DomainEvent;

namespace CleanArchitectureWeb.Domain.Entities;

public sealed class Customer : Entity
{
    private Customer() { }
    private Customer(
        Guid id,
        FirstName firstName,
        LastName lastName,
        Email email,
        Address address,
        PhoneNumber phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
        PhoneNumber = phoneNumber;
    }
    public Guid Id { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public static Customer CreateCustomer(FirstName firstName,
        LastName lastName,
        Email email,
        Address address,
        PhoneNumber phoneNumber)
    {
        Customer? customer = new Customer(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            address,
            phoneNumber);
        customer.RaiseDomainEvent(new CreateCustomerDomainEvent(customer.Id));
        return customer;
    }

}

