using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class PropertyResultValueViewModel
    {
        public string Gender { get; set; }
        public string Status { get; set; }
        public float? Value { get; set; } 


        public PropertyResultValueViewModel()
        {
            //Empty
        }
        public PropertyResultValueViewModel(PropertyResultValue model)
        {
            Gender = model.Gender;
            Status = model.Status;
            Value = model.Value;


        }
    }
}