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
using TownComparisons.MVC.Filters;
using System.IO;

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
        [ValidateModel] //this will handle validation (and return with errors) before method is run
        public HttpResponseMessage SaveCategory(HttpRequestMessage request, [FromBody]CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {

                category = category;


                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                //should not happen

                category = category;
            }


            return new HttpResponseMessage(HttpStatusCode.BadRequest);

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


        [HttpPost]
        [Route("admin/category/{categoryId}/operator/{organisationalUnitId}/image")]
        public HttpResponseMessage UploadOrganisationalUnitImage(HttpRequestMessage request, int categoryId, string organisationalUnitId) //, HttpPostedFileBase imageFile)
        {
            OrganisationalUnitInfo ou = _service.GetOrganisationalUnitInfo(categoryId, organisationalUnitId);
            if (ou != null)
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                if (file != null && file.ContentLength > 0)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filename = "";
                    var path = "";
                    while (path == "" || System.IO.File.Exists(path))
                    {
                        filename = Guid.NewGuid() + "." + fileExtension;
                        path = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/operator_images"),
                                                filename);

                    }

                    try
                    {
                        file.SaveAs(path);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(null, "Kunde inte spara bilden.");
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                    }

                    ou.ImagePath = filename;
                    _service.UpdateOrganisationalUnitInfo(ou);

                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("admin/category/{categoryId}/operator/{organisationalUnitId}")]
        [ValidateModel] //this will handle validation (and return with errors) before method is run
        public HttpResponseMessage SaveCategoryOrganisationalUnit(HttpRequestMessage request, int categoryId, string organisationalUnitId, [FromBody]OrganisationalUnitInfoEditViewModel organisationalUnit, HttpPostedFileBase imageFile)
        {
            Category category = _service.GetCategory(categoryId);
            if (category != null)
            {
                if (imageFile != null)
                {

                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                //should not happen

                category = category;
            }


            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

    }
}
