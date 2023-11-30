using Flunt.Notifications;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using JwtStore.Stock.Commands;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;

namespace JwtStore.Stock.Handlers;

public class ProductUpdateHandler : Notifiable<Notification>, IHandler<ProductUpdateCommand>
{
    private readonly IProductUpdateRepository _productUpdateRepository;

    public ProductUpdateHandler(IProductUpdateRepository productUpdateRepository)
    {
        _productUpdateRepository = productUpdateRepository;
    }

    public ICommandResult Handle(ProductUpdateCommand command)
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

        #region 02. Recebe ID e dados alterados do produto e realiza a alteração.
        Product? product;
        try
        {
            product = _productUpdateRepository.GetProductByIdAsync(command.Id).Result;
            if (product is null)
                return new CommandResult(false, "Falha ao alterar produto!");
            product.UpdateTitleProduct(command.Title);
            product.UpdateDescriptionProduct(command.Description);
            product.UpdatePriceProduct(command.Price);
            product.UpdateQuantityOnHandProduct(command.QuantityOnHand);
            product.UpdateCategoryProduct(command.CategoryId);
        }
        catch
        {
            return new CommandResult(false, "Falha ao alterar dados do produto!");
        }
        #endregion

        #region 03. Persiste dados alterados do produto.
        try
        {
            _productUpdateRepository.SaveAsync(product);
        }
        catch
        {
            return new CommandResult(false, "Falha ao Salvar alteracao o produto!");
        }
        #endregion

        return new CommandResult(true, "Produto alterado com sucesso!", product);
    }
}