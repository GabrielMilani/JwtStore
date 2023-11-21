using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class AccountAuthenticateRepository : IAccountAuthenticateRepository
{
    private readonly AppDbContext _context;
    public AccountAuthenticateRepository(AppDbContext context)
        => _context = context;
    public User? GetUserByEmailAsync(string email)
        => _context.Users.AsNoTracking().FirstOrDefault(x => x.Email.Address == email);

}