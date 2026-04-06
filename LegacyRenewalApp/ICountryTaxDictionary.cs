namespace LegacyRenewalApp;

public interface ICountryTaxDictionary
{
    ICountryTax getCountryTax(string countryCode);
}