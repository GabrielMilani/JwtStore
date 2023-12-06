using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class AddressCreateCommand : Notifiable<Notification>, ICommand
{
    public AddressCreateCommand(string street, string number, string neighborhood, string city, string state, string country,
                                string zipCode, int userId)
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

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
    public int UserId { get; private set; }

    public void Validate()
    {

    }
}