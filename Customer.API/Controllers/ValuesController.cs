using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<string> _values = new List<string>
        {
            "Values 1", "Values 2", "Values 3", "Values 4"
        };
        public async Task<ActionResult<string>> GetAll()
        {
            //return Ok(await Task.FromResult(_values));
            return await Task.FromResult(Ok(_values));
        }
    }
}