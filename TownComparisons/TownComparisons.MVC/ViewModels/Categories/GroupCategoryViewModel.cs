using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.ViewModels.Categories
{
    public class GroupCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        public GroupCategoryViewModel()
        {
            //Empty
        }
        public GroupCategoryViewModel(GroupCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Categories = entity.Categories.Select(c => new CategoryViewModel(c)).ToList();
        }
    }
}