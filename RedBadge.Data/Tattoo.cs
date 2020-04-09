﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RedBadge.Data
{
    public class Tattoo
    {
        [Key]
        public int TattooID { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        
        //[ForeignKey(nameof(Artist))]
        //public string ArtistFullName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool BlackAndWhite { get; set; }
        //public image
        public DateTime DateAndTime { get; set; }

        [ForeignKey("Client")]
        public int? ClientID { get; set; }

        public virtual Client Client { get; set; }
    }
}