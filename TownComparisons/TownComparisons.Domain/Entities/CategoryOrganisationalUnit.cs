using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    public class CategoryOrganisationalUnit : Models.OrganisationalUnit
    {
        public int Id { get; set; }

        //... more properties are inherited from Models.OrganisationalUnit
        
        public virtual Category Category { get; set; }  // which category this is in

    }
}
