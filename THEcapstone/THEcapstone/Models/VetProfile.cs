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
        [Display(Name = "Give a brief description of your Veterinary Hospital")]
        [Required]
        public string UserDescription { get; set; }
        [Display(Name = "Give a description of the services you offer")]
        public string ServicesDescription { get; set; } = null;
        [Display(Name = "Give a description of your staff")]
        public string StaffDescription { get; set; } = null;
        [Display(Name = "Would you like your profile to display your location on a map?")]
        public bool ShowMap { get; set; }
        [Display(Name = "What address would you like to use?")]
        public string MapAddress { get; set; } = null;

    }
}