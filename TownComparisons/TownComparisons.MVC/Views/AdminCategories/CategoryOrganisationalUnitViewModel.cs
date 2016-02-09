using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.Views.AdminCategories
{
    public class CategoryOrganisationalUnitViewModel
    {
        public string WebServiceName { get; set; }

        public string OrganisationalUnitId { get; set; } // Kpi id if using Kolada

        public string Name { get; set; } // name/title of the query


        public CategoryOrganisationalUnitViewModel(CategoryOrganisationalUnit entity)
        {
            WebServiceName = entity.WebServiceName;
            OrganisationalUnitId = entity.OrganisationalUnitId;
            Name = entity.Name;
        }
    }
}