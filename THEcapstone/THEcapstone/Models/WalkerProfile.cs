using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class WalkerProfile
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string WalkerFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string WalkerLastName { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Tell us a little about yourself")]
        public string UserDiscription { get; set; } 
        [Display(Name = "List any dog preferences you may have")]     
        public string DogTypePreference { get; set; }
        public string CityName { get; set; }
    }
}