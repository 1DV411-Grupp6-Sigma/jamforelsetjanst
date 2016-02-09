using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain.Abstract
{
    public abstract class TownWebServiceBase : ITownWebService
    {
        //(denna klass kan användas för att lägga till ev. funktioner som kan behövas oavsett vilken datakälla som används)

        /*
         *  Base of every URL, taken from Andreas's Test project
         */
        internal static readonly string BaseUrl = "http://api.kolada.se/v2/";

        public abstract string GetName();
        public abstract List<OU> GetOrganisationalUnits();
        public abstract List<OU> GetOrganisationalUnitByMunicipalityAndCategory(Municipality municipality, Category category);
        public abstract OU GetOrganisationalUnitByID(string id);
        public abstract List<KpiGroup> GetKpiGroupByCategory(Category category);
        public abstract List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OU> ou);
        public abstract List<KpiGroup> GetAllKpiGroups();
        public abstract string GetMunicipalityId();

        /// <summary>
        /// Function:
        /// 1. Takes apiRequest as argument, and builds valid URI
        /// 2. Makes HttpWebRequest (There are two additional techniques, one of those can be found in TestSigma repo made by Andreas)
        /// 3. Reads data from request and sends it back in raw format...
        /// 
        ///  The reason why I chose to send raw JSON back, is that I want get functions in KoladaTownWebService class manipulate data
        ///  in specific way.
        /// </summary>
        /// <param name="apiRequest"></param>
        /// <returns>rawJson, JSON in string format</returns>
        public string RawJson(string apiRequest)
        {
            var rawJson = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + apiRequest);

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }
            return rawJson;
        }

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
