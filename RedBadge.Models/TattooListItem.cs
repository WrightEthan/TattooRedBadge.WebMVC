using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class TattooListItem
    {
        public int TattooID { get; set; }
        public ClientDetail Client { get; set; }
        public string ClientFullName
        {
            get { return Client.ClientFullName; }
        }
        public string FName { get; set; }
        public string LName { get; set; }
        public string ArtistFullName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool BlackAndWhite { get; set; }
       // [ForeignKey("Client")]
        public int? ClientID { get; set; }

    }
}
