using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class CategoryUpdateRepository : ICategoryUpdateRepository
{
    private readonly AppDbContext _context;

    public CategoryUpdateRepository(AppDbContext context)
        => _context = context;

    public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
    {
        return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == categoryId);
    }

    public async Task SaveAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }
}