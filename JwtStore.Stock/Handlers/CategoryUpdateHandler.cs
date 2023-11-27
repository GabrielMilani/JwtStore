using Flunt.Notifications;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using JwtStore.Stock.Commands;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;

namespace JwtStore.Stock.Handlers;

public class CategoryUpdateHandler : Notifiable<Notification>, IHandler<CategoryUpdateCommand>
{
    private readonly ICategoryUpdateRepository _categoryUpdateReposiroty;

    public CategoryUpdateHandler(ICategoryUpdateRepository categoryUpdateReposiroty)
    {
        _categoryUpdateReposiroty = categoryUpdateReposiroty;
    }
    public ICommandResult Handle(CategoryUpdateCommand command)
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
        Category? category;
        try
        {
            category = _categoryUpdateReposiroty.GetCategoryByIdAsync(command.Id).Result;
            if (category is null)
                return new CommandResult(false, "Falha ao alterar categoria!");
            category.UpdateTitleCategory(command.Title);
        }
        catch
        {
            return new CommandResult(false, "Falha ao alterar categoria!");
        }
        try
        {
            _categoryUpdateReposiroty.SaveAsync(category);
        }
        catch
        {
            return new CommandResult(false, "Falha ao salvar alteração categoria!");
        }
        return new CommandResult(true, "Categoria Alterada com sucesso!", category);
    }
}