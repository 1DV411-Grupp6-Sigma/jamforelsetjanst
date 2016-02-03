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
        List<KpiGroups> GetKpiGroups();

        OperationalUnit GetTownOperatorData(OperationalUnit operator_); //"operator" är tydligen ett reserverat ord i .Net

        List<OperationalUnit> GetTownOperators(Municipality municipality, Category category);

        string GetMunicipalityId();
    }
}
