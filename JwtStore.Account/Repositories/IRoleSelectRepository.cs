using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface ISelectRoleRepository
{
    Task<Role?> GetById(int roleId);
}