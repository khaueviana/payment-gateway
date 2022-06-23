namespace PaymentGateway.Presentation.Mappers.Payments
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class CustomerMapper
    {
        public static ApplicationDto.Customer ToApplicationDto(this PresentationDto.Customer customer) =>
            new()
            {
                Id = customer.Id,
                Name = customer.Name,
            };

        public static PresentationDto.Customer ToPresentationDto(this ApplicationDto.Customer customer) =>
            new()
            {
                Id = customer.Id,
                Name = customer.Name,
            };
    }
}
