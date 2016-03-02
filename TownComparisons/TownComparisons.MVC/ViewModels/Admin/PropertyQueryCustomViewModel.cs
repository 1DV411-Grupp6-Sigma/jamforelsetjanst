using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Admin
{
    public class PropertyQueryCustomViewModel
    {
        public string Title { get; set; }


        public PropertyQueryCustomViewModel()
        {
            //Empty
        }
        public PropertyQueryCustomViewModel(string title)
        {
            Title = title;
        }
    }
}