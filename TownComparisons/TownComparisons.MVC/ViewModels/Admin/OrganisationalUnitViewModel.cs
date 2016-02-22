using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class OrganisationalUnitViewModel : Shared.OrganisationalUnitViewModel
    {
        public bool Use { get; set; }

        //.. more properties from Shared.OrganisationalUnitViewModel


        public OrganisationalUnitViewModel()
        {
            //Empty
        }
        public OrganisationalUnitViewModel(OrganisationalUnit model, bool use = false)
        {
            OrganisationalUnitId = model.OrganisationalUnitId;
            Name = model.Name;

            Use = use;
        }
    }
}