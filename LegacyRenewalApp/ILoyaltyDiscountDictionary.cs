namespace LegacyRenewalApp;

public interface ILoyaltyDiscountDictionary
{
    ILoyaltyDiscount GetDiscountByYear(int year);
}