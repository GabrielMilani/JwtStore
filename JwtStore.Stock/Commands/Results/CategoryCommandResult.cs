using JwtStore.Shared.Commands;
using JwtStore.Stock.Commands.Results.Response;

namespace JwtStore.Stock.Commands.Results;

public class CategoryCommandResult : ICommandResult
{
    public CategoryCommandResult() { }


    public CategoryCommandResult(bool? success, string? message, List<CategoryResponse>? categories)
    {
        Success = success;
        Message = message;
        Categories = categories;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public List<CategoryResponse>? Categories { get; set; }
}