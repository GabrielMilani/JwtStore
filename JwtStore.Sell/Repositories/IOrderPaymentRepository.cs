namespace JwtStore.Order.Repositories;

public interface IOrderPaymentRepository
{
    Task<Entities.Order?> GetOrderById(int orderId);
    Task SaveAsync(Entities.Order order);
}