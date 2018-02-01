using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class SitterClientJunction
    {
        [Key]
        public int Id { get; set; }
        public Customer Client { get; set; }
        public PetSitter Sitter { get; set; }
    }
}