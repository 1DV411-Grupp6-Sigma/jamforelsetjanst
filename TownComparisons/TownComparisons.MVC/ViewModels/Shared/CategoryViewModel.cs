using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namnet måste fyllas i")]
        [MaxLength(100, ErrorMessage = "Namnet kan inte vara längre än {1} tecken.")]
        [MinLength(4, ErrorMessage = "Namnet måste vara minst {1} tecken långt.")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Beskrivningen kan inte vara längre än {1} tecken.")]
        public string Description { get; set; }

        [Required]
        public List<PropertyQueryViewModel> Queries { get; set; }

        [Required]
        public List<OrganisationalUnitInfoViewModel> OrganisationalUnits { get; set; }


        public CategoryViewModel()
        {
            //Empty
        }
        public CategoryViewModel(Category entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Queries = entity.Queries.Select(q => new PropertyQueryViewModel(q)).ToList();
            OrganisationalUnits = entity.OrganisationalUnits.Select(o => new OrganisationalUnitInfoViewModel(o)).ToList();
        }
    }
}