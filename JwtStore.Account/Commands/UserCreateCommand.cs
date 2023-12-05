using Flunt.Notifications;
using Flunt.Validations;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class UserCreateCommand : Notifiable<Notification>, ICommand
{
    public UserCreateCommand(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(Name.Length, 160, "Name", "O nome deve conter menos que 160 caracteres")
            .IsGreaterThan(Name.Length, 3, "Name", "O nome deve conter mais que 3 caracteres")
            .IsLowerThan(Password.Length, 40, "Password", "A senha deve conter menos que 40 caracteres")
            .IsGreaterThan(Password.Length, 6, "Password", "A senha deve conter mais que 6 caracteres")
            .IsEmail(Email, "Email", "E-mail inválido"));
    }
}