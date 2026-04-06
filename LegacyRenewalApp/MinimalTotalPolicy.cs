namespace LegacyRenewalApp;

public class MinimalTotalPolicy : IMinimalTotalPolicy
{
    public (decimal subTotal, string note) MinimalTotal(decimal subTotal)
    {
        if (subTotal < 300m)
        {
            return (300, " minimum discounted subtotal applied; ");
        }
        else return (subTotal, "");
        
    }
}