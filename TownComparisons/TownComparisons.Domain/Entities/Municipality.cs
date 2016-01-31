using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TownComparisons.Domain.Entities
{
    public class Municipality
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public Municipality(JToken item)
        {
            Id = item.Value<string>("id");
            Title = item.Value<string>("title");
            Type = item.Value<string>("type");
        }

    }
}
