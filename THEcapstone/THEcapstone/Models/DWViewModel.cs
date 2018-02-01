using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class DWViewModel
    {
        public WalkerProfile WalkerProf { get; set; }
        public DogWalker Walker { get; set; }
        public Message Msg { get; set; }
        public List<ServiceRequest> Requests { get; set; }
        
    }
}