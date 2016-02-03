using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TownComparisons.Domain.Entities
{
    public class Municipality
    {

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        public Municipality(JToken item)
        {
            Id = item.Value<string>("id");
            Title = item.Value<string>("title");
            Type = item.Value<string>("type");
        }

    }
}
