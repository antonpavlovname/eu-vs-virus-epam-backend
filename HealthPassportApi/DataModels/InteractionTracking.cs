using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace HealthPassportApi.DataModels
{
    public class InteractionTracking
    {
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        
        public Guid InteractionEntity { get; set; }
        [Required]
        public DateTime CheckInTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        [Required]
        public string CheckInType { get; set; }
        public Point LatLong { get; set; }
    }
}
