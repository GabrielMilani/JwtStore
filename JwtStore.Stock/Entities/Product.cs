using JwtStore.Shared.Entities;

namespace JwtStore.Stock.Entities;

public class Product : Entity
{
    public Product()
    {
    }

    public Product(string title, string description, decimal price, decimal quantityOnHand,
                   DateTime createDate, DateTime lastUpdateDate, Guid categoryId)
    {
        Title = title;
        Description = description;
        Price = price;
        QuantityOnHand = quantityOnHand;
        CreateDate = createDate;
        LastUpdateDate = lastUpdateDate;
        CategoryId = categoryId;
    }

    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public decimal QuantityOnHand { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    public void UpdateTitleProduct(string newTitle)
    {
        Title = newTitle;
    }
    public void UpdateDescriptionProduct(string newDescription)
    {
        Description = newDescription;
    }
    public void UpdatePriceProduct(decimal newPrice)
    {
        Price = newPrice;
    }
    public void UpdateQuantityOnHandProduct(decimal newQuantityOnHand)
    {
        QuantityOnHand = newQuantityOnHand;
    }
    public void UpdateCategoryProduct(Guid newCategoryId)
    {
        CategoryId = newCategoryId;
    }
}