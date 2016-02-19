using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class PropertyResult
    {
        //public PropertyQuery Query { get; set; }

        //public OrganisationalUnit OrganisationalUnit { get; set; }

        public string QueryId { get; set; }

        public string OrganisationalUnitId { get; set; }

        public int Period { get; set; }

        public List<PropertyResultValue> Values { get; set; }


        //Constructors
        public PropertyResult()
        {
            // Empty
        }
        public PropertyResult(string queryId, string organisationalUnitId, int period, List<PropertyResultValue> values)
        {
            QueryId = queryId;
            OrganisationalUnitId = organisationalUnitId;
            Period = period;
            Values = values;
        }
    }
}
