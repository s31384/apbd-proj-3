namespace LegacyRenewalApp;

public interface IPaymentMethod
{
    public (decimal paymentFee, string note) GetPaymentFee(decimal sum);
}

public class Card : IPaymentMethod
{
    public (decimal paymentFee, string note) GetPaymentFee(decimal sum)
    {
        return (sum * 0.02m, " card payment fee; ");
    }
}

public class BandTransfer : IPaymentMethod
{
    public (decimal paymentFee, string note) GetPaymentFee(decimal sum)
    {
        return (sum * 0.01m, " bank transfer fee; ");
    }
}

public class Paypal : IPaymentMethod
{
    public (decimal paymentFee, string note) GetPaymentFee(decimal sum)
    {
        return  (sum * 0.035m, " paypal fee; ");
    }
}

public class Invoice : IPaymentMethod
{
    public (decimal paymentFee, string note) GetPaymentFee(decimal sum)
    {
        return (0m, " invoice payment; ");
    }
}