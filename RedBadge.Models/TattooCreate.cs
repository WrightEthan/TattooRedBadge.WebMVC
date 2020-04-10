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

        public int? ClientID { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool BlackAndWhite { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

    }
}
