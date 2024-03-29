namespace PaymentGateway.Presentation.Controllers
{
    using FluentValidation;
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
        private readonly IValidator<PaymentRequest> validator;

        public PaymentsController(IPaymentApplicationService paymentApplicationServices, IValidator<PaymentRequest> validator)
        {
            this.paymentApplicationServices = paymentApplicationServices;
            this.validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> PostAsync(PaymentRequest paymentRequest)
        {
            try
            {
                var result = await this.validator.ValidateAsync(paymentRequest);

                if (!result.IsValid)
                {
                    return BadRequest(result);
                }

                var paymentResponse = await this.paymentApplicationServices.CreateAsync(paymentRequest.ToApplicationDto());

                return CreatedAtAction($"{nameof(Get)}", new { id = paymentResponse.Id }, paymentResponse.ToPresentationDto());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PaymentResponse>> Get(Guid id)
        {
            try
            {
                var paymentResponse = await this.paymentApplicationServices.GetAsync(id);

                if (paymentResponse == null)
                {
                    return NotFound();
                }

                return Ok(paymentResponse.ToPresentationDto());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}