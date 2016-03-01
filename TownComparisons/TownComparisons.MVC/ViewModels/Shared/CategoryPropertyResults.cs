using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class CategoryPropertyResults
    {
        public List<PropertyResultViewModel> Results { get; set; }
        

        public CategoryPropertyResults()
        {
            //Empty
        }
        public CategoryPropertyResults(List<PropertyResult> models)
        {
            Results = models.Select(r => new PropertyResultViewModel(r)).ToList();
        }
    }
}