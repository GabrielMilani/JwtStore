using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class AccountCreateUserRepository : IAccountCreateUserRepository
{
    private readonly AppDbContext _context;

    public AccountCreateUserRepository(AppDbContext context)
        => _context = context;
    public async Task<bool> AnyAsync(string email)
        => await _context.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email.Address == email);

    public async Task SaveAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}