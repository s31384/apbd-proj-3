namespace LegacyRenewalApp;

public interface IDataValidator
{
    void ValidateData(int customerId, string planCode, int seatCount, string paymentMethod);
}