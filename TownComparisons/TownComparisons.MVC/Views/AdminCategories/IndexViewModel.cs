using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.Views.Admin.Categories
{
    public class IndexViewModel
    {
        public List<GroupCategoryViewModel> GroupCategories { get; set; }


        public IndexViewModel(List<GroupCategory> groupCategories)
        {
            GroupCategories = groupCategories.Select(g => new GroupCategoryViewModel(g)).ToList();
        }

    }
}