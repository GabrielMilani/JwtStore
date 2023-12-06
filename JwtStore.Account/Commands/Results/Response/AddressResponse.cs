namespace JwtStore.Account.Commands.Results.Response;

public class AddressResponse
{
    public AddressResponse(int? id, string? street, string? number, string? neighborhood, string? city,
                          string? state, string? country, string? zipCode)
    {
        Id = id;
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public int? Id { get; set; }
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; }
}