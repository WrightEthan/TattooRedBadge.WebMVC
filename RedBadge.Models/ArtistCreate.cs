using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class ArtistCreate
    {
        [Key]
        [Required]
        public int ArtistID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string ArtistFName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string ArtistLName { get; set; }

        [Required]
        public string ArtistFullName
        {
            get { return ArtistFName + " " + ArtistLName; }
        }
    }
}