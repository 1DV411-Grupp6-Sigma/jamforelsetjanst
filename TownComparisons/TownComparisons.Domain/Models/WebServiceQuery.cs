﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class WebServiceQuery
    {
        public string WebServiceName { get; set; }

        public string QueryId { get; set; } // Kpi id if using Kolada

        public string Title { get; set; } // name/title of the query
        
    }
}