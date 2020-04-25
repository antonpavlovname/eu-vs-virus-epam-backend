using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPassportApi.DataModels
{
    public class ImmuntisationStatus
    {
        public Guid Id { get; set; }
        public Guid Uuid { get; set; }
        public string ImmuneType { get; set; }
        public bool Tested { get; set; }
        public string CertBody { get; set; }
        [DataType(DataType.Date)]
        public DateTime CertDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CertExpiry { get; set; }
    }
}
