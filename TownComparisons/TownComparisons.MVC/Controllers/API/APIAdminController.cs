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
using TownComparisons.MVC.ViewModels.Admin;
using TownComparisons.MVC.ViewModels.OrganisationalUnitInfo;

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


        [HttpGet]
        [Route("admin/categories")]
        public HttpResponseMessage GetCategories(HttpRequestMessage request)
        {
            var categories = _service.GetAllCategories();
            CategoriesViewModel model = new CategoriesViewModel(categories);
            return request.CreateResponse<GroupCategoryViewModel[]>(HttpStatusCode.OK, model.GroupCategories.ToArray());
        }

        [HttpGet]
        [Route("admin/category/{categoryId}")]
        public HttpResponseMessage GetCategory(HttpRequestMessage request, int categoryId)
        {
            Category category = _service.GetCategory(categoryId);
            if (category != null)
            {
                List<OrganisationalUnit> allOrganisationalUnits = _service.GetAllOrganisationalUnits();
                List<PropertyQueryGroup> allPropertyQueryGroups = _service.GetAllPropertyQueries();
                CategoryWithUnusedViewModel model = new CategoryWithUnusedViewModel(category, allOrganisationalUnits, allPropertyQueryGroups);
                return request.CreateResponse<CategoryWithUnusedViewModel>(HttpStatusCode.OK, model);
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        //Get specific organisational unit info
        [HttpGet]
        [Route("operator/{operatorId}")]
        public HttpResponseMessage GetOrganisationalUnitInfo(HttpRequestMessage request, string ouId)
        {
            var operatorInfos = _service.GetOrganisationalUnitInfos();
            var operatorInfo = operatorInfos.FirstOrDefault(item => item.OrganisationalUnitId == ouId); //"operator" is reserved word
            OrganisationalUnitInfoViewModel model = new OrganisationalUnitInfoViewModel(operatorInfo);
            return request.CreateResponse<OrganisationalUnitInfoViewModel>(HttpStatusCode.OK, model);
        }

        [HttpGet]
        [Route("admin/allOU/{categoryId}")]
        public HttpResponseMessage GetStartCategories(HttpRequestMessage request, int categoryId)
        {
            // DEN HÄR RADEN KOMMER ANVÄNDAS!
            //// var ous = _service.GetCategory(categoryId).OrganisationalUnits;

            // Blocket nedan är temporärt, i brist på info i databas.
            // ---------------------------------------------------
            var ous = _service.GetAllOrganisationalUnits();
            List<OrganisationalUnit> ousFiltered;
            if (categoryId == 1)
            {
                ousFiltered = ous.Where(ou => ou.OrganisationalUnitId.Substring(0, 3) == "V15").ToList();
            }
            else if (categoryId == 2)
            {
                ousFiltered = ous.Where(ou => ou.OrganisationalUnitId.Substring(0, 3) == "V17").ToList();
            }
            else
            {
                throw new ArgumentException("Finns ingen sådan kategori.");
            }
            // ---------------------------------------------------

            OrganisationalUnitsViewModel model = new OrganisationalUnitsViewModel(ousFiltered);
            return request.CreateResponse<OrganisationalUnitViewModel[]>(HttpStatusCode.OK, model.GroupOrganisationalUnits.ToArray());
        }
    }
}
