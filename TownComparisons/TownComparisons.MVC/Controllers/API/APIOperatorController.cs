using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TownComparisons.Domain;
using TownComparisons.Domain.Abstract;
using TownComparisons.MVC.ViewModels.OrganisationalUnitInfo;

namespace TownComparisons.MVC.Controllers.API
{
    [RoutePrefix("api")]
    public class APIOperatorController : Controller
    {
        private IService _service;

        public APIOperatorController()
            : this (new Service())
        { }
        public APIOperatorController(IService service)
        {
            _service = service;
        }
        // GET: APIOperator
        public ActionResult Index()
        {
            return View();
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
    }
}