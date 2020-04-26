using System.Collections.Generic;

namespace ImmunisationPass.Models
{
    public class DiseaseUsefulUrl
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class DiseaseDescription
    {
        public string Information { get; set; }
        public string Symptoms { get; set; }
        public string Treatment { get; set; }
        public string Vaccination { get; set; }
        public List<DiseaseUsefulUrl> UsefulReferences { get; set; }
    }
}
