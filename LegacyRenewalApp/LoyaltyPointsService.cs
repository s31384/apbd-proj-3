namespace LegacyRenewalApp;

public class LoyaltyPointsService : ILoyaltyPoints
{
    public (int points, string note) UseLoyaltyPoints(Customer customer)
    {
        if (customer.LoyaltyPoints > 0)
        {
            int pointsToUse = customer.LoyaltyPoints > 200 ? 200 : customer.LoyaltyPoints;
            return (pointsToUse, $"loyalty points used: {pointsToUse}; ");
        }else return (0, "No loyalty points available");
    }
}