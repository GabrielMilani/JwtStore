using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Order.Commands;

public class OrderItemsInsertCommand : Notifiable<Notification>, ICommand
{
    public OrderItemsInsertCommand(int orderId, int productId, decimal quantity, decimal price)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public int OrderId { get; set; }
    public int ProductId { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal Price { get; private set; }
    public void Validate()
    {

    }
}