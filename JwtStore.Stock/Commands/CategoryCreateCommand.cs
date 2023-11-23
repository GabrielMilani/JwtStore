using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Stock.Commands;

public class CategoryCreateCommand : Notifiable<Notification>, ICommand
{
    public CategoryCreateCommand(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    public void Validate() { }
}