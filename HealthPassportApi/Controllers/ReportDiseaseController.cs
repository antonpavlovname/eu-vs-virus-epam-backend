using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HealthPassportApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HealthPassportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDiseaseController : ControllerBase
    {
        private readonly HealthDatabaseContext _context;

        public ReportDiseaseController(HealthDatabaseContext context)
        {
            _context = context;
        }

        private const string sqlText = @"SELECT persons.* FROM [dbo].[InteractionTracking] as persons inner join
(SELECT [InteractionEntity]
      ,[CheckInType] 
      ,[CheckInTime] as StartTime
      , DATEADD(day, 1, CONVERT(date, [CheckoutTime])) as EndTime
      ,[LatLong]
  FROM [dbo].[InteractionTracking]
  WHERE [UserId]=@userId) as dangerous
  ON persons.InteractionEntity = dangerous.InteractionEntity
  WHERE (persons.CheckInTime BETWEEN dangerous.StartTime and dangerous.EndTime
		or persons.CheckoutTime BETWEEN dangerous.StartTime and dangerous.EndTime)
		and persons.UserId <> @userId";

        [HttpPost("{userId}/{disease}")]
        public async Task<ActionResult<IEnumerable<string>>> Post(Guid userId, string disease)
        {
            var userIdParameter = new SqlParameter("userId", userId);
            var reportToPeople = await _context.InteractionTracking.FromSqlRaw(sqlText, userIdParameter).ToListAsync();
            foreach (var person in reportToPeople)
            {
                //TODO: push notifications
                Trace.WriteLine($"{person.UserId}: {person.InteractionEntity}");
            }
            return reportToPeople.Select(p => p.UserId.ToString()).Distinct().ToList();
        }
    }
}