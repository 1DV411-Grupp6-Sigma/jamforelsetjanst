using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    public class KpiGroups
    {
        public string Id { get; set; }
        public string Title { get; set; }

        [JsonProperty("members")]
        public List<Kpi>members { get; set; }

    }
}
