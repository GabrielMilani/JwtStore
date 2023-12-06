using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAddressCreateRepository
{
    Task SaveAsync(Address address);
}