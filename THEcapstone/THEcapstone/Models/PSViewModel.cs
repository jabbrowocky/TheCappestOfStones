using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THEcapstone.Models
{
    public class PSViewModel
    {
        public Message Msg { get; set; }
        public PetSitter Sitter { get; set; }
        public PetSitterProfile SitterProf { get; set; }

    }
}