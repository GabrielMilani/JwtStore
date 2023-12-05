using JwtStore.Account.Entities;
using System.Linq.Expressions;

namespace JwtStore.Account.Queries;

public static class RolesQueries
{
    public static Expression<Func<Role, bool>> GetById(int roleId)
    {
        return x => x.Id == roleId;
    }
}