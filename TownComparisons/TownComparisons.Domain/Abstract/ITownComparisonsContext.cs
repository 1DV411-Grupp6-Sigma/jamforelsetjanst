using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;

namespace TownComparisons.Domain.Abstract
{
    public interface ITownComparisonsContext
    {
        IDbSet<OrganisationalUnitInfo> OrganisationalUnitInfos { get; set; }
        //IDbSet<Settings> Settings { get; set; }
        IDbSet<GroupCategory> GroupCategories { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<WebServiceQuery> WebServiceQueries { get; set; }
    }
}
