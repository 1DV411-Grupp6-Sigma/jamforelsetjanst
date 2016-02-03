using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownComparisons.MVC.Views.Admin;

namespace TownComparisons.MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var model = new AdminIndexViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            var model = new AdminIndexViewModel();

            if (TryUpdateModel(model, new[] {"Municipality"}, collection))
            {
                return View(model);
            }
            
            ModelState.AddModelError("ErrorSaving", "Misslyckades att spara");
            
            return View();
        }
    }
}