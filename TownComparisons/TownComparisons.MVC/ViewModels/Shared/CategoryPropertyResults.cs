using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class CategoryPropertyResults
    {
        public List<PropertyResultForOrganisationalUnitViewModel> OrganisationalUnitResults { get; set; }
        

        public CategoryPropertyResults()
        {
            //Empty
        }
        public CategoryPropertyResults(List<PropertyResultForOrganisationalUnit> models)
        {
            OrganisationalUnitResults = models.Select(o => new PropertyResultForOrganisationalUnitViewModel(o)).ToList();
        }
    }
}