using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string UserDescription { get; set; }

    }
}