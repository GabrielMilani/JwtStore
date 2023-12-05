using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Queries;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class ProductSelectRepository : IProductSelectRepository
{
    private readonly AppDbContext _context;

    public ProductSelectRepository(AppDbContext context)
        => _context = context;

    public async Task<Product?> GetById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(ProductQueries.GetById(id));
    }
}