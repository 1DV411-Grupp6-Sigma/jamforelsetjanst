using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class PropertyQueryViewModel : Shared.PropertyQueryViewModel
    {
        public bool Use { get; set; }

        //.. more properties from Shared.PropertyQueryViewModel


        public PropertyQueryViewModel()
        {
            //Empty
        }
        public PropertyQueryViewModel(PropertyQuery model, bool use = false)
        {
            WebServiceName = model.WebServiceName;
            QueryId = model.QueryId;
            Title = model.Title;

            Use = use;
        }
    }
}