using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;

namespace TownComparisons.Domain.Abstract
{
    public abstract class TownWebServiceBase : ITownWebService
    {
        //(denna klass kan användas för att lägga till ev. funktioner som kan behövas oavsett vilken datakälla som används)

        /*
         *  Base of every URL, taken from Andreas Test project
         */
        internal static readonly string BaseUrl = "http://api.kolada.se/v2/";

        public abstract List<OrganisationalUnit> GetOrganisationalUnits(Municipality municipiality);
        public abstract OperationalUnit GetTownOperatorData(OperationalUnit operator_);


        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }
        
        #endregion
    }
}
