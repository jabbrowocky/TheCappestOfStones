using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        [Display(Name = "First Name")]
        public string CustFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string CustLastName { get; set; }
        public int AddressId { get; set; }
        public Addresses Address { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public List<Message> Inbox { get; set; }
        public bool IsSubscribed { get; set; } = false;
        public bool HasWalker { get; set; }
        public bool HasSitter { get; set; }
        
    }
}