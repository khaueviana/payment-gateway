namespace PaymentGateway.Application.Services.Mappers.Payments
{
    using ApplicationDto = PaymentGateway.Application.Dto.Payments;
    using DomainModel = PaymentGateway.Domain.Model.Payments;

    public static class CustomerMapper
    {
        public static ApplicationDto.Customer ToDto(this DomainModel.Customer customer)
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

        public static DomainModel.Customer ToDomainModel(this ApplicationDto.Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return new DomainModel.Customer(customer.Id, customer.Name);
        }
    }
}
