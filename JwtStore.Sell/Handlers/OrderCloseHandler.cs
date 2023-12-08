using Flunt.Notifications;
using JwtStore.Order.Commands;
using JwtStore.Order.Commands.Result;
using JwtStore.Order.Entities;
using JwtStore.Order.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Order.Handlers;

public class OrderCloseHandler : Notifiable<Notification>, IHandler<OrderCloseCommand>
{
    private readonly IOrderCloseRepository _orderCloseRepository;

    public OrderCloseHandler(IOrderCloseRepository orderCloseRepository)
    {
        _orderCloseRepository = orderCloseRepository;
    }

    public ICommandResult Handle(OrderCloseCommand command)
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
            order = _orderCloseRepository.GetOrderById(command.OrderId).Result;
            if (order is null)
                return new CommandResult(false, "Ops, falha ao Adicionar itens ao pedido!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao recuperar pedido!", command.Notifications);
        }
        #endregion  

        #region 03. Recupera o finaliza pedido
        try
        {
            var deliveries = new List<Delivery>();
            var count = 1;

            foreach (var item in order.Items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.UtcNow.AddDays(5)));
                }
                count++;
            }

            foreach (var delivery in deliveries)
            {
                delivery.Ship();
            }

            foreach (var delivery in deliveries)
            {
                order.Deliveries.Add(delivery);
            }
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao Adicionar itens ao pedido!", command.Notifications);
        }
        #endregion  

        #region 04. Perciste as alterações no banco.
        try
        {
            _orderCloseRepository.SaveAsync(order);
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

        var listDelivery = new List<Delivery?>();
        foreach (var delivery in order.Deliveries)
        {
            listDelivery.Add(delivery);
        }

        return new OrderCloseCommandResult(true, "Order", order.Id, order.Status.ToString(), listItems, listDelivery);
    }
}