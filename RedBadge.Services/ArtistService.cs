using RedBadge.Data;
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
            var entity =
                new Artist()
                {
                    OwnerId = _userId,
                    ArtistID = model.ArtistID,
                    FName = model.FName,
                    LName = model.LName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artists
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ArtistListItem
                                {
                                    ArtistID = e.ArtistID,
                                    FName = e.FName,
                                    LName = e.LName
                                }
                        );
                return query.ToArray();
            }
        }

        public ArtistDetail GetArtistById(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistID == ID && e.OwnerId == _userId);
                return
                    new ArtistDetail
                    {
                        ArtistID = entity.ArtistID,
                        OwnerId = _userId,
                        FName = entity.FName,
                        LName = entity.LName
                    };
            }
        }

        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Artists
                    .Single(e => e.ArtistID == model.ArtistID && e.OwnerId == _userId);

                entity.FName = model.FName;
                entity.LName = model.LName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.ArtistID == ID && e.OwnerId == _userId);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
