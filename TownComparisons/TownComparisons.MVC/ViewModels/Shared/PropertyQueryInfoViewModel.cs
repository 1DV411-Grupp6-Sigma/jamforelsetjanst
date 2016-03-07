using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        public string OriginalTitle { get; set; } // (original) name/title of the query

        [Required]
        [MaxLength(200, ErrorMessage = "Titeln kan inte vara längre än {1} tecken.")]
        [MinLength(3, ErrorMessage = "Titeln måste vara minst {1} tecken.")]
        public string Title { get; set; } // name/title of the query
        
        public string Type { get; set; }

        public int Period { get; set; }


        public PropertyQueryInfoViewModel()
        {
            //Empty
        }
        public PropertyQueryInfoViewModel(PropertyQuery model)
        {
            WebServiceName = model.WebServiceName;
            QueryId = model.QueryId;
            OriginalTitle = model.Title;
            Title = model.Title;
            Type = model.Type;
        }
        public PropertyQueryInfoViewModel(PropertyQueryInfo entity)
        {
            WebServiceName = entity.WebServiceName;
            QueryId = entity.QueryId;
            OriginalTitle = entity.OriginalTitle;
            Title = entity.Title;
            Type = entity.Type;
        }
    }
}