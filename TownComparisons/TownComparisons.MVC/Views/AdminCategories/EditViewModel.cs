using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.MVC.Views.Admin.Categories;

namespace TownComparisons.MVC.Views.AdminCategories
{
	public class EditViewModel
	{
        public CategoryViewModel Category { get; set; }

        public List<KpiGroup> KpiGroups { get; set; }


        public EditViewModel(Category category)
        {
            Category = new CategoryViewModel(category);
        }
	}
}