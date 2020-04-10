using RedBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TattooRedBadge.WebMVC.Controllers
{
    public class ArtistController : Controller
    {
        [Authorize]
        // GET: Artist
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            var model = service.GetArtists();

            return View(model);
        }
    }
}