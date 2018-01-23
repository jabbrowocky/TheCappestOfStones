﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public int AddressId { get; set; }
        public Addresses AddId { get; set; }
        public string UserId {get;set;}
        public virtual ApplicationUser Id { get; set; }
    }
}