namespace LegacyRenewalApp;
using System;

public class DataValidator : IDataValidator
{
    public void ValidateData(int customerId, string planCode, int seatCount, string paymentMethod)
    {
        ValidateId(customerId);
        ValidatePlanCode(planCode);
        ValidateSeatCount(seatCount);
        ValidatePaymentMethod(paymentMethod);
    }

    void ValidateId(int customerId)
    {
        if (customerId <= 0)
        {
            throw new ArgumentException("Customer id must be positive");
        }
    }

    void ValidatePlanCode(string planCode)
    {
        if (string.IsNullOrWhiteSpace(planCode))
        {
            throw new ArgumentException("Plan code is required");
        }
    }

    void ValidateSeatCount(int seatCount)
    {
        if (seatCount <= 0)
        {
            throw new ArgumentException("Seat count must be positive");
        }
    }

    void ValidatePaymentMethod(string paymentMethod)
    {
        if (string.IsNullOrWhiteSpace(paymentMethod))
        {
            throw new ArgumentException("Payment method is required");
        }
    }
}