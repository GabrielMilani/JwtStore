using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Stock.Commands;

public class ProductCreateCommand : Notifiable<Notification>, ICommand
{
    public ProductCreateCommand(string title, string description, decimal price, decimal quantityOnHand,
                                DateTime createDate, DateTime lastUpdateDate, int categoryId)
    {
        Title = title;
        Description = description;
        Price = price;
        QuantityOnHand = quantityOnHand;
        CreateDate = createDate;
        LastUpdateDate = lastUpdateDate;
        CategoryId = categoryId;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal QuantityOnHand { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public int CategoryId { get; set; }

    public void Validate() { }
}