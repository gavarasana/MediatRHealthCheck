using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Data.Repositories
{
    public class OrderRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OrderRepository(IHttpClientFactory  httpClientFactory )
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(Guid customerId)
        {

        }
    }
}
