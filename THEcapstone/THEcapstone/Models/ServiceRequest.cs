using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class ServiceRequest
    {
        [Key]
        public int RequestId { get; set; }
        public string UserId { get; set; }
        public string SenderName { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string RequestStatus { get;set;}
       
    }
}