using System;

namespace LegacyRenewalApp
{
    public class SubscriptionRenewalService
    {
        ICustomerRepository customerRepository;
        ISubscriptionPlanRepository planRepository;
        IDataValidator dataValidator;
       IDiscountService discountService;
        ILoyaltyPoints loyaltyPointsService;
        IMinimalTotalPolicy minimalTotalPolicy;
        IPaymentMethodDictionary paymentMethodDictionary;
        ICountryTaxDictionary countryTaxDictionary;
        IMinimalInvoicePolicy minimalInvoicePolicy;
        public SubscriptionRenewalService()
        {
            customerRepository = new CustomerRepository();
            planRepository = new SubscriptionPlanRepository();
            dataValidator = new DataValidator();
            loyaltyPointsService = new LoyaltyPointsService();
            discountService = new DiscountService(new LoyaltyDiscountDictionary(),new TeamDiscountDictionary()); 
            minimalTotalPolicy = new MinimalTotalPolicy();
            paymentMethodDictionary = new PaymentDictionary();
            countryTaxDictionary = new CountryTaxDictionary();
            minimalInvoicePolicy = new MinimalInvoicePolicy();
        }
        

        public RenewalInvoice CreateRenewalInvoice(
            int customerId,
            string planCode,
            int seatCount,
            string paymentMethod,
            bool includePremiumSupport,
            bool useLoyaltyPoints)
        {
            
            dataValidator.ValidateData(customerId, planCode, seatCount, paymentMethod);
            string normalizedPlanCode = planCode.Trim().ToUpperInvariant();
            string normalizedPaymentMethod = paymentMethod.Trim().ToUpperInvariant();

            

            var customer = customerRepository.GetById(customerId);
            var plan = planRepository.GetByCode(normalizedPlanCode);

            if (!customer.IsActive)
            {
                throw new InvalidOperationException("Inactive customers cannot renew subscriptions");
            }
            
            decimal baseAmount = (plan.MonthlyPricePerSeat * seatCount * 12m) + plan.SetupFee;
            var discount = discountService.GetTotalDiscount(customer,plan,baseAmount, seatCount);
            decimal discountAmount = discount.discount;
            string notes = discount.notes;
            
            if (useLoyaltyPoints)
            {
                var pointsToUse = loyaltyPointsService.UseLoyaltyPoints(customer);
                discountAmount += pointsToUse.points;
                notes += pointsToUse.note;
            }

            decimal subtotalAfterDiscount = baseAmount - discountAmount;
            var applyMinimalSubtotal = minimalTotalPolicy.MinimalTotal(subtotalAfterDiscount);
            subtotalAfterDiscount = applyMinimalSubtotal.subTotal;
            notes += applyMinimalSubtotal.note;

            decimal supportFee = 0m;
            if (includePremiumSupport)
            {
                supportFee = plan.PremiumSupportPrice;

                notes += "premium support included; ";
            }

            var paymentResult = paymentMethodDictionary.getPaymentMethod(normalizedPaymentMethod).GetPaymentFee(subtotalAfterDiscount + supportFee);
            decimal paymentFee = paymentResult.paymentFee;
            notes += paymentResult.note;

            decimal taxRate = countryTaxDictionary.getCountryTax(customer.Country).GetTax();
            

            decimal taxBase = subtotalAfterDiscount + supportFee + paymentFee;
            decimal taxAmount = taxBase * taxRate;
            decimal finalAmount = taxBase + taxAmount;
            var minimalInvoicePolicyResult = minimalInvoicePolicy.ApplyMinimalInvoisePolicy(finalAmount);
            finalAmount = minimalInvoicePolicyResult.finalAmount;
            notes += minimalInvoicePolicyResult.note;
            

            var invoice = new RenewalInvoice
            {
                InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMdd}-{customerId}-{normalizedPlanCode}",
                CustomerName = customer.FullName,
                PlanCode = normalizedPlanCode,
                PaymentMethod = normalizedPaymentMethod,
                SeatCount = seatCount,
                BaseAmount = Math.Round(baseAmount, 2, MidpointRounding.AwayFromZero),
                DiscountAmount = Math.Round(discountAmount, 2, MidpointRounding.AwayFromZero),
                SupportFee = Math.Round(supportFee, 2, MidpointRounding.AwayFromZero),
                PaymentFee = Math.Round(paymentFee, 2, MidpointRounding.AwayFromZero),
                TaxAmount = Math.Round(taxAmount, 2, MidpointRounding.AwayFromZero),
                FinalAmount = Math.Round(finalAmount, 2, MidpointRounding.AwayFromZero),
                Notes = notes.Trim(),
                GeneratedAt = DateTime.UtcNow
            };

            LegacyBillingGateway.SaveInvoice(invoice);

            if (!string.IsNullOrWhiteSpace(customer.Email))
            {
                string subject = "Subscription renewal invoice";
                string body =
                    $"Hello {customer.FullName}, your renewal for plan {normalizedPlanCode} " +
                    $"has been prepared. Final amount: {invoice.FinalAmount:F2}.";

                LegacyBillingGateway.SendEmail(customer.Email, subject, body);
            }

            return invoice;
        }
    }
}
