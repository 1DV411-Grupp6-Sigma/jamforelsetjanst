using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class PropertyResult
    {
        public PropertyQuery Query { get; set; }

        public OrganisationalUnit OrganisationalUnit { get; set; }

        public int Period { get; set; }

        public List<PropertyResultValue> Values { get; set; }


        //Constructors
        public PropertyResult()
        {
            // Empty
        }
        public PropertyResult(PropertyQuery query, OrganisationalUnit organisationalUnit, int period, List<PropertyResultValue> values)
        {
            Query = query;
            OrganisationalUnit = organisationalUnit;
            Period = period;
            Values = values;
        }
    }
}
