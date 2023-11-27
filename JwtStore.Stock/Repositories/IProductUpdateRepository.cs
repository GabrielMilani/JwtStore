using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface IProductUpdateRepository
{
    Task<Product?> GetProductByIdAsync(Guid productId);
    Task SaveAsync(Product product);
}