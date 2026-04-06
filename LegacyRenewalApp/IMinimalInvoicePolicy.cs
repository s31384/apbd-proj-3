namespace LegacyRenewalApp;

public interface IMinimalInvoicePolicy
{
    public (decimal finalAmount, string note) ApplyMinimalInvoisePolicy(decimal finalAmount);
}