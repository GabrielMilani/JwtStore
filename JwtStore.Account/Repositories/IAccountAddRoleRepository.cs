using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAccountAddRoleRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<Role?> GetRoleByTitleAsync(string title);
    Task SaveAsync(User user);
}