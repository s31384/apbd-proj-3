namespace LegacyRenewalApp;

public interface ISegmentDiscountStrategy
{
    decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan);
    string GetNotes(string notes);
}


public class SilverSegment : ISegmentDiscountStrategy
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
public class GoldSegment : ISegmentDiscountStrategy
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
public class PlatinumSegment : ISegmentDiscountStrategy
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
public class EducationSegment : ISegmentDiscountStrategy
{
    public decimal GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        return baseAmount * 0.2m;
    }

    public string GetNotes(string notes)
    {
        return notes += " education discount; ";
    }
}