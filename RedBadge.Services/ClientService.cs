using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedBadge.Data;
using RedBadge.Models;
using TattooRedBadge.WebMVC.Data;

namespace RedBadge.Services
{
    public class ClientService
    {
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Clients
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ClientListItem
                        {
                            ClientID = e.ClientID,
                            OwnerId = _userId,
                            FName = e.FName,
                            LName = e.LName,
                            DOB = e.DOB,
                            PhoneNumber = e.PhoneNumber,
                            Email = e.Email
                        });
                return query.ToArray();
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
                        FName = e.FName
                    }
            );
                return query.ToArray();
            }
    }

        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    OwnerId = _userId,
                    ClientID = model.ClientID,
                    FName = model.FName,
                    LName = model.LName,
                    DOB = model.DOB,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public ClientDetail GetClientById(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.ClientID == ID && e.OwnerId == _userId);
                return
                    new ClientDetail
                    {
                        OwnerId = entity.OwnerId,
                        ClientID = entity.ClientID,
                        FName = entity.FName,
                        LName = entity.LName,
                        DOB = entity.DOB,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email
                    };
            }
        }
        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Clients
                    .Single(e => e.ClientID == model.ClientID && e.OwnerId == _userId);

                entity.FName = model.FName;
                entity.LName = model.LName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteClient(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.ClientID == ID && e.OwnerId == _userId);

                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
        
    }
}
