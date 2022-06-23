namespace PaymentGateway.Application.Services.Mappers.Payments
{
    using ApplicationDto = Dto.Payments;
    using DomainModel = Domain.Model.Payments;

    public static class CustomerMapper
    {
        public static ApplicationDto.Customer ToDto(this DomainModel.Customer customer) =>
            new()
            {
                Id = customer.Id,
                Name = customer.Name,
            };

        public static DomainModel.Customer ToDomainModel(this ApplicationDto.Customer customer) => new(customer.Id, customer.Name);
    }
}
