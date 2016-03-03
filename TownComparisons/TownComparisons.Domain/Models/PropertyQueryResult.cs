using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class PropertyQueryResult
    {
        public string OrganisationalUnitId { get; set; }
        
        public List<PropertyQueryResultForPeriod> PeriodValues { get; set; }


        //Constructors
        public PropertyQueryResult()
        {
            // Empty
        }
        public PropertyQueryResult(string organisationalUnitId, List<PropertyQueryResultForPeriod> periodValues)
        {
            OrganisationalUnitId = organisationalUnitId;
            PeriodValues = periodValues;
        }
    }
}
