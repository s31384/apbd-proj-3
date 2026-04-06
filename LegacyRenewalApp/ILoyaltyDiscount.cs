namespace LegacyRenewalApp;

public interface ILoyaltyDiscount
{
    public decimal GetDiscountAmount(decimal baseAmount);
    public string GetNotes(string notes);
    public int GetYears();
}

public class LongTermDiscount : ILoyaltyDiscount
{
    private int years = 7;

    public int Years()
    {
        return years;
    }
    public decimal GetDiscountAmount(decimal baseAmount)
    {
        return baseAmount * 0.07m;
    }

    public string GetNotes(string notes)
    {
        return notes += " long-term loyalty discount; ";
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
    
    public decimal GetDiscountAmount(decimal baseAmount)
    {
        return baseAmount * 0.03m;
    }

    public string GetNotes(string notes)
    {
        return notes += " basic loyalty discount; ";
    }
    public  int GetYears(){
        return years;
    }
}


public class NoLoyaltyDiscount : ILoyaltyDiscount
{
    private int years = 0;
    public decimal GetDiscountAmount(decimal baseAmount)
    {
        return 0;
    }

    public string GetNotes(string notes)
    {
        return notes;
    }

    public int GetYears()
    {
        return years;
    }
}