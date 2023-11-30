using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class AccountInsertRoleCommand : Notifiable<Notification>, ICommand
{
    public AccountInsertRoleCommand(string email, string role)
    {
        Email = email;
        Role = role;
    }

    public string Email { get; set; }
    public string Role { get; set; }
    public void Validate() { }
}