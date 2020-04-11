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
    public class ClientController : Controller
    {
        [Authorize]
        // GET: Client
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            var model = service.GetClients();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "Your personal information was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your personal information was not properly saved.");
            return View(model);
        }

        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }

        public ActionResult Details(int ID)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(ID);

            return View(model);
        }

        public ActionResult Delete(int ID)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(ID);

            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int ID)
        {
            var service = CreateClientService();

            service.DeleteClient(ID);

            TempData["SaveResult"] = "Your personal information was deleted.";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {
            var service = CreateClientService();
            var detail = service.GetClientById(ID);
            var model =
                new ClientEdit
                {
                    ClientID = detail.ClientID,
                    FName = detail.FName,
                    LName = detail.LName,
                    PhoneNumber = detail.PhoneNumber,
                    Email = detail.Email
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClientID != ID)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "Your personal information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your personal information could not be updated");
            return View(model);
        }

    }
}