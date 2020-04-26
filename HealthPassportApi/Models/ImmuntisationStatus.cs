using System;

namespace ImmunisationPass.Models
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
