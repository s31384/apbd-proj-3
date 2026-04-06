namespace LegacyRenewalApp;

public interface IPaymentMethodDictionary
{
    public IPaymentMethod getPaymentMethod(string paymentMethod);
}