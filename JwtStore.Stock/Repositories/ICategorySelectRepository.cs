using JwtStore.Stock.Entities;

namespace JwtStore.Stock.Repositories;

public interface ICategorySelectRepository
{
    Task<Category?> GetById(int id);
}