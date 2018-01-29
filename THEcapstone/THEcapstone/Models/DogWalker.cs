using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class DogWalker
    {
        [Key]
        public int WalkerId { get; set; }
        public string WalkerFirstName { get; set; }
        public string WalkerLastName { get; set; }
        public int AddressId { get; set; }        
        public Addresses Address { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int? ProfileId { get; set; } = null;
        public WalkerProfile Profile { get; set; }
        public string FeedbackRating { get; set; }
        
    }
}