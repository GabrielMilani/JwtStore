using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class AccountRoleCreateCommand : Notifiable<Notification>, ICommand
{
    public AccountRoleCreateCommand(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    public void Validate() { }
}