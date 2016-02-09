using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.WebServices.Models
{
    public class OrganisationalUnits
    {
        public int Count { get; set; }

        [JsonProperty("values")]
        public List<OrganisationalUnit> Values { get; set; }

    }
}
