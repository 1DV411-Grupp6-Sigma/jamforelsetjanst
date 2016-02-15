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
using TownComparisons.MVC.ViewModels.Categories;

namespace TownComparisons.MVC.Controllers.API
{
    [RoutePrefix("api")]
    public class APIHomeController : ApiController
    {
        private IService _service;

        public APIHomeController()
            : this(new Service())
        { }
        public APIHomeController(IService service)
        {
            _service = service;
        }

        //Get all groupCategories and the categories inside each group
        [HttpGet]
        [Route("home/categories")]
        public HttpResponseMessage GetCategories(HttpRequestMessage request)
        {
            var categories = _service.GetAllCategories();
            CategoriesViewModel model = new CategoriesViewModel(categories);
            return request.CreateResponse<GroupCategoryViewModel[]>(HttpStatusCode.OK, model.GroupCategories.ToArray());
        }
    }
}