using System.Collections.Generic;

namespace LegacyRenewalApp;

public class CountryTaxDictionary : ICountryTaxDictionary
{
    Dictionary<string, ICountryTax> _taxDictionary;
    public CountryTaxDictionary()
    {
        _taxDictionary = new Dictionary<string, ICountryTax>()
        {
            {"Poland", new PolandTax()},
            {"Germany",new GermanyTax()},
            {"Norway", new NorwayTax()},
            {"Czech Republic", new CzechTax()}
        };
    }
    public ICountryTax getCountryTax(string countryCode)
    {
        try
        {
            return _taxDictionary[countryCode];
        }catch(KeyNotFoundException)
        {
            return new StandartTax();
        }
    }
}