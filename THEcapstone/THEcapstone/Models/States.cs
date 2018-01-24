using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class States
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }
    }
}