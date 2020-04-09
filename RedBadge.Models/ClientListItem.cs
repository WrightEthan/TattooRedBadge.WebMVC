using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class ClientListItem
    {
        public int ClientID { get; set; }

        public Guid OwnerId { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string ClientFullName
        {
            get { return FName + " " + LName; }
        }

        public DateTime DOB { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
