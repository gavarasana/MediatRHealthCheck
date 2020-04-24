using Customer.Data.IRepositories;
using Customer.Domain.Dtos;
using Customer.Domain.Queries;
using Customer.Service.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.Services
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerDxos _customerDxos;
        private readonly ILogger<GetCustomersHandler> _logger;

        public GetCustomersHandler(ICustomerRepository customerRepository, ICustomerDxos customerDxos, ILogger<GetCustomersHandler> logger)
        {
            _customerRepository = customerRepository;
            _customerDxos = customerDxos;
            _logger = logger;

        }
        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetListAsync(customer => customer.CreatedAt > DateTime.Now.AddYears(-1));
            return _customerDxos.MapCustomerDtos(customers);
        }
    }
}
