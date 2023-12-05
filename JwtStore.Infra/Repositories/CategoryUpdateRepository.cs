using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Queries;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class CategoryUpdateRepository : ICategoryUpdateRepository
{
    private readonly AppDbContext _context;

    public CategoryUpdateRepository(AppDbContext context)
        => _context = context;

    public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        => await _context.Categories.FirstOrDefaultAsync(CategoryQueries.GetById(categoryId));

    public async Task SaveAsync(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}