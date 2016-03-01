using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TownComparisons.Domain;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;
using TownComparisons.MVC.ViewModels.Shared;
using TownComparisons.MVC.ViewModels.Admin;

namespace TownComparisons.MVC.Controllers.API
{
    [RoutePrefix("api")]
    public class APIAdminController : ApiController
    {
        private IService _service;

        public APIAdminController()
            : this (new Service())
        { }
        public APIAdminController(IService service)
        {
            _service = service;
        }
        

        /* A special get category for admin pages, where all OU and Property queries also are included (not only the selected ones) */
        [HttpGet]
        [Route("admin/category/{categoryId}")]
        public HttpResponseMessage GetCategory(HttpRequestMessage request, int categoryId)
        {
            Category category = _service.GetCategory(categoryId);
            if (category != null)
            {
                List<OrganisationalUnit> allOrganisationalUnits = _service.GetWebServiceOrganisationalUnits();
                List<PropertyQueryGroup> allPropertyQueryGroups = _service.GetWebServicePropertyQueries();
                CategoryWithUnusedViewModel model = new CategoryWithUnusedViewModel(category, allOrganisationalUnits, allPropertyQueryGroups);
                return request.CreateResponse<CategoryWithUnusedViewModel>(HttpStatusCode.OK, model);
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        
        [HttpPost]
        [Route("admin/category/{categoryId}")]
        public HttpResponseMessage SaveCategory(HttpRequestMessage request, [FromBody]CategoryViewModel category)
        {
            category = category;
            return new HttpResponseMessage(HttpStatusCode.OK);
            /*
            Category category = _service.GetCategory(categoryId);
            if (category != null)
            {
                List<OrganisationalUnit> allOrganisationalUnits = _service.GetWebServiceOrganisationalUnits();
                List<PropertyQueryGroup> allPropertyQueryGroups = _service.GetWebServicePropertyQueries();
                CategoryWithUnusedViewModel model = new CategoryWithUnusedViewModel(category, allOrganisationalUnits, allPropertyQueryGroups);
                return request.CreateResponse<CategoryWithUnusedViewModel>(HttpStatusCode.OK, model);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
            */
        }

    }
}
