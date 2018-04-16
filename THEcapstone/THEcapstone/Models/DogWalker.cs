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
        [Display(Name = "First Name")]
        public string WalkerFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string WalkerLastName { get; set; }
        public int AddressId { get; set; }        
        public Addresses Address { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int? ProfileId { get; set; } = null;
        public WalkerProfile Profile { get; set; }
        public int FeedbackRating { get; set; }
        public int FeedbackCount { get; set; }
        public List<Message> Inbox { get; set; }
        public List<Customer> Clients { get; set; }
        
    }
}