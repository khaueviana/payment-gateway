namespace PaymentGateway.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PaymentGateway.Application.Services.Interfaces;
    using PaymentGateway.Presentation.Dto.Payments;
    using PaymentGateway.Presentation.Mappers.Payments;

    [ApiController]
    [Produces("application/json")]
    [Route("v1/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentApplicationService paymentApplicationServices;

        public PaymentsController(IPaymentApplicationService paymentApplicationServices)
        {
            this.paymentApplicationServices = paymentApplicationServices;
        }

        [HttpPost]
        public async Task<PaymentResponse> PostAsync(PaymentRequest paymentRequest)
        {
            var paymentResponseDto = await this.paymentApplicationServices.CreateAsync(paymentRequest.ToApplicationDto());

            return paymentResponseDto.ToPresentationDto();
        }

        [HttpGet]
        public async Task<PaymentResponse> Get(Guid id)
        {
            var paymentResponseDto = await this.paymentApplicationServices.GetAsync(id);

            return paymentResponseDto.ToPresentationDto();
        }
    }
}