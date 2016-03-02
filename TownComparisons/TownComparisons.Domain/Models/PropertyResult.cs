using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class PropertyResult
    {
        public string QueryId { get; set; }

        public int Period { get; set; }

        public List<PropertyResultValue> Values { get; set; }


        //Constructors
        public PropertyResult()
        {
            // Empty
        }
        public PropertyResult(string queryId, int period, List<PropertyResultValue> values)
        {
            QueryId = queryId;
            Period = period;
            Values = values;
        }
    }
}
