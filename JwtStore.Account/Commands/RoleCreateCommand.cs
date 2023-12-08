using Flunt.Notifications;
using Flunt.Validations;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class RoleCreateCommand : Notifiable<Notification>, ICommand
{
    public RoleCreateCommand(string title)
    {
        Title = title;
    }

    public string Title { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(Title.Length, 40, "Title", "A Title deve conter menos que 40 caracteres")
            .IsGreaterThan(Title.Length, 3, "Title", "A Title deve conter mais que 6 caracteres"));
    }
}