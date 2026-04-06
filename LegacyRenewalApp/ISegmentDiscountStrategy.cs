namespace LegacyRenewalApp;

public interface ISegmentDiscountStrategy
{
    decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan);
    string GetNotes(string notes, SubscriptionPlan subPlan);
}


public class SilverSegment : ISegmentDiscountStrategy
{
    
    public decimal GetDiscountAmount(decimal baseAmount,  SubscriptionPlan subPlan)
    {
        return baseAmount * 0.05m;
    }

    public string GetNotes(string notes, SubscriptionPlan subPlan)
    {
        return notes += " silver discount; ";
    }
}
public class GoldSegment : ISegmentDiscountStrategy
{
    
    public decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        return baseAmount * 0.1m;
    }

    public string GetNotes(string notes, SubscriptionPlan subPlan)
    {
        return notes += " gold discount; ";
    }
}
public class PlatinumSegment : ISegmentDiscountStrategy
{
   
    public decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        
        return baseAmount * 0.15m;
    }

    public string GetNotes(string notes, SubscriptionPlan subPlan)
    {
        return notes += " platinum discount; ";
    }
}
public class EducationSegment : ISegmentDiscountStrategy
{
   
    public decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        if (subPlan.IsEducationEligible)
        {
            return baseAmount * 0.2m;
        }
        else return 0m;
    }

    public string GetNotes(string notes, SubscriptionPlan subPlan)
    {
        if (subPlan.IsEducationEligible)
        {
            return notes += " education discount; ";
        }else return notes;
    }
    
    
}

public class BasicSegment : ISegmentDiscountStrategy
{
    public decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        return 0;
    }

    public string GetNotes(string notes, SubscriptionPlan subPlan)
    {
        return notes;
    }
}
