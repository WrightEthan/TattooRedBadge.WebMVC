using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Data
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string ClientFName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string ClientLName { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string ClientFullName
        {
            get { return ClientFName + " " + ClientLName; }
        }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
