using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class VetProfileViewModel
    {
        public Veterinarian Vet { get; set; }
        public VetProfile VetProfile { get; set; }
        public Message Msg { get; set; } = null;
    }
}