﻿using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class AuthenticateRepository : IAuthenticateRepository
{
    private readonly AppDbContext _context;

    public AuthenticateRepository(AppDbContext context)
        => _context = context;

    public async Task<User?> GetUserByEmailAsync(string email)
        => await _context.Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email.Address == email);

}