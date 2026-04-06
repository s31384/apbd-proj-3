namespace LegacyRenewalApp;

public interface ITeamDiscountDictionary
{
    public ITeamDiscount GeDiscountBySeats(int seats);
}