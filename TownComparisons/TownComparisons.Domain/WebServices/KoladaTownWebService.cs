using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace TownComparisons.Domain.WebServices
{
    /// <summary>
    /// Set of functions that calls KoladaAPI and returns different type of data
    /// </summary>
    public class KoladaTownWebService : TownWebServiceBase
    {
        private readonly Settings _settings;
        private string _municipalityId;

        public KoladaTownWebService()
            :this(new Settings())
        {
            _settings = new Settings();
            FetchMunicipalityId();
        }

        /// <summary>
        /// Mainly used for unit tests
        /// </summary>
        /// <param name="settings"></param>
        public KoladaTownWebService(Settings settings)
        {
            _settings = settings;
            FetchMunicipalityId();
        }

        /// <summary>
        /// looks up municipality Name from settingsConfig.json and fetches its Id from Kolada.se 
        /// </summary>
        private void FetchMunicipalityId()
        {
            //url example:
            //http://api.kolada.se/v2/municipality?title=lund

            var nameOfMunicipality = _settings.Municipality;
            var apiRequest = "municipality?title=" + nameOfMunicipality;

            string rawJson = RawJson(apiRequest);
            JObject json = JObject.Parse(rawJson);

            //This implementation includes only "Kommuner" and excludes "Landsting"
            _municipalityId = (from m in json["values"]
                                         where m["type"].ToString() == "K"
                                         select new Municipality(m)).ToString();   
        }

        //Replaced by FetchMunicipalityId() //andreas
        // Reads MunicipalityId from Settings
        //public override string GetMunicipalityId()
        //{
        //    //var _settings = new Settings();
        //    var municipalityId = _settings.MunicipalityId;
        //    return municipalityId;
        //}

        public IEnumerable<OperationalUnit> GetTownOperators(Municipality municipality, Category category)
        {
            //Method added becouse project would not compile without it!!
            throw new NotImplementedException();
        }
        public override OperationalUnit GetTownOperatorData(OperationalUnit operator_)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Function returns OrganisationalUnits for one municipality.
        /// Id, Municipality and Title are given.
        /// </summary>
        /// <param></param>
        /// <returns>List of OUs in one municipality</returns>
        public override List<OrganisationalUnit> GetOrganisationalUnits()
        {
            var rawJson = string.Empty;

            /*
             * http://api.kolada.se/v2/ou?municipality=1290
             * This is the URL that returns organisational units based on monicipality Id.
             * This is exactly what we need.
             */
            var municipality = _municipalityId; //GetMunicipalityId();
            var apiRequest= "ou?municipality=" + municipality;

            rawJson = RawJson(apiRequest);
           
            var OU = JsonConvert.DeserializeObject<OrganisationalUnits>(rawJson).Values;
            return OU;
        }

        public override List<KpiGroups> GetKpiGroups()
        {
            var rawJson = string.Empty;
            var apiRequest = "KpiGroups";

            rawJson = RawJson(apiRequest);

            // Additional help http://stackoverflow.com/questions/11220776/deserialize-list-of-objects-using-json-net
            var kpiGroups = JsonConvert.DeserializeObject<List<KpiGroups>>(rawJson);
            return kpiGroups;
        }
    }
}
