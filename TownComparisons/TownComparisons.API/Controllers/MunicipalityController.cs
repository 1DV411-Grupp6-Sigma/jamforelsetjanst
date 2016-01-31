using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;

namespace TownComparisons.API.Controllers
{
    public class MunicipalityController : ApiController
    {
        private ITownWebService _service;

        public MunicipalityController(ITownWebService service)
        {
            _service = service;
        }

        public HttpResponseMessage Get([FromUri]Model model)
        {
            if (model.Category > 0)
            {
                Municipality municipality = null; // = _service.Nånting
                Category category = null; // = _service.Nånting
                List<OperationalUnit> operators = _service.GetTownOperators(municipality, category);

                //create response
                // Kanske en view model istället för modellklassen Operator här:
                var response = Request.CreateResponse<IEnumerable<OperationalUnit>>(HttpStatusCode.OK, operators);
                return response;
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public class Model
        {
            // parametrar här (exempel):
            public int Category { get; set; }
        }
    }
}
