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
        OrganisationalUnit GetWebServiceOrganisationalUnit(string id);

        List<OrganisationalUnit> GetWebServiceOrganisationalUnits();

        List<PropertyQueryGroup> GetWebServicePropertyQueries();

        List<PropertyResultForOrganisationalUnit> GetWebServicePropertyResults(Category category, List<OrganisationalUnitInfo> organisationalUnits); //(List<string> queryIds, List<string> organisationalUnitIds);


        List<GroupCategory> GetAllCategories();
        List<Category> GetAllCategoriesBasedOnAlphabet();

        Category GetCategory(int id);

        List<OrganisationalUnitInfo> GetOrganisationalUnitInfos();

        OrganisationalUnitInfo GetOrganisationalUnitInfo(string organisationalUnitId);
        
    }
}
