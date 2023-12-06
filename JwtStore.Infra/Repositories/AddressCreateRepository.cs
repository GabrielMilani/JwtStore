using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;

namespace JwtStore.Infra.Repositories;

public class AddressCreateRepository : IAddressCreateRepository
{
    private readonly AppDbContext _context;

    public AddressCreateRepository(AppDbContext context)
        => _context = context;

    public async Task SaveAsync(Address address)
    {
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
    }
}