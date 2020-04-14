using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class TattooCreate
    {
        public IEnumerable<ClientListItem> ClientList { get; set; }
        [Required]
        public int TattooID { get; set; }

        [Display(Name = "Client")]
        public int ClientID { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Is this tattoo black and white?")]
        public bool BlackAndWhite { get; set; }

        [Required]
        [Display(Name = "Date and time of appointment")]
        public DateTime DateAndTime { get; set; }

    }
}
