using System.Collections.Generic;
using System.Linq;

namespace LegacyRenewalApp;
public class LoyaltyDiscountDictionary : ILoyaltyDiscountDictionary
{
    List<ILoyaltyDiscount> _discounts;
    Dictionary<int, ILoyaltyDiscount> _discountsByYear;
    public LoyaltyDiscountDictionary()
    {
        _discounts = new List<ILoyaltyDiscount>() { new BasicLoyaltyDiscount(), new LongTermDiscount() };
        _discountsByYear = _discounts
            .OrderByDescending(x => x.GetYears())
            .ToDictionary(x=>x.GetYears(),x=>x);
        foreach (var discount in _discounts)
        {
            _discountsByYear.Add(discount.GetYears(), discount);
        }
    }

    public ILoyaltyDiscount GetDiscountByYear(int year)
    {
        foreach (var pair in _discountsByYear)
        {
            if (pair.Key <= year)
            {
                return pair.Value;
            }
        }
        return new NoLoyaltyDiscount();
    }
}