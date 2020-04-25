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
    public class UserServiceController : ControllerBase
    {
        // GET: api/UserService/CZ123456?countryOfGovID=CZ
        [HttpGet("{govID}", Name = "GetToken")]
        public string GetToken(string govID, [FromQuery]string countryOfGovID)
        {
            return "mock-token: "+ govID + " : " + countryOfGovID;
        }
    }
}
