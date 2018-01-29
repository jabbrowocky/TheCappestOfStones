using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class PetSitter
    {
        [Key]
        public int SitterId { get; set; }
        public string SitterFirstName { get; set; }
        public string SitterLastName { get; set; }
        public int AddressId { get; set; }
        public Addresses Address { get; set; }
    }
}