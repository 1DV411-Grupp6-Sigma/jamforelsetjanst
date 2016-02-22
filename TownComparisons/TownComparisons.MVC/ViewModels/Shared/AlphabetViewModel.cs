using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class AlphabetViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }

        public AlphabetViewModel()
        {
            //Empty
        }
        public AlphabetViewModel(List<Category> groupCategories)
        {
            Categories = groupCategories.Select(c => new CategoryViewModel(c)).ToList();
        }
    }
}