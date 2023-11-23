using Flunt.Notifications;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using JwtStore.Stock.Commands;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;

namespace JwtStore.Stock.Handlers;

public class CategoryCreateHandler : Notifiable<Notification>, IHandler<CategoryCreateCommand>
{
    private readonly ICategoryCreateRepository _categoryCreateReposiroty;

    public CategoryCreateHandler(ICategoryCreateRepository categoryCreateReposiroty)
    {
        _categoryCreateReposiroty = categoryCreateReposiroty;
    }
    public ICommandResult Handle(CategoryCreateCommand command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult();
        }
        catch
        {
            return new CommandResult();
        }
        Category category;
        try
        {
            category = new Category(command.Title);
        }
        catch
        {
            return new CommandResult(false, "Falha ao criar categoria!");
        }
        try
        {
            _categoryCreateReposiroty.SaveAsync(category);
        }
        catch
        {
            return new CommandResult(false, "Falha ao salvar categoria!");
        }
        return new CommandResult(true, "Categoria criada com sucesso!", category);
    }
}