using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    public class CategoryPropertyQuery : Models.PropertyQuery
    {
        public int Id { get; set; }

        //... more properties are inherited from Models.PropertyQuery

        public virtual Category Category { get; set; }  // which category this is in

    }
}
