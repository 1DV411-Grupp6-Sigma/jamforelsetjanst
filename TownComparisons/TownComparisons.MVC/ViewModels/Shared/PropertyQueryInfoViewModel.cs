using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class PropertyQueryInfoViewModel
    {
        public string WebServiceName { get; set; }

        public string QueryId { get; set; } // Kpi id if using Kolada

        public string Title { get; set; } // name/title of the query

        public string Type { get; set; }


        public PropertyQueryInfoViewModel()
        {
            //Empty
        }
        public PropertyQueryInfoViewModel(PropertyQuery model)
        {
            WebServiceName = model.WebServiceName;
            QueryId = model.QueryId;
            Title = model.Title;
            Type = model.Type;
        }
        public PropertyQueryInfoViewModel(PropertyQueryInfo entity)
        {
            WebServiceName = entity.WebServiceName;
            QueryId = entity.QueryId;
            Title = entity.Title;
            Type = entity.Type;
        }
    }
}