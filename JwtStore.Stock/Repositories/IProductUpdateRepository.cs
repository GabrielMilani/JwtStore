using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface IProductUpdateRepository
{
    Product GetProductById(Guid productId);
    Task SaveAsync(Product product);
}