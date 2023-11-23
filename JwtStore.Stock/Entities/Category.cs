using JwtStore.Shared.Entities;

namespace JwtStore.Stock.Entities;

public class Category : Entity
{
    public Category()
    {
    }

    public Category(string title)
    {
        Title = title;
    }

    public string Title { get; private set; }
    public List<Product> Products { get; set; } = new();

    public void UpdateTitleCategory(string newTitle)
    {
        Title = newTitle;
    }

}