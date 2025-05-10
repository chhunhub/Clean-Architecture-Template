using FluentValidation;

namespace CleanArchitectureWeb.Application.CreateCustomer;
internal sealed class CustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
{
    public CustomerCommandValidation()
    {
        RuleFor(rule => rule.email).NotEmpty().EmailAddress();
        RuleFor(rule => rule.phonenumber).NotEmpty();
        RuleFor(rule => rule.lastName).NotEmpty();
        RuleFor(rule => rule.firstName).NotEmpty();
        RuleFor(rule => rule.phonenumber).NotEmpty();
    }
}

