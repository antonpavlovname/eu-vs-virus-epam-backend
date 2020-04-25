using System.ComponentModel.DataAnnotations;

namespace HealthPassportApi.DataModels
{
    public class DiseaseUsefulUrl
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}