using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImmunisationPass.DataModels
{
    public class DiseaseDescription
    {
        [Key]
        public string Name { get; set; }
        public string Information { get; set; }
        public string Symptoms { get; set; }
        public string Treatment { get; set; }
        public string Vaccination { get; set; }
        public List<DiseaseUsefulUrl> UsefulReferences { get; set; }

    }

}
