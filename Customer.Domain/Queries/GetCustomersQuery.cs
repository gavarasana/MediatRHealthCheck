using Customer.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Customer.Domain.Queries
{
    public class GetCustomersQuery : QueryBase<IEnumerable<CustomerDto>>
    {
        public GetCustomersQuery()
        {
        }      
    }
}
