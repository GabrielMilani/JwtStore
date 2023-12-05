using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;

namespace JwtStore.Infra.Repositories;

public class ProductCreateRepository : IProductCreateRepository
{
    private readonly AppDbContext _context;

    public ProductCreateRepository(AppDbContext context)
        => _context = context;

    public async Task SaveAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
}