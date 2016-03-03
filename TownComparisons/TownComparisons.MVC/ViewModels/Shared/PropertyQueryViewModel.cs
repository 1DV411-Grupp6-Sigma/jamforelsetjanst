using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class PropertyQueryViewModel
    {
        public string WebServiceName { get; set; }

        public string QueryId { get; set; } // Kpi id if using Kolada

        public string Title { get; set; } // name/title of the query


        public PropertyQueryViewModel()
        {
            //Empty
        }
        public PropertyQueryViewModel(PropertyQuery model)
        {
            WebServiceName = model.WebServiceName;
            QueryId = model.QueryId;
            Title = model.Title;
        }
    }
}