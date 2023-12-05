using JwtStore.Stock.Entities;
using System.Linq.Expressions;

namespace JwtStore.Stock.Queries;

public static class CategoryQueries
{
    public static Expression<Func<Category, bool>> GetById(int categoryId)
    {
        return x => x.Id == categoryId;
    }
}