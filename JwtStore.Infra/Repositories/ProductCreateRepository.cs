using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class ProductCreateRepository : IProductCreateRepository
{
    private readonly AppDbContext _context;

    public ProductCreateRepository(AppDbContext context)
        => _context = context;

    public async Task SaveAsync(Product product)
    {
        _context.Products.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}