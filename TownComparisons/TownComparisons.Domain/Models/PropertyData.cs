using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class PropertyData
    {
        public PropertyQuery Query { get; set; }

        public OrganisationalUnit OrganisationalUnit { get; set; }

        public int Period { get; set; }

        public List<PropertyDataValue> Values { get; set; }

        
    }
}
