using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain.Abstract
{
    public interface IService
    {
        // Gets a list of all KpiGroups.
        List<PropertyQueryGroup> GetAllPropertyQueries();

        // Gets a list of all PropertyResult for a list of PropertyQuery and a list of Organisational Units.
        List<PropertyResult> GetPropertyResults(List<PropertyQuery> queries, List<OrganisationalUnit> organisationalUnits);

        // Gets a Organisational Unit by ID.
        OrganisationalUnit GetOrganisationalUnitByID(string id);

        List<OrganisationalUnit> GetAllOrganisationalUnits();
        
        List<OrganisationalUnitInfo> GetOrganisationalUnitInfos();

        OrganisationalUnitInfo GetOrganisationalUnitInfo(string organisationalUnitId);

        // Gets a list of all Group categories (including it's categories)
        List<GroupCategory> GetAllCategories();

        // Gets a specific category
        Category GetCategory(int id);
    }
}
