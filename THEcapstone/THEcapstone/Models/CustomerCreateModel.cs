﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class CustomerCreateModel
    {
        public Customer Cust { get; set; }
        public Addresses Address { get; set; }
    }
}