using JwtStore.Stock.Entities;

namespace JwtStore.Order.Repositories;

public interface IOrderItemsInsertRepository
{
    Task<Entities.Order?> GetOrderById(int orderId);
    Task<Product?> GetItemById(int productId);
    Task SaveAsync(Entities.Order order);
}