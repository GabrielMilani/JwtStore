using JwtStore.Account.Entities;
using JwtStore.Account.Queries;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class AddressSelectRepository : IAddressSelectRepository
{
    private readonly AppDbContext _context;

    public AddressSelectRepository(AppDbContext context)
        => _context = context;
    public async Task<Address?> GetById(int addressId)
        => await _context.Addresses.FirstOrDefaultAsync(AddressQueries.GetById(addressId));
}