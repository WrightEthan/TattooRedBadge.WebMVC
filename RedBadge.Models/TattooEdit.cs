using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class TattooEdit
    {
        public int TattooID { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool BlackAndWhite { get; set; }
        public DateTime DateAndTime { get; set; }

    }
}
