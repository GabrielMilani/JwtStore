namespace JwtStore.Order.Repositories;

public interface IOrderCloseRepository
{
    Task<Entities.Order?> GetOrderById(int orderId);
    Task SaveAsync(Entities.Order order);
}