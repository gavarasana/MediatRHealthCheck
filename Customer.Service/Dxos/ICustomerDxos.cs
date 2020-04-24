using Customer.Domain.Dtos;
using System.Collections.Generic;

namespace Customer.Service.Dxos
{
    public interface ICustomerDxos
    {
        CustomerDto MapCustomerDto(Domain.Models.Customer customer);
        IEnumerable<CustomerDto> MapCustomerDtos(IEnumerable<Domain.Models.Customer> customers);
    }
}