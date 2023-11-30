using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class AccountCreateRoleCommand : Notifiable<Notification>, ICommand
{
    public AccountCreateRoleCommand(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    public void Validate() { }
}