using JwtStore.Shared.Entities;

namespace JwtStore.Account.Entities;

public class Address : Entity
{
    public Address()
    {
    }
    public Address(string street, string number, string neighborhood, string city, string state,
                   string country, string zipCode, int userId)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        UserId = userId;
    }

    public string Street { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;
    public string ZipCode { get; private set; } = string.Empty;
    public int? UserId { get; private set; }
    public User? User { get; set; }
}