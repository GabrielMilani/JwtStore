namespace JwtStore.Account.Commands.Results.Response;

public class RoleResponse
{
    public RoleResponse(int? id, string? title)
    {
        Id = id;
        Title = title;
    }

    public int? Id { get; set; }
    public string? Title { get; set; }
}