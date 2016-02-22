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
using TownComparisons.MVC.ViewModels.OrganisationalUnitInfo;

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

        [HttpGet]
        [Route("operators/{operatorId}")]
        public HttpResponseMessage GetOperator(HttpRequestMessage request, string operatorId)
        {
            //var operatorInfos = _service.GetOrganisationalUnitInfos();
            //var operatorInfo = operatorInfos.FirstOrDefault(item => item.OrganisationalUnitId == ouId); //"operator" is reserved word
            var operatorInfo = _service.GetOrganisationalUnitInfo(operatorId);
            OrganisationalUnitInfoViewModel model = new OrganisationalUnitInfoViewModel(operatorInfo);
            return request.CreateResponse<OrganisationalUnitInfoViewModel>(HttpStatusCode.OK, model);
        }

        [HttpGet]
        [Route("operators_in_category/{categoryId}")]
        public HttpResponseMessage GetOperatorsInCategory(HttpRequestMessage request, int categoryId)
        {
            // DEN HÄR RADEN KOMMER ANVÄNDAS!
            Category category = _service.GetCategory(categoryId);
            if (category != null)
            {
                var ous = category.OrganisationalUnits.ToList();

                OrganisationalUnitsViewModel model = new OrganisationalUnitsViewModel(ous);
                return request.CreateResponse<OrganisationalUnitViewModel[]>(HttpStatusCode.OK, model.OrganisationalUnits.ToArray());
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);

            // Blocket nedan är temporärt, i brist på info i databas.
            // ---------------------------------------------------
            /*
            var ous = _service.GetWebServiceOrganisationalUnits();
            List<OrganisationalUnitInfo> ousFiltered;
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
            */
            // ---------------------------------------------------
        }
    }
}
