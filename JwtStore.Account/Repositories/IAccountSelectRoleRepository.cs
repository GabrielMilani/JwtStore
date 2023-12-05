using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAccountSelectRoleRepository
{
    Task<Role?> GetById(int roleId);
}