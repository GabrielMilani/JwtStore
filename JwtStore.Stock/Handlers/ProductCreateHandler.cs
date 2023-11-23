﻿using Flunt.Notifications;
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
        Product product;
        try
        {
            product = new Product(command.Title, command.Description, command.Price, command.QuantityOnHand,
                                  DateTime.UtcNow, DateTime.UtcNow, command.CategoryId);
        }
        catch
        {
            return new CommandResultStock(false, "Falha ao criar o produto!");
        }
        try
        {
            _productCreateRepository.SaveAsync(product);
        }
        catch
        {
            return new CommandResultStock(false, "Falha ao Salvar o produto!");
        }
        return new CommandResultStock(true, "Produto cadastrado com sucesso!", product);
    }
}