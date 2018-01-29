using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class CustomerSendModel
    {
        public Customer Cust { get; set; }
        public Veterinarian Vet { get; set; } = null;
        public DogWalker Walker { get; set; } = null;
        public PetSitter Sitter { get; set; } = null;
        public Message Msg { get; set; }

    }
}