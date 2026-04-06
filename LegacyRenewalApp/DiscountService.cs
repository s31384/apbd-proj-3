using System;

namespace LegacyRenewalApp;

public class DiscountService : IDiscountService
{
    ILoyaltyDiscountDictionary loyaltyDiscountDictionary;
    ITeamDiscountDictionary teamDiscountDictionary;

    public DiscountService(ILoyaltyDiscountDictionary loyaltyDiscountDictionary,ITeamDiscountDictionary teamDiscountDictionary)
    {
        this.loyaltyDiscountDictionary = loyaltyDiscountDictionary;
        this.teamDiscountDictionary = teamDiscountDictionary;
    }
    public (decimal discount, string notes) GetTotalDiscount(Customer customer, SubscriptionPlan subscriptionPlan, decimal baseAmount, int seatCount)
    {
        decimal discount = 0;
        string notes = "";
        var segmentDiscount =  customer.Segment.GetDiscountAmount(baseAmount, subscriptionPlan);
        discount += segmentDiscount.discount;
        notes += segmentDiscount.note;
        var loyaltyDiscount =  loyaltyDiscountDictionary.GetDiscountByYear(customer.YearsWithCompany).GetDiscountAmount(baseAmount);
        discount += loyaltyDiscount.discount;
        notes += loyaltyDiscount.note;

        var teamDiscount = teamDiscountDictionary.GeDiscountBySeats(seatCount).GetDiscountAmount(baseAmount);
        discount += teamDiscount.discount;
        notes += teamDiscount.note;

        return (discount, notes);

    }
}