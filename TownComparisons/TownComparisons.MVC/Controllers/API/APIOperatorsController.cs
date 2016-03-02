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

namespace TownComparisons.MVC.Controllers.API
{
    [RoutePrefix("api")]
    public class APIOperatorsController : ApiController
    {
        private IService _service;

        public APIOperatorsController()
            : this (new Service())
        { }
        public APIOperatorsController(IService service)
        {
            _service = service;
        }

        /*
        [HttpGet]
        [Route("operators/{operatorId}")]
        public HttpResponseMessage GetOperator(HttpRequestMessage request, string operatorId)
        {
            OrganisationalUnitInfo ou = _service.GetOrganisationalUnitInfo(operatorId);
            if (ou != null)
            {
                OrganisationalUnitInfoViewModel model = new OrganisationalUnitInfoViewModel(ou);
                return request.CreateResponse<OrganisationalUnitInfoViewModel>(HttpStatusCode.OK, model);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        */

        [HttpGet]
        [Route("operators_in_category/{categoryId}")]
        public HttpResponseMessage GetOperatorsInCategory(HttpRequestMessage request, int categoryId)
        {
            Category category = _service.GetCategory(categoryId);
            if (category != null)
            {
                OrganisationalUnitsViewModel model = new OrganisationalUnitsViewModel(category.OrganisationalUnits.ToList());
                return request.CreateResponse<OrganisationalUnitInfoViewModel[]>(HttpStatusCode.OK, model.OrganisationalUnits.ToArray());
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
