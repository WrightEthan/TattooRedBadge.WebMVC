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
                                    ArtistFName = e.ArtistFName,
                                    ArtistLName = e.ArtistLName
                                }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ArtistList> GetArtistNames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Artists
                    .Select(
                    e =>
                    new ArtistList
                    {
                        ArtistID = e.ArtistID,
                        ArtistFullName = e.ArtistFName + " " + e.ArtistLName
                    }
            );
                return query.ToArray();
            }
        }

        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    OwnerId = _userId,
                    ArtistID = model.ArtistID,
                    ArtistFName = model.ArtistFName,
                    ArtistLName = model.ArtistLName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
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
                        ArtistFName = entity.ArtistFName,
                        ArtistLName = entity.ArtistLName
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

                entity.ArtistFName = model.ArtistFName;
                entity.ArtistLName = model.ArtistLName;

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
