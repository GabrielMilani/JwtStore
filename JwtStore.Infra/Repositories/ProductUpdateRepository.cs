using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Queries;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class ProductUpdateRepository : IProductUpdateRepository
{
    private readonly AppDbContext _context;

    public ProductUpdateRepository(AppDbContext context)
        => _context = context;

    public async Task<Product?> GetProductByIdAsync(int productId)
        => await _context.Products.FirstOrDefaultAsync(ProductQueries.GetById(productId));

    public async Task SaveAsync(Product product)
    {
        _context.Products.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}