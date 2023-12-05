using Flunt.Notifications;
using Flunt.Validations;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class AuthenticateCommand : Notifiable<Notification>, ICommand
{
    public AuthenticateCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(Password.Length, 40, "Password", "A senha deve conter menos que 40 caracteres")
            .IsGreaterThan(Password.Length, 6, "Password", "A senha deve conter mais que 6 caracteres")
            .IsEmail(Email, "Email", "E-mail inválido"));
    }
}