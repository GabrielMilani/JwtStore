namespace JwtStore.Payment.Entities;

public class CreditCardPayment : Payment
{
    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
}