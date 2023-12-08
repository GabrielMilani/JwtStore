using JwtStore.Order.Entities;
using JwtStore.Shared.Commands;

namespace JwtStore.Order.Commands.Result;

public class OrderCloseCommandResult : ICommandResult
{
    public OrderCloseCommandResult(bool? success, string? message, int? orderId, string? orderStatus,
                                   List<OrderItem?> items, List<Delivery?> deliveries)
    {
        Success = success;
        Message = message;
        OrderId = orderId;
        OrderStatus = orderStatus;
        Items = items;
        Deliveries = deliveries;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public int? OrderId { get; set; }
    public string? OrderStatus { get; set; }
    public List<OrderItem?> Items { get; set; }
    public List<Delivery?> Deliveries { get; set; }
}