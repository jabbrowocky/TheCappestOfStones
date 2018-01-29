using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class Veterinarian
    {
        [Key]
        public int VetId { get; set; }
        [Display(Name = "Name of Vetrinary Establishment")]
        public string VetName { get; set; }
        public int AddressId { get; set; }
        public Addresses Address { get; set; }
        public int? ProfileId { get; set; } = null;
        public VetProfile Profile { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public List<Message> Inbox { get; set; }
        public int FeedbackRating { get; set; }
    }
}