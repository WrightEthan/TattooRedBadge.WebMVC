using RedBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooRedBadge.WebMVC.Data;

namespace RedBadge.Services
{
    public class ArtistService
    {
        private readonly Guid _userId;

        public ArtistService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateArtist(ArtistCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    new Artist()
                    {
                        OwnerId = _userId,
                        ArtistID = model.AristID == 0 ? null : model.ArtistID,

                    }
            }
        }
    }
}
