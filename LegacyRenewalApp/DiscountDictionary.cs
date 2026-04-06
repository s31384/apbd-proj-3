using System.Collections.Generic;

namespace LegacyRenewalApp;
public class DiscountDictionary : IDiscountDictionary
{
    Dictionary<string, IDiscountStrategy> discountStrategies;

    public DiscountDictionary()
    {
        discountStrategies = new Dictionary<string, IDiscountStrategy>()
        {
            {"Silver", new SilverSegment()},
            {"Gold",new GoldSegment()},
            {"Platinum", new PlatinumSegment()},
            {"Education", new EducationSegment()}
        };
    }

    public IDiscountStrategy GetDiscountStrategy(string discountName)
    {
        return discountStrategies[discountName];
    }
}