using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class ArtistListItem
    {
        [Key]
        [Required]
        public int ArtistID { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string ArtistFName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string ArtistLName { get; set; }

        [Display(Name = "Artist Name")]
        [Required]
        public string ArtistFullName
        {
            get { return ArtistFName + " " + ArtistLName; }
        }

    }
}
