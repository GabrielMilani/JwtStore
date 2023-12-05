using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Stock.Commands;

public class ProductUpdateCommand : Notifiable<Notification>, ICommand
{
    public ProductUpdateCommand(int id, string title, string description, decimal price, decimal quantityOnHand,
                                DateTime lastUpdateDate, int categoryId)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        QuantityOnHand = quantityOnHand;
        LastUpdateDate = lastUpdateDate;
        CategoryId = categoryId;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal QuantityOnHand { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public int CategoryId { get; set; }

    public void Validate() { }
}