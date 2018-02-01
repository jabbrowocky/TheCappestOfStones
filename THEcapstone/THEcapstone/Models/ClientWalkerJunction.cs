using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class ClientWalkerJunction
    {
        public int ClientId { get; set; }
        public Customer Client { get; set; }
        [Key]
        public int WalkerId { get; set; }
        public DogWalker Walker { get; set; }
    }
}