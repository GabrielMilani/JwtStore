using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface ICategoryCreateRepository
{
    Task SaveAsync(Category category);
}