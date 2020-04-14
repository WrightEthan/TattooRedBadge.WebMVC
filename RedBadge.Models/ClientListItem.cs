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

        public string ClientFName { get; set; }

        public string ClientLName { get; set; }

        public string ClientFullName
        {
            get { return ClientFName + " " + ClientLName; }
        }

        public DateTime DOB { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
