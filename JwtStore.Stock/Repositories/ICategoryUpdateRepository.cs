using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface ICategoryUpdateRepository
{
    Task<Category?> GetCategoryByIdAsync(Guid categoryId);
    Task SaveAsync(Category category);
}