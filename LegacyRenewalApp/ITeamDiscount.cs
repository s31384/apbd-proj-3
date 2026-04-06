namespace LegacyRenewalApp;

public interface ITeamDiscount
{
    public decimal GetDiscountAmount(decimal baseAmount);
    public string GetNotes(string notes);
    public int GetSeats();
}

public class LargeTeamDiscount : ITeamDiscount
{
    private int seats = 50;
    public decimal GetDiscountAmount(decimal baseAmount)
    {
        return baseAmount * 0.12m;
    }

    public string GetNotes(string notes)
    {
        return notes += " large team discount; ";
    }

    public int GetSeats()
    {
        return seats;
    }
}

public class MediumTeamDiscount : ITeamDiscount
{
    int seats = 20;
    public decimal GetDiscountAmount(decimal baseAmount)
    {
        return baseAmount * 0.8m;
        
    }

    public string GetNotes(string notes)
    {
        return    notes += " medium team discount; ";
        
    }

    public int GetSeats()
    {
        return seats;
    }
}

public class SmallTeamDiscount : ITeamDiscount
{
    int seats = 10;
    public decimal GetDiscountAmount(decimal baseAmount)
    {
        return baseAmount * 0.4m;
        
    }

    public string GetNotes(string notes)
    {
        return    notes += " small team discount; ";
        
    }

    public int GetSeats()
    {
        return seats;
    }
}

public class NoTeamDiscount : ITeamDiscount
{
    int seats = 0;
    public decimal GetDiscountAmount(decimal baseAmount)
    {
        return 0;
    }

    public string GetNotes(string notes)
    {
        return notes;

    }

    public int GetSeats()
    {
        return seats;
    }
}