using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPassportApi.Data;
using HealthPassportApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthPassportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImmunisationController : ControllerBase
    {
        private const string ForLive = "for live";
        private readonly HealthDatabaseContext _context;
        private static Guid user1 = new Guid("9f71b7d3-5f8f-4824-a09c-adf63c96449c");
        private static Guid user2 = new Guid("1e139a24-8020-4e81-b0d0-fbdc7e78f55e");
        private List<ImmuntisationStatus> _immuntisationStatus =
            new List<ImmuntisationStatus>();

        public ImmunisationController(HealthDatabaseContext context)
        {
            _context = context;
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
                CertExpiry = ForLive
            };

            _immuntisationStatus.Add(status1);
            _immuntisationStatus.Add(status2);
            _immuntisationStatus.Add(status3);
        }

        // GET: api/Todoes/5
        [HttpGet("{uuid}")]
        public async Task<ActionResult<IEnumerable<ImmuntisationStatus>>> Get(Guid uuid, string immuneType)
        {
            //MockUserId
            var query = _context.ImmuntisationStatus.Where(v => v.Uuid == uuid);
            if (immuneType!=null)
            {
                query = query.Where(v => v.ImmuneType == immuneType);
            }

            var result = await query.ToArrayAsync();
            return result.Select(ConvertImmuntisationStatusFromDb).ToList();
        }

        private ImmuntisationStatus ConvertImmuntisationStatusFromDb(DataModels.ImmuntisationStatus r)
        {
            return new ImmuntisationStatus
            {
                ImmuneType = r.ImmuneType,
                Uuid = r.Uuid,
                CertExpiry = ConvertDateTimeFromDb(r.CertExpiry),
                CertDate = ConvertDateTimeFromDb(r.CertDate),
                Tested = r.Tested,
                CertBody = r.CertBody
            };
        }
        private DataModels.ImmuntisationStatus ConvertImmuntisationStatusToDb(ImmuntisationStatus r)
        {
            return new DataModels.ImmuntisationStatus
            {
                ImmuneType = r.ImmuneType,
                Uuid = r.Uuid,
                CertExpiry = ConvertDateTimeToDb(r.CertExpiry),
                CertDate = ConvertDateTimeToDb(r.CertDate),
                Tested = r.Tested,
                CertBody = r.CertBody
            };
        }

        private DateTime ConvertDateTimeToDb(string dt)
        {
            if (dt == ForLive)
                return DateTime.MaxValue;
            return DateTime.Parse(dt);
        }

        private string ConvertDateTimeFromDb(DateTime dt)
        {
            if (dt.Year > 9000) 
                return "for live";
            return dt.ToString("M/d/yyyy");
        }

        [HttpPost()]
        public async Task<ActionResult<ImmuntisationStatus>> Post(ImmuntisationStatus status)
        {
            var result = await _context.ImmuntisationStatus.AddAsync(ConvertImmuntisationStatusToDb(status));
            _context.SaveChanges();
            return CreatedAtAction("Get", new { uuid = status.Uuid, immuneType = status.ImmuneType }, ConvertImmuntisationStatusFromDb(result.Entity));
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult<ImmuntisationStatus>> Delete(Guid uuid, string immuneType)
        {
            var result = await _context.ImmuntisationStatus.Where(v => v.Uuid == uuid && v.ImmuneType == immuneType).SingleOrDefaultAsync();
            
            if(result == null)
            {
                return NotFound();
            }

            _context.ImmuntisationStatus.Remove(result);
            _context.SaveChanges();
            return ConvertImmuntisationStatusFromDb(result);
        }
    }
}