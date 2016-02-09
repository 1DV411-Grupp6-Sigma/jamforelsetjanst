using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public virtual GroupCategory GroupCategory { get; set; }

        public virtual ICollection<WebServiceQuery> Queries { get; set; }
    }
}
