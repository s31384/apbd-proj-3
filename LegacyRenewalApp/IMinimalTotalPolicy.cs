namespace LegacyRenewalApp;

public interface IMinimalTotalPolicy
{
    public (decimal subTotal, string note)  MinimalTotal(decimal subTotal);
}