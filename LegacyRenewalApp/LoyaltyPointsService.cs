namespace LegacyRenewalApp;

public class LoyaltyPointsService : ILoyaltyPoints
{
    public int UseLoyaltyPoints(Customer customer)
    {
        int pointsToUse = customer.LoyaltyPoints > 200 ? 200 : customer.LoyaltyPoints;
        return pointsToUse;
    }
}