using JwtStore.Infra.Data;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Queries;
using JwtStore.Stock.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Repositories;

public class CategorySelectRepository : ICategorySelectRepository
{
    private readonly AppDbContext _context;

    public CategorySelectRepository(AppDbContext context)
        => _context = context;

    public async Task<Category?> GetById(int id)
        => await _context.Categories.FirstOrDefaultAsync(CategoryQueries.GetById(id));

}