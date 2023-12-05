using JwtStore.Stock.Entities;
using System.Linq.Expressions;

namespace JwtStore.Stock.Queries;

public static class ProductQueries
{
    public static Expression<Func<Product, bool>> GetById(int productId)
    {
        return x => x.Id == productId;
    }
}