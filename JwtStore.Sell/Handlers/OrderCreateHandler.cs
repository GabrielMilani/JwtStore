using Flunt.Notifications;
using JwtStore.Account.Entities;
using JwtStore.Order.Commands;
using JwtStore.Order.Commands.Result;
using JwtStore.Order.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Order.Handlers;

public class OrderCreateHandler : Notifiable<Notification>, IHandler<OrderCreateCommand>
{
    private readonly IOrderCreateRepository _orderCreateRepository;

    public OrderCreateHandler(IOrderCreateRepository orderCreateRepository)
    {
        _orderCreateRepository = orderCreateRepository;
    }

    public ICommandResult Handle(OrderCreateCommand command)
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

        #region 02. Carrega dados do usuário

        User? user;
        try
        {
            user = _orderCreateRepository.GetUserByEmailAsync(command.CustomerEmail).Result;
            if (user is null)
                return new CommandResult(false, "Perfil não encontrado", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao recuperar dados do usuário!", command.Notifications);
        }
        #endregion

        #region 03. Cria o pedido

        Entities.Order order;
        try
        {
            order = new Entities.Order(user);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao criar pedido!", command.Notifications);
        }
        #endregion

        #region 04. Perciste as alterações no banco.
        try
        {
            _orderCreateRepository.SaveAsync(order);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível salvar order", command.Notifications);
        }
        #endregion

        return new OrderCommandResult(true, "Order", order.Id, order.Status.ToString());
    }
}