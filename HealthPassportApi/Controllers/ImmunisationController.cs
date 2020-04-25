using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPassportApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPassportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImmunisationController : ControllerBase
    {
        private static Guid user1 = new Guid("9f71b7d3-5f8f-4824-a09c-adf63c96449c");
        private static Guid user2 = new Guid("1e139a24-8020-4e81-b0d0-fbdc7e78f55e");
        private List<ImmuntisationStatus> _immuntisationStatus =
            new List<ImmuntisationStatus>();

        public ImmunisationController()
        {
            var status1 = new ImmuntisationStatus
            {
                Uuid = user1,
                ImmuneType = "covid-19",
                CertBody = "gov",
                Tested = true,
                CertDate = DateTime.Today.AddDays(-5).Date.ToString("o"),
                CertExpiry = DateTime.Today.AddDays(14).Date.ToString("o")
            };
            var status2 = new ImmuntisationStatus
            {
                Uuid = user1,
                ImmuneType = "ebola",
                CertBody = "gov",
                CertDate = DateTime.Today.Date.ToString("o"),
                CertExpiry = DateTime.Today.AddDays(30).Date.ToString("o")
            };
            var status3 = new ImmuntisationStatus
            {
                Uuid = user2,
                ImmuneType = "covid-19",
                CertBody = "gov",
                CertDate = DateTime.Today.Date.ToString("o"),
                CertExpiry = "for live"
            };

            _immuntisationStatus.Add(status1);
            _immuntisationStatus.Add(status2);
            _immuntisationStatus.Add(status3);
        }

        // GET: api/Todoes/5
        [HttpGet("{uuid}")]
        public ActionResult<IEnumerable<ImmuntisationStatus>> Get(Guid uuid, string immuneType)
        {
            //MockUserId
            var query = _immuntisationStatus.Where(v => v.Uuid == uuid);
            if (immuneType!=null)
            {
                query = query.Where(v => v.ImmuneType == immuneType);
            }

            return query.ToArray();
        }

        [HttpPost()]
        public ActionResult<ImmuntisationStatus> Post(ImmuntisationStatus status)
        {
            _immuntisationStatus.Add(status);

            return CreatedAtAction("Get", new { uuid = status.Uuid, immuneType = status.ImmuneType }, status);
        }

        [HttpDelete("{uuid}")]
        public ActionResult<ImmuntisationStatus> Delete(Guid uuid, string immuneType)
        {
            var result = _immuntisationStatus.Where(v => v.Uuid == uuid && v.ImmuneType == immuneType).SingleOrDefault();
            
            if(result == null)
            {
                return NotFound();
            }

            _immuntisationStatus.Remove(result);

            return result;
        }
    }
}