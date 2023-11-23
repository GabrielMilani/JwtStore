using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class CategoryUpdateRepository : ICategoryUpdateRepository
{
    private readonly AppDbContext _context;

    public CategoryUpdateRepository(AppDbContext context)
    {
        _context = context;
    }

    public Category GetCategoryById(Guid categoryId)
    {
        return _context.Categories.AsNoTracking().First(x => x.Id == categoryId);
    }

    public async Task SaveAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }
}