using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class PropertyResultViewModel
    {
        public string QueryId { get; set; }
       
        public int Period { get; set; }

        public List<PropertyResultValueViewModel> Values { get; set; }


        public PropertyResultViewModel()
        {
            //Empty
        }
        public PropertyResultViewModel(PropertyResult model)
        {
            QueryId = model.QueryId;
            Period = model.Period;
            Values = model.Values.Select(v => new PropertyResultValueViewModel(v)).ToList();
        }
    }
}