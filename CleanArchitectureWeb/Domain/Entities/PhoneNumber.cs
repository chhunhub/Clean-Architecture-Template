using System.Text.RegularExpressions;

namespace CleanArchitectureWeb.Domain.Entities;
public sealed record PhoneNumber(string phoneNumber)
{
    public string Value => IsValid(phoneNumber) ? phoneNumber : throw new ApplicationException("Your phonenumber is not match!");
    private static bool IsValid(string value)
    {
        return Regex.IsMatch(value, @"^\+?[1-9]\d{9,14}$");
    }

}
