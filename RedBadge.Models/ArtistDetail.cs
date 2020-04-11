using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class ArtistDetail
    {
        [Key]
        [Required]
        public int ArtistID { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        public string ArtistFullName
        {
            get { return FName + " " + LName; }
        }

    }
}
