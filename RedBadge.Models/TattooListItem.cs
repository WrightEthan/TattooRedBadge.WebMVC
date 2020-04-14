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
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool BlackAndWhite { get; set; }
        public int ClientID { get; set; }

        public ClientDetail Client { get; set; }
        public string ClientFullName
        {
            get { return Client.ClientFullName; }
        }
        public string ClientFName { get; set; }
        public string ClientLName { get; set; }

        public int ArtistID { get; set; }
        public ArtistDetail Artist { get; set; }
        public string ArtistFullName
        {
            get { return Artist.ArtistFullName; }
        }
        public string ArtistFName { get; set; }
        public string ArtistLName { get; set; }
    }
}
