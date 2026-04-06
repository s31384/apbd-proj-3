namespace LegacyRenewalApp;

public interface IBillingGatewayService
{
    public void SaveInvoice(RenewalInvoice invoice);
    public void SendEmail(string email, string subject, string body);
}