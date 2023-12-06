using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAddressSelectRepository
{
    Task<Address?> GetById(int addressId);
}