using JwtStore.Order.Entities;
using JwtStore.Shared.Commands;

namespace JwtStore.Order.Commands.Result;

public class OrderInsertItemsCommandResult : ICommandResult
{
    public OrderInsertItemsCommandResult(bool? success, string? message, int? orderId, string? orderStatus,
                                         List<OrderItem?> items)
    {
        Success = success;
        Message = message;
        OrderId = orderId;
        OrderStatus = orderStatus;
        Items = items;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public int? OrderId { get; set; }
    public string? OrderStatus { get; set; }
    public List<OrderItem?> Items { get; set; }

}