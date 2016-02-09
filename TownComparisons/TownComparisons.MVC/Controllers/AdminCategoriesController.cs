using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TownComparisons.Domain;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;
using TownComparisons.MVC.Views.AdminCategories;

namespace TownComparisons.MVC.Controllers
{
    public class AdminCategoriesController : Controller
    {
        private IService _service;

        //Constructors
        public AdminCategoriesController()
            : this(new Service())
        {
            //Empty
        }
        public AdminCategoriesController(IService service)
        {
            _service = service;
        }


        // GET: AdminCategories
        public ActionResult Index()
        {
            List<GroupCategory> groupCategories = _service.GetAllCategories();
            IndexViewModel model = new IndexViewModel(groupCategories);
            return View(model);
        }

        // GET: AdminCategories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCategories/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCategories/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _service.GetCategory(id);
            if (category != null)
            {
                List<OrganisationalUnit> allOrganisationalUnits = _service.GetAllOrganisationalUnits();
                List<PropertyQueryGroup> allPropertyQueryGroups = _service.GetAllPropertyQueries();
                EditViewModel model = new EditViewModel(category, allOrganisationalUnits, allPropertyQueryGroups);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: AdminCategories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCategories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminCategories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
