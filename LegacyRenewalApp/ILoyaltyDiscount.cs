namespace LegacyRenewalApp;

public interface ILoyaltyDiscount
{
    public (decimal discount, string note)  GetDiscountAmount(decimal baseAmount);
    public int GetYears();
}

public class LongTermDiscount : ILoyaltyDiscount
{
    private int years = 7;

    public int Years()
    {
        return years;
    }
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount)
    {
        return (baseAmount * 0.07m, " long-term discount; ");
    }

   
    
    public int GetYears(){
        return years;
    }
}

public class BasicLoyaltyDiscount : ILoyaltyDiscount
{
    private int years = 2;

    public int Years()
    {
        return years;
    }
    
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount)
    {
        return (baseAmount * 0.03m, " basic loyalty discount; ");
    }

  
    public  int GetYears(){
        return years;
    }
}


public class NoLoyaltyDiscount : ILoyaltyDiscount
{
    private int years = 0;
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount)
    {
        return (0, "");
    }

    public int GetYears()
    {
        return years;
    }
}