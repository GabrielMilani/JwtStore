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
                return new CommandResultStock();
        }
        catch
        {
            return new CommandResultStock();
        }
        Category category;
        try
        {
            category = _categoryUpdateReposiroty.GetCategoryById(command.Id);
            category.UpdateTitleCategory(command.Title);
        }
        catch
        {
            return new CommandResultStock(false, "Falha ao alterar categoria!");
        }
        try
        {
            _categoryUpdateReposiroty.SaveAsync(category);
        }
        catch
        {
            return new CommandResultStock(false, "Falha ao salvar alteração categoria!");
        }
        return new CommandResultStock(true, "Categoria Alterada com sucesso!", category);
    }
}