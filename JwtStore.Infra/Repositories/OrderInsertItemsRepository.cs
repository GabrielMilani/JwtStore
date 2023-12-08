using JwtStore.Infra.Data;
using JwtStore.Order.Repositories;
using JwtStore.Stock.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class OrderInsertItemsRepository : IOrderItemsInsertRepository
{
    private readonly AppDbContext _context;

    public OrderInsertItemsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetItemById(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
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