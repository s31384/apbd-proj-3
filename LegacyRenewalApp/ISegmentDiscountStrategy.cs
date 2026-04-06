namespace LegacyRenewalApp;

public interface ISegmentDiscountStrategy
{
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan);
}


public class SilverSegment : ISegmentDiscountStrategy
{
    
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        return (baseAmount * 0.05m, " silver discount; ");
    }

    
}
public class GoldSegment : ISegmentDiscountStrategy
{
    
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        return (baseAmount * 0.1m,  " gold discount; ");
    }

 
}
public class PlatinumSegment : ISegmentDiscountStrategy
{
   
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        
        return (baseAmount * 0.15m, "  platinum discount; ");
    }

  
}
public class EducationSegment : ISegmentDiscountStrategy
{
   
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        if (subPlan.IsEducationEligible)
        {
            return (baseAmount * 0.2m, " education discount; ");
        }
        else return (0m, "");
    }

  
    
    
}

public class BasicSegment : ISegmentDiscountStrategy
{
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount, SubscriptionPlan subPlan)
    {
        return (0,"");
    }

   
}
