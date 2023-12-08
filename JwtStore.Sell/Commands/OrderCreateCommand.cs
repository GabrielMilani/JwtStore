using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Order.Commands;

public class OrderCreateCommand : Notifiable<Notification>, ICommand
{
    public OrderCreateCommand(string customerEmail, DateTime createDate)
    {
        CustomerEmail = customerEmail;
        CreateDate = createDate;
    }

    public string CustomerEmail { get; set; }
    public DateTime CreateDate { get; set; }


    public void Validate()
    {

    }
}