using System.Collections.Generic;
using System.Linq;

namespace LegacyRenewalApp;

public class TeamDiscountDictionary : ITeamDiscountDictionary
{
    List<ITeamDiscount> _discounts;
    Dictionary<int, ITeamDiscount> _discountsBySeats;
    public TeamDiscountDictionary()
    {
        _discounts = new List<ITeamDiscount>() { new SmallTeamDiscount(), new MediumTeamDiscount(), new LargeTeamDiscount() };
        _discountsBySeats = _discounts
            .OrderByDescending(x => x.GetSeats())
            .ToDictionary(x=>x.GetSeats(),x=>x);
       
    }

    public ITeamDiscount GeDiscountBySeats(int seats)
    {
        foreach (var pair in _discountsBySeats)
        {
            if (pair.Key <= seats)
            {
                return pair.Value;
            }
        }
        return new NoTeamDiscount();
    }
}