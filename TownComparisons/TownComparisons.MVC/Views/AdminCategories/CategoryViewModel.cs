using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.Views.AdminCategories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<CategoryPropertyQueryViewModel> Queries { get; set; }
        public List<CategoryOrganisationalUnitViewModel> OrganisationalUnits { get; set; }

        public CategoryViewModel(Category entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Queries = entity.Queries.Select(q => new CategoryPropertyQueryViewModel(q)).ToList();
            OrganisationalUnits = entity.OrganisationalUnits.Select(o => new CategoryOrganisationalUnitViewModel(o)).ToList();
        }
    }
}