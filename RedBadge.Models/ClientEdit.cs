using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class ClientEdit
    {
        public int ClientID { get; set; }

        [Required]
        public string ClientFName { get; set; }

        [Required]
        public string ClientLName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
