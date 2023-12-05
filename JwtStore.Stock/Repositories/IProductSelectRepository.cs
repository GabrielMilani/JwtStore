using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface IProductSelectRepository
{
    Task<Product?> GetById(int id);
}