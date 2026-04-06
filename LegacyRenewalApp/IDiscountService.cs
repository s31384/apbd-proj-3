namespace LegacyRenewalApp;

public interface IDiscountService
{
    public (decimal discount, string notes) GetTotalDiscount(Customer customer, SubscriptionPlan subscriptionPlan, decimal baseAmount, int seatCount);
}