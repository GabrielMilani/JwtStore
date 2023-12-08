using JwtStore.Account.Entities;
using JwtStore.Infra.Data;
using JwtStore.Order.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class OrderCreateRepository : IOrderCreateRepository
{
    private readonly AppDbContext _context;

    public OrderCreateRepository(AppDbContext context)
        => _context = context;


    public async Task<User?> GetUserByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(x => x.Email.Address == email);

    public async Task SaveAsync(Order.Entities.Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
}