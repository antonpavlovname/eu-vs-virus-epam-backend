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
    public class DiseaseDescriptionController : ControllerBase
    {
        private Dictionary<string, DiseaseDescription> _diseaseDescriptions = new Dictionary<string, DiseaseDescription>();

        public DiseaseDescriptionController()
        {
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
        public ActionResult<DiseaseDescription> Get(string disease)
        {
            if (_diseaseDescriptions.TryGetValue(disease, out var description))
            {
                return description;
            }

            return NotFound();
        }

    }
}