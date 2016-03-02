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
using TownComparisons.MVC.ModelBinders;
using TownComparisons.MVC.ViewModels.Shared;

namespace TownComparisons.MVC.Controllers.API
{
    [RoutePrefix("api")]
    public class APICategoriesController : ApiController
    {
        private IService _service;

        public APICategoriesController()
            : this (new Service())
        { }
        public APICategoriesController(IService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("categories")]
        public HttpResponseMessage GetCategories(HttpRequestMessage request)
        {
            var categories = _service.GetAllCategories();
            //Category OrganisationalUnits
            CategoriesViewModel model = new CategoriesViewModel(categories);
            return request.CreateResponse<GroupCategoryViewModel[]>(HttpStatusCode.OK, model.GroupCategories.ToArray());
        }


        [HttpGet]
        [Route("categories/alphabet")]
        public HttpResponseMessage GetCategoriesBasedOnAlphabet(HttpRequestMessage request)
        {
            var categories = _service.GetAllCategoriesBasedOnAlphabet();
            AlphabetViewModel model = new AlphabetViewModel(categories);
            return request.CreateResponse<CategoryViewModel[]>(HttpStatusCode.OK, model.Categories.ToArray());
           
        }

        [HttpGet]
        [Route("category/{categoryId}/properties")]
        public HttpResponseMessage GetCategoryProperyResults(HttpRequestMessage request, int categoryId, [CommaDelimitedArrayModelBinder]string[] operators)
        {
            Category category = _service.GetCategory(categoryId);
            if (category != null)
            {
                List<OrganisationalUnitInfo> organisationalUnitsToCompare = category.OrganisationalUnits.Where(o => operators.Contains(o.OrganisationalUnitId)).ToList();
                if (organisationalUnitsToCompare.Count > 0)
                {
                    List<PropertyResult> results = _service.GetWebServicePropertyResults(category, organisationalUnitsToCompare);
                    CategoryPropertyResults model = new CategoryPropertyResults(results);
                    return request.CreateResponse<PropertyResultViewModel[]>(HttpStatusCode.OK, model.Results.ToArray());
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public HttpResponseMessage GetCategory(HttpRequestMessage request, int categoryId)
        {
            Category category = _service.GetCategory(categoryId);
            if (category != null)
            {
                CategoryViewModel model = new CategoryViewModel(category);
                return request.CreateResponse<CategoryViewModel>(HttpStatusCode.OK, model);
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }


    }
}
