using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class ProductUpdateRepository : IProductUpdateRepository
{
    private readonly AppDbContext _context;

    public ProductUpdateRepository(AppDbContext context)
        => _context = context;

    public async Task<Product?> GetProductByIdAsync(Guid productId)
        => await _context.Products.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == productId);

    public async Task SaveAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
}