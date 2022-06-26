namespace PaymentGateway.Application.Services.Tests
{
    using Infrastructure.CrossCutting.Extensions;
    using PaymentGateway.Application.Services.Mappers.Payments;
    using PaymentGateway.Domain.Core.Interfaces;

    public class PaymentApplicationServiceTests
    {
        private readonly Mock<IAcquiringBankService> acquiringBankServiceMock;
        private readonly Mock<IPaymentsRepository> paymentsRepositoryMock;
        private readonly PaymentApplicationService paymentApplicationService;
        private readonly Fixture fixture;

        public PaymentApplicationServiceTests()
        {
            this.acquiringBankServiceMock = new Mock<IAcquiringBankService>();
            this.paymentsRepositoryMock = new Mock<IPaymentsRepository>();
            this.paymentApplicationService = new PaymentApplicationService(acquiringBankServiceMock.Object, paymentsRepositoryMock.Object);
            this.fixture = new Fixture();
        }

        [Fact]
        public async Task CreateAsync_ExistingPayment_ReturnsPayment()
        {
            // Arrange
            var paymentRequest = this.fixture.Build<ApplicationDto.PaymentRequest>()
                .With(x => x.Source, this.fixture.Create<ApplicationDto.Sources.CreditCard>())
                .Create();

            var payment = paymentRequest.ToDomainModel();

            this.paymentsRepositoryMock.Setup(x => x.GetByReference(paymentRequest.Reference))
                .ReturnsAsync(payment)
                .Verifiable();

            // Act
            var result = await paymentApplicationService.CreateAsync(paymentRequest);

            // Assert
            result.Should().BeEquivalentTo(payment);
            this.paymentsRepositoryMock.Verify();
        }

        [Fact]
        public async Task CreateAsync_ValidPayment_ReturnsAuthorizedPayment()
        {
            // Arrange
            var creditCard = this.fixture.Create<ApplicationDto.Sources.CreditCard>();

            var paymentRequest = this.fixture.Build<ApplicationDto.PaymentRequest>()
                .With(x => x.Source, creditCard)
                .Create();

            this.paymentsRepositoryMock.Setup(x => x.GetByReference(paymentRequest.Reference))
                .ReturnsAsync(default(DomainModel.Payment))
                .Verifiable();

            this.acquiringBankServiceMock.Setup(x => x.AuthorizeAsync(It.IsAny<DomainModel.Payment>()))
                .ReturnsAsync(true)
                .Verifiable();

            this.paymentsRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<DomainModel.Payment>()))
                .Verifiable();

            // Act
            var result = await paymentApplicationService.CreateAsync(paymentRequest);

            // Assert
            result.Status.Should().Be(ApplicationDto.Status.Authorized);
            result.Source.As<ApplicationDto.Sources.CreditCard>().Number.Should().Be(creditCard.Number.Mask(0, creditCard.Number.Length - 1));
            result.Source.As<ApplicationDto.Sources.CreditCard>().Cvv.Should().Be(creditCard.Cvv.Mask(0, creditCard.Cvv.Length));
            this.paymentsRepositoryMock.Verify();
            this.acquiringBankServiceMock.Verify();
        }

        [Fact]
        public async Task CreateAsync_InvalidPayment_ReturnsDeclinedPayment()
        {
            // Arrange
            var creditCard = this.fixture.Create<ApplicationDto.Sources.CreditCard>();

            var paymentRequest = this.fixture.Build<ApplicationDto.PaymentRequest>()
                .With(x => x.Source, creditCard)
                .Create();

            this.paymentsRepositoryMock.Setup(x => x.GetByReference(paymentRequest.Reference))
                .ReturnsAsync(default(DomainModel.Payment))
                .Verifiable();

            this.acquiringBankServiceMock.Setup(x => x.AuthorizeAsync(It.IsAny<DomainModel.Payment>()))
                .ReturnsAsync(false)
                .Verifiable();

            this.paymentsRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<DomainModel.Payment>()))
                .Verifiable();

            // Act
            var result = await paymentApplicationService.CreateAsync(paymentRequest);

            // Assert
            result.Status.Should().Be(ApplicationDto.Status.Declined);
            result.Source.As<ApplicationDto.Sources.CreditCard>().Number.Should().Be(creditCard.Number.Mask(0, creditCard.Number.Length - 1));
            result.Source.As<ApplicationDto.Sources.CreditCard>().Cvv.Should().Be(creditCard.Cvv.Mask(0, creditCard.Cvv.Length));
            this.paymentsRepositoryMock.Verify();
            this.acquiringBankServiceMock.Verify();
        }

        [Fact]
        public async Task GetAsync_ExistingId_ReturnsFilledPayment()
        {
            // Arrange
            var id = this.fixture.Create<Guid>();

            var customer = new DomainModel.Customer(this.fixture.Create<string>(), this.fixture.Create<string>());

            var shippingAddress = new DomainModel.ShippingAddress(this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>(),
                                                      this.fixture.Create<string>());

            var shipping = new DomainModel.Shipping(shippingAddress, this.fixture.Create<string>());

            var billingAddress = new DomainModel.Sources.BillingAddress(this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>(),
                                                    this.fixture.Create<string>());

            var billing = new DomainModel.Sources.Billing(billingAddress, this.fixture.Create<string>());

            var creditCard = new DomainModel.Sources.CreditCard(this.fixture.Create<string>(),
                                            this.fixture.Create<int>(),
                                            this.fixture.Create<int>(),
                                            this.fixture.Create<string>(),
                                            this.fixture.Create<string>(),
                                            billing);

            var payment = new DomainModel.Payment(id,
                                      this.fixture.Create<string>(),
                                      this.fixture.Create<string>(),
                                      this.fixture.Create<decimal>(),
                                      this.fixture.Create<string>(),
                                      customer,
                                      shipping,
                                      creditCard,
                                      DomainModel.Status.Authorized);

            this.paymentsRepositoryMock.Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(payment)
                .Verifiable();

            // Act
            var result = await this.paymentApplicationService.GetAsync(id);

            // Arrange
            result.Should().BeEquivalentTo(payment);
            this.paymentsRepositoryMock.Verify();
        }

        [Fact]
        public async Task GetAsync_InexistentId_ReturnsNullPayment()
        {
            // Arrange
            var id = this.fixture.Create<Guid>();

            this.paymentsRepositoryMock.Setup(x => x.GetByIdAsync(id))
                .ReturnsAsync(default(DomainModel.Payment))
                .Verifiable();

            // Act
            var result = await this.paymentApplicationService.GetAsync(id);

            // Arrange
            result.Should().BeNull();
            this.paymentsRepositoryMock.Verify();
        }
    }
}
