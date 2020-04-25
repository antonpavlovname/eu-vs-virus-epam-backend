using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenServiceController : ControllerBase
    {
        // GET: api/TokenService/123456
        [HttpGet("{token}", Name = "Get")]
        public string Get(string token)
        {
            return "echo: "+ token;
        }
    }
}
