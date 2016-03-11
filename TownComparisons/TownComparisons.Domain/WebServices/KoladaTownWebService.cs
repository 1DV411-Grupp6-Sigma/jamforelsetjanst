using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using TownComparisons.Domain.WebServices.Models;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;

namespace TownComparisons.Domain.WebServices
{
    /// <summary>
    /// Set of functions that calls KoladaAPI and returns different type of data
    /// </summary>
    public class KoladaTownWebService : TownWebServiceBase
    {
        public override string GetName()
        {
            return "Kolada"; 
        }
        
        public override OrganisationalUnit GetOrganisationalUnit(string id)
        {
            var rawJson = string.Empty;

            var apiRequest = "ou/" + id;
            rawJson = RawJson(apiRequest);
            var ou = JsonConvert.DeserializeObject<OUs>(rawJson).Values;
            OU theOu = ou.First();

            return new OrganisationalUnit(this.GetName(), theOu.Id, theOu.Title);
        }
        
        public override List<PropertyQueryWithResults> GetPropertyResults(List<PropertyQueryInfo> queries, List<OrganisationalUnitInfo> organisationalUnits) //List<PropertyQuery> queries, List<OrganisationalUnit> organisationalUnits)
        {
            var rawJson = string.Empty;

            //Set the Kolada url
            var apiRequest = "oudata/kpi/";
            apiRequest += string.Join(",", queries.Select(q => q.QueryId).ToList());
            apiRequest += "/ou/" + string.Join(",", organisationalUnits.Select(o => o.OrganisationalUnitId).ToList());
            
            //Load the data from Kolada
            rawJson = RawJson(apiRequest);

            //serialize the json data
            var kpiAnswers = JsonConvert.DeserializeObject<KpiAnswers>(rawJson).Values;

            //create correct models
            List<PropertyQueryWithResults> results = new List<PropertyQueryWithResults>();
            foreach(PropertyQueryInfo query in queries)
            {
                PropertyQueryWithResults queryWithResults = new PropertyQueryWithResults(query);
                foreach (OrganisationalUnitInfo ou in organisationalUnits)
                {
                    queryWithResults.Results.Add(new PropertyQueryResult(ou.OrganisationalUnitId, kpiAnswers.Where(a => a.Kpi == query.QueryId && a.Ou == ou.OrganisationalUnitId)
                                                                                                                .Select(a => new PropertyQueryResultForPeriod(a.Period, 
                                                                                                                                                                        a.Values.Select(v => new PropertyQueryResultValue(v.Gender, v.Status, v.Value)).ToList()))
                                                                                                                .ToList(), query.Period));
                }
                results.Add(queryWithResults);
            }

            return results;
        }

        public override List<PropertyQueryGroup> GetAllPropertyQueries()
        {
            var rawJson = string.Empty;
            var apiRequest= "kpi_groups";
            rawJson = RawJson(apiRequest);
            var kpi = JsonConvert.DeserializeObject<KpiGroups>(rawJson).Values;

            return kpi.Select(k => new PropertyQueryGroup(this.GetName(), k.Id, k.Title, k.Members.Select(m => new PropertyQuery(this.GetName(), m.Member_id, m.Member_title, GuessPropertyQueryType(m.Member_title))).ToList())).ToList();
        }
        private string GuessPropertyQueryType(string title)
        {
            if (title.ToLower().Contains("(%)"))
            {
                return PropertyQuery.TYPE_PERCENT;
            }
            else if (title.ToLower().Contains("procentenheter"))
            {
                return PropertyQuery.TYPE_PERCENTAGE;
            }
            else if (title.ToLower().Contains("ja=1") && title.ToLower().Contains("nej=0")) 
            {
                return PropertyQuery.TYPE_YESNO;
            }

            return PropertyQuery.TYPE_STANDARD;
        }

        public override List<OrganisationalUnit> GetAllOrganisationalUnits(string municipalityId)
        {
            var rawJson = string.Empty;
            var apiRequest = "ou?municipality=" + municipalityId;

            rawJson = RawJson(apiRequest);

            var OUs = JsonConvert.DeserializeObject<OUs>(rawJson).Values;
            return OUs.Select(o => new OrganisationalUnit(this.GetName(), o.Id, o.Title)).ToList();
        }
        
        /*
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
        */

            //Replaced by FetchMunicipalityId() //andreas
            // Reads MunicipalityId from Settings
            //public override string GetMunicipalityId()
            //{
            //    //var _settings = new Settings();
            //    var municipalityId = _settings.MunicipalityId;
            //    return municipalityId;
            //}

            /// <summary>
            /// Function returns OrganisationalUnits for one municipality.
            /// Id, Municipality and Title are given.
            /// </summary>
            /// <param></param>
            /// <returns>List of OUs in one municipality</returns>


            //public override List<KpiGroups> GetKpiGroups()
            //{
            //    var rawJson = string.Empty;
            //    var apiRequest = "KpiGroups";

            //    rawJson = RawJson(apiRequest);

            //    // Additional help http://stackoverflow.com/questions/11220776/deserialize-list-of-objects-using-json-net
            //    var kpiGroups = JsonConvert.DeserializeObject<List<KpiGroups>>(rawJson);
            //    return kpiGroups;
            //}
        }
    }
