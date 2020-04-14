using Microsoft.AspNet.Identity;
using RedBadge.Models;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateArtistService();

            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Your personal information was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your personal information was not properly saved.");
            return View(model);
        }
        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            return service;
        }

        public ActionResult Details(int ID)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistById(ID);

            return View(model);
        }

        public ActionResult Delete(int ID)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistById(ID);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int ID)
        {
            var service = CreateArtistService();

            service.DeleteArtist(ID);

            TempData["SaveResult"] = "Your personal information was deleted.";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            var service = CreateArtistService();
            var detail = service.GetArtistById(ID);
            var model =
                new ArtistEdit
                {
                    ArtistID = detail.ArtistID,
                    ArtistFName = detail.ArtistFName,
                    ArtistLName = detail.ArtistLName,
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID, ArtistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtistID != ID)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateArtistService();

            if (service.UpdateArtist(model))
            {
                TempData["SaveResult"] = "Your personal information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your personal information could not be updated");
            return View(model);
        }

    }
}