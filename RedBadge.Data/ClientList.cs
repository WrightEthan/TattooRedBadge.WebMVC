﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Data
{
    public class ClientList
    {
        [Key]
        public int ClientID { get; set; }
        public string ClientFName { get; set; }
        public string ClientLName { get; set; }
        public string ClientFullName { get; set; }


    }
}
