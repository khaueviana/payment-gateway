namespace PaymentGateway.Domain.Model.Tests.Payments
{
    using Infrastructure.CrossCutting.Extensions;

    public class PaymentTests
    {
        private readonly Fixture fixture;

        public PaymentTests()
        {
            this.fixture = new Fixture();
        }

        [Fact]
        public void Payment_IsAuthorized_ReturnsPaymentAuhtorized()
        {
            // Arrange
            var customer = new Customer(this.fixture.Create<string>(), this.fixture.Create<string>());

            var shippingAddress = new ShippingAddress(this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>());

            var shipping = new Shipping(shippingAddress, this.fixture.Create<string>());

            var billingAddress = new BillingAddress(this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>());

            var billing = new Billing(billingAddress, this.fixture.Create<string>());

            var creditCard = new CreditCard(this.fixture.Create<string>(),
                                            this.fixture.Create<int>(),
                                            this.fixture.Create<int>(),
                                            this.fixture.Create<string>(),
                                            this.fixture.Create<string>(),
                                            billing);

            var payment = new Payment(this.fixture.Create<string>(),
                                      this.fixture.Create<string>(),
                                      this.fixture.Create<decimal>(),
                                      this.fixture.Create<string>(),
                                      customer,
                                      shipping,
                                      creditCard);

            // Act
            payment.Authorize(true);

            // Assert
            payment.Status.Should().Be(Status.Authorized);
            payment.Source.As<CreditCard>().Number.Should().Be(creditCard.Number.Mask(0, creditCard.Number.Length - 1));
            payment.Source.As<CreditCard>().Cvv.Should().Be(creditCard.Cvv.Mask(0, creditCard.Cvv.Length));
        }

        [Fact]
        public void Payment_IsNotAuthorized_ReturnsPaymentAuhtorized()
        {
            // Arrange
            var customer = new Customer(this.fixture.Create<string>(), this.fixture.Create<string>());

            var shippingAddress = new ShippingAddress(this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>());

            var shipping = new Shipping(shippingAddress, this.fixture.Create<string>());

            var billingAddress = new BillingAddress(this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>());

            var billing = new Billing(billingAddress, this.fixture.Create<string>());

            var creditCard = new CreditCard(this.fixture.Create<string>(),
                                            this.fixture.Create<int>(),
                                            this.fixture.Create<int>(),
                                            this.fixture.Create<string>(),
                                            this.fixture.Create<string>(),
                                            billing);

            var payment = new Payment(this.fixture.Create<string>(),
                                      this.fixture.Create<string>(),
                                      this.fixture.Create<decimal>(),
                                      this.fixture.Create<string>(),
                                      customer,
                                      shipping,
                                      creditCard);

            // Act
            payment.Authorize(false);

            // Assert
            payment.Status.Should().Be(Status.Declined);
            payment.Source.As<CreditCard>().Number.Should().Be(creditCard.Number.Mask(0, creditCard.Number.Length - 1));
            payment.Source.As<CreditCard>().Cvv.Should().Be(creditCard.Cvv.Mask(0, creditCard.Cvv.Length));
        }
    }
}
