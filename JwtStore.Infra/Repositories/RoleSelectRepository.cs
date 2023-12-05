using JwtStore.Account.Entities;
using JwtStore.Account.Queries;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class RoleSelectRepository : ISelectRoleRepository
{
    private readonly AppDbContext _context;

    public RoleSelectRepository(AppDbContext context)
      => _context = context;

    public async Task<Role?> GetById(int roleId)
    {
        return await _context.Roles.FirstOrDefaultAsync(RolesQueries.GetById(roleId));
    }
}