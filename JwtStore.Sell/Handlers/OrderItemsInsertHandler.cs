using Flunt.Notifications;
using JwtStore.Order.Commands;
using JwtStore.Order.Commands.Result;
using JwtStore.Order.Entities;
using JwtStore.Order.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Order.Handlers;

public class OrderItemsInsertHandler : Notifiable<Notification>, IHandler<OrderItemsInsertCommand>
{
    private readonly IOrderItemsInsertRepository _repositoryOrderItemsInsert;

    public OrderItemsInsertHandler(IOrderItemsInsertRepository repositoryOrderItemsInsert)
    {
        _repositoryOrderItemsInsert = repositoryOrderItemsInsert;
    }

    public ICommandResult Handle(OrderItemsInsertCommand command)
    {
        #region 01. Valida a requisição
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult(false, "Ops, falha ao autenticar Usuário!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao verificar requisição!", command.Notifications);
        }
        #endregion

        #region 02. Recupera o pedido

        Entities.Order? order;
        try
        {
            order = _repositoryOrderItemsInsert.GetOrderById(command.OrderId).Result;
            if (order is null)
                return new CommandResult(false, "Ops, falha ao Adicionar itens ao pedido!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao recuperar pedido!", command.Notifications);
        }
        #endregion

        #region 03. Adiciona prodito ao pedido

        try
        {
            var product = _repositoryOrderItemsInsert.GetItemById(command.ProductId).Result;
            if (product is null)
                return new CommandResult(false, "Ops, falha recuperar produto!", command.Notifications);
            var item = new OrderItem(product, command.Quantity);
            order.Items.Add(item);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao Adicionar itens ao pedido!", command.Notifications);
        }
        #endregion

        #region 04. Perciste as alterações no banco.
        try
        {
            _repositoryOrderItemsInsert.SaveAsync(order);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível salvar a adição de Items no pedido", command.Notifications);
        }
        #endregion

        var listItems = new List<OrderItem?>();
        foreach (var item in order.Items)
        {
            listItems.Add(item);
        }

        return new OrderInsertItemsCommandResult(true, "Order", order.Id, order.Status.ToString(), listItems);
    }
}