using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace TownComparisons.Domain.Entities
{
    public class Municipality_Unused
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public Municipality_Unused(string id, string title, string type)
        {
            Id = id;
            Title = title;
            Type = type;
        }

        public Municipality_Unused(JToken item)
        {
            Id = item.Value<string>("id");
            Title = item.Value<string>("title");
            Type = item.Value<string>("type");
        }
    }
}
