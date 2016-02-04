using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;

namespace TownComparisons.Domain.Abstract
{
    public interface ITownWebService : IDisposable
    {
        //(några exempel-funktioner):
        List<OrganisationalUnit> GetOrganisationalUnits();
        //OperationalUnit GetTownOperatorData(OperationalUnit operator_); //"operator" är tydligen ett reserverat ord i .Net
        //List<OperationalUnit> GetTownOperators(Municipality municipality, Category category);

        // New methods.
        List<OrganisationalUnit> GetOrganisationalUnitByMunicipalityAndCategory(Municipality municipality, Category category);
        OrganisationalUnit GetOrganisationalUnitByID(string id);
        List<KpiGroup> GetKpiGroupByCategory(Category category);
        List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OrganisationalUnit> ou);
        List<KpiGroup> GetAllKpiGroups();
        string GetMunicipalityId();

        //List<KpiGroups> GetKpiGroups();
    }
}
