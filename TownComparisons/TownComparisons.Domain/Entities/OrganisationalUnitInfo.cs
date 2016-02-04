using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    //this class holds the extra info for an "OU"
    public class OrganisationalUnitInfo
    {
        public int Id { get; set; }

        public string OrganisationalUnitId { get; set; }  // this is the external ID from the web service (Kolada)

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }
    }
}
