using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    public class CategoryWebServiceQuery : Models.WebServiceQuery
    {
        public int Id { get; set; }

        //... and properties from Models.WebServiceQuery
        
        public virtual Category Category { get; set; }  // which category this is in

    }
}
