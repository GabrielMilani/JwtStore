using JwtStore.Shared.Entities;

namespace JwtStore.Account.Entities;

public class Role : Entity
{
    public Role()
    {
    }

    public Role(string title)
    {
        Title = title;
    }

    public string Title { get; private set; } = string.Empty;
    public IList<User?> Users { get; private set; } = new List<User?>();
}