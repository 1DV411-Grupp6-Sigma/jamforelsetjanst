using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class CategoryWithUnusedViewModel
    {
        public CategoryViewModel Category { get; set; }

        public List<OrganisationalUnitViewModel> AllOrganisationalUnits { get; set; }
        public List<PropertyQueryGroupViewModel> AllPropertyQueryGroups { get; set; }

        public CategoryWithUnusedViewModel()
        {
            AllOrganisationalUnits = new List<OrganisationalUnitViewModel>();
            AllPropertyQueryGroups = new List<PropertyQueryGroupViewModel>();
        }
        public CategoryWithUnusedViewModel(Category category, List<OrganisationalUnit> allOrganisationalUnits, List<PropertyQueryGroup> allPropertyQueryGroups)
        {
            Category = new CategoryViewModel(category);
            AllOrganisationalUnits = allOrganisationalUnits.Select(o => new OrganisationalUnitViewModel(o)).ToList();
            AllPropertyQueryGroups = allPropertyQueryGroups.Select(p => new PropertyQueryGroupViewModel(p)).ToList();
        }
    }
}