using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class ProductUpdateRepository : IProductUpdateRepository
{
    private readonly AppDbContext _context;

    public ProductUpdateRepository(AppDbContext context)
    {
        _context = context;
    }

    public Product GetProductById(Guid productId)
    {
        return _context.Products.AsNoTracking().First(x => x.Id == productId);
    }

    public async Task SaveAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
}