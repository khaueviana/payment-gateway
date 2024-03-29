﻿namespace PaymentGateway.Application.Services
{
    using PaymentGateway.Application.Services.Interfaces;
    using PaymentGateway.Application.Services.Mappers.Payments;
    using PaymentGateway.Domain.Core.Interfaces;
    using System;
    using System.Threading.Tasks;
    using ApplicationDto = Dto.Payments;

    public class PaymentApplicationService : IPaymentApplicationService
    {
        private readonly IAcquiringBankService acquiringBankService;
        private readonly IPaymentsRepository paymentsRepository;

        public PaymentApplicationService(IAcquiringBankService acquiringBankService, IPaymentsRepository paymentsRepository)
        {
            this.acquiringBankService = acquiringBankService;
            this.paymentsRepository = paymentsRepository;
        }

        public async Task<ApplicationDto.PaymentResponse> CreateAsync(ApplicationDto.PaymentRequest paymentRequest)
        {
            var existingPayment = await this.paymentsRepository.GetByReference(paymentRequest.Reference);

            if (existingPayment != null)
            {
                return existingPayment.ToDto();
            }

            var payment = paymentRequest.ToDomainModel();

            var isAuthorized = await this.acquiringBankService.AuthorizeAsync(payment);

            payment.Authorize(isAuthorized);

            await this.paymentsRepository.InsertAsync(payment);

            return payment.ToDto();
        }

        public async Task<ApplicationDto.PaymentResponse> GetAsync(Guid id)
        {
            var payment = await this.paymentsRepository.GetByIdAsync(id);

            return payment.ToDto();
        }
    }
}
