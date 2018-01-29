using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class DogWalkerCreateModel
    {
        public DogWalker Walker { get; set; }
        public Addresses Address { get; set; }
        public States State { get; set; }
        public List<States> StateList { get; set; }
    }
}