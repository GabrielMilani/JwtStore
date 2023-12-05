using JwtStore.Shared.Commands;
using JwtStore.Stock.Commands.Results.Response;

namespace JwtStore.Stock.Commands.Results;

public class ProductCommandResult : ICommandResult
{
    public ProductCommandResult(bool? success, string? message, List<ProductResponse>? products)
    {
        Success = success;
        Message = message;
        Products = products;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public List<ProductResponse>? Products { get; set; }
}