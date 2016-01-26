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

        List<Operator> GetTownOperators(Municipality municipiality, Category category);

        Operator GetTownOperatorData(Operator operator_); //"operator" är tydligen ett reserverat ord i .Net

    }
}
