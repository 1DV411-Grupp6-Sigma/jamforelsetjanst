using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class OrganisationalUnitViewModel
    {
        public string WebServiceName { get; set; }

        public string OrganisationalUnitId { get; set; } // Kpi id if using Kolada

        public string Name { get; set; } // name/title of the query


        public OrganisationalUnitViewModel()
        {
            //Empty
        }
        public OrganisationalUnitViewModel(OrganisationalUnit model)
        {
            WebServiceName = model.WebServiceName;
            OrganisationalUnitId = model.OrganisationalUnitId;
            Name = model.Name;
        }
    }
}