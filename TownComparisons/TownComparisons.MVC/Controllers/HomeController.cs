using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownComparisons.Domain;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.MVC.Controllers
{
    public class HomeController : Controller
    {
        /*
        private IService _service;

        public HomeController()
            : this(new Service())
        {
            //Empty
        }
        public HomeController(IService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            // Just to get the database initializer runned
            List<OrganisationalUnitInfo> ouInfos = _service.GetOrganisationalUnitInfos();

            return View();
        }

      
        // Returns information about one organisational unit by kolada api id
        public ActionResult Operator(string ouId)
        {
            OrganisationalUnitInfo activeOU = new OrganisationalUnitInfo();
            List<OrganisationalUnitInfo> ouInfos = _service.GetOrganisationalUnitInfos();


            activeOU.OrganisationalUnitId = ouId;
            ViewBag.Ounit = _service.GetOrganisationalUnit(ouId);
            return View();
        }

        public ActionResult Category(int id)
        {
            // [Temporary]
            // Adds a temporary Category and Municipality. (The municipality should be fetched from "Settings.cs".)
            Category activeCategory = new Category();
            activeCategory.Id = id;
            activeCategory.Name = "Grundskola";
            //Municipality activeMunicipality = new Municipality("1290", String.Empty, String.Empty);

            // ViewBags for the View.
            ViewBag.OUnits = _service.GetOrganisationalUnitsByCategory(activeCategory);

            return View();
        }

        public ActionResult AddOrganisationalUnit(string id)
        {
            SessionHandler session = new SessionHandler();
            // Gets a Organisational Units-list from a Session.
            // If there is no Session, a new list is created.
            List<string> organisationalUnitsV15 = (List<string>)session.GetSession("ComparisonV15") ?? new List<string>();
            List<string> organisationalUnitsV17 = (List<string>)session.GetSession("ComparisonV17") ?? new List<string>();

            // Checks if the new added Organisational Unit-ID is already in the list.
            bool alreadyInList = false;
            if (id.Substring(0, 3) == "V15")
            {
                foreach (string ouID in organisationalUnitsV15)
                {
                    if (ouID == id)
                    {
                        alreadyInList = true;
                    }
                }

                // Adds a new Organisational Unit-ID to the list if it not yet exits.
                if (!alreadyInList)
                {
                    organisationalUnitsV15.Add(id);
                }
            }
            else if (id.Substring(0, 3) == "V17")
            {
                foreach (string ouID in organisationalUnitsV17)
                {
                    if (ouID == id)
                    {
                        alreadyInList = true;
                    }
                }

                // Adds a new Organisational Unit-ID to the list if it not yet exits.
                if (!alreadyInList)
                {
                    organisationalUnitsV17.Add(id);
                }
            }

            // Adds Organisational Units to a list by IDs.
            List<OrganisationalUnit> ouListV15 = new List<OrganisationalUnit>();
            List<OrganisationalUnit> ouListV17 = new List<OrganisationalUnit>();

            foreach (string ou in organisationalUnitsV15)
            {
                ouListV15.Add(_service.GetOrganisationalUnit(ou));
            }
            foreach (string ou in organisationalUnitsV17)
            {
                ouListV17.Add(_service.GetOrganisationalUnit(ou));
            }

            // Adds the list to the Session.
            session.AddSession("ComparisonV15", organisationalUnitsV15);
            session.AddSession("ComparisonV17", organisationalUnitsV17);

            // ViewBags for the View.
            ViewBag.AddedOU = _service.GetOrganisationalUnit(id);
            ViewBag.ComparisionV15 = ouListV15;
            ViewBag.ComparisionV17 = ouListV17;

            return View();
        }

        public ActionResult Compare(int id)
        {
            // Gets a Organisational Units-list (IDs) from a Session.
            // If there is no Session, a new list is created.
            string category = "";
            if (id == 1)
            {
                category = "ComparisonV15";
            }
            else if (id == 2)
            {
                category = "ComparisonV17";
            }
            List<string> organisationalUnits = (List<string>)Session[category] ?? new List<string>();

            // Gets all Organisational Units from the list with IDs.
            List<OrganisationalUnit> ouList = new List<OrganisationalUnit>();
            foreach (string ou in organisationalUnits)
            {
                ouList.Add(_service.GetOrganisationalUnit(ou));
            }

            // Creates a Category by ID. (Should be in Settings-file.)
            Category tempCategory = new Category();
            tempCategory.Id = id;
            if (id == 1)
            {
                tempCategory.Name = "Grundskola";
            }
            else if (id == 2)
            {
                tempCategory.Name = "Gymnasieskola";
            }

            // Gets KpiGroups by choosen Category.
            List<KpiGroup> kpiList = _service.TempGetKpiGroupByCategory(tempCategory);

            // Adds all KpiQuestions from the KpiGroup-list to a KpiQuestion-list.
            List<KpiQuestion> kpiQuestions = new List<KpiQuestion>();
            foreach (KpiGroup kg in kpiList)
            {
                foreach (KpiQuestion kq in kg.Members)
                {
                    kpiQuestions.Add(kq);
                }
            }

            // Gets KpiAnswers from KpiQuestions and Organisational Units.
            List<KpiAnswer> kpiAnswerList = _service.GetKpiAnswersByKpiQuestionAndOrganisationalUnit(kpiQuestions, ouList);

            // Reverses the KpiAnswer-list, so that the newest values (period eg. 2014) is shown first.
            IEnumerable<KpiAnswer> revList = kpiAnswerList;
            revList = revList.Reverse();
            List<KpiAnswer> retList = revList.ToList<KpiAnswer>();

            // ViewBags for the View.
            ViewBag.Comparision = ouList;
            ViewBag.KpiList = kpiList;
            ViewBag.KpiAnswerList = retList;

            return View();
        }

        public ActionResult Test()
        {
            List<KpiGroup> allKpiGroups = new List<KpiGroup>(); //_service.GetAllKpiGroups();
            ViewBag.allKpiGroups = allKpiGroups;
            return View();
        }
        */
    }
}