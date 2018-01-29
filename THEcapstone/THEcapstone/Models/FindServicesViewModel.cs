using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class FindServicesViewModel
    {
        public Customer Cust { get; set; }
        public List <Veterinarian> Vet { get; set; }
        public List <DogWalker> Walker { get; set; }
        public List <PetSitter> Sitter { get; set; }

    }
}