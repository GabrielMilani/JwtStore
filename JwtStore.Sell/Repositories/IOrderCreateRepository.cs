using JwtStore.Account.Entities;

namespace JwtStore.Order.Repositories;

public interface IOrderCreateRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task SaveAsync(Entities.Order order);
}