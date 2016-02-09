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
        // Gets a list of all KpiGroups by Category.
        List<KpiGroup> TempGetKpiGroupByCategory(Category category);

        // Gets a list of all KpiAnswers by a list of KpiQuestions and a list of Organisational Units.
        List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OrganisationalUnit> organisationalUnit);

        // Gets a list of all KpiGroups.
        List<PropertyQueryGroup> GetAllPropertyQueries();

        // Gets a Organisational Unit by ID.
        OrganisationalUnit GetOrganisationalUnitByID(string id);

        List<OrganisationalUnit> GetAllOrganisationalUnits();

        // Gets a list of all Organisational Units by Municipality and Category.
        List<OrganisationalUnit> GetOrganisationalUnitsByCategory(Category category);


        List<OrganisationalUnitInfo> GetOrganisationalUnitInfos();
        
        // Gets a list of all Group categories (including it's categories)
        List<GroupCategory> GetAllCategories();

        // Gets a specific category
        Category GetCategory(int id);
    }
}
