namespace LegacyRenewalApp;

public class MinimalInvoicePolicy : IMinimalInvoicePolicy
{
    public (decimal finalAmount, string note) ApplyMinimalInvoisePolicy(decimal finalAmount)
    {
        if (finalAmount < 500m)
        {
            return (500, " minimum invoice amount applied; ");
        }else return (finalAmount, "");
    }
}