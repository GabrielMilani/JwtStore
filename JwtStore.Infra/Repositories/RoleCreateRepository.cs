using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class RoleCreateRepository : IRoleCreateRepository
{
    private readonly AppDbContext _context;

    public RoleCreateRepository(AppDbContext context)
        => _context = context;

    public async Task<bool> AnyAsync(string title)
        => await _context.Roles
            .AsNoTracking()
            .AnyAsync(x => x.Title == title);
    public async Task SaveAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
    }
}