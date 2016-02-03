using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain;

namespace TownComparisons.MVC.Views.Admin
{
    public class AdminIndexViewModel
    {
        private readonly Settings _settings;

        public string Municipality
        {
            get { return _settings.Municipality; }
            set { _settings.Municipality = value; }
        }

        public AdminIndexViewModel()
        {
            _settings = new Settings();
        }

        
    }

}