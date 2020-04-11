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
    [Authorize]
    public class TattooController : Controller
    {
        [Authorize]
        // GET: Tattoo
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TattooService(userId);
            var model = service.GetTattoos();

            return View(model);
        }

        public ActionResult Create()
        {
            //create client service and getClientsForUser assign it to a var listOfClients
            //ViewBag = SelectList(listOfCLients,ClientID,ClientName)
            return View();
        }
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TattooCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            
            var service = CreateTattooService();

            if (service.CreateTattoo(model))
            {
                TempData["SaveResult"] = "Your appointment was made.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Appointment could not be made.");
            return View(model);
        }
        public ActionResult Details(int ID)
        {
            var svc = CreateTattooService();
            var model = svc.GetTattooById(ID);

            return View(model);
        }

        public ActionResult Edit(int ID)
        {
            var service = CreateTattooService();
            var detail = service.GetTattooById(ID);
            var model =
                new TattooEdit
                {
                    TattooID = detail.TattooID,
                    Location = detail.Location,
                    Description = detail.Description,
                    BlackAndWhite = detail.BlackAndWhite,
                    DateAndTime = detail.DateAndTime
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID, TattooEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TattooID != ID)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateTattooService();

            if (service.UpdateTattoo(model))
            {
                TempData["SaveResult"] = "Your appointment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your appointment could not be updated");
            return View(model);
        }


        private TattooService CreateTattooService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TattooService(userId);
            return service;
        }

        public ActionResult Delete(int ID)
        {
            var svc = CreateTattooService();
            var model = svc.GetTattooById(ID);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int ID)
        {
            var service = CreateTattooService();

            service.DeleteTattoo(ID);

            TempData["SaveResult"] = "Your appointment was cancelled.";

            return RedirectToAction("Index");
        }

    }
}