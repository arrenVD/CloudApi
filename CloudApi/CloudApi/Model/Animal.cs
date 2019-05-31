using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApi.Model
{
    public class Animal
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public Family Family { get; set; }
        public string Description { get; set; }
        public double? LifeSpan { get; set; }
    
        public string ConservationStatus {get;set;}
        public string ImageURL { get; set; }
        public int? FamilyId { get; set; }

        public string Order { get; set; }
    }



}
