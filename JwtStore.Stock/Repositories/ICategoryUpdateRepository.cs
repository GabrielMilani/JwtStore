using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface ICategoryUpdateRepository
{
    Category GetCategoryById(Guid categoryId);
    Task SaveAsync(Category category);
}