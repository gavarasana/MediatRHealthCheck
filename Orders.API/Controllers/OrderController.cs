using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Orders.API.Dtos;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly Dictionary<Guid, OrderDto> Orders = new Dictionary<Guid, OrderDto>();

        static OrderController()
        {
            Orders.Add(Guid.Parse("C6B67734-38CA-4CF3-9426-ADD7D246EEF3"), new OrderDto { Id = Guid.Parse("C6B67734-38CA-4CF3-9426-ADD7D246EEF3"), CustomerId = Guid.Parse("71628E00-EF69-4F11-A3AA-2E0EC772B0FF"), OrderDate = DateTime.Now.AddDays(-5), OrderTotal = 123.23m, TotalItems = 12 });
            Orders.Add(Guid.Parse("84354C8B-D1B2-4A02-B19F-FDE6272E24C3"), new OrderDto { Id = Guid.Parse("84354C8B-D1B2-4A02-B19F-FDE6272E24C3"), CustomerId = Guid.Parse("5A41AE1F-51E0-4215-8317-5B96BD8092F7"), OrderDate = DateTime.Now.AddDays(-4), OrderTotal = 45.67m, TotalItems = 4 });
            Orders.Add(Guid.Parse("{FADB9781-8BD0-4046-B7EF-56EDE2439B05}"), new OrderDto { Id = Guid.Parse("{FADB9781-8BD0-4046-B7EF-56EDE2439B05}"), CustomerId = Guid.Parse("71628E00-EF69-4F11-A3AA-2E0EC772B0FF"), OrderDate = DateTime.Now.AddDays(-15), OrderTotal = 55.19m, TotalItems = 5 });
        }

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<OrderDto> GetAll()
        {
            return Orders.Values;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), 200)]
        [ProducesResponseType(404)]
        public ActionResult<OrderDto> GetById(Guid id)
        {
            return (Orders.TryGetValue(id, out OrderDto orderDto)) ? Ok(orderDto) : (ActionResult<OrderDto>)NotFound();
        }
    }
}
