using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class PropertyQueryInfoViewModel : Shared.PropertyQueryInfoViewModel
    {
        public bool Use { get; set; }

        //.. more properties from Shared.PropertyQueryViewModel
        

        public List<string> AllTypes
        {
            get
            {
                return new List<string>()
                {
                    PropertyQuery.TYPE_STANDARD,
                    PropertyQuery.TYPE_PERCENT,
                    PropertyQuery.TYPE_YESNO,
                    PropertyQuery.TYPE_PERCENTAGE
                };
            }
        }


        public PropertyQueryInfoViewModel()
        {
            //Empty
        }
        public PropertyQueryInfoViewModel(Shared.PropertyQueryInfoViewModel baseViewModel, bool use = false)
        {
            Id = baseViewModel.Id;
            WebServiceName = baseViewModel.WebServiceName;
            QueryId = baseViewModel.QueryId;
            OriginalTitle = baseViewModel.OriginalTitle;
            Title = baseViewModel.Title;
            Type = baseViewModel.Type;
            Period = baseViewModel.Period;

            Use = use;
        }
        public PropertyQueryInfoViewModel(PropertyQuery model, bool use = false)
        {
            WebServiceName = model.WebServiceName;
            QueryId = model.QueryId;
            OriginalTitle = model.Title;
            Title = model.Title;
            Type = model.Type;

            Use = use;
        }
    }
}