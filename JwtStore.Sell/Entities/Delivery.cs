using JwtStore.Order.Enums;
using JwtStore.Shared.Entities;

namespace JwtStore.Order.Entities;

public class Delivery : Entity
{
    public Delivery()
    {
    }
    public Delivery(DateTime estimatedDeliveryDate)
    {
        CreateDate = DateTime.UtcNow;
        EstimatedDeliveryDate = estimatedDeliveryDate;
        Status = EDeliveryStatus.Waiting;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime EstimatedDeliveryDate { get; private set; }
    public EDeliveryStatus Status { get; private set; }

    public void Ship()
    {
        Status = EDeliveryStatus.Shipped;
    }
    public void Canceled()
    {
        Status = EDeliveryStatus.Canceled;
    }
}