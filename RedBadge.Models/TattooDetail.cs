using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class TattooDetail
    {
        public int TattooID { get; set; }

        public Guid OwnerId { get; set; }

        public int ClientID { get; set; }

        public int ArtistID { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public bool BlackAndWhite { get; set; }
        //public image
        public DateTime DateAndTime { get; set; }

    }
}
