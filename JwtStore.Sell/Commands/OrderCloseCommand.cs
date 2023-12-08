using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Order.Commands;

public class OrderCloseCommand : Notifiable<Notification>, ICommand
{
    public OrderCloseCommand(int orderId)
    {
        OrderId = orderId;
    }

    public int OrderId { get; private set; }

    public void Validate()
    {

    }
}