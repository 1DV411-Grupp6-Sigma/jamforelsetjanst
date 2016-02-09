using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Models
{
    [NotMapped]
    public class OrganisationalUnit
    {
        public string WebServiceName { get; set; }

        public string OrganisationalUnitId { get; set; } // Like OU id if using Kolada

        public string Name { get; set; }

    }
}
