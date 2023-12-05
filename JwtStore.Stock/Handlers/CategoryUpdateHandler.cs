using Flunt.Notifications;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using JwtStore.Stock.Commands;
using JwtStore.Stock.Commands.Results;
using JwtStore.Stock.Commands.Results.Response;
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
        #region 01. Valida a requisição.
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
        #endregion

        #region 02. Busca dados da categoria.
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
        #endregion

        #region 03. Persiste dados alterados no banco.
        try
        {
            _categoryUpdateReposiroty.SaveAsync(category);
        }
        catch
        {
            return new CommandResult(false, "Falha ao salvar alteração categoria!");
        }
        #endregion

        var categoryResponse = new CategoryResponse(category.Id, category.Title);
        var listCategoryResponse = new List<CategoryResponse>();
        listCategoryResponse.Add(categoryResponse);

        return new CategoryCommandResult(true, "Category Updated success!", listCategoryResponse);
    }
}