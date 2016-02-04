using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;

namespace TownComparisons.Domain.Abstract
{
    public interface IService
    {
        // Gets a list of all Organisational Units by Municipality and Category.
        List<OrganisationalUnit> GetOrganisationalUnitByMunicipalityAndCategory(Municipality municipality, Category category);

        // Gets a list of all KpiGroups by Category.
        List<KpiGroup> GetKpiGroupByCategory(Category category);

        // Gets a list of all KpiAnswers by a list of KpiQuestions and a list of Organisational Units.
        List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OrganisationalUnit> organisationalUnit);
        
        // Gets a list of all KpiGroups.
        List<KpiGroup> GetAllKpiGroups();

        // Gets a Organisational Unit by ID.
        OrganisationalUnit GetOrganisationalUnitByID(string id);

        // [Tidigare metoder]
        ////List<OperationalUnit> GetTownOperators(Municipality municipality, Category category);
        ////List<OrganisationalUnitInfo> GetOrganisationalUnitInfos();
    }
}
