﻿namespace PaymentGateway.Data.MongoDB.Model.Payments.Sources
{
    public class Billing
    {
        public BillingAddress Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
