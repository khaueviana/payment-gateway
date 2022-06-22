namespace PaymentGateway.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PaymentGateway.Presentation.Dto.Payment;

    [ApiController]
    [Produces("application/json")]
    [Route("v1/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public PaymentResponse Post(PaymentRequest paymentRequest)
        {
            return new PaymentResponse();
        }
    }
}