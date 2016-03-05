using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    public class PropertyQueryInfo
    {
        public int Id { get; set; } //just the database table id

        public string WebServiceName { get; set; }

        public string QueryId { get; set; } // this is the external ID from the web service (like Kolada)

        public string Title { get; set; } // name/title of the query
        
        public string Type { get; set; }


        public virtual Category Category { get; set; }  // which category this is in

    }
}
