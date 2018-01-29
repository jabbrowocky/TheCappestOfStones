using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class Message
    {
        [Key]
        public int MsgId { get; set; }  
        public string AuthorId { get; set; }     
        public string TargetId { get; set; }
        public virtual ApplicationUser Target { get; set; }
        public string MsgText { get; set; }
        public DateTime SentOn { get; set; }        
        public bool Opened { get; set; }
        public bool Deleted { get; set; }
       


    }
}