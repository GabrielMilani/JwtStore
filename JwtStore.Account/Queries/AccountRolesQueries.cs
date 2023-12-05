using JwtStore.Account.Entities;
using System.Linq.Expressions;

namespace JwtStore.Account.Queries;

public static class AccountRolesQueries
{
    public static Expression<Func<Role, bool>> GetById(int roleId)
    {
        return x => x.Id == roleId;
    }
}