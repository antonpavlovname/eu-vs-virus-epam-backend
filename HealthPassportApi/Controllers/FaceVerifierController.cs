using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ImmunisationPass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaceVerifierController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync([FromRoute]Guid faceId, List<IFormFile> faceImages)
        {
            foreach (var file in faceImages)
            {
                var filePath = Path.Combine(Path.GetTempPath(), file.FileName);
                await using (var outputStream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(outputStream);
                }
            }

            return Ok(new { uuid = new Guid("EE244393-84D2-4A63-9442-5FC0F9B0B385") });
        }
    }
}