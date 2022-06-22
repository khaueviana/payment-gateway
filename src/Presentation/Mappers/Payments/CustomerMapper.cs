namespace PaymentGateway.Presentation.Mappers.Payments
{
    using ApplicationDto = Application.Dto.Payments;
    using PresentationDto = Dto.Payments;

    public static class CustomerMapper
    {
        public static ApplicationDto.Customer ToApplicationDto(this PresentationDto.Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new ApplicationDto.Customer
            {
                Id = customer.Id,
                Name = customer.Name,
            };
        }
    }
}
