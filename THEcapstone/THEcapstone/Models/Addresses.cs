using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class Addresses
    {
        [Key]
        public int AddressId { get; set; }
        [Display(Name="Street Address")]
        public string Street { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        public int StateId { get; set; }
        public States state { get; set; }  
        [Display(Name = "Zip Code")]      
        public int ZipCode { get; set; }
    }
}