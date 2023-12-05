using Flunt.Notifications;
using JwtStore.Shared.Commands;

namespace JwtStore.Stock.Commands;

public class CategoryUpdateCommand : Notifiable<Notification>, ICommand
{
    public CategoryUpdateCommand(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public void Validate() { }
}