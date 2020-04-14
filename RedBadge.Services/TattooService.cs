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
    public class TattooService
    {
        private readonly Guid _userId;

        public TattooService(Guid userId)
        {
            _userId = userId;
        }



        public bool CreateTattoo(TattooCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    new Tattoo()
                    {
                        OwnerId = _userId,
                        ClientID = model.ClientID,
                        Location = model.Location,
                        Description = model.Description,
                        BlackAndWhite = model.BlackAndWhite,
                        DateAndTime = model.DateAndTime,
                    };

                ctx.Tattoos.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<TattooListItem> GetTattoos()
        {
            var clientService = new ClientService(_userId);
            using (var ctx = new ApplicationDbContext())
            {
                var clientDetail = new ClientDetail();
                var query =
                    ctx
                        .Tattoos
                        .Where(e => e.OwnerId == _userId).ToArray()
                        .Select(
                            e =>
                                new TattooListItem
                                {
                                    TattooID = e.TattooID,
                                    // ClientID = e.ClientID, // Client = A method that takes in a Client, assigns values to properties in a new ClientListItem, return that ClientListItem
                                    Client = clientService.GetClientById(e.ClientID),
                                    Location = e.Location,
                                    Description = e.Description,
                                    BlackAndWhite = e.BlackAndWhite,
                                    DateAndTime = e.DateAndTime,
                                }
                        );  
                return query;//.ToArray();
            }

        }

        //private ClientListItem ConvertClientToListItem (Client){}
        public TattooDetail GetTattooById(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Tattoos
                    .Single(e => e.TattooID == ID && e.OwnerId == _userId);
                return
                    new TattooDetail
                    {
                        OwnerId = entity.OwnerId,
                        TattooID = entity.TattooID,
                        ClientID = entity.ClientID,
                        Location = entity.Location,
                        Description = entity.Description,
                        BlackAndWhite = entity.BlackAndWhite,
                        DateAndTime = entity.DateAndTime
                    };
            }

        }
        public bool UpdateTattoo(TattooEdit model)
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var entity = ctx
                        .Tattoos
                        .Single(e => e.TattooID == model.TattooID && e.OwnerId == _userId);
                entity.ClientID = model.ClientID;
                entity.Location = model.Location;
                entity.Description = model.Description;
                entity.BlackAndWhite = model.BlackAndWhite;
                entity.DateAndTime = model.DateAndTime;

                return ctx.SaveChanges() == 1;
                }
            }

        public IEnumerable<ClientList> GetClientNames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Clients
                    .Select(
                    e =>
                    new ClientList
                    {
                        ClientID = e.ClientID,
                    }
            );
                return query.ToArray();
            }
        }

            public bool DeleteTattoo(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Tattoos
                    .Single(e => e.TattooID == ID && e.OwnerId == _userId);

                ctx.Tattoos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}