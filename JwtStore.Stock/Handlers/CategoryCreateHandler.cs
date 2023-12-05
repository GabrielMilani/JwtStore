using Flunt.Notifications;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using JwtStore.Stock.Commands;
using JwtStore.Stock.Commands.Results;
using JwtStore.Stock.Commands.Results.Response;
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

        #region 02. Recebe dados da categoria.
        Category category;
        try
        {
            category = new Category(command.Title);
        }
        catch
        {
            return new CommandResult(false, "Falha ao criar categoria!");
        }
        #endregion

        #region 03. Persiste categoria no banco.
        try
        {
            _categoryCreateReposiroty.SaveAsync(category);
        }
        catch
        {
            return new CommandResult(false, "Falha ao salvar categoria!");
        }
        #endregion

        var categoryResponse = new CategoryResponse(category.Id, category.Title);
        var listCategoryResponse = new List<CategoryResponse>();
        listCategoryResponse.Add(categoryResponse);

        return new CategoryCommandResult(true, "Category created success!", listCategoryResponse);
    }
}