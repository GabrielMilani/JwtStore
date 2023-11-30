using Flunt.Notifications;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using JwtStore.Stock.Commands;
using JwtStore.Stock.Entities;
using JwtStore.Stock.Repositories;

namespace JwtStore.Stock.Handlers;

public class ProductCreateHandler : Notifiable<Notification>, IHandler<ProductCreateCommand>
{
    private readonly IProductCreateRepository _productCreateRepository;

    public ProductCreateHandler(IProductCreateRepository productCreateRepository)
    {
        _productCreateRepository = productCreateRepository;
    }

    public ICommandResult Handle(ProductCreateCommand command)
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

        #region 02. Recebe dados do produto.
        Product product;
        try
        {
            product = new Product(command.Title, command.Description, command.Price, command.QuantityOnHand,
                                  DateTime.UtcNow, DateTime.UtcNow, command.CategoryId);
        }
        catch
        {
            return new CommandResult(false, "Falha ao criar o produto!");
        }
        #endregion

        #region 03. Persiste da dos do produto no banco.
        try
        {
            _productCreateRepository.SaveAsync(product);
        }
        catch
        {
            return new CommandResult(false, "Falha ao Salvar o produto!");
        }
        #endregion

        return new CommandResult(true, "Produto cadastrado com sucesso!", product);
    }
}