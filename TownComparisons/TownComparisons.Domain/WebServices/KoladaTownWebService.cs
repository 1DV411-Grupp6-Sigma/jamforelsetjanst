using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;

namespace TownComparisons.Domain.WebServices
{
    public class KoladaTownWebService : TownWebServiceBase
    {
        //(kod för att anropa Kolada API här i olika funktioner)
        

        public override Operator GetTownOperatorData(Operator operator_)
        {


            throw new NotImplementedException();
        }

        public override List<Operator> GetTownOperators(Municipality municipiality, Category category)
        {


            throw new NotImplementedException();
        }

    }
}
