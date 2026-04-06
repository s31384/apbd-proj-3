using System;
using System.Collections.Generic;

namespace LegacyRenewalApp;

public class PaymentDictionary : IPaymentMethodDictionary
{
    private Dictionary<string, IPaymentMethod> _dictionary;
    public PaymentDictionary()
    {
        _dictionary = new Dictionary<string, IPaymentMethod>()
        {
            {"INVOICE", new Invoice()},
            {"PAYPAL", new Paypal()},
            {"BANK_TRANSFER", new BandTransfer()},
            {"CARD", new Card()},
        };
        
    }
    public IPaymentMethod getPaymentMethod(string paymentMethod)
    {
        IPaymentMethod payment;
        try
        {
            payment = _dictionary[paymentMethod];
        }catch(KeyNotFoundException)
        {
            throw new ArgumentException("Unsupported payment method");
            
        }
        return payment;

    }
}