using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class PropertyResultForOrganisationalUnit
    {
        public string OrganisationalUnitId { get; set; }
        
        public List<PropertyResult> Results { get; set; }


        //Constructors
        public PropertyResultForOrganisationalUnit()
        {
            // Empty
        }
        public PropertyResultForOrganisationalUnit(string organisationalUnitId, List<PropertyResult> results)
        {
            OrganisationalUnitId = organisationalUnitId;
            Results = results;
        }

    }
}
