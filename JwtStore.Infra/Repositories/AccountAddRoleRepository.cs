﻿using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class AccountAddRoleRepository : IAccountAddRoleRepository
{
    private readonly AppDbContext _context;
    public AccountAddRoleRepository(AppDbContext context)
        => _context = context;
    public async Task<User?> GetUserByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(x => x.Email.Address == email);

    public async Task<Role?> GetRoleByTitleAsync(string title)
        => await _context.Roles.FirstOrDefaultAsync(x => x.Title == title);

    public async Task SaveAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}