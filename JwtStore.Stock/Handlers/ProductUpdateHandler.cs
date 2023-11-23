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
        Product product;
        try
        {
            product = _productUpdateRepository.GetProductById(command.Id);
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
        try
        {
            _productUpdateRepository.SaveAsync(product);
        }
        catch
        {
            return new CommandResult(false, "Falha ao Salvar alteracao o produto!");
        }
        return new CommandResult(true, "Produto alterado com sucesso!", product);
    }
}