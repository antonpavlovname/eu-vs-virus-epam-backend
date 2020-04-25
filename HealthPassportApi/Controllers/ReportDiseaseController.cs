using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPassportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDiseaseController : ControllerBase
    {
        [HttpPost("{uuid}/{disease}")]
        public IActionResult Post(Guid uuid, string disease)
        {
            //TODO: Fire some complex logic
            return Accepted();
        }
    }
}