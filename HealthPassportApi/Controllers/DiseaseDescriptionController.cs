using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ImmunisationPass.Data;
using ImmunisationPass.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImmunisationPass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseDescriptionController : ControllerBase
    {
        private readonly HealthDatabaseContext _context;
        private Dictionary<string, DiseaseDescription> _diseaseDescriptions = new Dictionary<string, DiseaseDescription>();

        public DiseaseDescriptionController(HealthDatabaseContext context)
        {
            _context = context;
            _diseaseDescriptions.Add("covid-19", new DiseaseDescription
            {
                Information = "Some information about covid",
                Symptoms = "High temperature",
                Treatment = "Keep home",
                Vaccination = "On their way",
                UsefulReferences = new List<DiseaseUsefulUrl> {new DiseaseUsefulUrl()
                {
                    Name = "WHO",
                    Url = "https://www.who.int/emergencies/diseases/novel-coronavirus-2019"
                }}
            });
            _diseaseDescriptions.Add("ebola", new DiseaseDescription
            {
                Information = "Some information about ebola",
                Symptoms = "High temperature",
                Treatment = "Drink a lot",
                Vaccination = "Some specialized center",
                UsefulReferences = new List<DiseaseUsefulUrl> {new DiseaseUsefulUrl()
                {
                    Name = "WHO",
                    Url = "https://www.who.int/emergencies/diseases/ebola"
                }}
            });
        }


        [HttpGet("{disease}")]
        public async Task<ActionResult<DiseaseDescription>> Get(string disease)
        {
            try
            {

                var diseaseData = await _context.DiseaseDescriptions.Where(d => d.Name == disease)
                    .Include(d => d.UsefulReferences)
                    .FirstOrDefaultAsync();
                
                if (diseaseData == null)
                {
                    return NotFound();
                }

                var usefulReferences = diseaseData.UsefulReferences?.Select(d => new DiseaseUsefulUrl
                {
                    Url = d.Url,
                    Name = d.Name
                }).ToList();

                DiseaseDescription result = new DiseaseDescription()
                {
                    Treatment = diseaseData.Treatment,
                    Symptoms = diseaseData.Symptoms,
                    Vaccination = diseaseData.Vaccination,
                    Information = diseaseData.Information,
                    UsefulReferences = usefulReferences ?? new List<DiseaseUsefulUrl>()
                };
                return result;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
        }

    }
}