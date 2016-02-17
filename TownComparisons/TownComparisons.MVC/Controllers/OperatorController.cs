using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TownComparisons.MVC.Controllers
{
    public class OperatorController : Controller
    {
        // GET: Operator
        public ActionResult Index(string ouId)
        {
            return View();
        }
    }
}