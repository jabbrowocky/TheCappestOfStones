using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class PetSitterProfile
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string SitterFirstName { get; set;}
        [Display(Name = "Last Name")]
        public string SitterLastName { get; set; }
        [Display(Name = "City of residence")]
        public string CityName { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Brief description of yourself")]
        public string BriefDescription { get; set; }
        [Display(Name = "Description of previous experience")]
        public string ExperienceDescription { get; set; }
        [Display(Name="Rate of pay expected")]
        public string RatePerHour { get; set; }
    }
}