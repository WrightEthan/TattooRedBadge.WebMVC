using System;
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
        public string FName { get; set; }
        public string LName { get; set; }
        public string FullName { get; set; }


    }
}
