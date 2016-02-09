using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain.Abstract
{
    public interface ITownWebService : IDisposable
    {
        string GetName();
        List<OU> GetOrganisationalUnits();
        List<OU> GetOrganisationalUnitByMunicipalityAndCategory(Municipality municipality, Category category);
        OU GetOrganisationalUnitByID(string id);
        List<KpiGroup> GetKpiGroupByCategory(Category category);
        List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OU> ou);
        List<KpiGroup> GetAllKpiGroups();
        string GetMunicipalityId();
    }
}
