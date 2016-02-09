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

namespace TownComparisons.Domain.WebServices
{
    /// <summary>
    /// Set of functions that calls KoladaAPI and returns different type of data
    /// </summary>
    public class KoladaTownWebService : TownWebServiceBase
    {
        private readonly SettingsForFile _settings;
        private string _municipalityId;

        public KoladaTownWebService()
            :this(new SettingsForFile())
        {
            _settings = new SettingsForFile();
            FetchMunicipalityId();
        }
        /// <summary>
        /// Mainly used for unit tests
        /// </summary>
        /// <param name="settings"></param>
        public KoladaTownWebService(SettingsForFile settings)
        {
            _settings = settings;
            FetchMunicipalityId();
        }
        
        public override string GetName()
        {
            return "Kolada"; 
        }
        
        public override List<OU> GetOrganisationalUnitByMunicipalityAndCategory(Municipality municipality, Category category)
        {
            List<OU> allOUnits = GetOrganisationalUnits();
            List<OU> tempAllOUnits = new List<OU>();

            // Adds OrganisationalUnits by Category.
            string categoryValue = String.Empty;
            if (category.Id == 1)
            {
                categoryValue = "V15";
            }
            else if (category.Id == 2)
            {
                categoryValue = "V17";
            }
            else if (category.Id == 3)
            {
                categoryValue = "V23";
            }

            foreach (OU ou in allOUnits)
            {
                if (ou.Id.Substring(0, 3) == categoryValue)
                {
                    tempAllOUnits.Add(ou);
                }
            }

            return tempAllOUnits;
        }

        public override OU GetOrganisationalUnitByID(string id)
        {
            var rawJson = string.Empty;

            var apiRequest = "ou/" + id;
            rawJson = RawJson(apiRequest);
            var ou = JsonConvert.DeserializeObject<OUs>(rawJson).Values;

            return ou.First();
        }

        public override List<KpiGroup> GetKpiGroupByCategory(Category category)
        {
            var rawJson = string.Empty;
            var apiRequest = "kpi_groups?title=" + category.Name;
            rawJson = RawJson(apiRequest);
            var kpi = JsonConvert.DeserializeObject<KpiGroups>(rawJson).Values;
            return kpi;
        }

        public override List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OU> organisationalUnit)
        {
            var rawJson = string.Empty;
            var apiRequest = "oudata/kpi/";

            foreach (KpiQuestion kq in kpiQuestion)
            {
                apiRequest += kq.Member_id + ",";
            }

            apiRequest += "/ou/";
     
            foreach (OU ou in organisationalUnit)
            {
                apiRequest += ou.Id + ",";
            }
            rawJson = RawJson(apiRequest);

            var kpiAnswers = JsonConvert.DeserializeObject<KpiAnswers>(rawJson).Values;
            return kpiAnswers;
        }

        public override List<KpiGroup> GetAllKpiGroups()
        {
            var rawJson = string.Empty;
            //var BaseUrlGetOperators = BaseUrl + "kpi_groups";
            var apiRequest= "kpi_groups";
            rawJson = RawJson(apiRequest);
            var kpi = JsonConvert.DeserializeObject<KpiGroups>(rawJson).Values;

            return kpi;
        }

        public override List<OU> GetOrganisationalUnits()
        {
            var rawJson = string.Empty;
            var municipality = _municipalityId; //GetMunicipalityId();
            var apiRequest = "ou?municipality=1290";

            rawJson = RawJson(apiRequest);

            var OU = JsonConvert.DeserializeObject<OUs>(rawJson).Values;
            return OU;
        }

        public override string GetMunicipalityId()
        {
            return _municipalityId;
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
