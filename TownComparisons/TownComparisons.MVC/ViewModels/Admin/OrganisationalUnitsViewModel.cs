using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class OrganisationalUnitsViewModel
    {
        public List<OrganisationalUnitViewModel> GroupOrganisationalUnits { get; set; }

        public OrganisationalUnitsViewModel()
        {
            //Empty
        }
        public OrganisationalUnitsViewModel(ICollection<CategoryOrganisationalUnit> groupOrganisationalUnits)
        {
            GroupOrganisationalUnits = groupOrganisationalUnits.Select(g => new OrganisationalUnitViewModel(g)).ToList();
        }

        public OrganisationalUnitsViewModel(List<OrganisationalUnit> groupOrganisationalUnits)
        {
            GroupOrganisationalUnits = groupOrganisationalUnits.Select(g => new OrganisationalUnitViewModel(g)).ToList();
        }
    }
}