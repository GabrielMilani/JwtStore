using Flunt.Notifications;
using JwtStore.Account.Entities;
using JwtStore.Shared.Commands;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JwtStore.Account.Commands;

public class AccountAddRoleCommand : Notifiable<Notification>, ICommand
{
    public AccountAddRoleCommand(string email, string role)
    {
        Email = email;
        Role = role;
    }

    public string Email { get; set; }
    public string Role { get; set; }
    public void Validate() { }
}