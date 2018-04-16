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
        [DataType(DataType.MultilineText)]
        [Required]
        public string UserDescription { get; set; }
        [Display(Name = "Give a description of the services you offer")]
        [DataType(DataType.MultilineText)]
        public string ServicesDescription { get; set; } = null;
        [Display(Name = "Give a description of your staff")]
        [DataType(DataType.MultilineText)]
        public string StaffDescription { get; set; } = null;
        [Required]
        [Display (Name = "Discount you'll offer to subscribed clients")]
        public string DiscountToDisplay { get; set; }
        [Display(Name = "City you operate out of.")]
        [Required]
        public string MapAddressCity { get; set; } = null;
        [Display(Name = "Would you like your profile to display your location on a map?")]
        public bool ShowMap { get; set; }
        [Display(Name = "What street address would you like to use?")]
        public string MapAddressStreet { get; set; } = null;        
        [Display(Name = "State")]
        public string MapAddressState { get; set; } = null;
        

    }
}