using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class OrganisationalUnitInfoEditViewModel : Shared.OrganisationalUnitInfoViewModel
    {
        //public HttpPostedFileBase ImageFile { get; set; }

        //.. more properties from Shared.OrganisationalUnitViewModel


        public OrganisationalUnitInfoEditViewModel()
        {
            //Empty
        }
        public OrganisationalUnitInfoEditViewModel(OrganisationalUnitInfo entity)
            : base(entity)
        { }
    }
}