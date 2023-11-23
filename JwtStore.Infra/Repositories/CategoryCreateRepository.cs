using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;

namespace JwtStore.Infra.Repositories;

public class CategoryCreateRepository : ICategoryCreateRepository
{
    private readonly AppDbContext _context;

    public CategoryCreateRepository(AppDbContext context)
        => _context = context;

    public async Task SaveAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }
}