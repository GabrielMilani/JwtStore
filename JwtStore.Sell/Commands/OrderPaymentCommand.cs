using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Order.Commands;

public class OrderPaymentCommand : Notifiable<Notification>, ICommand
{
    public OrderPaymentCommand(int orderId)
    {
        OrderId = orderId;
    }

    public int OrderId { get; private set; }

    public void Validate()
    {

    }
}