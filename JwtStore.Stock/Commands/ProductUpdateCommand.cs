using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Stock.Commands;

public class ProductUpdateCommand : Notifiable<Notification>, ICommand
{
    public ProductUpdateCommand(Guid id, string title, string description, decimal price, decimal quantityOnHand,
                                DateTime lastUpdateDate, Guid categoryId)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        QuantityOnHand = quantityOnHand;
        LastUpdateDate = lastUpdateDate;
        CategoryId = categoryId;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal QuantityOnHand { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public Guid CategoryId { get; set; }

    public void Validate() { }
}