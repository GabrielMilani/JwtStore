using JwtStore.Account.Entities;
using JwtStore.Order.Enums;
using JwtStore.Shared.Entities;

namespace JwtStore.Order.Entities;

public class Order : Entity
{
    public Order()
    {
    }

    public Order(User? customer)
    {
        Customer = customer;
        CreateDate = DateTime.UtcNow;
        Status = EOrderStatus.Created;
    }

    public User? Customer { get; private set; }
    public DateTime CreateDate { get; private set; }
    public EOrderStatus Status { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();
    public List<Delivery> Deliveries { get; private set; } = new();

    public void PaidOrder()
    {
        Status = EOrderStatus.Paid;
    }
}