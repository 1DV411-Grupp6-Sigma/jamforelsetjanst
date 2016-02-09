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
        string GetName();
        List<OrganisationalUnit> GetOrganisationalUnits();
        List<OrganisationalUnit> GetOrganisationalUnitByMunicipalityAndCategory(Municipality municipality, Category category);
        OrganisationalUnit GetOrganisationalUnitByID(string id);
        List<KpiGroup> GetKpiGroupByCategory(Category category);
        List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OrganisationalUnit> ou);
        List<KpiGroup> GetAllKpiGroups();
        string GetMunicipalityId();
    }
}
