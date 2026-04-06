namespace LegacyRenewalApp;

public interface ITeamDiscount
{
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount);
    public int GetSeats();
}

public class LargeTeamDiscount : ITeamDiscount
{
    private int seats = 50;
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount)
    {
        return (baseAmount * 0.12m, " large team discount; ");
    }

    public int GetSeats()
    {
        return seats;
    }
}

public class MediumTeamDiscount : ITeamDiscount
{
    int seats = 20;
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount)
    {
        return (baseAmount * 0.08m, " medium team discount; ");
        
    }

    public int GetSeats()
    {
        return seats;
    }
}

public class SmallTeamDiscount : ITeamDiscount
{
    int seats = 10;
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount)
    {
        return (baseAmount * 0.04m, " small team discount; ");
        
    }

    public int GetSeats()
    {
        return seats;
    }
}

public class NoTeamDiscount : ITeamDiscount
{
    int seats = 0;
    public (decimal discount, string note) GetDiscountAmount(decimal baseAmount)
    {
        return (0, "");
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