using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class VetProfile
    {
        [Key]
        public int ProfileId { get; set; }
        [Display(Name = "Brief description of your Veterinary Hospital")]
        [Required]
        public string UserDescription { get; set; }
        [Display(Name = "Description of the services you offer")]
        public string ServicesDescription { get; set; } = null;
        [Display(Name = "Description of your staff")]
        public string StaffDescription { get; set; } = null;
        public bool ShowMap { get; set; }
        public string MapAddress { get; set; } = null;

    }
}