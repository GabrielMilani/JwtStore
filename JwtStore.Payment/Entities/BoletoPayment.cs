namespace JwtStore.Payment.Entities;

public class BoletoPayment : Payment
{
    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
}