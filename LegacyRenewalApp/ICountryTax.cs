namespace LegacyRenewalApp;

public interface ICountryTax
{
    public decimal GetTax();
}

public class NorwayTax : ICountryTax
{
    public decimal GetTax()
    {
        return 0.25m;
    }
}

public class PolandTax : ICountryTax
{
    public decimal GetTax()
    {
        return 0.23m;
    }
}

public class GermanyTax : ICountryTax
{
    public decimal GetTax()
    {
        return 0.19m;
    }
}

public class CzechTax : ICountryTax
{
    public decimal GetTax()
    {
        return 0.21m;
    }
}

public class StandartTax : ICountryTax
{
    public decimal GetTax()
    {
        return 0.20m;
    }
}