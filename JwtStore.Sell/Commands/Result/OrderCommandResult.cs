using JwtStore.Shared.Commands;

namespace JwtStore.Order.Commands.Result;

public class OrderCommandResult : ICommandResult
{
    public OrderCommandResult(bool? success, string? message, int? orderId, string? orderStatus)
    {
        Success = success;
        Message = message;
        OrderId = orderId;
        OrderStatus = orderStatus;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public int? OrderId { get; set; }
    public string? OrderStatus { get; set; }
}