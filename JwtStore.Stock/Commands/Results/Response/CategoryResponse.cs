namespace JwtStore.Stock.Commands.Results.Response;

public class CategoryResponse
{
    public CategoryResponse(int? id, string? title)
    {
        Id = id;
        Title = title;
    }

    public int? Id { get; set; }
    public string? Title { get; set; }
}