using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class ViewProfileModel
    {
        public Customer Cust { get; set; }
        public VetProfile VetProfile { get; set; } = null;
        public WalkerProfile WalkerProf { get; set; } = null;
        public PetSitterProfile SitterProf { get; set; } = null;

    }
}