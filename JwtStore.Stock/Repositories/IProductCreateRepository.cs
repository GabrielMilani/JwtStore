using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface IProductCreateRepository
{
    Task SaveAsync(Product product);
}