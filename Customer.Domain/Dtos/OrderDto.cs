using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public int TotalItems { get; set; }
    }
}
