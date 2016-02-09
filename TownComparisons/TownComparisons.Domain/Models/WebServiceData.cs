using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    public class WebServiceData
    {
        public WebServiceQuery Query { get; set; }

        public OrganisationalUnit Ou { get; set; }

        public int Period { get; set; }

        public List<WebServiceDataValue> Values { get; set; }

    }
}
