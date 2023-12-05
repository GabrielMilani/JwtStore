using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface IProductUpdateRepository
{
    Task<Product?> GetProductByIdAsync(int productId);
    Task SaveAsync(Product product);
}