namespace LegacyRenewalApp;

public interface IDiscountDictionary
{
    public IDiscountStrategy GetDiscountStrategy(string discountName);
}