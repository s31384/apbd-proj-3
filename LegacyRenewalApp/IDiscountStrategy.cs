namespace LegacyRenewalApp;

public interface IDiscountStrategy
{
    decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan);
    string GetNotes(string notes);
}


public class SilverSegment : IDiscountStrategy
{
    public decimal GetDiscountAmount(decimal baseAmount,  SubscriptionPlan subPlan)
    {
        return baseAmount * 0.05m;
    }

    public string GetNotes(string notes)
    {
        return notes += " silver discount; ";
    }
}
public class GoldSegment : IDiscountStrategy
{
    public decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        return baseAmount * 0.1m;
    }

    public string GetNotes(string notes)
    {
        return notes += " gold discount; ";
    }
}
public class PlatinumSegment : IDiscountStrategy
{
    public decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        
        return baseAmount * 0.15m;
    }

    public string GetNotes(string notes)
    {
        return notes += " platinum discount; ";
    }
}
public class EducationSegment : IDiscountStrategy
{
    public decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        if (subPlan.IsEducationEligible)
        {
            return baseAmount * 0.2m;
        }
        else return 0m;
    }

    public string GetNotes(string notes)
    {
        return notes += " education discount; ";
    }
}