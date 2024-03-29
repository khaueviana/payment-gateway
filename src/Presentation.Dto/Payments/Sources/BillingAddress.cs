﻿namespace PaymentGateway.Presentation.Dto.Payments.Sources
{
    public class BillingAddress
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }
    }
}
