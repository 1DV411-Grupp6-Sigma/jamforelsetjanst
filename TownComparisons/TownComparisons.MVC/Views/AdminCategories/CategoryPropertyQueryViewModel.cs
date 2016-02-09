using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.Views.AdminCategories
{
    public class CategoryPropertyQueryViewModel
    {
        public string WebServiceName { get; set; }

        public string QueryId { get; set; } // Kpi id if using Kolada

        public string Title { get; set; } // name/title of the query


        public CategoryPropertyQueryViewModel(CategoryPropertyQuery entity)
        {
            WebServiceName = entity.WebServiceName;
            QueryId = entity.QueryId;
            Title = entity.Title;
        }
    }
}