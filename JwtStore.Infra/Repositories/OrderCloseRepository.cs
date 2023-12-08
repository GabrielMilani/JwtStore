using JwtStore.Infra.Data;
using JwtStore.Order.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class OrderCloseRepository : IOrderCloseRepository
{
    private readonly AppDbContext _context;

    public OrderCloseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order.Entities.Order?> GetOrderById(int orderId)
    {
        return await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
    }

    public async Task SaveAsync(Order.Entities.Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}