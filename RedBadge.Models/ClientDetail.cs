using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class ClientDetail
    {
        public int ClientID { get; set; }

        public Guid OwnerId { get; set; }

        public string ClientFullName
        {
            get { return ClientFName + " " + ClientLName; }
        }
        [Display(Name = "First Name")]
        public string ClientFName { get; set; }

        [Display(Name = "Last Name")]
        public string ClientLName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

    }
}
