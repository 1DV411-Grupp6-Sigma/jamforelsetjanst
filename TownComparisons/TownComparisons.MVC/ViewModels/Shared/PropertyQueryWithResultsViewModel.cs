using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class PropertyQueryWithResultsViewModel
    {
        public PropertyQueryViewModel Query { get; set; }
        
        public List<PropertyQueryResult> Results { get; set; }


        public PropertyQueryWithResultsViewModel()
        {
            //Empty
        }
        public PropertyQueryWithResultsViewModel(PropertyQueryWithResults model)
        {
            Query = new PropertyQueryViewModel(model.Query);
            Results = model.Results;
        }
    }
}