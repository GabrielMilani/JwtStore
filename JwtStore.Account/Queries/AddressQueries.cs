using JwtStore.Account.Entities;
using System.Linq.Expressions;

namespace JwtStore.Account.Queries;

public static class AddressQueries
{
    public static Expression<Func<Address, bool>> GetById(int addressId)
    {
        return x => x.Id == addressId;
    }
}