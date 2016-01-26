using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    public class Operator
    {
        public string Name { get; set; }

        public Location Location { get; set; }

        public List<Property> Properties { get; set; }

    }
}
