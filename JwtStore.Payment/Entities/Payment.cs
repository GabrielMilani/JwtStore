using JwtStore.Shared.Entities;

namespace JwtStore.Payment.Entities;

public abstract class Payment : Entity
{
    public string Number { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
}