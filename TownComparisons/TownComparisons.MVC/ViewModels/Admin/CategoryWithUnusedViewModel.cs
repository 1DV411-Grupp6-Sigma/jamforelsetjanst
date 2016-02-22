using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;
using TownComparisons.MVC.ViewModels.Shared;

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

            foreach (OrganisationalUnitViewModel ou in AllOrganisationalUnits)
            {
                ou.Use = (Category.OrganisationalUnits.Find(cou => cou.OrganisationalUnitId == ou.OrganisationalUnitId) != null);
            }
            foreach (PropertyQueryGroupViewModel qg in AllPropertyQueryGroups)
            {
                foreach (PropertyQueryViewModel q in qg.Queries)
                {
                    q.Use = (Category.Queries.Find(cq => cq.WebServiceName == q.WebServiceName && cq.QueryId == q.QueryId) != null);
                }
            }
        }
    }
}