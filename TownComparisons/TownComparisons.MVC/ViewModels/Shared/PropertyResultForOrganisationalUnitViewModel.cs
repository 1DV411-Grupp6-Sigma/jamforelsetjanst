using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class PropertyResultForOrganisationalUnitViewModel
    {
        public string OrganisationalUnitId { get; set; }
        
        public List<PropertyResultViewModel> Results { get; set; }


        public PropertyResultForOrganisationalUnitViewModel()
        {
            //Empty
        }
        public PropertyResultForOrganisationalUnitViewModel(PropertyResultForOrganisationalUnit model)
        {
            OrganisationalUnitId = model.OrganisationalUnitId;
            Results = model.Results.Select(v => new PropertyResultViewModel(v)).ToList();
        }
    }
}