using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.Views.Admin.Categories
{
    public class GroupCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        public GroupCategoryViewModel(GroupCategory groupCategory)
        {
            Id = groupCategory.Id;
            Name = groupCategory.Name;
            Categories = groupCategory.Categories.Select(c => new CategoryViewModel(c)).ToList();
        }
    }
}