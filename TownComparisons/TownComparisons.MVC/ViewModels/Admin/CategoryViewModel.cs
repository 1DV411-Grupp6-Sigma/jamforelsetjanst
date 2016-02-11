using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<PropertyQueryViewModel> Queries { get; set; }
        public List<OrganisationalUnitViewModel> OrganisationalUnits { get; set; }


        public CategoryViewModel()
        {
            //Empty
        }
        public CategoryViewModel(Category entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Queries = entity.Queries.Select(q => new PropertyQueryViewModel(q, true)).ToList();
            OrganisationalUnits = entity.OrganisationalUnits.Select(o => new OrganisationalUnitViewModel(o)).ToList();
        }
    }
}