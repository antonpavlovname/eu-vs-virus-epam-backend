using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPassportApi.Models
{
    public class ImmuntisationStatus
    {
        public Guid Uuid { get; set; }
        public string ImmuneType { get; set; }
        public bool Tested { get; set; }
        public string CertBody { get; set; }
        public string CertDate { get; set; }
        public string CertExpiry { get; set; }
    }
}
