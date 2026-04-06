namespace LegacyRenewalApp;

public interface ILoyaltyPoints
{
    public (int points, string note)  UseLoyaltyPoints(Customer customer);
}