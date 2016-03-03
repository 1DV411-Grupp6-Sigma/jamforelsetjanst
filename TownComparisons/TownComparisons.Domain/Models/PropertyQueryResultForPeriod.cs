using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class PropertyQueryResultForPeriod
    {
        public int Period { get; set; }

        public List<PropertyQueryResultValue> Values { get; set; }


        //Constructors
        public PropertyQueryResultForPeriod()
        {
            // Empty
        }
        public PropertyQueryResultForPeriod(int period, List<PropertyQueryResultValue> values)
        {
            Period = period;
            Values = values;
        }
    }
}
