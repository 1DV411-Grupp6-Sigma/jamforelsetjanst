using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.Views.AdminCategories
{
	public class EditViewModel
	{
        public CategoryViewModel Category { get; set; }

        public List<OrganisationalUnitViewModel> AllOrganisationalUnits { get; set; }
        public List<PropertyQueryGroupViewModel> AllPropertyQueryGroups { get; set; }
        
        public EditViewModel()
        {
            AllOrganisationalUnits = new List<OrganisationalUnitViewModel>();
            AllPropertyQueryGroups = new List<PropertyQueryGroupViewModel>();
        }
        public EditViewModel(Category category, List<OrganisationalUnit> allOrganisationalUnits, List<PropertyQueryGroup> allPropertyQueryGroups)
        {
            Category = new CategoryViewModel(category);
            AllOrganisationalUnits = allOrganisationalUnits.Select(o => new OrganisationalUnitViewModel(o)).ToList();
            AllPropertyQueryGroups = allPropertyQueryGroups.Select(p => new PropertyQueryGroupViewModel(p)).ToList();
        }
	}
}