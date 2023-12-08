using Flunt.Notifications;
using JwtStore.Order.Commands;
using JwtStore.Order.Commands.Result;
using JwtStore.Order.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Order.Handlers;

public class OrderPaymentHandler : Notifiable<Notification>, IHandler<OrderPaymentCommand>
{
    private readonly IOrderPaymentRepository _orderPaymentRepository;

    public OrderPaymentHandler(IOrderPaymentRepository orderPaymentRepository)
    {
        _orderPaymentRepository = orderPaymentRepository;
    }

    public ICommandResult Handle(OrderPaymentCommand command)
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
            order = _orderPaymentRepository.GetOrderById(command.OrderId).Result;
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao recuperar pedido!", command.Notifications);
        }
        #endregion

        #region 02. Pagar o pedido
        try
        {
            if (order is null)
                return new CommandResult(false, "Ops, falha ao Adicionar itens ao pedido!", command.Notifications);
            order.PaidOrder();
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao recuperar pedido!", command.Notifications);
        }
        #endregion

        #region 04. Perciste as alterações no banco.
        try
        {
            _orderPaymentRepository.SaveAsync(order);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível salvar a adição de Items no pedido", command.Notifications);
        }
        #endregion

        return new OrderCommandResult(true, "Payment", order.Id, order.Status.ToString());

    }
}